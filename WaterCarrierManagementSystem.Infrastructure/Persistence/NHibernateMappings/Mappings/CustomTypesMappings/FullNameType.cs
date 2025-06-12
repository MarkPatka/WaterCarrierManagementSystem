using NHibernate.Engine;
using NHibernate.SqlTypes;
using NHibernate;
using NHibernate.UserTypes;
using System.Data.Common;
using System.Data;
using WaterCarrierManagementSystem.Domain.ContractorAggregate.ValueObjects;
using WaterCarrierManagementSystem.Domain.EmplyeeAggregate.ValueObjects;
using System.Text;
using FluentNHibernate.Conventions.AcceptanceCriteria;

namespace WaterCarrierManagementSystem.Infrastructure.Persistence.NHibernateMappings.Mappings.CustomTypesMappings;
public class FullNameType : IUserType
{
    public SqlType[] SqlTypes =>
    [
        new SqlType(DbType.String),  
        new SqlType(DbType.String),  
        new SqlType(DbType.String)   
    ];

    public Type ReturnedType => typeof(FullName);
    public bool IsMutable => false;

    public object NullSafeGet(DbDataReader rs, string[] names, ISessionImplementor session, object owner)
    {
        var firstName = (string)NHibernateUtil.String.NullSafeGet(rs, names[0], session);
        var lastName = (string)NHibernateUtil.String.NullSafeGet(rs, names[1], session);
        var middleName = (string)NHibernateUtil.String.NullSafeGet(rs, names[2], session);

        return FullName.Create(firstName, lastName, middleName);
    }

    public void NullSafeSet(DbCommand cmd, object value, int index, ISessionImplementor session)
    {
        if (value == null)
        {
            NHibernateUtil.String.NullSafeSet(cmd, null, index, session);
            NHibernateUtil.String.NullSafeSet(cmd, null, index + 1, session);
            NHibernateUtil.String.NullSafeSet(cmd, null, index + 2, session);
        }
        else
        {
            var fullName = (FullName)value;

            NHibernateUtil.String.NullSafeSet(cmd, fullName.FirstName, index, session);
            NHibernateUtil.String.NullSafeSet(cmd, fullName.LastName, index + 1, session);
            NHibernateUtil.String.NullSafeSet(cmd, fullName.MiddleName, index + 2, session);
        }
    }

    public object DeepCopy(object value) => value;
    public object Replace(object original, object target, object owner) => original;
    public object Assemble(object cached, object owner) => cached;
    public object Disassemble(object value) => value;
    public new bool Equals(object x, object y) => object.Equals(x, y);
    public int GetHashCode(object x) => x?.GetHashCode() ?? 0;
}