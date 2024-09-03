using System.Reflection.Metadata.Ecma335;

using BuberDinner.Application.Services.Menus.Commands.CreateMenu;
using BuberDinner.Contracts.Menus;
using BuberDinner.Domain.Menus;
using BuberDinner.Domain.Menus.Entites;

using Mapster;

namespace BuberDinner.Api.Common.Mapping;

public class MenuMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(CreateMenuRequest Request, string HostId), CreateMenuCommand>()
            .Map(dest => dest.HostId, src => src.HostId)
            .Map(dest => dest, src => src.Request);

        config.NewConfig<Menu, MenuResponse>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.HostId, src => src.HostId.Value)
            .Map(dest => dest.AverageRating, src => src.AverageRating.NumRatings > 0 ? src.AverageRating.Value : default)
            .Map(dest => dest.DinnerIds, src => src.DinnerIds.Select(id => id.Value))
            .Map(dest => dest.MenuReviewIds, src => src.MenuReviewIds.Select(id => id.Value));

        config.NewConfig<MenuSection, MenuSectionResponse>()
            .Map(dest => dest.Id, src => src.Id.Value);

        config.NewConfig<MenuItem, MenuItemResponse>()
            .Map(dest => dest.Id, src => src.Id.Value);
    }
}