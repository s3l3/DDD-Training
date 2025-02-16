
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Hosts.ValueObjects;
using BuberDinner.Domain.Menus;
using BuberDinner.Domain.Menus.Entites;
using BuberDinner.Domain.Menus.Events;

using ErrorOr;

using MediatR;

using Microsoft.AspNetCore.Builder;

namespace BuberDinner.Application.Services.Menus.Commands.CreateMenu;

public class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommand, ErrorOr<Menu>>
{
    private readonly IMenuRepository _menuRepository;

    public CreateMenuCommandHandler(IMenuRepository menuRepository)
    {
        _menuRepository = menuRepository;
    }

    public async Task<ErrorOr<Menu>> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
    {
        Menu menu = Menu.Create(
            name: request.Name,
            description: request.Description,
            hostId: HostId.Create(request.HostId),
            menuSections: request.Sections.ConvertAll(section => MenuSection.Create(
                name: section.Name,
                description: section.Description,
                items: section.Items.ConvertAll(item => MenuItem.Create(
                    name: item.Name,
                    description: item.Description)))));

        await _menuRepository.AddAsync(menu);

        return menu;
    }
}