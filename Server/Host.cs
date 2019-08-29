using System;
using System.ServiceModel;
using ClientServer.Common;
using ClientServer.Repository;

namespace ClientServer.Server {
    /// <summary>
    /// Handles the hosting of the WCF ServiceEndpoint
    /// </summary>
    /// <typeparam name="T">ISessionScope implementing type</typeparam>
    class Host<T> : IDisposable where T : ISessionScope, new() {
        private bool disposedValue = false;

        ServiceHost serviceHost = new ServiceHost(typeof(EventService<T>));

        /// <summary>
        /// Starts the ServiceHost (Needs to be closed)
        /// </summary>
        public void Start() {
            Uri baseAddress = new Uri("net.tcp://localhost:8009/Event");
            NetTcpBinding binding = new NetTcpBinding();
            serviceHost.AddServiceEndpoint(typeof(IEventService), binding, baseAddress);
            serviceHost.Open();
        }

        /// <summary>
        /// Closes an opened ServiceHost
        /// </summary>
        public void Close() {
            serviceHost.Close();
        }

        /// <summary>
        /// Disposes the ServiceHost
        /// </summary>
        public void Dispose() {
            if (!disposedValue) {
                ((IDisposable)serviceHost).Dispose();
                disposedValue = true;
            }
        }
    }
}
