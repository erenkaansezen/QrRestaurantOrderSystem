using Microsoft.AspNetCore.SignalR;
using Web.DataAccessLayer.Concrete;

namespace WebAPI.Hubs
{
    public class WebHub : Hub
    {
        WebContext context = new WebContext();
        public async Task SendCategoryCount()
        {
            var count=context.Categories.Count();
            await Clients.All.SendAsync("ReceiveCategoryCount", count);
        }
    }
}
