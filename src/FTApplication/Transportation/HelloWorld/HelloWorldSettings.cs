using System;
using FubuMVC.Core.ServiceBus;

namespace FTApplication.Transportation.HelloWorld
{
    public class PingSettings
    {
        public Uri Pinger { get; set; } = "lq.tcp://localhost:2352/pinger".ToUri();
        public Uri Ponger { get; set; } = "lq.tcp://localhost:2353/ponger".ToUri();
    }
}