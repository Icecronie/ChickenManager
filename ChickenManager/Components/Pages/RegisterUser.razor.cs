using ChickenManager.Models;
using Microsoft.AspNetCore.Components;
using Radzen;

namespace ChickenManager.Components.Pages
{
    public partial class RegisterUser
    {
        User user = new User() { };
        Variant variant = Variant.Filled;
        DateTime Birthday = DateTime.Now;

        public async Task CreateUser(User user)
        {
            string sql = "exec CreateNewUser @FirstName, @LastName, @CreatorName, @Email, @PhoneNumber, @Birthday";
            object parameters = new
            {
                user.FirstName,
                user.LastName,
                user.CreatorName,
                user.Email,
                user.PhoneNumber,
                user.BirthDay,
            };
            var rows = await _data.LoadData<User, dynamic>(sql, parameters, _config.GetConnectionString("Default"));

            Navigationmanager.NavigateTo("RegisterUserSuccess");
        }
    }
}