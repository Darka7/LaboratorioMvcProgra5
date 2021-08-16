using Entity;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace BD
{
    public interface IDataAccess
    {
        SqlConnection DbConnection { get; }

        DBEntity Execute(string sp, object Param = null, int? Timeout = null);
        IEnumerable<dynamic> Query(string sp, object Param = null, int? Timeout = null);
        IEnumerable<A> Query<A, B, C, D, E, H, I>(string sp, string split, object Param = null, int? Timeout = null);
        IEnumerable<A> Query<A, B, C, D, E, H>(string sp, string split, object Param = null, int? Timeout = null);
        IEnumerable<A> Query<A, B, C, D, E>(string sp, string split, object Param = null, int? Timeout = null);
        IEnumerable<A> Query<A, B, C, D>(string sp, string split, object Param = null, int? Timeout = null);
        IEnumerable<A> Query<A, B, C>(string sp, string split, object Param = null, int? Timeout = null);
        IEnumerable<A> Query<A, B>(string sp, string split, object Param = null, int? Timeout = null);
        IEnumerable<T> Query<T>(string sp, object Param = null, int? Timeout = null);
        T QueryFirst<T>(string sp, object Param = null, int? Timeout = null);
    }
}