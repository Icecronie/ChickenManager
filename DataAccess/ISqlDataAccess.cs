namespace DataAccess
{
    public interface ISqlDataAccess
    {
        Task<List<T>> LoadData<T, U>(string sql, U parameters, string connectionString);

        Task<int> SaveData<T, U>(string sql, U parameters, string connectionString);
    }
}
