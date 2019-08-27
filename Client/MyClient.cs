using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Channels;
using ClientServer.Common;
using System.Linq;

namespace ClientServer.Client {
    class MyClient {
        public static void Main(string[] args) {
            Uri baseAddress = new Uri("net.tcp://localhost:8009/Event");
            EndpointAddress address = new EndpointAddress(baseAddress);
            NetTcpBinding binding = new NetTcpBinding();
            using (var factory = new ChannelFactory<IEventService>(binding, address)) {
                IEventService svc = factory.CreateChannel();

                var myConsumer = svc.CreateConsumer("ConsumerName");
                var mySession = svc.CreateSession(myConsumer.Id);
                svc.CreateEvent("BeganToPlay", mySession.Id);

                Console.WriteLine("CONSUMERS" + Environment.NewLine + "---------");
                svc.GetConsumers().ToList().ForEach(c => Console.WriteLine(c.Id + " | " + c.Name));
                Console.WriteLine();
                Console.WriteLine("SESSIONS" + Environment.NewLine + "--------");
                svc.GetSessions().ToList().ForEach(s => Console.WriteLine(s.Id));
                Console.WriteLine();
                Console.WriteLine("EVENTS" + Environment.NewLine + "------");
                svc.GetEvents().ToList().ForEach(c => Console.WriteLine(c.Id + " | " + c.EventName));

                (svc as IChannel).Close();
            }

            Console.ReadKey();
        }
    }
}
