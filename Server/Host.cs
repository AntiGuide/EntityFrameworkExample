using System;
using System.ServiceModel;
using ClientServer.Common;
using ClientServer.Repository;

namespace ClientServer.Server {
    class Host<T> : IDisposable where T : ISessionScope, new() {
        private bool disposedValue = false;

        ServiceHost serviceHost = new ServiceHost(typeof(EventService<T>));

        public void Start() {
            Uri baseAddress = new Uri("net.tcp://localhost:8009/Event");
            NetTcpBinding binding = new NetTcpBinding();
            serviceHost.AddServiceEndpoint(typeof(IEventService), binding, baseAddress);
            serviceHost.Open();
        }

        public void Close() {
            serviceHost.Close();
        }

        protected virtual void Dispose(bool disposing) {
            if (!disposedValue) {
                if (disposing) {
                    ((IDisposable)serviceHost).Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose() {
            Dispose(true);
        }
    }
}
