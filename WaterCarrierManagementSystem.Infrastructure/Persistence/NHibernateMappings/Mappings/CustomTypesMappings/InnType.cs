using NHibernate.Engine;
using NHibernate;
using System.Data.Common;
using WaterCarrierManagementSystem.Domain.ContractorAggregate.ValueObjects;
using NHibernate.SqlTypes;
using NHibernate.UserTypes;
using System.Data;

namespace WaterCarrierManagementSystem.Infrastructure.Persistence.NHibernateMappings.Mappings.CustomTypesMappings;

public class INNType : IUserType
{
    public SqlType[] SqlTypes => [new SqlType(DbType.Int64)];
    public Type ReturnedType => typeof(INN);
    public bool IsMutable => false;

    public INNType()
    {
        
    }

    public object NullSafeGet(
        DbDataReader rs,
        string[] names,
        ISessionImplementor session,
        object owner)
    {
        var value = NHibernateUtil.Int64
            .NullSafeGet(rs, names[0], session);
        
        return INN.Create((long)value);
    }

    public void NullSafeSet(
        DbCommand cmd,
        object value,
        int index,
        ISessionImplementor session)
    {
        if (value == null)
        {
            NHibernateUtil.Int64
                .NullSafeSet(cmd, null, index, session);
        }
        else
        {
            var inn = (INN)value;

            NHibernateUtil.Int64
                .NullSafeSet(cmd, inn.Value, index, session);
        }
    }

    public object DeepCopy(object value) => value;
    public object Replace(object original, object target, object owner) => original;
    public object Assemble(object cached, object owner) => cached;
    public object Disassemble(object value) => value;
    public new bool Equals(object x, object y) => object.Equals(x, y);
    public int GetHashCode(object x) => x?.GetHashCode() ?? 0;
}