using System;
using ClientServer.Repository;

namespace ClientServer.EFRepository {
    public class EFSessionScope : ISessionScope {
        private Lazy<MyContext> ctx = new Lazy<MyContext>(() => new MyContext(), false);

        private Lazy<IGameSessionRepository> gameSessionRepository;
        private Lazy<IConsumerRepository> consumerRepository;
        private Lazy<IEventRepository> eventRepository;

        public IGameSessionRepository GameSessionRepository => gameSessionRepository.Value;
        public IConsumerRepository ConsumerRepository => consumerRepository.Value;
        public IEventRepository EventRepository => eventRepository.Value;

        public EFSessionScope() {
            gameSessionRepository = new Lazy<IGameSessionRepository>(() => new EFGameSessionRepository(ctx.Value), false);
            consumerRepository = new Lazy<IConsumerRepository>(() => new EFConsumerRepository(ctx.Value), false);
            eventRepository = new Lazy<IEventRepository>(() => new EFEventRepository(ctx.Value), false);
        }

        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing) {
            if (!disposedValue) {
                if (disposing && ctx.IsValueCreated) {
                    ctx.Value.Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose() {
            Dispose(true);
        }
    }
}
