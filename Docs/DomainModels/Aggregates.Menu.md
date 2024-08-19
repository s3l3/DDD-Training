# Domain Models

## Menu

```csharp
class Menu
{
    Menu Create();
    void AddDinner(Dinner dinner);
    void RemoveDinner(Dinner dinner);
    void UpdateSection(MenuSection section);
}
```

```json
{
  "id": "00000000-00000-0000-00000000",
  "name": "Yummy Menu",
  "description": "A menu with yummy food",
  "averageRating": 4.5,
  "sections": [],
  "createdDateTime": "",
  "updatedDateTime": "",
  "hostId": "00000000-00000-0000-00000000",
  "dinnerIds": ["00000000-00000-0000-00000000"],
  "menuReviewIds": ["00000000-00000-0000-00000000"]
}
```
