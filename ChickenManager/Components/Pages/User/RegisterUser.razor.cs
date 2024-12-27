using Radzen;

namespace ChickenManager.Components.Pages.User
{
    public partial class RegisterUser
    {
        Models.User user = new Models.User() { };
        Variant variant = Variant.Filled;
        bool popup = true;

        public async Task CreateUser(Models.User user)
        {
            string sql = "exec CreateNewUser @FirstName, @LastName, @CreatorName, @Email, @PhoneNumber, @Password";
            object parameters = new
            {
                user.FirstName,
                user.LastName,
                user.CreatorName,
                user.Email,
                user.PhoneNumber,
                user.Password
            };
            var rows = await _data.LoadData<Models.User, dynamic>(sql, parameters, _config.GetConnectionString("Default"));

            Navigationmanager.NavigateTo("User/RegisterUserSuccess");
        }
    }
}