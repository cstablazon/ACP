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

        public DataTable fetchCategoryHierarchy(string sp, string tableName, string action, long? RID, string code)
        {
            return db.fetchCategoryHierarchy(sp, tableName, action, RID, code);
        }

        public DataTable fetchProductLine(string sp, string tableName, string action, string suppID, string code)
        {
            return db.fetchProductLine(sp, tableName, action, suppID, code);
        }

        public DataTable fetchPOline(string sp, string tableName, string action, string orderNo)
        {
            return db.fetchPOline(sp, tableName, action, orderNo);
        }

//CRUD
        public void createUpdatePurchaseOrder(string action, string orderNo, string poType, int modID, string poolID, decimal? seasonalDiscount, int delAddressID, DateTime? deliveryDate, DateTime? cancelDate, string status, string remarks, int? userID)
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
            cmd.Parameters.AddWithValue("@seasonalDiscount", seasonalDiscount);
            cmd.Parameters.AddWithValue("@delAddressID", delAddressID);
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

        public void deletePO(string sp, string action, string orderNo)
        {
            SqlConnection conn = db.getConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand(sp, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", action);
            cmd.Parameters.AddWithValue("@orderNo", orderNo);

            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void createUpdatePesoDiscount(string action, int? PDID, string orderNo, decimal pesoDisc, decimal priceUnit, int? userID)
        {
            SqlConnection conn = db.getConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("sp_pesoDiscount", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", action);
            cmd.Parameters.AddWithValue("@PDID", PDID);
            cmd.Parameters.AddWithValue("@orderNo", orderNo);
            cmd.Parameters.AddWithValue("@pesoDisc", pesoDisc);
            cmd.Parameters.AddWithValue("@priceUnit", priceUnit);
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

        public void createUpdatePOlines(string action, string orderNo, string barcode, decimal qty, int? userID)
        {
            SqlConnection conn = db.getConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("sp_POlines", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", action);
            cmd.Parameters.AddWithValue("@orderNo", orderNo);
            cmd.Parameters.AddWithValue("@barcode", barcode);
            cmd.Parameters.AddWithValue("@qty", qty);
            cmd.Parameters.AddWithValue("@userID", userID);

            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void deletePOline(string sp, string tableName, string action, long lineID)
        {
            SqlConnection conn = db.getConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand(sp, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@tableName", tableName);
            cmd.Parameters.AddWithValue("@action", action);
            cmd.Parameters.AddWithValue("@lineID", lineID);

            cmd.ExecuteNonQuery();
            conn.Close();
        }
//END of CRUD
    }
}
