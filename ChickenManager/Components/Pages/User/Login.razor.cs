using Microsoft.AspNetCore.Components;
using Radzen;

namespace ChickenManager.Components.Pages.User
{
    public partial class Login
    {
        Models.User User = new Models.User();
        bool rememberMe = true;


        void OnLogin(LoginArgs args, string name)
        {
            //console.Log($"{name} -> Username: {args.Username}, password: {args.Password}, remember me: {args.RememberMe}");
        }

        void OnRegister()
        {
            Navigationmanager.NavigateTo("User/RegisterUser");
        }

        void Reset()
        {
            Navigationmanager.NavigateTo("User/ResetPassword");
        }
    }
}
