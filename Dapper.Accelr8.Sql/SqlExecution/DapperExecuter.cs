using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Dapper;
using Dapper.Accelr8.Repo.Parameters;
using SqlMapper = Dapper.SqlMapper;

namespace Dapper.Accelr8.Sql
{
    public class DapperExecuter
    {
        static string _type = typeof(DapperExecuter).Name;
        static object _syncConn = new object();

        static string GetConnectionString(string name)
        {
            lock (_syncConn)
                if (_connectionStringContainer.ContainsKey(name))
                    return _connectionStringContainer[name];

            throw new KeyNotFoundException(string.Format("Connection string {0} was not found.", name));
        }

        static IDictionary<string, string> _connectionStringContainer = new Dictionary<string, string>();

        public DapperExecuter(IDictionary<string, string> connectionStringContainer)
        {
            lock (_syncConn)
                if (_connectionStringContainer.Count < connectionStringContainer.Count)
                    foreach (var c in connectionStringContainer)
                        if (!_connectionStringContainer.ContainsKey(c.Key))
                            _connectionStringContainer.Add(c.Key, c.Value);
        }

        protected void LogSqlException(string query, SqlTypeException sqlEx)
        {
            try
            {
                Trace.CorrelationManager.StartLogicalOperation(_type);

                Trace.TraceError("Sql query failed: {0}", query);

                Trace.TraceError(sqlEx.ToString());
            }
            finally
            {
                Trace.CorrelationManager.StopLogicalOperation();
            }
        }

        protected void LogSqlException(string query, SqlException sqlEx)
        {
            try
            {
                Trace.CorrelationManager.StartLogicalOperation(_type);

                Trace.TraceError("Sql query failed: {0}", query);

                Trace.TraceError(sqlEx.ToString());

                if (sqlEx.Errors != null && sqlEx.Errors.Count > 0)
                    foreach (var e in sqlEx.Errors.Cast<object>().Take(10))
                        Trace.TraceError(e.ToString());
            }
            finally
            {
                Trace.CorrelationManager.StopLogicalOperation();
            }
        }

        protected void LogSqlException(string query, DbException dbEx)
        {
            try
            {
                Trace.CorrelationManager.StartLogicalOperation(_type);

                Trace.TraceError("Sql query failed: {0}", query);

                Trace.TraceError(dbEx.ToString());
            }
            finally
            {
                Trace.CorrelationManager.StopLogicalOperation();
            }
        }

        protected void LogException(string query, SystemException nEx)
        {
            try
            {
                Trace.CorrelationManager.StartLogicalOperation(_type);

                Trace.TraceError("Sql query failed: {0}", query);

                Trace.TraceError(nEx.ToString());
            }
            finally
            {
                Trace.CorrelationManager.StopLogicalOperation();
            }
        }

        protected virtual DbConnection GetSqlConnection(string connectionStringName)
        {
            return new SqlConnection(GetConnectionString(connectionStringName));
        }

        public virtual IList<ReturnType> Execute<ReturnType>
            (string connectionStringName
            , string query, object parameters
            , Func<IEnumerable<dynamic>, IList<ReturnType>> visitor)
            where ReturnType : class
        {
            using (var connection = GetSqlConnection(connectionStringName))
            {
                connection.Open();

                try
                {
                    var results = connection.Query(query, param: parameters);

                    return visitor(results);
                }
                catch (DbException dbEx)
                {
                    LogSqlException(query, dbEx);
                    throw;
                }
                finally
                {
                    if (connection.State != ConnectionState.Closed)
                        connection.Close();
                }
            }
        }

        public virtual IList<ReturnType> Execute<ReturnType, JoinType>
            (string connectionStringName
            , string query
            , object parameters
            , IList<Join> joins
            , Func<dynamic, JoinType, ReturnType> load)
            where ReturnType : class
            where JoinType : class
        {
            using (var connection = GetSqlConnection(connectionStringName))
            {
                connection.Open();

                try
                {
                    return connection.Query
                        (query
                        , map: load
                        , param: parameters
                        , splitOn: string.Join(",", joins.Select(j => j.SplitOnColumnName)))
                        .ToList();
                }
                catch (DbException dbEx)
                {
                    LogSqlException(query, dbEx);
                    throw;
                }
                finally
                {
                    if (connection.State != ConnectionState.Closed)
                        connection.Close();
                }
            }
        }

        public virtual IList<ReturnType> Execute<ReturnType, JoinType, SecondJoinType>
            (string connectionStringName
            , string query
            , object parameters
            , IList<Join> joins
            , Func<dynamic, JoinType, SecondJoinType, ReturnType> load)
            where ReturnType : class
            where JoinType : class
            where SecondJoinType : class
        {
            using (var connection = GetSqlConnection(connectionStringName))
            {
                connection.Open();

                try
                {
                    return connection.Query
                        (query
                        , map: load
                        , param: parameters
                        , splitOn: string.Join(",", joins.Select(j => j.SplitOnColumnName)))
                        .ToList();
                }
                catch (DbException dbEx)
                {
                    LogSqlException(query, dbEx);
                    throw;
                }
                finally
                {
                    if (connection.State != ConnectionState.Closed)
                        connection.Close();
                }
            }
        }

