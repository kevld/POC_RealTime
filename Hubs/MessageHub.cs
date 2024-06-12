using Microsoft.AspNetCore.SignalR;
using POC_RealTime.Models;

namespace POC_RealTime.Hubs;

public class MessageHub : Hub
{
    public async Task NewMessage(ReceivedMessage msg)
    {
        Console.WriteLine($"From : {msg.Name} - {msg.Message}");

        await Clients.All.SendAsync("messageReceived", msg);
    }

    public override async Task OnConnectedAsync()
    {
        await base.OnConnectedAsync();

        // Next step - identity
        // await Clients.All.SendAsync("messageReceived", new ReceivedMessage() 
        // {
        //     Name = Context?.User?.Identity?.Name ?? "No name",
        //     Message = "Connected"
        // });
    }

}