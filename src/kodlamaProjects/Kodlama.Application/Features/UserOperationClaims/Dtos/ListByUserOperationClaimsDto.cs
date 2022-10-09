namespace Kodlama.Application.Features.UserOperationClaims.Dtos
{
    public class ListByUserOperationClaimsDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }
        public string? OperationClaimName { get; set; }
    }
}
