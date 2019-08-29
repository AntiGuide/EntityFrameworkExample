using ClientServer.EFRepository;
using System;

namespace ClientServer.Server {
    /// <summary>Starts the server and leaves it running until a key is pressed.</summary>
    class Program {
        public static void Main() {
            var controller = new EventController(() => new EFSessionScope());
            using (var host = new Host<EFSessionScope>()) {
                host.Start();
                Console.WriteLine("Server gestartet");
                Console.ReadKey();
                host.Close();
            }
        }
    }
}
