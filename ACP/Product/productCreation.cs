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
        public DataSet cbRecords(string tableName, string action, string dss)
        {
            return db.cbRecords("sp_Product", tableName, action, dss);
        }
//Fetch by Id
        public DataTable fetchRecordById(string sp, string tableName, string action, string columnValue)
        {
            return db.fetchRecordsForProduct(sp, tableName, action, columnValue);
        }

//Retreive
        public DataTable fetchRecords(string sp, string tableName, string action, string SKU)
        {
            return db.fetchRecordsForProduct(sp, tableName, action, SKU);
        }

        public DataTable fetch(string sp, string tableName, string action)
        {
            return db.fetchRecords(sp, tableName, action);
        }

        public DataTable fetchComponentSetup(string sp, string action)
        {
            return db.fetchComponentSetup(sp, action);
        }
//Department hierarchy
        public DataTable fetchDept(string sp, string tableName, string action, long RID)
        {
            return db.fetchRecordForDepartment(sp, tableName, action, RID);
        }
//CRUD
    //Product CRUD
        public void createUpdateProduct(string action, string SKU, string @SKUtoBeUpdated, long RID, int prodTypeID, int prodSubTypeID, string suppID, int? brandID, string pDimension, string itemDesc, bool isConcession, int? userID)
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

            var returnPara = cmd.Parameters.Add("@autoIncSKU", SqlDbType.NVarChar);
            if (Id.button == "Create")
            {
                returnPara.Direction = ParameterDirection.ReturnValue;
            }
            cmd.ExecuteNonQuery();
            if (Id.button == "Create")
            {
                Id.autoIncSKU = returnPara.Value.ToString();
            }
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
//End of CRUD

















