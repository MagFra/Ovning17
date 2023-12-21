using ManagmentCentral.Shared.Domain;

namespace DeviceAPI.Collections
{
    public class DeviceDataService : IDeviceDataService
    {
        //############################################################################################################################
        public static List<Device> DeviceList { get; set; } = new List<Device>();
        //############################################################################################################################



        //############################################################################################################################
        public DeviceDataService()
        {
            int xId = 0;
            DeviceList.Add(new Device() { Id = ++xId, Location = Location.Sweden, Date = DateTime.Now, DeviceType = "Sensor", Status = Status.online });
            DeviceList.Add(new Device() { Id = ++xId, Location = Location.England, Date = DateTime.Now, DeviceType = "Machine", Status = Status.offline });
            DeviceList.Add(new Device() { Id = ++xId, Location = Location.Sweden, Date = DateTime.Now, DeviceType = "Sensor", Status = Status.online });
            DeviceList.Add(new Device() { Id = ++xId, Location = Location.Sweden, Date = DateTime.Now, DeviceType = "Sensor", Status = Status.online });
            DeviceList.Add(new Device() { Id = ++xId, Location = Location.England, Date = DateTime.Now.AddDays(-30), DeviceType = "Machine", Status = Status.offline });
            DeviceList.Add(new Device() { Id = ++xId, Location = Location.England, Date = DateTime.Now.AddDays(-130), DeviceType = "Sensor", Status = Status.offline });
            DeviceList.Add(new Device() { Id = ++xId, Location = Location.Sweden, Date = DateTime.Now.AddDays(-230), DeviceType = "Sensor", Status = Status.online });
            DeviceList.Add(new Device() { Id = ++xId, Location = Location.England, Date = DateTime.Now.AddDays(-330), DeviceType = "Sensor", Status = Status.online });
        }
        //############################################################################################################################



        //############################################################################################################################
        public List<Device> GetDevices()
        {
            return DeviceList;
        }
        //############################################################################################################################



        //############################################################################################################################
        public Device GetDevice(int? Id)
        {
            if (Id == null) throw new ArgumentNullException($"{nameof(Id)} is null");
            var device = DeviceList.FirstOrDefault(d => d.Id == Id);
            if (device == null) throw new ArgumentNullException($"There is no \"Device\" with ID {Id}");
            return device;
        }
        //############################################################################################################################



        //############################################################################################################################
        public void AddDevice(Device? Device)
        {
            if (Device == null) throw new ArgumentNullException($"{nameof(Device)} is null");
            int maxId = DeviceList.Max(x => x.Id);
            Device.Id = maxId + 1;
            DeviceList.Add(Device);
        }
        //############################################################################################################################



        //############################################################################################################################
        public void UpdateDevice(Device? Device)
        {
            if (Device == null) throw new ArgumentNullException($"{nameof(Device)} is null");
            var device = DeviceList.FirstOrDefault(d => d.Id == Device.Id);
            if (device == null) throw new ArgumentNullException($"There is no \"Device\" with ID {Device.Id}");
            device.Location = Device.Location;
            device.Date = Device.Date;
            device.DeviceType = Device.DeviceType;
            device.Status = Device.Status;
        }
        //############################################################################################################################



        //############################################################################################################################
        public void DeleteDevice(int? Id)
        {
            if (Id == null) throw new ArgumentNullException($"{nameof(Id)} is null");
            var device = DeviceList.FirstOrDefault(x => x.Id == Id);
            if (device == null) throw new ArgumentException($"There is no \"Device\" with ID {Id}");
            DeviceList.Remove(device);
        }
        //############################################################################################################################
    }
}
