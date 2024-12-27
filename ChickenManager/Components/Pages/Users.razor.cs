namespace ChickenManager.Components.Pages
{
    public partial class Users
    {
        IEnumerable<Models.User> userList;
        string message;

        //This right now is working
        protected override async Task OnInitializedAsync()
        {
            await GetUsers();
        }

        protected async Task GetUsers()
        {
            string sql = "select * from [User]";
            message = "Loading";
            userList = await _data.LoadData<Models.User, dynamic>(sql, new { }, _config.GetConnectionString("Default"));
            message = "Loading Complete";
        }
    }
}
