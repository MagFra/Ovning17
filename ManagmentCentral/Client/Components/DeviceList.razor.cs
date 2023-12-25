using ManagmentCentral.Client.Services;
using ManagmentCentral.Shared.Domain;
using Microsoft.AspNetCore.Components;

namespace ManagmentCentral.Client.Components
{
    public partial class DeviceList
    {
        [Parameter]
        public string ExtraCaption { get; set; } = string.Empty;
        [Parameter]
        public bool ShowButtons { get; set; }
        [Inject]
        IDeviceDataService _deviceDataService { get; set; } = default!;
        public List<Device> Devices { get; set; } = new List<Device>();

        protected override async Task OnInitializedAsync()
        {
            Devices = await _deviceDataService.GetDevicesAsync();
            base.OnInitialized();
        }

    }
}