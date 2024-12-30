using ChickenManager.Models;
using Microsoft.AspNetCore.Components;
using Radzen;

namespace ChickenManager.Components.Pages.Chicken
{
    public partial class EditChicken
    {
        [Parameter]
        public Models.Chicken Chicken { get; set; }

        Variant variant = Variant.Filled;
        bool popup = true;
        List<Breed> breeds = new List<Breed>();
        List<Gender> genders = new List<Gender>();
        List<Color> colors = new List<Color>();
        string updateButtonText = "Update";

        protected override async Task OnInitializedAsync()
        {
            breeds = await _lookupRepository.LoadBreeds<Breed>(_data, _config);
            genders = await _lookupRepository.LoadGenders<Gender>(_data, _config);
            colors = await _lookupRepository.LoadColors<Color>(_data, _config);
        }

        public async Task UpdateChicken(Models.Chicken chicken)
        {
            updateButtonText = "Updating...";

            _lookupRepository.UpdateChicken<Models.Chicken>(_data, _config, chicken);

            updateButtonText = "Complete!";

            await Task.Delay(2000);

            DialogService.Close();
        }
    }
}
