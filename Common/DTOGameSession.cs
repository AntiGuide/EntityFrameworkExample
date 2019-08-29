namespace ClientServer.Common {
    /// <summary>A game session a consumer started. Can contain multiple events per session. (DTO variant)</summary>
    public class DTOGameSession {

        /// <summary>Unique database ID used as the primary key.</summary>
        public int Id { get; set; }
    }
}
