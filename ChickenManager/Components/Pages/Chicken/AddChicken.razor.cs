using ChickenManager.Models;
using Radzen;

namespace ChickenManager.Components.Pages.Chicken
{
    public partial class AddChicken
    {
        Variant variant = Variant.Filled;
        bool popup = true;
        List<Breed> breeds = new List<Breed>();
        List<Gender> genders = new List<Gender>();
        List<Color> colors = new List<Color>();
        Models.User user = new Models.User();
        Models.Chicken Chicken = new Models.Chicken();

        protected override async Task OnInitializedAsync()
        {
            breeds = await _lookupRepository.LoadBreeds<Breed>(_data,_config);
            genders = await _lookupRepository.LoadGenders<Gender>(_data,_config);
            colors = await _lookupRepository.LoadColors<Color>(_data,_config);
            
            //for testing, since I don't have login right now just grabbing a person
            user = await _lookupRepository.LoadUser<Models.User>(_data,_config);
            Chicken.User = user;
        }

        public async Task CreateChicken(Models.Chicken chicken)
        {
            var success = await _lookupRepository.CreateChicken<Models.Chicken>(_data,_config,chicken);

            NavigationManager.NavigateTo("Chicken/AddChickenSuccess");
        }
    }
}
