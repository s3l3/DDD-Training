using BuberDinner.Domain.Bills.ValueObjects;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.Dinners.ValueObjects;
using BuberDinner.Domain.Guests.ValueObjects;
using BuberDinner.Domain.Hosts.ValueObjects;

namespace BuberDinner.Domain.Bills;

public class Bill : AggregateRoot<BillId, Guid>
{
    public DinnerId DinnerId { get; private set; }

    public GuestId GuestId { get; private set; }

    public HostId HostId { get; private set; }

    public Price Price { get; private set; }

    public DateTime CreatedDateTime { get; private set; }

    public DateTime UpdatedDateTime { get; private set; }

#pragma warning disable CS8618
    private Bill() { }
#pragma warning restore CS8618

    private Bill(
        BillId billId,
        DinnerId dinnerId,
        GuestId guestId,
        HostId hostId,
        Price price,
        DateTime createdDateTime,
        DateTime updatedDateTime) : base(billId)
    {
        DinnerId = dinnerId;
        GuestId = guestId;
        HostId = hostId;
        Price = price;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static Bill Create(
        DinnerId dinnerId,
        GuestId guestId,
        HostId hostId,
        Price price)
    {
        return new(
            BillId.CreateUnique(),
            dinnerId,
            guestId,
            hostId,
            price,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }

}
