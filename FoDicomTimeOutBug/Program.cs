using FellowOakDicom.Network;
using FellowOakDicom.Network.Client;

var client = DicomClientFactory.Create("1.1.1.1", 4242, false, "dummy", "dummy");
client.ClientOptions.AssociationRequestTimeoutInMs = 1000;

var cEchoRequest = new DicomCEchoRequest {
    OnTimeout = (_, _) => { Console.WriteLine($"TimeOut {DateTime.Now}"); },
    OnResponseReceived = (_, response) => { Console.WriteLine($"Response {DateTime.Now}"); }
};
await client.AddRequestAsync(cEchoRequest);
Console.WriteLine($"Sending {DateTime.Now}");
try {
    await client.SendAsync();
}
catch (AggregateException) {}
Console.WriteLine($"Done {DateTime.Now}");
