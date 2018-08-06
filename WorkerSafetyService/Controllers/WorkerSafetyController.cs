using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.EventHubs;
using Newtonsoft.Json;
using WorkerSafetyService.Models;

namespace WorkerSafetyService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkerSafetyController : ControllerBase
    {
        
        private readonly static string s_eventHubsCompatibleEndpoint = "sb://iothub-ns-worksafe-621089-b9a677b430.servicebus.windows.net/";

        // Event Hub-compatible name
        // az iot hub show --query properties.eventHubEndpoints.events.path --name {your IoT Hub name}
        private readonly static string s_eventHubsCompatiblePath = "WorkSafe";

        // az iot hub policy show --name iothubowner --query primaryKey --hub-name {your IoT Hub name}
        private readonly static string s_iotHubSasKey = "YL8NQT0lr74v2G+02zfToCb/Fj0uF1hQuH9oyK+SAvA=";
        private readonly static string s_iotHubSasKeyName = "iothubowner";
        private static EventHubClient s_eventHubClient;
        private static List<WorkerModel> lstWorkerModels = new List<WorkerModel>();
        // GET api/values

        [HttpGet]
        public async Task<IEnumerable<WorkerModel>> GetAsync()
        {
            //return new string[] { "value1", "value2" };
            // Create an EventHubClient instance to connect to the
            // IoT Hub Event Hubs-compatible endpoint.
            var connectionString = new EventHubsConnectionStringBuilder(new Uri(s_eventHubsCompatibleEndpoint), s_eventHubsCompatiblePath, s_iotHubSasKeyName, s_iotHubSasKey);
            s_eventHubClient = EventHubClient.CreateFromConnectionString(connectionString.ToString());

            // Create a PartitionReciever for each partition on the hub.
            var runtimeInfo = await s_eventHubClient.GetRuntimeInformationAsync();
            var d2cPartitions = runtimeInfo.PartitionIds;

            CancellationTokenSource cts = new CancellationTokenSource();

            //Console.CancelKeyPress += (s, e) =>
            //{
            //    e.Cancel = true;
            //    cts.Cancel();
            //    Console.WriteLine("Exiting...");
            //};

            var tasks = new List<Task>();

            foreach (string partition in d2cPartitions)
            {
                tasks.Add(ReceiveMessagesFromDeviceAsync(partition, cts.Token));
            }

            // Wait for all the PartitionReceivers to finsih.
            //Task.WaitAll(tasks.ToArray());
            return lstWorkerModels;
        }
        private static async Task ReceiveMessagesFromDeviceAsync(string partition, CancellationToken ct)
        {
            // Create the receiver using the default consumer group.
            // For the purposes of this sample, read only messages sent since 
            // the time the receiver is created. Typically, you don't want to skip any messages.
            var eventHubReceiver = s_eventHubClient.CreateReceiver("$Default", partition, EventPosition.FromEnqueuedTime(DateTime.Now));
            Console.WriteLine("Create receiver on partition: " + partition);
            //while (true)
            //{
                //if (ct.IsCancellationRequested) break;
                Console.WriteLine("Listening for messages on: " + partition);
                // Check for EventData - this methods times out if there is nothing to retrieve.
                var events = await eventHubReceiver.ReceiveAsync(100);

                // If there is data in the batch, process it.
                //if (events == null) continue;

                foreach (EventData eventData in events)
                {
                    string data = Encoding.UTF8.GetString(eventData.Body.Array);
                    //Console.WriteLine("Message received on partition {0}:", partition);
                    Console.WriteLine("  {0}:", data);
                    WorkerModel workerModel = new WorkerModel();
                    workerModel = JsonConvert.DeserializeObject<WorkerModel>(data);
                    lstWorkerModels.Add(workerModel);
                }
            //}
        }

        //// GET api/values/5
        //[HttpGet("{id}")]
        //public ActionResult<string> Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/values
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
