using Radzen;

namespace ChickenManager.Components.Pages.Chicken
{
    public partial class Search
    {
        int ChickenId;
        Models.User user = new Models.User();
        List<Models.Chicken> chickens = new List<Models.Chicken>();
        List<Models.Chicken> userChickens = new List<Models.Chicken>();
        protected override async Task OnInitializedAsync()
        {
            //for testing, since I don't have login right now just grabbing a person
            user = await _lookupRepository.LoadUser<Models.User>(_data, _config);

            userChickens = await _lookupRepository.LoadChickens<Models.Chicken>(_data, _config, user.Id);

        }

        void Refresh()
        {
            NavigationManager.Refresh(true);
        }

        void Delete(EventArgs args)
        {
            string name = "bobbly";

            string message = $"Delete chicken {name}";
            string title = "Remove chicken from account?";
            var options = new ConfirmOptions
            {
                OkButtonText = "Yes",
                CancelButtonText = "No"
            };

            DialogService.Confirm(message, title, options);

            //Refresh();
        }

        public async Task OpenOrder(EventArgs args)
        {
            //await LoadStateAsync();

            Models.Chicken Chicken = new Models.Chicken();

            await DialogService.OpenAsync<AddChicken>("Modify Chicken Name",
                   new Dictionary<string, object>() { { "ChickenId", ChickenId } },
                   new DialogOptions()
                   {
                       Resizable = false,
                       Draggable = false,
                       //           //Resize = OnResize,
                       //           //Drag = OnDrag,
                       //           //Width = Settings != null ? Settings.Width : "700px",
                       //           //Height = Settings != null ? Settings.Height : "512px",
                       //           //Left = Settings != null ? Settings.Left : null,
                       //           //Top = Settings != null ? Settings.Top : null
                       //       });

                       //await SaveStateAsync();
                   });
        }
    }
}
