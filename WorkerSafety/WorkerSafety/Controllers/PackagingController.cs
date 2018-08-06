﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.EventHubs;
using Newtonsoft.Json;
using WorkerSafety.Models;

namespace WorkerSafety.Controllers
{
    public class PackagingController : Controller
    {
        // private readonly static string s_eventHubsCompatibleEndpoint = "sb://iothub-ns-worksafe-621089-b9a677b430.servicebus.windows.net/";

        // // Event Hub-compatible name
        // // az iot hub show --query properties.eventHubEndpoints.events.path --name {your IoT Hub name}
        // private readonly static string s_eventHubsCompatiblePath = "WorkSafe";

        // // az iot hub policy show --name iothubowner --query primaryKey --hub-name {your IoT Hub name}
        // private readonly static string s_iotHubSasKey = "YL8NQT0lr74v2G+02zfToCb/Fj0uF1hQuH9oyK+SAvA=";
        // private readonly static string s_iotHubSasKeyName = "iothubowner";
        // private static EventHubClient s_eventHubClient;
        private  static List<WorkerModel> lstWorkerModels = new List<WorkerModel>();

        // public  async void IndexAsync()
        // {
        //     // Create an EventHubClient instance to connect to the
        //     // IoT Hub Event Hubs-compatible endpoint.
        //     var connectionString = new EventHubsConnectionStringBuilder(new Uri(s_eventHubsCompatibleEndpoint), s_eventHubsCompatiblePath, s_iotHubSasKeyName, s_iotHubSasKey);
        //     s_eventHubClient = EventHubClient.CreateFromConnectionString(connectionString.ToString());

        //     // Create a PartitionReciever for each partition on the hub.
        //     var runtimeInfo = await s_eventHubClient.GetRuntimeInformationAsync();
        //     var d2cPartitions = runtimeInfo.PartitionIds;

        //     CancellationTokenSource cts = new CancellationTokenSource();

        //     Console.CancelKeyPress += (s, e) =>
        //     {
        //         e.Cancel = true;
        //         cts.Cancel();
        //         Console.WriteLine("Exiting...");
        //     };

        //     var tasks = new List<Task>();

        //     foreach (string partition in d2cPartitions)
        //     {
        //         tasks.Add(ReceiveMessagesFromDeviceAsync(partition, cts.Token));
        //     }

        //     // Wait for all the PartitionReceivers to finsih.
        //     Task.WaitAll(tasks.ToArray());
        //     //return View(lstWorkerModels);
        // }

        //public IActionResult IndexCompleted()
        //{
        //    return View(lstWorkerModels);
        //}
        private readonly HttpClient _client;
        private readonly string _url;
        public PackagingController()
        {
            _url = "https://localhost:5001/api/WorkerSafety";
            _client = new HttpClient { BaseAddress = new Uri(_url) };
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async Task<IActionResult> Index()
        {

            //var accesstoken = HttpContext.Session.GetString("Access_code");
            //_client.SetBearerToken(accesstoken);
            HttpResponseMessage responseMessageRequests = await _client.GetAsync(_url);
            if (responseMessageRequests.IsSuccessStatusCode)
            {
                var responseDataRequests = await responseMessageRequests.Content.ReadAsStringAsync();
                lstWorkerModels = JsonConvert.DeserializeObject<List<WorkerModel>>(responseDataRequests);
            }
            return View(lstWorkerModels);
        }

        //private async List<WorkerModel> W

        // Asynchronously create a PartitionReceiver for a partition and then start 
        // reading any messages sent from the simulated client.
        //private static async Task ReceiveMessagesFromDeviceAsync(string partition, CancellationToken ct)
        //{
        //    // Create the receiver using the default consumer group.
        //    // For the purposes of this sample, read only messages sent since 
        //    // the time the receiver is created. Typically, you don't want to skip any messages.
        //    var eventHubReceiver = s_eventHubClient.CreateReceiver("$Default", partition, EventPosition.FromEnqueuedTime(DateTime.Now));
        //    Console.WriteLine("Create receiver on partition: " + partition);
        //    while (true)
        //    {
        //        if (ct.IsCancellationRequested) break;
        //        Console.WriteLine("Listening for messages on: " + partition);
        //        // Check for EventData - this methods times out if there is nothing to retrieve.
        //        var events = await eventHubReceiver.ReceiveAsync(100);

        //        // If there is data in the batch, process it.
        //        if (events == null) continue;

        //        foreach (EventData eventData in events)
        //        {
        //            string data = Encoding.UTF8.GetString(eventData.Body.Array);
        //            Console.WriteLine("Message received on partition {0}:", partition);
        //            Console.WriteLine("  {0}:", data);
        //            WorkerModel workerModel = new WorkerModel();
        //            workerModel = JsonConvert.DeserializeObject<WorkerModel>(data);
        //            lstWorkerModels.Add(workerModel);

        //            //Console.WriteLine("Application properties (set by device):");
        //            //foreach (var prop in eventData.Properties)
        //            //{
        //            //    Console.WriteLine("  {0}: {1}", prop.Key, prop.Value);
        //            //}
        //            //Console.WriteLine("System properties (set by IoT Hub):");
        //            //foreach (var prop in eventData.SystemProperties)
        //            //{
        //            //    Console.WriteLine("  {0}: {1}", prop.Key, prop.Value);
        //            //}
        //        }
        //    }
        //}

    }
}
