using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System;

namespace ACP
{
    public class dbClass
    {
        private string ConnectionString = Properties.Settings.Default.connectionDB;
        AutoCompleteStringCollection data;
        DataTable dt;
        DataSet ds;
        public SqlConnection getConnection()
        {
            System.Data.SqlClient.SqlConnection conn = new SqlConnection(ConnectionString);
            return conn;
        }

//Authenticate user login form
        public DataTable authenticateUser(string query, string username, string password)
        {
            SqlConnection conn = getConnection();
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            dt.Columns.Add("userID", typeof(int));
            dt.Columns.Add("username", typeof(string));
            dt.Columns.Add("password", typeof(string));
            dt.Columns.Add("authID", typeof(int));
            dt.Columns.Add("authDesc", typeof(string));
            dt.Columns.Add("RID", typeof(string));
            dt.Columns.Add("firstname", typeof(string));
            dt.Columns.Add("mi", typeof(string));
            dt.Columns.Add("lastname", typeof(string));
            dt.Columns.Add("suffix", typeof(string));
            dt.Columns.Add("isActive", typeof(bool));
            dt.Columns.Add("transDate", typeof(DateTime));
            sda.Fill(dt);

            return dt;
        }
//Retreive for supplier data
        public DataTable fetchRecordsForSupplier(string query, string tableName, string action, string suppID, string RID, string distriID, string name, string itemTaxID)
        {
            SqlConnection conn = getConnection();
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@tableName", tableName);
            cmd.Parameters.AddWithValue("@action", action);
            cmd.Parameters.AddWithValue("@suppID", suppID);
            cmd.Parameters.AddWithValue("@RID", RID);
            cmd.Parameters.AddWithValue("@distriID", distriID);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@itemTaxID", itemTaxID);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);


            return dt;
        }

//Retreive for product data
        public DataTable fetchComponentSetup(string query, string action)
        {
            SqlConnection conn = getConnection();
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", action);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);


            return dt;
        }

        public DataTable fetchRecordsForProduct(string query, string tableName, string action, string columnValue)
        {
            SqlConnection conn = getConnection();
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@tableName", tableName);
            cmd.Parameters.AddWithValue("@action", action);
            cmd.Parameters.AddWithValue(Id.columnName, columnValue);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);


            return dt;
        }

        public DataTable fetchBarcodeById(string query, string tableName, string action, string barcode)
        {
            SqlConnection conn = getConnection();
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@tableName", tableName);
            cmd.Parameters.AddWithValue("@action", action);
            cmd.Parameters.AddWithValue("@barcode", barcode);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);


            return dt;
        }

        public DataTable fetch(string query, string tableName, string action)
        {
            SqlConnection conn = getConnection();
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@tableName", tableName);
            cmd.Parameters.AddWithValue("@action", action);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);


            return dt;
        }

        public DataTable fetchRecords(string query, string tableName, string action)
        {
            SqlConnection conn = getConnection();
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@tableName", tableName);
            cmd.Parameters.AddWithValue("@action", action);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);


            return dt;
        }
        public DataTable fetchCategoryHierarchy(string query, string tableName, string action, long? RID, string code)
        {
            SqlConnection conn = getConnection();
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@tableName", tableName);
            cmd.Parameters.AddWithValue("@action", action);
            cmd.Parameters.AddWithValue("@RID", RID);
            cmd.Parameters.AddWithValue("@code", code);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);


            return dt;
        }

//Fetch product lines for purchase order based on department search
        public DataTable fetchProductLine(string query, string tableName, string action, string suppID, string code)
        {
            SqlConnection conn = getConnection();
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@tableName", tableName);
            cmd.Parameters.AddWithValue("@action", action);
            cmd.Parameters.AddWithValue("@suppID", suppID);
            cmd.Parameters.AddWithValue("@code", code);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);


            return dt;
        }

        public DataTable fetchProductLine2(string query, string tableName, string action, string suppID, string barcode)
        {
            SqlConnection conn = getConnection();
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@tableName", tableName);
            cmd.Parameters.AddWithValue("@action", action);
            cmd.Parameters.AddWithValue("@suppID", suppID);
            cmd.Parameters.AddWithValue("@barcode", barcode);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);


            return dt;
        }
