using ManagmentCentral.Shared.Domain;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.Data;
using System.Net.Http;
using System.Security.Claims;
using System.Text.Json;

namespace ManagmentCentral.Client.Services
{
    public class DeviceDataService : IDeviceDataService
    {
        //############################################################################################################################



        //############################################################################################################################
        private static readonly HttpClient http = new HttpClient();
        private static readonly JsonSerializerOptions options = new JsonSerializerOptions
        {
            WriteIndented = true,
            PropertyNameCaseInsensitive = true,
        };
        public static List<Device> DeviceList { get; set; } = new List<Device>();
        //############################################################################################################################



        //############################################################################################################################
        public DeviceDataService()
        {
            DeviceList.Add(new Device() { Id = 1, Location = Location.Sweden, Date = DateTime.Now, DeviceType = "Sensor", Status = Status.online });
            DeviceList.Add(new Device() { Id = 2, Location = Location.England, Date = DateTime.Now, DeviceType = "Machine", Status = Status.offline });
            DeviceList.Add(new Device() { Id = 3, Location = Location.Sweden, Date = DateTime.Now, DeviceType = "Sensor", Status = Status.online });
        }
        //############################################################################################################################



        //############################################################################################################################
        public async Task<List<Device>> GetDevicesAsync()
        {
            var response = await http.GetAsync("/devices");

            if (response != null && response.IsSuccessStatusCode)
            {
                var responseData = await response.Content.ReadAsStringAsync();
                if (responseData != null)
                {
                    return (List<Device>)JsonSerializer.Deserialize<IEnumerable<Device>>(responseData, options)!;
                }
            }
            throw new NullReferenceException("No data.");
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



        //############################################################################################################################
    }
}
