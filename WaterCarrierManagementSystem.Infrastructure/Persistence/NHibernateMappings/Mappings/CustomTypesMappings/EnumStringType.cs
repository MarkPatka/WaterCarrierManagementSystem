
using NHibernate.Engine;
using NHibernate.SqlTypes;
using NHibernate.UserTypes;
using NHibernate;
using System.Data.Common;
using System.Data;
using WaterCarrierManagementSystem.Domain.Common.Abstract;

namespace WaterCarrierManagementSystem.Infrastructure.Persistence.NHibernateMappings.Mappings.CustomTypesMappings;

public abstract class EnumStringType<T> 
    : IUserType where T : Enumeration
{
    public SqlType[] SqlTypes => [new SqlType(DbType.String)];
    public Type ReturnedType { get; }
    public bool IsMutable => false;

    protected EnumStringType()
    {
        ReturnedType = typeof(T);
    }

    protected EnumStringType(Type enumType)
    {
        ReturnedType = enumType;
    }

    public object NullSafeGet(
        DbDataReader rs,
        string[] names,
        ISessionImplementor session,
        object owner)
    {
        var name = NHibernateUtil.String
            .NullSafeGet(rs, names[0], session) as string;

        ArgumentNullException.ThrowIfNull(name);

        return Enumeration.GetFromName<T>(name);
    }

    public void NullSafeSet(
        DbCommand cmd,
        object value,
        int index,
        ISessionImplementor session)
    {
        var enumeration = value as Enumeration;

        NHibernateUtil.String
            .NullSafeSet(cmd, enumeration?.Name, index, session);
    }

    public object DeepCopy(object value) => value;
    public object Replace(object original, object target, object owner) => original;
    public object Assemble(object cached, object owner) => cached;
    public object Disassemble(object value) => value;
    public new bool Equals(object x, object y) => object.Equals(x, y);
    public int GetHashCode(object x) => x.GetHashCode();
}