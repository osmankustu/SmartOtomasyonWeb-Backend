using AutoMapper;
using MediatR;
using SmartOtomasyonWebApp.Application.Interfaces.Repository;
using SmartOtomasyonWebApp.Application.Utilities.Security.Hashing;
using SmartOtomasyonWebApp.Application.Utilities.Security.JWT;
using SmartOtomasyonWebApp.Application.Wrappers;
using SmartOtomasyonWebApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Application.Features.Commands.CreateCommands.CreateUser
{
    public class CreateUserCommand : IRequest<SuccessServiceResponse<String>>
    {
        
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }

        public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand,SuccessServiceResponse<String>>
        {
            IUserRepository _userRepository;
            IUserOperationClaimRepository _userOperationClaimRepository;
            ITokenHelper _tokenHelper;
            private readonly IMapper _mapper;
            public CreateUserCommandHandler(IUserRepository userRepository,ITokenHelper tokenHelper,IMapper mapper,IUserOperationClaimRepository userOperationClaimRepository)
            {
                _userRepository = userRepository;
                _tokenHelper = tokenHelper;
                _mapper = mapper;
               _userOperationClaimRepository = userOperationClaimRepository;
            }

            public async Task<SuccessServiceResponse<String>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
            {
                byte[] passwordHash,passwordSalt;
                HashingHelper.CreatePasswordHash(request.Password, out passwordHash, out passwordSalt);
                var user = new User
                {
                    Email = request.Email,
                    Name = request.FirstName,
                    SureName = request.LastName,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    Status = true
                };
                await _userRepository.AddAsync(user);
                var claim = new UserOperationClaim
                {
                    OperationClaimId = Guid.Parse("2d60f4af-1020-49fd-b04a-6e152a8725c6"),
                    UserId = user.Id,
                };
                await _userOperationClaimRepository.AddAsync(claim);
                return new SuccessServiceResponse<String>(user.Email);
            }
        }
    }
}
