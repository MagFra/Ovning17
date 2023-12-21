using ManagmentCentral.Shared.Domain;
using DeviceAPI.Collections;

namespace DeviceAPI.Endpoints
{
    public static class Devices
    {
        private static IDeviceDataService _deviceDataService = default!;
        public static void RegisterUserEndpoint(this IEndpointRouteBuilder routes, IDeviceDataService deviceDataService)
        {
            _deviceDataService = deviceDataService;

            var devices = routes.MapGroup("");//.RequireAuthorization();

            devices.MapGet("/devices", () =>
            {
                return _deviceDataService.GetDevices();
            }).AllowAnonymous();


            devices.MapGet("/device{Id}", (int Id) =>
            {
                return _deviceDataService.GetDevice(Id);
            });


            devices.MapPost("/device/add", (Device device) =>
            {
                _deviceDataService.AddDevice(device);
            });


            devices.MapPut("/device/edit", (Device device) =>
            {
                _deviceDataService.UpdateDevice(device);
            });


            devices.MapDelete("/device/delete/{Id}", (int Id) =>
            {
                _deviceDataService.DeleteDevice(Id);
            });
        }
    }
}
