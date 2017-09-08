using System;
using System.Threading.Tasks;
using FubuMVC.Core;
using FubuMVC.Core.ServiceBus;
using FubuMVC.Core.ServiceBus.Configuration;
using Shouldly;
using Xunit;

namespace Fubu3TodoApp.Transportation
{
    public class HelloWorld
    {
        [Fact]
        public async Task send_and_recieve()
        {
            var pinger = FubuRuntime.For<PingApp>();
            var ponger = FubuRuntime.For<PongApp>();
            var bus = pinger.Get<IServiceBus>();

            PongMessage pong = await bus.Request<PongMessage>(new PingMessage {Message = "ping"});
            PingMessage ping = await bus.Request<PingMessage>(pong);
            pong.Message.ShouldBe("pong");
            ping.Message.ShouldBe("ping");
            pinger.Dispose();
            ponger.Dispose();
        }

        [Fact]
        public async Task send_and_recieve2()
        {
            var pinger = FubuRuntime.For<PingApp>();
            var ponger = FubuRuntime.For<PongApp>();
            var bus = pinger.Get<IServiceBus>();

            // Publish a Message
            bus.Send(new PingMessage {Message = "ping"});

            // Request/Reply
            PongMessage pong = await bus.Request<PongMessage>(new PingMessage {Message = "You've been pinged"});

            // "Delay" Send
            bus.DelaySend(pong, TimeSpan.FromMilliseconds(1));

            pinger.Dispose();
            ponger.Dispose();
        }
    }

    public class PingMessage
    {
        public string Message { get; set; }
    }

    public class PongMessage
    {
        public string Message { get; set; }
    }

    public class HelloWorldSettings
    {
        public Uri Pinger { get; set; } = "lq.tcp://localhost:2352/pinger".ToUri();
        public Uri Ponger { get; set; } = "lq.tcp://localhost:2353/ponger".ToUri();
    }

    public class PongHandler
    {
        public PingMessage Handle(PongMessage pong)
        {
            Console.WriteLine("Recieved pong message: " + pong.Message);
            return pong.Message == "pong"
                ? new PingMessage {Message = "ping" }
                : new PingMessage {Message = string.Empty };
        }
    }

    public class PingHandler
    {
        public PongMessage Handle(PingMessage ping)
        {
            Console.WriteLine("Recieved ping message: " + ping.Message);
            return ping.Message == "ping"
                ? new PongMessage { Message = "pong" }
                : new PongMessage { Message = string.Empty };
        }
    }

    public class PingApp : FubuTransportRegistry<HelloWorldSettings>
    {
        public PingApp()
        {
            AlterSettings<TransportSettings>(_ => _.InMemoryTransport = InMemoryTransportMode.AllInMemory);
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

    public class PongApp : FubuTransportRegistry<HelloWorldSettings>
    {
       // listen for incoming messages from "Ponger" 
        public PongApp()
        {
            AlterSettings<TransportSettings>(_ => _.InMemoryTransport = InMemoryTransportMode.AllInMemory);
            Channel(x => x.Ponger)
                .ReadIncoming();
        }
    }
}