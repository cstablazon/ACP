using System;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace ACP
{
    public class CatHierarchyClass
    {   
        dbClass db = new dbClass();
        public static string code = "",rid = "";
        //Fetch the record from the database
        public DataTable fetchCatHierarchy()
        {
            return db.getRecord("sp_catHierarchy 'FETCHDATA'");
        }
        public DataTable fetchDepartment()
        {
            return db.getRecord("sp_catHierarchy 'fetchDepartment'");
        }
        public DataTable removeCategory()
        {
            return db.getRecord("sp_catHierarchy 'DELETECAT','','" + Id.RID + "'");
        }
        public DataTable fetchRecord(string code)
        {
            return db.getRecord("sp_catHierarchy 'FETCHRECORD', '','"+code+"'");
        }
        public DataTable CheckRecord(string code, string rid)
        {
            return db.getRecord("SELECT code,RID from vwCatHierarchy WHERE code = '" + code + "' AND RID != '" + rid + "'");
        }

        public long autoIncrementRid()
        {
            long autoID = 0;
            SqlConnection conn = db.getConnection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("sp_autoInc 'Hierarchy'", conn);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    autoID = Convert.ToInt64(reader["ID"]);
                }
            }

            conn.Close();
            return autoID;
        }
       public void CatHierarchyCrud(string rid, string code, string desc, string rtype,int status, string code2)
       {
           try
           {
               SqlConnection conn = db.getConnection();
               conn.Open();
               SqlCommand cmd = new SqlCommand("sp_catHierarchy", conn);
               cmd.CommandType = CommandType.StoredProcedure;
               cmd.Parameters.AddWithValue("@Action", "CRUD");
               cmd.Parameters.AddWithValue("@Code", code);
               cmd.Parameters.AddWithValue("@Rid", rid);
               cmd.Parameters.AddWithValue("@Desc", desc);
               cmd.Parameters.AddWithValue("@rtype", rtype);
               cmd.Parameters.AddWithValue("@process", "WI");
               cmd.Parameters.AddWithValue("@status", status);
               cmd.Parameters.AddWithValue("@Code2", code2);
               string message = cmd.ExecuteScalar().ToString();
               conn.Close();
               MessageBox.Show(message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
           }
           catch (Exception ex)
           {
               MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
           }
          
       }
      
    }
}
