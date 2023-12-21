using ManagmentCentral.Client.Services;
using ManagmentCentral.Shared.Domain;
using Microsoft.AspNetCore.Components;

namespace ManagmentCentral.Client.Components
{
    public partial class DevDetails
    {
        [Inject]
        public IDeviceDataService _deviceDataService { get; set; } = default!;

        [Inject]
        public NavigationManager _navigationManager { get; set; } = default!;


        [Parameter]
        public int Id { get; set; }


        [Parameter]
        public bool Del { get; set; }

        
        public Device Device { get; set; } = new Device();

        protected override void OnInitialized()
        {
            Device = _deviceDataService?.GetDevice(Id)!;
            base.OnInitialized();
        }

        protected void Delete(int id)
        {
            _deviceDataService.DeleteDevice(id);

            _navigationManager.NavigateTo($"/devicelst");

        }
    }
}