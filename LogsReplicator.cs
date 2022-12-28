using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Logs_Replicator
{
    public static class LogsReplicator
    {
        [FunctionName("LogsReplicator")]
        public static async Task Run(
            [EventHubTrigger("aadlogs", Connection = "EventHubConnection")] EventData[] events,
            [EventHub("destaadlogs", Connection = "DestEventHubConnection")] IAsyncCollector<string> outputEvents,
            ILogger log)
        {
            var exceptions = new List<Exception>();

            foreach (EventData eventData in events)
            {
                try
                {
                    // Replace these two lines with your processing logic.
                    //log.LogInformation($"C# Event Hub trigger function processed a message: {eventData.EventBody}");
                    string rawMessage = eventData.EventBody.ToString();
                    if (string.IsNullOrEmpty( rawMessage ) )
                    {
                        exceptions.Add(new Exception("Empty message"));
                    }
                    else
                    {
                        // Process the logs
                        // As a sample, I added tenant name in the logs entry
                        LogsSchema logEntry = JsonConvert.DeserializeObject<LogsSchema>( rawMessage );
                        foreach(Record record in logEntry.records)
                        {
                            record.tenantName = "abc.com";
                        }

                        log.LogInformation($"Number of record received: {logEntry.records.Count()}");
                        await outputEvents.AddAsync(JsonConvert.SerializeObject(logEntry));
                    }

                    await Task.Yield();
                }
                catch (Exception e)
                {
                    // We need to keep processing the rest of the batch - capture this exception and continue.
                    // Also, consider capturing details of the message that failed processing so it can be processed again later.
                    exceptions.Add(e);
                }
            }

            // Once processing of the batch is complete, if any messages in the batch failed processing throw an exception so that there is a record of the failure.
            if (exceptions.Count > 1)
                throw new AggregateException(exceptions);

            if (exceptions.Count == 1)
                throw exceptions.Single();
        }
    }

}
