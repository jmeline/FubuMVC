using System;

namespace FTApplication.Transportation.HelloWorld
{
    public class PingPongHandler
    {
        public PongMessage Handle(PingMessage ping)
        {
            Console.WriteLine("Recieved ping message: " + ping.Message);
            return ping.Message == "ping"
                ? new PongMessage { Message = "pong" }
                : new PongMessage { Message = string.Empty };
        }
        public PingMessage Handle(PongMessage pong)
        {
            Console.WriteLine("Recieved pong message: " + pong.Message);
            return pong.Message == "pong"
                ? new PingMessage { Message = "ping" }
                : new PingMessage { Message = string.Empty };
        }
    }
}