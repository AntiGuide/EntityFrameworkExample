using System;
using ClientServer.Repository;

namespace ClientServer.EFRepository {
    /// <summary>Connection to the dependency injected implementations of data repositories</summary>
    public class EFSessionScope : ISessionScope {
        /// <summary>The context that this session and its repositories operate in</summary>
        private Lazy<MyContext> ctx = new Lazy<MyContext>(() => new MyContext(), false);

        private Lazy<IGameSessionRepository> gameSessionRepository;
        private Lazy<IConsumerRepository> consumerRepository;
        private Lazy<IEventRepository> eventRepository;

        /// <summary>The interface to operate on all GameSession data</summary>
        public IGameSessionRepository GameSessionRepository => gameSessionRepository.Value;

        /// <summary>The interface to operate on all Consumer data</summary>
        public IConsumerRepository ConsumerRepository => consumerRepository.Value;

        /// <summary>The interface to operate on all Event data</summary>
        public IEventRepository EventRepository => eventRepository.Value;

        public EFSessionScope() {
            gameSessionRepository = new Lazy<IGameSessionRepository>(() => new EFGameSessionRepository(ctx.Value), false);
            consumerRepository = new Lazy<IConsumerRepository>(() => new EFConsumerRepository(ctx.Value), false);
            eventRepository = new Lazy<IEventRepository>(() => new EFEventRepository(ctx.Value), false);
        }

        private bool disposedValue = false;

        /// <summary>Disposes the Lazy DBContext</summary>
        public void Dispose() {
            if (!disposedValue) {
                if (ctx.IsValueCreated) {
                    ctx.Value.Dispose();
                }

                disposedValue = true;
            }
        }
    }
}
