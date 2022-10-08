using Kodlama.Application.Features.OperationClaims.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.Application.Features.OperationClaims.Models
{
    public class OperationClaimListModel
    {
        public IList<OperationClaimListDto> Items { get; set; }
    }
}
