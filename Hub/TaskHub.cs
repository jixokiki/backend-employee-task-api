using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace EmployeeTaskApi.Hubs
{
    public class TaskHub : Hub
    {
        public async Task SendTaskNotification(string message)
        {
            await Clients.All.SendAsync("ReceiveTask", message);
        }
    }
}
