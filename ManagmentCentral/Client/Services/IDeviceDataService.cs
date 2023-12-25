using ManagmentCentral.Shared.Domain;

namespace ManagmentCentral.Client.Services
{
    public interface IDeviceDataService
    {
        public Task<List<Device>> GetDevicesAsync();

        Device GetDevice(int? Id);

        void DeleteDevice(int? Id);

        void UpdateDevice(Device? Device);

        void AddDevice(Device? Device);
    }
}
