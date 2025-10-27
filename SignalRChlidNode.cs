namespace Server
{
    public class SignalRChildNode(string connectionId)
    {
        public string ConnectionId { get; set; } = connectionId;
        public SignalRChildNode Left { get; set; }
        public SignalRChildNode Right { get; set; }

        public bool HasOpenSlot => Left == null || Right == null;
    }
}
