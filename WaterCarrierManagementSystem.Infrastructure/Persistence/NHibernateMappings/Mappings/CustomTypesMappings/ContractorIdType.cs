using NHibernate.Engine;
using NHibernate;
using NHibernate.UserTypes;
using System.Data.Common;
using WaterCarrierManagementSystem.Domain.ContractorAggregate.ValueObjects;
using NHibernate.SqlTypes;
using System.Data;

namespace WaterCarrierManagementSystem.Infrastructure.Persistence.NHibernateMappings.Mappings.CustomTypesMappings;

public class ContractorIdType : IUserType
{
    public SqlType[] SqlTypes => [new SqlType(DbType.Int32)];
    public Type ReturnedType => typeof(ContractorId);
    public bool IsMutable => false;

    public ContractorIdType()
    {
        
    }

    public object NullSafeGet(
        DbDataReader rs, 
        string[] names, 
        ISessionImplementor session, 
        object owner)
    {
        var value = (int)NHibernateUtil.Int32.NullSafeGet(rs, names[0], session);
        return ContractorId.Create(value);
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
            var id = ContractorId.Create((int)value);
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