//Fetch PO lines based on order no
        public DataTable fetchPOline(string query, string tableName, string action, string orderNo)
        {
            SqlConnection conn = getConnection();
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@tableName", tableName);
            cmd.Parameters.AddWithValue("@action", action);
            cmd.Parameters.AddWithValue("@orderNo", orderNo);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);


            return dt;
        }

        public DataTable fetchPOlineByBarcodeAndOrderNo(string query, string tableName, string action, string barcode, string orderNo)
        {
            SqlConnection conn = getConnection();
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@tableName", tableName);
            cmd.Parameters.AddWithValue("@action", action);
            cmd.Parameters.AddWithValue("@barcode", barcode);
            cmd.Parameters.AddWithValue("@orderNo", orderNo);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);


            return dt;
        }

        public DataTable fetchRecordForDepartment(string query, string action, long? RID)
        {
            SqlConnection conn = getConnection();
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", action);
            cmd.Parameters.AddWithValue("@RID", RID);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);


            return dt;
        }


//Retreive for supplier setup data
        public DataTable fetchSupplierSetup()
        {

            return dt;
        }

        //public DataTable fetchAddressRecords(string query, string tableName, string action, int addressID)
        //{
        //    SqlConnection conn = getConnection();
        //    SqlCommand cmd = new SqlCommand(query, conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@tableName", tableName);
        //    cmd.Parameters.AddWithValue("@action", action);
        //    cmd.Parameters.AddWithValue("@addressID", addressID);
        //    SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //    dt = new DataTable();
        //    sda.Fill(dt);

        //    return dt;
        //}














//WALA GINA GAMIT// NEED CHECK
        public DataTable fetchRecord(string query, string action, string suppID)
        {
            SqlConnection conn = getConnection();
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", action);
            cmd.Parameters.AddWithValue("@suppID", suppID);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);

            return dt;
        }

        public DataTable getRecord(string query) {
            //fetch all record
            try{
                SqlConnection conn = getConnection();
                SqlCommand cmd = new SqlCommand(query,conn);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dt;
        }


        //fetch all product and tables connected/ linked to it
        public DataTable getRecords(string query, string action, string desc, string desc2, string desc3, string desc4, string desc5, string desc6, string desc7)
        {
            //fetch all record
            //try{
            SqlConnection conn = getConnection();
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", action);
            cmd.Parameters.AddWithValue("@desc", desc);
            cmd.Parameters.AddWithValue(Id.desc2, desc2);
            cmd.Parameters.AddWithValue(Id.desc3, desc3);
            cmd.Parameters.AddWithValue(Id.desc4, desc4);
            cmd.Parameters.AddWithValue(Id.desc5, desc5);
            cmd.Parameters.AddWithValue(Id.desc6, desc6);
            cmd.Parameters.AddWithValue(Id.desc7, desc7);
            SqlDataAdapter adt = new SqlDataAdapter(cmd);
            dt = new DataTable();
            adt.Fill(dt);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            return dt;
        }

        public int autoIncrement(string query)
        {
            int currentMaxValue = 0;
            try
            {
                SqlConnection conn = getConnection();
                conn.Open();
                SqlCommand command = new SqlCommand(query, conn);
                currentMaxValue = Convert.ToInt32(command.ExecuteScalar());
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return currentMaxValue + 1;
        }

        public long auto_Increment(string query)
        {
            long currentMaxValue = 0;
            try
            {
                SqlConnection conn = getConnection();
                conn.Open();
                SqlCommand command = new SqlCommand(query, conn);
                currentMaxValue = Convert.ToInt64(command.ExecuteScalar());
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return (int)(currentMaxValue + 1);
        }


        

        public DataSet cbRecords(string query, string tableName, string action, string dss)
        {
            //Use this for fetching all records in the combobox. 
            try
            {
                SqlConnection conn = getConnection();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@tableName", tableName);
                cmd.Parameters.AddWithValue("@action", action);
                SqlDataAdapter adt = new SqlDataAdapter(cmd);
                ds = new DataSet();
                adt.Fill(ds, dss);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return ds;
        }


        //Remake
        public DataSet cbRecord(string query, string action, string desc, string dss)
        {
            //Use this for fetching all records in the combobox. 
            try
            {
                SqlConnection conn = getConnection();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", action);
                cmd.Parameters.AddWithValue("@desc", desc);
                SqlDataAdapter adt = new SqlDataAdapter(cmd);
                ds = new DataSet();
                adt.Fill(ds, dss);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return ds;
        }

        //Autocomplete comboBox
        public AutoCompleteStringCollection cbAutoComplete(string query, string action, string desc, string dss)
        {
            
            try
            {
                SqlConnection conn = getConnection();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", action);
                cmd.Parameters.AddWithValue("@desc", desc);
                SqlDataAdapter adt = new SqlDataAdapter(cmd);
                ds = new DataSet();
                adt.Fill(ds, dss);
                conn.Close();
                conn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                data = new AutoCompleteStringCollection();
                while (reader.Read())
                {
                    data.Add(reader[dss].ToString());
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return data;
        }
    }
}
