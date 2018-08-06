using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkerSafetyService.Models
{
    public class WorkerModel
    {
        public string DeviceId { get; set; }

        public  float Temperature { get; set; }

        public float Humidity { get; set; }
    }
}
