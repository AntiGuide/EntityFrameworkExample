using System;

namespace ClientServer.Repository {
    public interface ISessionScope : IDisposable {
        IGameSessionRepository GameSessionRepository { get; }
        IConsumerRepository ConsumerRepository { get; }
        IEventRepository EventRepository { get; }
    }
}
