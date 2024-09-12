using System.Security.Cryptography;
using System.Text;

using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Hosts.ValueObjects;

public sealed class HostId : AggregateRootId<Guid>
{
    public override Guid Value { get; protected set; }

    private HostId() { }

    private HostId(Guid value)
    {
        Value = value;
    }

    public static HostId CreateUnique()
    {
        return new HostId(Guid.NewGuid());
    }

    public static HostId Create(Guid value)
    {
        return new HostId(value);
    }

    public static HostId Create(string value)
    {
        Guid result;

        using (MD5 md5 = MD5.Create())
        {
            byte[] hash = md5.ComputeHash(Encoding.UTF8.GetBytes(value));
            result = new Guid(hash);
        }

        return Create(result);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}