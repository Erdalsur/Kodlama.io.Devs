namespace Kodlama.Application.Features.UserOperationClaims.Dtos
{
    public class UpdatedUserOperationClaimDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public int OperationClaimId { get; set; }
        public string? OperationClaimName { get; set; }
    }
}
