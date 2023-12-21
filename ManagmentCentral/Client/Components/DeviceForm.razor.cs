using ManagmentCentral.Client.Services;
using ManagmentCentral.Shared.Domain;
using Microsoft.AspNetCore.Components;

namespace ManagmentCentral.Client.Components
{
    public partial class DeviceForm
    {
        [Inject]
        public IDeviceDataService _deviceDataService { get; set; } = default!;

        [Inject]
        public NavigationManager _navigationManager { get; set; } = default!;


        [Parameter]
        public int? Id { get; set; }


        [Parameter]
        [EditorRequired]
        public bool Create { get; set; }


        public Device Device { get; set; } = new Device();

        protected override void OnInitialized()
        {
            if (!Create)
            {
                if (Id == null)
                {
                    _navigationManager.NavigateTo($"/devicelst");
                }
                else
                {
                    Device = _deviceDataService?.GetDevice(Id)!;
                }
            }
            base.OnInitialized();
        }

        protected void HandleValidSubmit()
        {
            if (Create)
            {
                _deviceDataService.AddDevice(Device);
            }
            else
            {
                _deviceDataService.UpdateDevice(Device);
            }
            _navigationManager.NavigateTo($"/devicelst");
        }
    }
}