using ChickenManager.Models;
using DataAccess;

namespace ChickenManager.Repositories
{
    public class LookupRepository : ILookupRepository
    {
        public async Task<List<Breed>> LoadBreeds<T>(ISqlDataAccess _data, IConfiguration _config)
        {
            string sql = "exec GetBreeds";

           return await _data.LoadData<Breed, dynamic>(sql, new { }, _config.GetConnectionString("Default"));
        }

        public async Task<List<Gender>> LoadGenders<T>(ISqlDataAccess _data, IConfiguration _config)
        {
            string sql = "exec GetGenders";
            return await _data.LoadData<Gender, dynamic>(sql, new { }, _config.GetConnectionString("Default"));
        }

        public async Task<List<Color>> LoadColors<T>(ISqlDataAccess _data, IConfiguration _config)
        {
            string sql = "exec GetColors";
            return await _data.LoadData<Color, dynamic>(sql, new { }, _config.GetConnectionString("Default"));
        }

        public async Task<User> LoadUser<T>(ISqlDataAccess _data, IConfiguration _config)
        {
            string sql = "exec GetUserByEmail @email";

            var parameters = new { email = "hck@test.com" };

            return await _data.LoadSingle<User, dynamic>(sql, parameters, _config.GetConnectionString("Default"));
        }

        public async Task<int> CreateChicken<Chicken>(ISqlDataAccess _data, IConfiguration _config, Models.Chicken chicken)
        {
            string sql = "exec CreateNewChicken @name,@breedId,@genderId,@colorId,@age,@layseggs,@userId";

            var parameters = new
            {
                name = chicken.Name,
                breedId = chicken.Breed.Id,
                genderId = chicken.Gender.Id,
                colorId = chicken.Color.Id,
                age = chicken.Age,
                layseggs = chicken.LaysEggs,
                userId = chicken.User.Id,
            };

            return await _data.SaveData<Chicken, dynamic>(sql,parameters,_config.GetConnectionString("Default"));
        }
    }
}
