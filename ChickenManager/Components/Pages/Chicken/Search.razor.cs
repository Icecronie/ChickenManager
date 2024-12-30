using ChickenManager.Models;
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
            List<Breed> breeds = await _lookupRepository.LoadBreeds<Breed>(_data, _config);
            List<Gender> genders = await _lookupRepository.LoadGenders<Gender>(_data, _config);
            List<Color> colors = await _lookupRepository.LoadColors<Color>(_data, _config);

            foreach (var item in userChickens)
            {
                item.Breed = breeds.Where(x => x.Text == item.BreedName).First();
                item.Gender = genders.Where(x => x.Text == item.GenderName).First();
                item.Color = colors.Where(x => x.Text == item.ColorName).First();
                item.User = user;
            }

        }

        void Refresh()
        {
            NavigationManager.Refresh(true);
        }

        public async void Delete(Models.Chicken chicken)
        {
            string message = $"Delete chicken {chicken.Name}?";
            var options = new ConfirmOptions
            {
                OkButtonText = "Yes",
                CancelButtonText = "No",
                CloseDialogOnOverlayClick = true
            };

            var confirm = await DialogService.Confirm("", message, options);

            if (confirm.Value)
            {
                await _lookupRepository.DeleteChicken<Models.Chicken>(_data,_config,chicken.Id);

                Refresh();
            }
        }

        public async Task Edit(Models.Chicken chicken)
        {

            await DialogService.OpenAsync<EditChicken>("Edit Chicken",
                   new Dictionary<string, object>() { { "Chicken", chicken} },
                   new DialogOptions()
                   {
                       Resizable = false,
                       Draggable = false,
                       CloseDialogOnOverlayClick = true,
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
