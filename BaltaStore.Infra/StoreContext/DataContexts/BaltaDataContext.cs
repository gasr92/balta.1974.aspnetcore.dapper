using System;
using System.Data;
using BaltaStore.Shared;
using Microsoft.Data.SqlClient;

namespace BaltaStore.Infra.StoreContext.DataContexts
{
    public class BaltaDataContext : IDisposable
    {
        public SqlConnection Connection {get;set;}

        public BaltaDataContext()
        {
            this.Connection = new SqlConnection(Settings.ConnectionString);
            this.Connection.Open();
        }

        public void Dispose()
        {
            if(this.Connection.State != ConnectionState.Closed)
            this.Connection.Close();
        }
    }
}