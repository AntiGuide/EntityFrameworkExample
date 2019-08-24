using ClientServer.EFRepository;
using ClientServer.Repository;
using System;

namespace ClientServer.Server {
    class Program {
        static void Main(string[] args) {
            using (var ctx = new MyContext()) {
                foreach (var item in ctx.Consumers) {
                    Console.WriteLine(item.Id + " | " + item.Name);
                }

                Console.ReadKey();
            }
        }
    }
}
