using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceManager.Shared.Domain
{

    public enum Status
    {
        online,
        offline
    }

    public enum Location
    {
        Sweden,
        England
    }
    public class Device
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public Location Location { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [DisplayName("Device type")]
        [StringLength(15, ErrorMessage = "{0} måste vara mellan {2} och {1} tecken långt.", MinimumLength = 6)]
        public string DeviceType { get; set; } = string.Empty;

        [Required]
        public Status Status { get; set; }

    }
}