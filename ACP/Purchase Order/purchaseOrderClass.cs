using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACP
{
    class purchaseOrderClass
    {
        dbClass db = new dbClass();

//Combobox datasource
        public DataSet cbRecords(string tableName, string action, string dss)
        {
            return db.cbRecords("sp_purchaseOrderOperations", tableName, action, dss);
        }
//Retreive
        public DataTable fetchRecords(string sp, string tableName, string action)
        {
            return db.fetchRecords(sp, tableName, action);
        }

//CRUD
        public void createUpdatePurchaseOrder(string action, string orderNo, string poType, int modID, string poolID, int delAddressID, int? discountID, DateTime? deliveryDate, DateTime? cancelDate, string status, string remarks, int? userID)
        {
            SqlConnection conn = db.getConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("sp_purchaseOrder", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", action);
            cmd.Parameters.AddWithValue("@orderNo", orderNo);
            cmd.Parameters.AddWithValue("@poType", poType);
            cmd.Parameters.AddWithValue("@modID", modID);
            cmd.Parameters.AddWithValue("@poolID", poolID);
            cmd.Parameters.AddWithValue("@delAddressID", delAddressID);
            cmd.Parameters.AddWithValue("@discountID", discountID);
            cmd.Parameters.AddWithValue("@deliveryDate", deliveryDate);
            cmd.Parameters.AddWithValue("@cancelDate", cancelDate);
            cmd.Parameters.AddWithValue("@status", status);
            cmd.Parameters.AddWithValue("@remarks", remarks);
            cmd.Parameters.AddWithValue("@userID", userID);

            var returnPara = cmd.Parameters.Add("@autoIncSKU", SqlDbType.NVarChar);
            if (Id.button == "Create")
            {
                returnPara.Direction = ParameterDirection.ReturnValue;
            }
            cmd.ExecuteNonQuery();
            if (Id.button == "Create")
            {
                Id.autoIncOrderNo = returnPara.Value.ToString();
            }
            conn.Close();
        }
//END of CRUD
    }
}
