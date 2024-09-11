
using BuberDinner.Domain.Menus.Events;

using MediatR;

namespace BuberDinner.Application.Services.Menus.Events;

public class MenuCreatedDomainEventHandler : INotificationHandler<MenuCreated>
{
    public async Task Handle(MenuCreated notification, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        Console.WriteLine(notification);
    }
}