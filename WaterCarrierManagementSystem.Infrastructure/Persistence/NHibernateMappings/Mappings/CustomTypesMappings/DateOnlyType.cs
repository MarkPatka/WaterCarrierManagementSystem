using NHibernate.Engine;
using NHibernate.SqlTypes;
using NHibernate.UserTypes;
using NHibernate;
using System.Data.Common;
using System.Data;

namespace WaterCarrierManagementSystem.Infrastructure.Persistence.NHibernateMappings.Mappings.CustomTypesMappings;

public class DateOnlyType : IUserType
{
    public SqlType[] SqlTypes => [new SqlType(DbType.Date)];
    public Type ReturnedType => typeof(DateOnly);
    public bool IsMutable => false;

    public DateOnlyType()
    {
        
    }

    public object NullSafeGet(
        DbDataReader rs,
        string[] names,
        ISessionImplementor session,
        object owner)
    {
        var value = NHibernateUtil.Date
            .NullSafeGet(rs, names[0], session);

        return value switch
        {
            DateTime dt => DateOnly.FromDateTime(dt),
            null => throw new InvalidOperationException("Cannot convert null to DateOnly"),
            _ => throw new InvalidOperationException($"Unexpected type: {value.GetType()}")
        };
    }

    public void NullSafeSet(
        DbCommand cmd,
        object value,
        int index,
        ISessionImplementor session)
    {
        if (value == null)
        {
            NHibernateUtil.Date
                .NullSafeSet(cmd, null, index, session);
        }
        else
        {
            var dateOnly = (DateOnly)value;
            NHibernateUtil.Date
                .NullSafeSet(cmd, dateOnly.ToDateTime(TimeOnly.MinValue), index, session);
        }
    }

    public object DeepCopy(object value) => value;
    public object Replace(object original, object target, object owner) => original;
    public object Assemble(object cached, object owner) => cached;
    public object Disassemble(object value) => value;
    public new bool Equals(object x, object y) => ReferenceEquals(x, y);
    public int GetHashCode(object x) => x?.GetHashCode() ?? 0;
}
