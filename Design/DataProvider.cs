using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;

namespace Design
{
    class DataProvider
    {
        private static OleDbConnection con;
        private DataTable dt;
        //DataProvider()
        //{
        //    if (con == null)
        //    {
        //        con = new OleDbConnection();
        //        con.ConnectionString = @"Provider = Microsoft.Jet.Oledb.4.0; Data Source = C:\Users\Asus\Documents\Visual Studio 2017\Projects\managementApp\Design\Database.mdb";
        //    }
        //}

        public DataTable Get()
        {
            return dt;
        }

        public DataTable withQuery(string query)
        {
            create();


            OleDbCommand cmd = new OleDbCommand();
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            cmd.Connection = con;
            cmd.CommandText = query;
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
           //cmd.ExecuteNonQuery();
            da.Fill(dt);
            return dt;
        }
        public DataTable groupBy(string table, string field, string condition)
        {
            create();


            OleDbCommand cmd = new OleDbCommand();
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            cmd.Connection = con;
            if (string.IsNullOrEmpty(condition))
            {
                cmd.CommandText = $"select {field}, count(*) as counts from {table} group by {field}";
            }
            else
            {
                cmd.CommandText = $"select {field}, count(*) as counts from {table} where {condition} group by {field}";
            }

            OleDbDataAdapter da = new OleDbDataAdapter(cmd);

            da.Fill(dt);
            return dt;
        }

        public DataTable showAll(string table, string condition)
        {
            create();


            OleDbCommand cmd = new OleDbCommand();
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            cmd.Connection = con;
            if(string.IsNullOrEmpty(condition))
            {
                cmd.CommandText = $"select * from {table}";
            }
            else
            {
                
                cmd.CommandText = $"select * from {table} where {condition}";
            }
            cmd.ExecuteNonQuery();

            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            
            da.Fill(dt);
            return dt;
        }
        public DataTable showField(string table, string field, string condition)
        {
            create();

            OleDbCommand cmd = new OleDbCommand();
            if (con.State != ConnectionState.Open)
                con.Open();
            cmd.Connection = con;
            if (string.IsNullOrEmpty(condition))
            {
                cmd.CommandText = $"select {field} from {table}";

            }
            else
            {
                cmd.CommandText = $"select {field} from {table} where {condition}";
            }
            
            cmd.ExecuteNonQuery();

            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            
            
            da.Fill(dt);
            return dt;
        }
        public DataTable Search(string table, string searchStr)
        {
            create();


            OleDbCommand cmd = new OleDbCommand();
            if (con.State != ConnectionState.Open)
                con.Open();

            cmd.Connection = con;           
            cmd.CommandText = "select * from " + table + " where Deleted <> True and Name like '%" + searchStr + "%'";
            cmd.ExecuteNonQuery();

            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            
            da.Fill(dt);
            return dt;
        }
        public int CreateID(string table)
        {
            create();
            OleDbCommand cmd = new OleDbCommand();
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            cmd.Connection = con;
            cmd.CommandText = "select count(*) from " + table;

            Int32 count = (Int32)cmd.ExecuteScalar();
            cmd.ExecuteNonQuery();
            return count + 1;
        }

        public string Get(string table, string field, string condition)
        {
            create();
            OleDbCommand cmd = new OleDbCommand();
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            cmd.Connection = con;
            cmd.CommandText = $"select {field} from {table} where {condition}";

            string s = cmd.ExecuteScalar().ToString();
            cmd.ExecuteNonQuery();
            return s;
        }

        public void Add(string table, string value)
        {
            create();
            OleDbCommand cmd = new OleDbCommand();
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            cmd.Connection = con;
            cmd.CommandText = $"insert into {table} Values ({value})";
            //(ID, Name, Amount, Publisher, Category, PurchaseCost, SaleCost, Dated)
            cmd.ExecuteNonQuery();

        }

        public void Update(string table, string value, string condition)
        {
            create();
            OleDbCommand cmd = new OleDbCommand();
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            cmd.Connection = con;
            cmd.CommandText = $"update {table} set {value} where {condition}";
            cmd.ExecuteNonQuery();
        }
        public void deleteRow(string table, string ID)
        {
            create();

            OleDbCommand cmd = new OleDbCommand();
            if (con.State != ConnectionState.Open)
                con.Open();
            cmd.Connection = con;
            cmd.CommandText = "update " + table + " set Deleted = True where ID =" + ID;
            cmd.ExecuteNonQuery();
        }

        private void create()
        {
            if (con == null)
            {
                con = new OleDbConnection();
                con.ConnectionString = @"Provider = Microsoft.Jet.Oledb.4.0; Data Source = "+ System.AppDomain.CurrentDomain.BaseDirectory + @"\Database.mdb";
                
            }
            if (dt == null)
                dt = new DataTable();
            else
                dt.Clear();
        }
        public void close()
        {
            con.Close();
            dt.Clear();
        }
    }
}
