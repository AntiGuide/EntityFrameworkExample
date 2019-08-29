using System;

namespace ClientServer.Repository {
    public interface ISessionScope : IDisposable {

        /// <summary>The interface to operate on all GameSession data</summary>
        IGameSessionRepository GameSessionRepository { get; }

        /// <summary>The interface to operate on all Consumer data</summary>
        IConsumerRepository ConsumerRepository { get; }

        /// <summary>The interface to operate on all Event data</summary>
        IEventRepository EventRepository { get; }
    }
}
