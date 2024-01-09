using SmartOtomasyonWebApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Domain.Entities
{
    public class UserOperationClaim : BaseEntity
    {
        public Guid UserId { get; set; }
        public Guid OperationClaimId { get; set; }
    }
}