//WALA GINA GAMIT!!
        //Datasets for comboBox
        public DataSet fetchData(string action, string desc, string dss)
        {
            return db.cbRecord("sp_Product", action, desc, dss);
        }
        public DataSet fetchSupplierId(string action, string desc, string dss)
        {
            return db.cbRecord("sp_Supplier", action, desc, dss);
        }
        public DataSet fetchCatHierarchy(string action, string desc, string dss)
        {
            return db.cbRecord("sp_catHierarchy", action, desc, dss);
        }
        
        //public DataTable productList()
        //{
        //    //return db.getRecord("select * from vwProduct");
        //}
        //autoComplete comboBox
        public AutoCompleteStringCollection fetchAutoComplete(string sp, string action, string desc, string dss)
        {
            return db.cbAutoComplete(sp, action, desc, dss);
        }

        public AutoCompleteStringCollection autoCompleteBrand(string sp, string action, string desc, string dss)
        {
            return db.cbAutoComplete(sp, action, desc, dss);
        }

        //get all product and tables connected/ linked connected to it and validation for create and update if desc is already exist
        public DataTable fetchRecord(string action, string desc, string desc2, string desc3, string desc4, string desc5, string desc6, string desc7)
            //(string action, string desc, string sdID, string sdDesc, string itemID, string itemDesc, string tdID, string tdDesc)
        {
            return db.getRecords("sp_Product", action, desc, desc2, desc3, desc4, desc5, desc6, desc7);
        }

        //Insert, update, delete of product and tables connected / linked to it
        public void modifyProduct(string action, string desc, string desc2, string desc3, string desc4, string desc5, string desc6, string desc7, string desc8, string desc9, string desc10, string desc11, string desc12, string desc13, string desc14, string desc15, string desc16, string desc17, string desc18, string desc19, string desc20, string desc21, string desc22, string desc23, string desc24, string desc25, int desc26, int desc27, int desc28, int desc29)
          
        {
            //try
            //{
                SqlConnection conn = db.getConnection();
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_Product", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", action);
                cmd.Parameters.AddWithValue("@desc", desc);
                cmd.Parameters.AddWithValue(Id.desc2, desc2);
                cmd.Parameters.AddWithValue(Id.desc3, desc3);
                cmd.Parameters.AddWithValue(Id.desc4, desc4);
                cmd.Parameters.AddWithValue(Id.desc5, desc5);
                cmd.Parameters.AddWithValue(Id.desc6, desc6);
                cmd.Parameters.AddWithValue(Id.desc7, desc7);
                cmd.Parameters.AddWithValue(Id.desc8, desc8);
                cmd.Parameters.AddWithValue(Id.desc9, desc9);
                cmd.Parameters.AddWithValue(Id.desc10, desc10);
                cmd.Parameters.AddWithValue(Id.desc11, desc11);
                cmd.Parameters.AddWithValue(Id.desc12, desc12);
                cmd.Parameters.AddWithValue(Id.desc13, desc13);
                cmd.Parameters.AddWithValue(Id.desc14, desc14);
                cmd.Parameters.AddWithValue(Id.desc15, desc15);
                cmd.Parameters.AddWithValue(Id.desc16, desc16);
                cmd.Parameters.AddWithValue(Id.desc17, desc17);
                cmd.Parameters.AddWithValue(Id.desc18, desc18);
                cmd.Parameters.AddWithValue(Id.desc19, desc19);
                cmd.Parameters.AddWithValue(Id.desc20, desc20);
                cmd.Parameters.AddWithValue(Id.desc21, desc21);
                cmd.Parameters.AddWithValue(Id.desc22, desc22);
                cmd.Parameters.AddWithValue(Id.desc23, desc23);
                cmd.Parameters.AddWithValue(Id.desc24, desc24);
                cmd.Parameters.AddWithValue(Id.desc25, desc25);
                cmd.Parameters.AddWithValue(Id.desc26, desc26);
                cmd.Parameters.AddWithValue(Id.desc27, desc27);
                cmd.Parameters.AddWithValue(Id.desc28, desc28);
                cmd.Parameters.AddWithValue(Id.desc29, desc29);
               
                cmd.ExecuteNonQuery();
               // conn.Close();
                //MessageBox.Show("Successfully Modified", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

             //   string message = cmd.ExecuteScalar().ToString();
                conn.Close();
             //   MessageBox.Show(message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        

        //public int itemModelID()
        //{
        //    int currentMaxValue = 0;
        //    currentMaxValue = db.autoIncrement("SELECT ISNULL(MAX(itemModelID), 0) FROM itemModelGroup");
        //    return currentMaxValue;
        //}
        //public int sdGroupID()
        //{
        //    int currentMaxValue = 0;
        //    currentMaxValue = db.autoIncrement("SELECT ISNULL(MAX(tdGroupID), 0) FROM trackingDmnsnGroup");
        //    return currentMaxValue;
        //}
        //public int sdGroupID()
        //{
        //    int currentMaxValue = 0;
        //    currentMaxValue = db.autoIncrement("SELECT ISNULL(MAX(rsrvID), 0) FROM rsrvtnHierarchy");
        //    return currentMaxValue;
        //}

        public void insertbarcode(string barcode, string sku, int prodtype, int prodSub, string rid, int cpuomID, int rpuomID, int retail, int costPrice, string posDesc, string saleTax, string purchaseTax, string bmrx)
        {
            SqlConnection conn = db.getConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("sp_Product", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "CRUD");
            cmd.Parameters.AddWithValue("@Id", "");
            cmd.Parameters.AddWithValue("@desc", "BARCODE");
            cmd.Parameters.AddWithValue("@barcode", barcode);
            cmd.Parameters.AddWithValue("@SKU", sku);
            cmd.Parameters.AddWithValue("@prodTypeID", prodtype);
            cmd.Parameters.AddWithValue("@prodSubTypeID", prodSub);
            cmd.Parameters.AddWithValue("@RID", rid);
            cmd.Parameters.AddWithValue("@CPuomID", cpuomID);
            cmd.Parameters.AddWithValue("@RPuomID", rpuomID);
            cmd.Parameters.AddWithValue("@retailPrice", retail);
            cmd.Parameters.AddWithValue("@costPrice", costPrice);
            cmd.Parameters.AddWithValue("@posDesc", posDesc);
            cmd.Parameters.AddWithValue("@salesTax", saleTax);
            cmd.Parameters.AddWithValue("@purchaseTax", purchaseTax);
            cmd.Parameters.AddWithValue("@bmrx", bmrx);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
