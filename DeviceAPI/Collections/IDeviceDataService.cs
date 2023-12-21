using ManagmentCentral.Shared.Domain;

namespace DeviceAPI.Collections
{
    public interface IDeviceDataService
    {
        List<Device> GetDevices();

        Device GetDevice(int? Id);

        void DeleteDevice(int? Id);

        void UpdateDevice(Device? Device);

        void AddDevice(Device? Device);
    }
}
