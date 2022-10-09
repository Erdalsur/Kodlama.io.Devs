using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.Application.Features.UserOperationClaims.Dtos
{
    public class CreatedUserOperationClaimDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public int OperationClaimId { get; set; }
        public string? OperationClaimName { get; set; }
    }
}
