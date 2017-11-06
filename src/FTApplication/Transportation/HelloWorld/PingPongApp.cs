using FubuMVC.Core.ServiceBus.Configuration;

namespace FTApplication.Transportation.HelloWorld
{
    /// <summary>
    /// Channel - a pathway to communicate with a running fubuMVC 
    /// node that is backed by a transport node
    /// </summary>
    public class PingApp : FubuTransportRegistry<PingSettings>
    {
        public PingApp()
        {
            // option to restrict testing to in memory only
            //AlterSettings<TransportSettings>(_ => _.InMemoryTransport = InMemoryTransportMode.AllInMemory);
            // configuring PingApp to send PingMessage's
            // to the Pong App
            Channel(x => x.Ponger)
                .AcceptsMessage<PingMessage>()
                .AcceptsMessage<PongMessage>();

            // listen for incoming messages from "Pinger"
            Channel(x => x.Pinger)
                .ReadIncoming();
        }
    }

    public class PongApp : FubuTransportRegistry<PingSettings>
    {
        // option to restrict testing to in memory only
        // listen for incoming messages from "Ponger" 
        public PongApp()
        {
            //AlterSettings<TransportSettings>(_ => _.InMemoryTransport = InMemoryTransportMode.AllInMemory);
            Channel(x => x.Ponger)
                .ReadIncoming();
        }
    }
}