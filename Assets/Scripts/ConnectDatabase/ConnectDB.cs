using UnityEngine;
using System.Collections;
using Mono.Data.Sqlite;
using System.Data;
using UnityEngine.SceneManagement;
using System;

namespace Assets
{
    public class ConnectDB
    {
        string conn = "URI=file:" + Application.dataPath + "/Database/MathForKids.s3db"; //Path to database.
        IDbConnection dbconn;
        IDbCommand dbcmd;

        public ConnectDB()
        {
            dbconn = (IDbConnection)new SqliteConnection(conn);
            dbcmd = dbconn.CreateCommand();
        }
        public void Open()
        {
            dbconn.Open(); //Open connection to the database.
        }

        public IDataReader getData(string sql)
        {
            try
            {
                dbcmd.CommandText = sql;
                IDataReader reader = dbcmd.ExecuteReader();
                return reader;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public bool setData(string sql)
        {
            try
            {
                dbcmd.CommandText = sql;
                IDataReader reader = dbcmd.ExecuteReader();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public void Close()
        {
            dbcmd.Dispose();
            dbcmd = null;
            dbconn.Close();
            dbconn = null;
        }

    }
}
