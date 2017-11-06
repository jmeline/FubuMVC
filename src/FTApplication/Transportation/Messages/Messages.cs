using System.IO;
using FTApplication.Transportation.HelloWorld;
using FubuMVC.Core;
using FubuMVC.Core.ServiceBus;
using FubuMVC.Core.ServiceBus.Configuration;
using Shouldly;
using Xunit;

namespace FTApplication.Transportation.Messages
{
    public class Messages
    {
        public Messages()
        {
            DeleteDir(Directory.GetCurrentDirectory() + "/fubutransportationqueues.2352");
            DeleteDir(Directory.GetCurrentDirectory() + "/fubutransportationqueues.2353");
        }

        public void DeleteDir(string path)
        {
            if (Directory.Exists(path))
            {
                Directory.Delete(path, true);
            }
        }

        [Fact]
        public void Send_wait_Example()
        {
            var pinger = FubuRuntime.For<PingApp>();
            var ponger = FubuRuntime.For<PongApp>();
            var bus = pinger.Get<IServiceBus>();

            bus.SendAndWait(new PingMessage { Message = "ping message" })
               .Wait(1000)
               .ShouldBeTrue();

            bus.SendAndWait(new PongMessage { Message = "pong message" })
               .Wait(1000)
               .ShouldBeTrue();

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

    public class PingApp : FubuTransportRegistry<PingSettings>
    {
        public PingApp()
        {
            // listen for incoming messages from "Pinger"
            Channel(x => x.Pinger)
                .ReadIncoming();

            // same as .AcceptsMessage<PingMessage>()
            Channel(x => x.Ponger)
                .AcceptsMessage(typeof(PingMessage))
                .AcceptsMessage<PongMessage>();

        }
    }

    public class PongApp : FubuTransportRegistry<PingSettings>
    {
        public PongApp()
        {
            // listen for incoming messages from "Ponger"
            Channel(x => x.Ponger)
                .ReadIncoming();
        }
    }

    public class PongHandler
    {
        public void Consume(PongMessage message)
        {
        }
    }

    public class PingHandler
    {
        public void Consume(PingMessage envelope)
        {
        }
    }
}