using NHibernate.Engine;
using NHibernate.SqlTypes;
using NHibernate.UserTypes;
using NHibernate;
using System.Data.Common;
using System.Data;
using WaterCarrierManagementSystem.Domain.ContractorAggregate.ValueObjects;
using WaterCarrierManagementSystem.Domain.EmplyeeAggregate.ValueObjects;

namespace WaterCarrierManagementSystem.Infrastructure.Persistence.NHibernateMappings.Mappings.CustomTypesMappings;

public class EmployeeIdType : IUserType
{
    public SqlType[] SqlTypes => [new SqlType(DbType.Int32)];
    public Type ReturnedType => typeof(EmployeeId);
    public bool IsMutable => false;

    public EmployeeIdType()
    {
        
    }

    public object NullSafeGet(
        DbDataReader rs,
        string[] names,
        ISessionImplementor session,
        object owner)
    {
        var value = (int)NHibernateUtil.Int32.NullSafeGet(rs, names[0], session);
        return EmployeeId.Create(value);
    }

    public void NullSafeSet(
        DbCommand cmd,
        object value,
        int index,
        ISessionImplementor session)
    {
        if (value == null)
        {
            NHibernateUtil.Int32.NullSafeSet(cmd, null, index, session);
        }
        else
        {
            var id = EmployeeId.Create((int)value);
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