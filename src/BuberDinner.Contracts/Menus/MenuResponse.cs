namespace BuberDinner.Contracts.Menus;

public record MenuResponse(
    Guid Id,
    Guid HostId,
    string Name,
    string Description,
    double? AverageRating,
    List<MenuSectionResponse> MenuSections,
    List<string> DinnerIds,
    List<string> MenuReviewIds,
    DateTime CreatedDateTime,
    DateTime UpdatedDateTime);

public record MenuSectionResponse(
    string Id,
    string Name,
    string Description,
    List<MenuItemResponse> MenuItems);

public record MenuItemResponse(
        Guid Id,
        string Name,
        string Description);