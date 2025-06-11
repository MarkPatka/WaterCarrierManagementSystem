using NHibernate.Engine;
using NHibernate.SqlTypes;
using NHibernate.UserTypes;
using NHibernate;
using System.Data.Common;
using System.Data;
using WaterCarrierManagementSystem.Domain.EmplyeeAggregate.ValueObjects;
using WaterCarrierManagementSystem.Domain.OrderAggregate.ValueObjects;
namespace WaterCarrierManagementSystem.Infrastructure.Persistence.NHibernateMappings.Mappings.CustomTypesMappings;

public class OrderIdType : IUserType
{
    public SqlType[] SqlTypes => [new SqlType(DbType.Guid)];
    public Type ReturnedType => typeof(OrderId);
    public bool IsMutable => false;


    public OrderIdType()
    {
        
    }

    public object NullSafeGet(
        DbDataReader rs,
        string[] names,
        ISessionImplementor session,
        object owner)
    {
        string? value = NHibernateUtil.Guid
            .NullSafeGet(rs, names[0], session)
            .ToString();

        ArgumentNullException.ThrowIfNull(value);

        Guid guid = Guid.Parse(value);
        return OrderId.Create(guid);
    }

    public void NullSafeSet(
        DbCommand cmd,
        object value,
        int index,
        ISessionImplementor session)
    {
        if (value == null)
        {
            NHibernateUtil.Guid
                .NullSafeSet(cmd, null, index, session);
        }
        else
        {

            string? guidString = value.ToString();
            ArgumentNullException.ThrowIfNull(guidString);

            var id = OrderId.Create(Guid.Parse(guidString));
            NHibernateUtil.Int32.NullSafeSet(cmd, id.Value, index, session);
        }
    }

    public object Assemble(object cached, object owner) => cached;
    public object DeepCopy(object value) => value;
    public object Disassemble(object value) => value;
    public object Replace(object original, object target, object owner) => original;

    public new bool Equals(object x, object y) => object.Equals(x, y);
    public int GetHashCode(object x) => x.GetHashCode();


}
