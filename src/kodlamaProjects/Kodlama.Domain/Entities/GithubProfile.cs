using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Kodlama.Domain.Entities
{
    public class GitHubProfile:Entity
    {
        public GitHubProfile()
        {
        }

        public GitHubProfile(int id,int userId, User user, string? gitHubUrl):base(id)
        {
            Id = id;
            UserId = userId;
            User = user;
            GitHubUrl = gitHubUrl;
        }

        public int UserId { get; set; }
        public virtual User User { get; set; }
        public string? GitHubUrl { get; set; }
        


    }
}
