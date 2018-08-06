using System;

namespace WorkerSafety.Models
{
    public class PackagingDataTwin
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}