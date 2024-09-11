using BuberDinner.Domain.Common.Models;

using MediatR;

namespace BuberDinner.Domain.Menus.Events;

public record MenuCreated(Menu Menu) : IDomainEvent, INotification;