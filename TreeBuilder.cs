namespace Server
{
    public class TreeBuilder
    {
        private readonly List<SignalRChildNode> nodes = new();

        public Tuple<string, string> AttachNewNode(string connectionId)
        {
            var newNode = new SignalRChildNode(connectionId);

            foreach (var node in nodes)
            {
                if (node.Left == null)
                {
                    node.Left = newNode;
                    nodes.Add(newNode);
                    return new Tuple<string, string>(node.ConnectionId, newNode.ConnectionId);
                }
                else if (node.Right == null)
                {
                    node.Right = newNode;
                    nodes.Add(newNode);
                    return new Tuple<string, string>(node.ConnectionId, newNode.ConnectionId);
                }
            }

            nodes.Add(newNode); // root node if no open slots
            return new Tuple<string, string>("", newNode.ConnectionId);
        }

        public SignalRChildNode FindNode(string connectionId)
        {
            return nodes.FirstOrDefault(n => n.ConnectionId == connectionId);
        }

        public string GetChildSide(string parentId, string childId)
        {
            var parentNode = FindNode(parentId);
            if (parentNode == null) return "unknown";

            if (parentNode.Left != null && parentNode.Left.ConnectionId == childId)
                return "left";

            if (parentNode.Right != null && parentNode.Right.ConnectionId == childId)
                return "right";

            return "unknown";
        }
    }
}