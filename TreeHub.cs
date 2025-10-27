using Microsoft.AspNetCore.SignalR;

namespace Server
{
    public class TreeHub : Hub
    {
        private readonly TreeBuilder _treeBuilder;

        public TreeHub(TreeBuilder treeBuilder)
        {
            _treeBuilder = treeBuilder;
        }

        // Called by a new node joining the tree
        public async Task<Tuple<string, string>> ConnectNode()
        {
            try
            {
                var connectionId = Context.ConnectionId;

                // Attach the new node and get parent-child mapping
                var parentChildId = _treeBuilder.AttachNewNode(connectionId);
                var parentId = parentChildId.Item1;
                var childId = parentChildId.Item2;

                // Determine which side this child was assigned to
                var side = _treeBuilder.GetChildSide(parentId, childId); // returns "left" or "right"

                // Notify the parent to attach this child
                await Clients.Client(parentId).SendAsync("ChildAssigned", childId, side);

                return parentChildId;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ConnectNode error: {ex.Message}");
                throw;
            }
        }

        public async Task SendOffer(string targetConnectionId, string offer)
        {
            await Clients.Client(targetConnectionId).SendAsync("ReceiveOffer", Context.ConnectionId, offer);
        }

        public async Task SendAnswer(string targetConnectionId, string answer)
        {
            await Clients.Client(targetConnectionId).SendAsync("ReceiveAnswer", Context.ConnectionId, answer);
        }

        public async Task SendCandidate(string targetConnectionId, string candidate)
        {
            await Clients.Client(targetConnectionId).SendAsync("ReceiveCandidate", Context.ConnectionId, candidate);
        }
    }
}
