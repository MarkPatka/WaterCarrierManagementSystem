
using NHibernate.Engine;
using NHibernate.SqlTypes;
using NHibernate.UserTypes;
using NHibernate;
using System.Data.Common;
using System.Data;
using WaterCarrierManagementSystem.Domain.Common.Abstract;

namespace WaterCarrierManagementSystem.Infrastructure.Persistence.NHibernateMappings.Mappings.CustomTypesMappings;

public abstract class EnumIntType<T> 
    : IUserType where T : Enumeration
{
    public SqlType[] SqlTypes => [new SqlType(DbType.Int32)];
    public Type ReturnedType { get; }
    public bool IsMutable => false;

    protected EnumIntType()
    {
        ReturnedType = typeof(T);
    }

    protected EnumIntType(Type enumType)
    {
        ReturnedType = enumType;
    }

    public object NullSafeGet(
        DbDataReader rs,
        string[] names,
        ISessionImplementor session,
        object owner)
    {
        var id = (Int32)NHibernateUtil.Int32
            .NullSafeGet(rs, names[0], session);

        return Enumeration.GetFromId<T>(id);
    }

    public void NullSafeSet(
        DbCommand cmd,
        object value,
        int index,
        ISessionImplementor session)
    {
        var enumeration = value as Enumeration;

        NHibernateUtil.String
            .NullSafeSet(cmd, enumeration?.Id, index, session);
    }

    public object DeepCopy(object value) => value;
    public object Replace(object original, object target, object owner) => original;
    public object Assemble(object cached, object owner) => cached;
    public object Disassemble(object value) => value;
    public new bool Equals(object x, object y) => object.Equals(x, y);
    public int GetHashCode(object x) => x.GetHashCode();
}