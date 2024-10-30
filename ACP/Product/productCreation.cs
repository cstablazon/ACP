using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ACP
{
    class productCreation
    {
        dbClass db = new dbClass();
        DataTable dt;
        string printOutput;
        public int autoIncrementID(string columnID, string table)
        {
            int currentMaxValue = 0;
            currentMaxValue = db.autoIncrement("SELECT ISNULL(MAX(CAST(" + columnID + " as int)),0) FROM " + table + "");
            return currentMaxValue;
            
        }

        public int autoInc(string columnID, string table)
        {
            int currentMaxValue = 0;
            currentMaxValue = db.autoIncrement("SELECT ISNULL(MAX(CAST(" + columnID + " as int)),0) FROM " + table + "");
            return currentMaxValue;
        }
//Combobox datasource
        public DataSet cbRecords(string query, string tableName, string action, string dss)
        {
            return db.cbRecords(query, tableName, action, dss);
        }
//Fetch by Id
        public DataTable fetchRecordById(string sp, string tableName, string action, string columnValue)
        {
            return db.fetchRecordsForProduct(sp, tableName, action, columnValue);
        }

        public DataTable fetchBarcodeById(string sp, string tableName, string action, string barcode)
        {
            return db.fetchBarcodeById(sp, tableName, action, barcode);
        }

//Retreive
        public DataTable fetchRecords(string sp, string tableName, string action, string SKU)
        {
            return db.fetchRecordsForProduct(sp, tableName, action, SKU);
        }

        public DataTable fetch(string sp, string tableName, string action)
        {
            return db.fetch(sp, tableName, action);
        }

        public DataTable fetchComponentSetup(string sp, string action)
        {
            return db.fetchComponentSetup(sp, action);
        }
//Department hierarchy
        public DataTable fetchDept(string sp, string action, long? RID)
        {
            return db.fetchRecordForDepartment(sp, action, RID);
        }
//CRUD
    //Product CRUD
        public void createUpdateProduct(string action, string SKU, string @SKUtoBeUpdated, long? RID, int prodTypeID, int prodSubTypeID, string suppID, int? brandID, string pDimension, string itemDesc, bool isConcession, int? userID)
        {
            SqlConnection conn = db.getConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("sp_productCreation", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", action);
            cmd.Parameters.AddWithValue("@SKU", SKU);
            cmd.Parameters.AddWithValue("@SKUtoBeUpdated", @SKUtoBeUpdated);
            cmd.Parameters.AddWithValue("@RID", RID);
            cmd.Parameters.AddWithValue("@prodTypeID", prodTypeID);
            cmd.Parameters.AddWithValue("@prodSubTypeID", prodSubTypeID);
            cmd.Parameters.AddWithValue("@suppID", suppID);
            cmd.Parameters.AddWithValue("@brandID", brandID);
            cmd.Parameters.AddWithValue("@pDimension", pDimension);
            cmd.Parameters.AddWithValue("@itemDesc", itemDesc);
            cmd.Parameters.AddWithValue("@isConcession", isConcession);
            cmd.Parameters.AddWithValue("@userID", userID);


            
            if (Id.button == "Create")
            {
                var returnPara = cmd.Parameters.Add("@autoIncSKU", SqlDbType.NVarChar);
                returnPara.Direction = ParameterDirection.ReturnValue;
                cmd.ExecuteNonQuery();
                Id.autoIncSKU = returnPara.Value.ToString();
            }
            cmd.ExecuteNonQuery();
            conn.Close();
            
        }

        public void deleteProduct(string sp, string tableName, string action, string SKU)
        {
            SqlConnection conn = db.getConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand(sp, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@tableName", tableName);
            cmd.Parameters.AddWithValue("@action", action);
            cmd.Parameters.AddWithValue("@SKU", SKU);

            cmd.ExecuteNonQuery();
            conn.Close();
        }
    //End of product CRUD

    //Barcode CRUD
        public void createUpdateBarcode(string action, string barcode, string SKU, string itemModelID, int? chargeID, long? PID, long? bmrxID, string LID, int? discountID, int? CPuomID, int? RPuomID, int? bomID, decimal? factor, decimal? retailPrice, decimal? costPrice, decimal? inventoryCost, string posDesc, string salesTax, string purchaseTax, bool? isDiscountable, bool isActive, int? userID, string parameter)
        {
            SqlConnection conn = db.getConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("sp_productDetails", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", action);
            cmd.Parameters.AddWithValue("@barcodeTobeUpdated", barcode);
            cmd.Parameters.AddWithValue("@SKU", SKU);
            cmd.Parameters.AddWithValue("@itemModelID", itemModelID);
            cmd.Parameters.AddWithValue("@chargeID", chargeID);
            cmd.Parameters.AddWithValue("@PID", PID);
            cmd.Parameters.AddWithValue("@bmrxID", bmrxID);
            cmd.Parameters.AddWithValue("@LID", LID);
            cmd.Parameters.AddWithValue("@discountID", discountID);
            cmd.Parameters.AddWithValue("@CPuomID", CPuomID);
            cmd.Parameters.AddWithValue("@RPuomID", RPuomID);
            cmd.Parameters.AddWithValue("@bomID", bomID);
            cmd.Parameters.AddWithValue("@factor", factor);
            cmd.Parameters.AddWithValue("@retailPrice", retailPrice);
            cmd.Parameters.AddWithValue("@costPrice", costPrice);
            cmd.Parameters.AddWithValue("@inventoryCost", inventoryCost);
            cmd.Parameters.AddWithValue("@posDesc", posDesc);
            cmd.Parameters.AddWithValue("@salesTax", salesTax);
            cmd.Parameters.AddWithValue("@purchaseTax", purchaseTax);
            cmd.Parameters.AddWithValue("@isDiscountable", isDiscountable);
            cmd.Parameters.AddWithValue("@isActive", isActive);
            cmd.Parameters.AddWithValue("@userID", userID);
            cmd.Parameters.AddWithValue("@barcode", parameter);

            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void deleteBarcode(string sp, string tableName, string action, string Barcode)
        {
            SqlConnection conn = db.getConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand(sp, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@tableName", tableName);
            cmd.Parameters.AddWithValue("@action", action);
            cmd.Parameters.AddWithValue("@Barcode", Barcode);

            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void deleteBarcodeBySKU(string sp, string tableName, string action, string SKU)
        {
            SqlConnection conn = db.getConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand(sp, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@tableName", tableName);
            cmd.Parameters.AddWithValue("@action", action);
            cmd.Parameters.AddWithValue("@SKU", SKU);

            cmd.ExecuteNonQuery();
            conn.Close();
        }
    //End of barcode CRUD

    //Brand CRUD
        public void createUpdateBrand(string tableName, string action, int? brandID, string bDesc, int? userID)
        {
            SqlConnection conn = db.getConnection();
            conn.InfoMessage += (object obj, SqlInfoMessageEventArgs e) =>
            {
                printOutput += e.Message;
            };
            conn.Open();
            SqlCommand cmd = new SqlCommand("sp_Product", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@tableName", tableName);
            cmd.Parameters.AddWithValue("@action", action);
            cmd.Parameters.AddWithValue("@brandID", brandID);
            cmd.Parameters.AddWithValue("@bDesc", bDesc);
            cmd.Parameters.AddWithValue("@userID", userID);

            cmd.ExecuteNonQuery();
            MessageBox.Show(printOutput, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            printOutput = "";
            conn.Close();
        }

        public void deleteBrand(string tableName, string action, int brandID)
        {
            SqlConnection conn = db.getConnection();
            conn.InfoMessage += (object obj, SqlInfoMessageEventArgs e) =>
            {
                printOutput += e.Message;
            };
            conn.Open();
            SqlCommand cmd = new SqlCommand("sp_Supplier", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@tableName", tableName);
            cmd.Parameters.AddWithValue("@action", action);
            cmd.Parameters.AddWithValue("@brandID", brandID);

            cmd.ExecuteNonQuery();
            MessageBox.Show(printOutput, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            printOutput = "";
            conn.Close();
        }
    //End of brand CRUD

    //Kit component setup CRUD
        public void createUpdateComponent(string action, int kitID, string masterBarcode, string prodBarcode, decimal qty, int? userID)
        {
            SqlConnection conn = db.getConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("sp_componentSetup", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", action);
            cmd.Parameters.AddWithValue("@kitID", kitID);
            cmd.Parameters.AddWithValue("@masterBarcode", masterBarcode);
            cmd.Parameters.AddWithValue("@prodBarcode", prodBarcode);
            cmd.Parameters.AddWithValue("@qty", qty);
            cmd.Parameters.AddWithValue("@userID", userID);

            cmd.ExecuteNonQuery();
            conn.Close();
        }
    //End of component setup CRUD

    //product_subType CRUD
        public void createUpdateProduct_subType(string action, int? prodSubTypeID, string prodSubTypeDesc, int? userID)
        {
            SqlConnection conn = db.getConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("sp_prodSubType", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", action);
            cmd.Parameters.AddWithValue("@prodSubTypeID", prodSubTypeID);
            cmd.Parameters.AddWithValue("@prodSubTypeDesc", prodSubTypeDesc);
            cmd.Parameters.AddWithValue("@userID", userID);

            cmd.ExecuteNonQuery();
            conn.Close();
        }
    //END of product_subType CRUD
//End of CRUD
    }
}
