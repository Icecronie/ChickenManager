using Radzen;

namespace ChickenManager.Components.Pages.User
{
    public partial class ResetPassword
    {
        Models.User user = new Models.User();
        Variant variant = Variant.Filled;
        bool popup = true;


        public async Task Reset(Models.User user)
        {
            string sql = "exec CreateNewUser @FirstName, @LastName, @CreatorName, @Email, @PhoneNumber, @Password";
            object parameters = new
            {
                user.Password
            };
            var rows = await _data.LoadData<Models.User, dynamic>(sql, parameters, _config.GetConnectionString("Default"));

            //Navigationmanager.NavigateTo("User/RegisterUserSuccess");
        }
    }
}