        public virtual IList<ReturnType> Execute<ReturnType, JoinType, SecondJoinType, ThirdJoinType>
            (string connectionStringName
            , string query
            , object parameters
            , IList<Join> joins
            , Func<dynamic, JoinType, SecondJoinType, ThirdJoinType, ReturnType> load)
            where ReturnType : class
            where JoinType : class
            where SecondJoinType : class
            where ThirdJoinType : class
        {
            using (var connection = GetSqlConnection(connectionStringName))
            {
                connection.Open();

                try
                {
                    return connection.Query
                        (query
                        , map: load
                        , param: parameters
                        , splitOn: string.Join(",", joins.Select(j => j.SplitOnColumnName).ToArray()))
                        .ToList();
                }
                catch (DbException dbEx)
                {
                    LogSqlException(query, dbEx);
                    throw;
                }
                finally
                {
                    if (connection.State != ConnectionState.Closed)
                        connection.Close();
                }
            }
        }

        public virtual IList<ReturnType> Execute<ReturnType, JoinType, SecondJoinType, ThirdJoinType, FourthJoinType>
            (string connectionStringName
            , string query
            , object parameters
            , IList<Join> joins
            , Func<dynamic, JoinType, SecondJoinType, ThirdJoinType, FourthJoinType, ReturnType> load)
            where ReturnType : class
            where JoinType : class
            where SecondJoinType : class
            where ThirdJoinType : class
            where FourthJoinType : class
        {
            using (var connection = GetSqlConnection(connectionStringName))
            {
                connection.Open();

                try
                {
                    return connection.Query
                        (query
                        , map: load
                        , param: parameters
                        , splitOn: string.Join(",", joins.Select(j => j.SplitOnColumnName).ToArray()))
                        .ToList();
                }
                catch (DbException dbEx)
                {
                    LogSqlException(query, dbEx);
                    throw;
                }
                finally
                {
                    if (connection.State != ConnectionState.Closed)
                        connection.Close();
                }
            }
        }

        public virtual IList<ReturnType> Execute<ReturnType, JoinType, SecondJoinType, ThirdJoinType, FourthJoinType, FifthJoinType>
        (string connectionStringName
        , string query
        , object parameters
        , IList<Join> joins
        , Func<dynamic, JoinType, SecondJoinType, ThirdJoinType, FourthJoinType, FifthJoinType, ReturnType> load)
            where ReturnType : class
            where JoinType : class
            where SecondJoinType : class
            where ThirdJoinType : class
            where FourthJoinType : class
            where FifthJoinType : class
        {
            using (var connection = GetSqlConnection(connectionStringName))
            {
                connection.Open();

                try
                {
                    return connection.Query
                        (query
                        , map: load
                        , param: parameters
                        , splitOn: string.Join(",", joins.Select(j => j.SplitOnColumnName).ToArray()))
                        .ToList();
                }
                catch (SqlException sqlEx)
                {
                    LogSqlException(query, sqlEx);
                    throw;
                }
                finally
                {
                    if (connection.State != ConnectionState.Closed)
                        connection.Close();
                }
            }
        }

        public virtual IList<ReturnType> Execute<ReturnType, JoinType, SecondJoinType, ThirdJoinType, FourthJoinType, FifthJoinType, SixthJoinType>
        (string connectionStringName
        , string query
        , object parameters
        , IList<Join> joins
        , Func<dynamic, JoinType, SecondJoinType, ThirdJoinType, FourthJoinType, FifthJoinType, SixthJoinType, ReturnType> load)
            where ReturnType : class
            where JoinType : class
            where SecondJoinType : class
            where ThirdJoinType : class
            where FourthJoinType : class
            where FifthJoinType : class
            where SixthJoinType : class
        {
            using (var connection = GetSqlConnection(connectionStringName))
            {
                connection.Open();

                try
                {
                    return connection.Query
                        (query
                        , map: load
                        , param: parameters
                        , splitOn: string.Join(",", joins.Select(j => j.SplitOnColumnName).ToArray()))
                        .ToList();
                }
                catch (SqlException sqlEx)
                {
                    LogSqlException(query, sqlEx);
                    throw;
                }
                finally
                {
                    if (connection.State != ConnectionState.Closed)
                        connection.Close();
                }
            }
        }

        public virtual IList<ReturnType> Execute<ReturnType>(string connectionStringName, string query, object parms, Func<SqlMapper.GridReader, IList<ReturnType>> loader)
            where ReturnType : class
        {
            using (var connection = GetSqlConnection(connectionStringName))
            {
                connection.Open();

                try
                {
                    return loader(connection.QueryMultiple(query, parms));
                }
                catch (DbException dbEx)
                {
                    LogSqlException(query, dbEx);
                    throw;
                }
                finally
                {
                    if (connection.State != ConnectionState.Closed)
                        connection.Close();
                }
            }
        }

        public virtual int Execute(string connectionStringName, string sql, object parms)
        {
            using (var connection = GetSqlConnection(connectionStringName))
            {
                connection.Open();

                try
                {
                    return connection.Query(sql, parms).Count();
                }
                catch (DbException sqlEx)
                {
                    LogSqlException(sql, sqlEx);
                    throw;
                }
                finally
                {
                    if (connection.State != ConnectionState.Closed)
                        connection.Close();
                }
            }
        }

        public virtual int Execute<IdType>(string connectionStringName, string sql, object parms, Action<IList<IdType>> idSetter)
        {
            using (var connection = GetSqlConnection(connectionStringName))
            {
                connection.Open();

                try
                {
                    var ids = connection.Query<IdType>(sql, param: parms).ToList();

                    idSetter(ids);

                    return ids.Count;
                }
                catch (NotSupportedException nEx)
                {
                    LogException(sql, nEx);
                    throw;
                }
                catch (SqlTypeException sqlTex)
                {
                    LogSqlException(sql, sqlTex);
                    throw;
                }
                catch (SqlException sqlEx)
                {
                    LogSqlException(sql, sqlEx);
                    throw;
                }
                finally
                {
                    if (connection.State != ConnectionState.Closed)
                        connection.Close();
                }
            }
        }
    }
}
