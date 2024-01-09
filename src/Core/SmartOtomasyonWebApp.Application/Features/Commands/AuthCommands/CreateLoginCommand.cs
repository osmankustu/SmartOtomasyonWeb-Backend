using AutoMapper;
using MediatR;
using SmartOtomasyonWebApp.Application.Constants;
using SmartOtomasyonWebApp.Application.Interfaces.Repository;
using SmartOtomasyonWebApp.Application.Utilities.Security.Hashing;
using SmartOtomasyonWebApp.Application.Utilities.Security.JWT;
using SmartOtomasyonWebApp.Application.Wrappers;
using SmartOtomasyonWebApp.Application.Wrappers.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Application.Features.Commands.CreateCommands.CreateAuth
{
    public class CreateLoginCommand : IRequest<IDataResponse<AccessToken>>
    {
        public String Email { get; set; }
        public String Password { get; set; }

        public class CreateLoginCommandHandler: IRequestHandler<CreateLoginCommand,IDataResponse<AccessToken>>
        {
            IUserRepository _userRepository;
            ITokenHelper _tokenHelper;
            public CreateLoginCommandHandler(IUserRepository userRepository,ITokenHelper tokenHelper)
            {
                _userRepository = userRepository;
                _tokenHelper = tokenHelper;
            }

            public async Task<IDataResponse<AccessToken>> Handle(CreateLoginCommand request, CancellationToken cancellationToken)
            {
                var userToCheck = await _userRepository.GetByMail(request.Email);
                if(userToCheck == null)
                {
                    return new ErrorServiceResponse<AccessToken>(null, Messages.UserNotFound);
                }
                if(userToCheck.Status == false)
                {
                    return new ErrorServiceResponse<AccessToken>(null, Messages.UserNonActive);
                }
                if (!HashingHelper.VerifyPasswordHash(request.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
                {
                    return new ErrorServiceResponse<AccessToken>(null, Messages.WrongPassword);
                }
                else
                {
                    var claims = await _userRepository.getClaims(userToCheck);
                    var accessToken = _tokenHelper.CreateToken(userToCheck, claims);
                    return new SuccessServiceResponse<AccessToken>(accessToken,Messages.LoginSuccessful);
                }
                

            }
        }
    }
}
