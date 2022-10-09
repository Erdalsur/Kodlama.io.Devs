using Core.Persistence.Paging;
using Kodlama.Application.Features.UserOperationClaims.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.Application.Features.UserOperationClaims.Models
{
    public class UserOperationClaimsListByUserModel: BasePageableModel
    {
        public IList<ListByUserOperationClaimsDto> Items { get; set; }
    }
}
