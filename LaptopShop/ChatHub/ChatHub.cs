using LaptopShop.Models.database;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Serilog;

namespace LaptopShop.ChatHub
{
	public class Chathub : Hub
	{
		private readonly DBlaptops dBlaptops;
		public UserManager<User> UserManager { get; set; }

		ILogger<Chathub> _logger;

		public Chathub(DBlaptops dBlaptops, UserManager<User> userManager, ILogger<Chathub> logger)
		{
			this.dBlaptops = dBlaptops;
			UserManager = userManager;
			_logger = logger;
		}

		public async Task joinGroup(string username)
		{
			User user = await UserManager.FindByNameAsync(username);
			bool IsInRole = await UserManager.IsInRoleAsync(user, "Customer_service");

			if (!IsInRole)
			{
				user.groupname = username;
				await UserManager.UpdateAsync(user);

				await Groups.AddToGroupAsync(Context.ConnectionId, username);
				await Clients.Group(username).SendAsync("Custadd", "You will be contacted by a customer service representative.");
				Groups groups = new Groups { GroupName = username };
				dBlaptops.Groups.Add(groups);
				await dBlaptops.SaveChangesAsync();
			}
			else
			{
				var group = dBlaptops.Groups.FirstOrDefault();
				if (group != null)
				{
					user.groupname = group.GroupName;
					await UserManager.UpdateAsync(user);
					await Groups.AddToGroupAsync(Context.ConnectionId, group.GroupName);

					await Clients.Group(group.GroupName).SendAsync("added", $"{user.UserName} has joined");
					dBlaptops.Groups.Remove(group);
					await dBlaptops.SaveChangesAsync();
				}
				else
				{
					await Clients.Caller.SendAsync("error", "No group available to join.");
				}
			}
		}

		public async Task leaveGroup(string groupName)
		{
			User user = await UserManager.FindByNameAsync(groupName);
			await Groups.RemoveFromGroupAsync(Context.ConnectionId, user.groupname);

			var groupToRemove = dBlaptops.Groups.FirstOrDefault(g => g.GroupName == user.groupname);
			if (groupToRemove != null)
			{
				dBlaptops.Groups.Remove(groupToRemove);
				await dBlaptops.SaveChangesAsync();
			}

			await Clients.Caller.SendAsync("groupLeft", $"You have left the group: {user.groupname}");
		}

		public async Task sendMessage(string name, string message)
		{
			User user = await UserManager.FindByNameAsync(name);
			if (user != null && !string.IsNullOrEmpty(user.groupname))
			{
				await Clients.Group(user.groupname).SendAsync("sendmessage", name, message);
				_logger.LogInformation("{user} send this {massage}",name, message);
			}
		}
	}
}
