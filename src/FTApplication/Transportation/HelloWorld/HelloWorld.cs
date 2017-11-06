using System.IO;
using System.Threading.Tasks;
using FubuMVC.Core;
using FubuMVC.Core.ServiceBus;
using Shouldly;
using Xunit;

namespace FTApplication.Transportation.HelloWorld
{
    public class HelloWorld
    {
        public HelloWorld()
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
        public async Task request_reply_example()
        {
            var pinger = FubuRuntime.For<PingApp>();
            var ponger = FubuRuntime.For<PongApp>();
            var bus = pinger.Get<IServiceBus>();
            PongMessage pong = await bus.Request<PongMessage>(new PingMessage { Message = "ping" });
            PingMessage ping = await bus.Request<PingMessage>(pong);
            pong.Message.ShouldBe("pong");
            ping.Message.ShouldBe("ping");
            pinger.Dispose();
            ponger.Dispose();
        }

        [Fact]
        public void send_to_specific_destination()
        {
            var pinger = FubuRuntime.For<PingApp>();
            var ponger = FubuRuntime.For<PongApp>();
            var bus = pinger.Get<IServiceBus>();
            var settings = new PingSettings();

            // Providing a URI sends the message to the URI regardless of routing rules
            bus.SendAndWait(settings.Pinger, new PingMessage { Message = "This is a direct message" });
            pinger.Dispose();
            ponger.Dispose();
        }
    }
}