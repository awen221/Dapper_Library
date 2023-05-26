using System.Data;
using System.Data.Common;

using Dapper;

namespace Dapper_Library
{
    abstract public class Connection<TDbConnection> 
        where TDbConnection : DbConnection, new() 
    {
        abstract protected string ConnectionString { get; }

        public IEnumerable<TData> Query<TData>(string sql, object? param = null, IDbTransaction? transaction = null, bool buffered = true, int? commandTimeout = null, CommandType? commandType = null)
        {
            using var connection = new TDbConnection();
            connection.ConnectionString = ConnectionString;

            return connection.Query<TData>(sql, param, transaction, buffered, commandTimeout, commandType);
        }
        public TData QuerySingle<TData>(string sql, object? param = null, IDbTransaction? transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            using var connection = new TDbConnection();
            connection.ConnectionString = ConnectionString;

            return connection.QuerySingle<TData>(sql, param, transaction, commandTimeout, commandType);
        }
        public TData QuerySingleOrDefault<TData>(string sql, object? param = null, IDbTransaction? transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            using var connection = new TDbConnection();
            connection.ConnectionString = ConnectionString;

            return connection.QuerySingleOrDefault<TData>(sql, param, transaction, commandTimeout, commandType);
        }

        public int Execute(string sql, object? param = null, IDbTransaction? transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            using var connection = new TDbConnection();
            connection.ConnectionString = ConnectionString;

            return connection.Execute(sql, param, transaction, commandTimeout, commandType);
        }
    }
}
