using DeviceManager.Shared.Domain;
using ManagmentCentral.Client.Services;
using Microsoft.AspNetCore.Components;

namespace ManagmentCentral.Client.Components
{
    public partial class DevDetails
    {
        [Inject]
        public IDeviceDataService? _deviceDataService { get; set; }

        [Inject]
        public NavigationManager? _navigationManager { get; set; }


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