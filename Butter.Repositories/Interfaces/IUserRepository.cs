using Butter.Entities;
using Butter.Models;

namespace Butter.Repositories.Interfaces
{
    public interface IUserRepository : IRepo<UserModel, UserEntity, int>
    {
        UserEntity ToEntite(UserModel Model);
        UserModel ToModel(UserEntity entite);
    }
}