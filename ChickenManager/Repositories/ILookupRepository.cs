using ChickenManager.Models;
using DataAccess;

namespace ChickenManager.Repositories
{
    public interface ILookupRepository
    {
        Task<List<Breed>> LoadBreeds<T>(ISqlDataAccess _data, IConfiguration _config);
        Task<List<Gender>> LoadGenders<T>(ISqlDataAccess _data, IConfiguration _config);
        Task<List<Color>> LoadColors<T>(ISqlDataAccess _data, IConfiguration _config);
        Task<User> LoadUser<T>(ISqlDataAccess _data, IConfiguration _config);
        Task<int> CreateChicken<Chicken>(ISqlDataAccess _data, IConfiguration _config, Models.Chicken chicken);
        Task<List<Models.Chicken>> LoadChickens<Chicken>(ISqlDataAccess _data, IConfiguration _config, int userId);
    }
}