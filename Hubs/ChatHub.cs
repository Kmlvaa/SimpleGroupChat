using Microsoft.AspNetCore.SignalR;

namespace ChatTest.Hubs
{
    public class ChatHub : Hub
    {
        public override Task OnConnectedAsync()
        {
            ConnectedUsers.Users.Add(Context.ConnectionId);

            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            ConnectedUsers.Users.Remove(Context.ConnectionId);

            return base.OnDisconnectedAsync(exception);
        }

        public async Task SendMessage(string user, string message)
        {
            if(string.IsNullOrEmpty(user))
                await Clients.All.SendAsync("ReceiveMessage", user, message);

            else await Clients.Client(user).SendAsync("ReceiveMessage", user, message);
        }
    }
}
