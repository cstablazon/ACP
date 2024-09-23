using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace ACP
{
    public class supplierClass
    {
        dbClass db = new dbClass();
        private string ConnectionString = Properties.Settings.Default.connectionDB;
        string printOutput;
        public SqlConnection getConnection()
        {
            System.Data.SqlClient.SqlConnection conn = new SqlConnection(ConnectionString);
            return conn;
        }

        public int autoIncrementID(string columnID, string table)
        {
            int currentMaxValue = 0;
            currentMaxValue = db.autoIncrement("SELECT ISNULL(MAX(CAST(" + columnID + " as int)),0) FROM " + table + " WHERE isDistributor = 0");
            return currentMaxValue;
        }
        //insert and update supplier records
        public void insertSupplier(string suppID, string payID, string sGroup, string name, string agent, string rtype, string fn, string mn, string ln, string suffix, string gender, string dob, string status)
        {
            try
            {
                SqlConnection conn = db.getConnection();
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_Supplier", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                //organization directory
                cmd.Parameters.AddWithValue("@desc", "SUPPLIER");
                cmd.Parameters.AddWithValue("@Id", "");
                cmd.Parameters.AddWithValue("@action", "CRUD");
                cmd.Parameters.AddWithValue("@suppID", suppID);
                cmd.Parameters.AddWithValue("@payID", payID);
                cmd.Parameters.AddWithValue("@sGroupID", sGroup);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@agent", agent);
                cmd.Parameters.AddWithValue("@rType", rtype);
                cmd.Parameters.AddWithValue("@isActive", "1");

                //person directory
                cmd.Parameters.AddWithValue("@TID", suppID);
                cmd.Parameters.AddWithValue("@firstname", fn);
                cmd.Parameters.AddWithValue("@middlename", mn);
                cmd.Parameters.AddWithValue("@lastname", ln);
                cmd.Parameters.AddWithValue("@suffix", suffix);
                cmd.Parameters.AddWithValue("@gender", gender);
                cmd.Parameters.AddWithValue("@dateOfBirth", dob);
                cmd.Parameters.AddWithValue("@status", status);
                cmd.Parameters.AddWithValue("@rType2", "Supplier");
                string message = cmd.ExecuteScalar().ToString();
                conn.Close();
                MessageBox.Show(message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //list of supplier record
        



        
        public DataTable fetchRecord()
        {
            return db.getRecord("select * from vwSupplier order by ID");
        }
        //view the specific supplier by their IDs
        public DataTable getSuppByID(string suppID)
        {
            return db.getRecord("Select * from vwSupplier where suppID = '" + suppID + "'");
        }

        //search supplier record by their name or ID
        public DataTable searchSupplier(string name)
        {
            return db.getRecord("sp_Supplier 'SEARCHSUPPLIER','','CRUD','','','" + name + "'");
        }

        //view all payment terms records in combo box
        public DataSet showPayterms()
        {
            return db.cbRecords("sp_Supplier", "paymentTerms", "fetchPaymentTerms", "days");
        }
        //view all payment terms in datagridview

        //view all group records
        public DataSet showSuppGroup()
        {
            return db.cbRecords("sp_Supplier", "suppGroup", "fetchSuppGroup", "desc");
        }













//Retreive
        //Supplier/Principal/Distributor
        public DataTable fetchSupplier(string action, string RID)
        {
            return db.fetchRecordsForSupplier("sp_Supplier", "Supplier", action, "", RID, "", "", "");
        }
        //Get supplier by supplier ID
        public DataTable getSupplierById(string action, string suppId)
        {
            return db.fetchRecordsForSupplier("sp_Supplier", "Supplier", action, suppId, "", "", "", "");
        }

        //Name validation for updating supplier
        public DataTable nameValidation(string action, string suppId, string name)
        {
            return db.fetchRecordsForSupplier("sp_Supplier", "Supplier", action, suppId, name, "", "", "");
        }

        //Address
        public DataTable getRecords(string tableName, string action, string suppId, string itemTaxID)
        {
            return db.fetchRecordsForSupplier("sp_Supplier", tableName, action, suppId, "", "", "", itemTaxID);
        }

        //public DataTable fetchAddress(string action, string suppId)
        //{
        //    return db.fetchRecords("sp_Supplier", "AddressDIR", action, suppId, "", "", "");
        //}

        //public DataTable fetchContact(string action, string suppId)
        //{
        //    return db.fetchRecords("sp_Supplier", "contactDIR", action, suppId, "", "", "");
        //}

        //public DataTable fetchContactType(string action, string suppId)
        //{
        //    return db.fetchRecords("sp_Supplier", "contactType", action, suppId, "", "", "");
        //}
        //public DataTable fetchDistributors(string action, string suppId)
        //{
        //    return db.fetchRecords("sp_Supplier", "Supplier", action, suppId, "", "", "");
        //}

        //Principal change distributor
        public DataTable fetchPrincipalToBeUpdated(string action, string RID, string suppId, string distriId)
        {
            return db.fetchRecordsForSupplier("sp_Supplier", "Supplier", action, suppId, RID, distriId, "", "");
        }

//CRUD
    //Supplier CRUD
        //Supplier CRUD
        public void createUpdateSupplier(string tableName, string action, string suppID, string itemTaxID, int? payID, int? sGroupID, string name, string rType, string agent, string RID, bool isDistributor, bool isActive, int? userID)
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
            cmd.Parameters.AddWithValue("@suppID", suppID);
            cmd.Parameters.AddWithValue("@itemTaxID", itemTaxID);
            cmd.Parameters.AddWithValue("@payID", payID);
            cmd.Parameters.AddWithValue("@sGroupID", sGroupID);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@rType", rType);
            cmd.Parameters.AddWithValue("@agent", agent);
            cmd.Parameters.AddWithValue("@RID", RID);
            cmd.Parameters.AddWithValue("@isDistributor", isDistributor);
            cmd.Parameters.AddWithValue("@isActive", isActive);
            cmd.Parameters.AddWithValue("@userID", userID);

            cmd.ExecuteNonQuery(); 
            MessageBox.Show(printOutput, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            printOutput = "";
            conn.Close();
        }
        //Update supplier/distributor/principal
        //public void updateSupplier(string tableName, string action, string suppID, string itemTaxID, int? payID, int? sGroupID, string name, string rType, string agent)
        //{
        //    SqlConnection conn = getConnection();
        //    conn.Open();
        //    SqlCommand cmd = new SqlCommand("sp_Supplier", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@tableName", tableName);
        //    cmd.Parameters.AddWithValue("@action", action);
        //    cmd.Parameters.AddWithValue("@suppID", suppID);
        //    cmd.Parameters.AddWithValue("@itemTaxID", itemTaxID);
        //    cmd.Parameters.AddWithValue("@payID", payID);
        //    cmd.Parameters.AddWithValue("@sGroupID", sGroupID);
        //    cmd.Parameters.AddWithValue("@name", name);
        //    cmd.Parameters.AddWithValue("@rType", rType);
        //    cmd.Parameters.AddWithValue("@agent", agent);

        //    cmd.ExecuteNonQuery();
        //    conn.Close();
        //}
        
        //Delete
        public void deleteSupplier(string tableName, string action, string suppID)
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
            cmd.Parameters.AddWithValue("@suppID", suppID);

            cmd.ExecuteScalar();
            MessageBox.Show(printOutput, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            printOutput = "";
            conn.Close();
        }
    //End of Supplier CRUD

    //Address CRUD
        //Create and Update address
        public void createUpdateAddress(string tableName, string action, int? addressID, string address, string suppID, string city, string province, string purpose, bool isPrimary, int? userID)
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
            cmd.Parameters.AddWithValue("@addressID", addressID);
            cmd.Parameters.AddWithValue("@address", address);
            cmd.Parameters.AddWithValue("@suppID", suppID);
            cmd.Parameters.AddWithValue("@city", city);
            cmd.Parameters.AddWithValue("@province", province);
            cmd.Parameters.AddWithValue("@purpose", purpose);
            cmd.Parameters.AddWithValue("@isPrimary", isPrimary);
            cmd.Parameters.AddWithValue("@userID", userID);

            cmd.ExecuteNonQuery();
            MessageBox.Show(printOutput, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            printOutput = "";
            conn.Close();
        }

        public void deleteAddress(string tableName, string action, int addressID)
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
            cmd.Parameters.AddWithValue("@addressID", addressID);

            cmd.ExecuteScalar();
            MessageBox.Show(printOutput, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            printOutput = "";
            conn.Close();
        }
    //End of address CRUD

    //Contact CRUD
        //Create and update crud
        public void createUpdateContact(string tableName, string action, int? contactID, string TID, int? typeID, string contactDesc, bool isPrimary, int? userID)
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
            cmd.Parameters.AddWithValue("@contactID", contactID);
            cmd.Parameters.AddWithValue("@suppID", TID);
            cmd.Parameters.AddWithValue("@typeID", typeID);
            cmd.Parameters.AddWithValue("@cDesc", contactDesc);
            cmd.Parameters.AddWithValue("@isPrimary", isPrimary);
            cmd.Parameters.AddWithValue("@userID", userID);

            cmd.ExecuteNonQuery();
            MessageBox.Show(printOutput, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            printOutput = "";
            conn.Close();
        }

        public void deleteContact(string tableName, string action, int contactID)
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
            cmd.Parameters.AddWithValue("@contactID", contactID);

            cmd.ExecuteScalar();
            MessageBox.Show(printOutput, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            printOutput = "";
            conn.Close();
        }
    //End of contact CRUD
    
    //Contact type CRUD
        public void createUpdateContactType(string tableName, string action, int? typeID, string contactTypeDesc, int? userID)
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
            cmd.Parameters.AddWithValue("@typeID", typeID);
            cmd.Parameters.AddWithValue("@tDesc", contactTypeDesc);
            cmd.Parameters.AddWithValue("@userID", userID);

            cmd.ExecuteNonQuery();
            MessageBox.Show(printOutput, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            printOutput = "";
            conn.Close();
        }

        public void deleteContactType(string tableName, string action, int typeID)
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
            cmd.Parameters.AddWithValue("@typeID", typeID);

            cmd.ExecuteScalar();
            MessageBox.Show(printOutput, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            printOutput = "";
            conn.Close();
        }
    //End of contact Type CRUD
//END OF CRUD

//PAYMENT TERM
        //Payment terms CRUD

       
        public void createUpdatePaymentTerm(string tableName, string action, int? payID, string payDesc, string days, int? userID)
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
            cmd.Parameters.AddWithValue("@payID", payID);
            cmd.Parameters.AddWithValue("@payDesc", payDesc);
            cmd.Parameters.AddWithValue("@days", days);
            cmd.Parameters.AddWithValue("@userID", userID);
            cmd.ExecuteNonQuery();
            MessageBox.Show(printOutput, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            printOutput = "";
            conn.Close();
        }

        public void deletePaymentTerm(string tableName, string action, int payID)
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
            cmd.Parameters.AddWithValue("@payID", payID);

            cmd.ExecuteScalar();
            MessageBox.Show(printOutput, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            printOutput = "";
            conn.Close();
        }
        //End of payment term CRUD
//END OF PAYMENT TERM

//ITEMSALESTAXGROUP
        public void createUpdateItemTax(string tableName, string action, string itemtaxID, string taxID, string taxDesc, int? userID)
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
            cmd.Parameters.AddWithValue("@itemtaxID", itemtaxID);
            cmd.Parameters.AddWithValue("@taxID", taxID);
            cmd.Parameters.AddWithValue("@taxDesc", taxDesc);
            cmd.Parameters.AddWithValue("@userID", userID);

            cmd.ExecuteNonQuery();
            MessageBox.Show(printOutput, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            printOutput = "";
            conn.Close();
        }

        public void deleteItemTax(string tableName, string action, string itemtaxID)
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
            cmd.Parameters.AddWithValue("@itemtaxID", itemtaxID);

            cmd.ExecuteScalar();
            MessageBox.Show(printOutput, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            printOutput = "";
            conn.Close();
        }
//END OF ITEMSALESTAXGROUP

//TAXSETUP CRUD
        public void createUpdateItemTaxSetup(string tableName, string action, int SID, string itemtaxID, string name, decimal percent, int? userID)
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
            cmd.Parameters.AddWithValue("@SID", SID);
            cmd.Parameters.AddWithValue("@itemtaxID", itemtaxID);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@percent", percent);
            cmd.Parameters.AddWithValue("@userID", userID);

            cmd.ExecuteNonQuery();
            MessageBox.Show(printOutput, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            printOutput = "";
            conn.Close();
        }

        public void deleteItemTaxSetup(string tableName, string action, int SID)
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
            cmd.Parameters.AddWithValue("@SID", SID);

            cmd.ExecuteScalar();
            MessageBox.Show(printOutput, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            printOutput = "";
            conn.Close();
        }
//END OF TAXSETUP CRUD

//ComboBox
        //Fill comboBox
        public DataSet contactType()
        {
            return db.cbRecords("sp_Supplier", "contactType", "fetchContactType", "tDesc");
        }

        //Fill comboBox
        public DataSet itemTax()
        {
            return db.cbRecords("sp_Supplier", "ItemSalesTaxGroup", "fetchItemSalesTaxGroup", "Tax ID");
        }









        //insert and update address records
        public void insertMultiAddress(string suppID, string address, string city, string province, string purpose, string isPrimary,string ID)
        {
            try
            {
                SqlConnection conn = db.getConnection();
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_Supplier", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@desc", "ADDRESSDIR");
                cmd.Parameters.AddWithValue("@Id", "");
                cmd.Parameters.AddWithValue("@action", "CRUD");
                cmd.Parameters.AddWithValue("@TID", suppID);
                cmd.Parameters.AddWithValue("@address", address);
                cmd.Parameters.AddWithValue("@city", city);
                cmd.Parameters.AddWithValue("@province", province);
                cmd.Parameters.AddWithValue("@purpose", purpose);
                cmd.Parameters.AddWithValue("@isPrimary", isPrimary);
                cmd.Parameters.AddWithValue("@addressID",ID);

                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //view all address records
        public DataTable fetch_address()
        {
            return db.getRecord("select * from viewaddressDIR");
        }


        //insert contact records 
        public void insertContact(string suppID, string typeID, string cDesc, string isPrimary,string ID)
        {
            SqlConnection conn = db.getConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("sp_Supplier", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@desc", "CONTACTDIR");
            cmd.Parameters.AddWithValue("@Id", "");
            cmd.Parameters.AddWithValue("@action", "CRUD");
            cmd.Parameters.AddWithValue("@TID", suppID);
            cmd.Parameters.AddWithValue("@typeID", typeID);
            cmd.Parameters.AddWithValue("@cDesc", cDesc);
            cmd.Parameters.AddWithValue("@isPrimary", isPrimary);
            cmd.Parameters.AddWithValue("@contactID", ID);
            cmd.ExecuteNonQuery();
            conn.Close();

        }

        //delete address record by their ID
        //public void delete_suppAddress(string suppID, string addressID)
        //{
        //    try
        //    {
        //        SqlConnection conn = db.getConnection();
        //        conn.Open();
        //        SqlCommand cmd = new SqlCommand("sp_Supplier", conn);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@desc", "SUPPADDRESS");
        //        cmd.Parameters.AddWithValue("@Id", "");
        //        cmd.Parameters.AddWithValue("@action", "DELETE");
        //        cmd.Parameters.AddWithValue("@suppID", suppID);
        //        cmd.Parameters.AddWithValue("@addressID", addressID);
        //        cmd.ExecuteNonQuery();
        //        conn.Close();
        //        MessageBox.Show("Successfully Deleted", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}



        //public int autoIncrementID()
        //{
        //    int currentMaxValue = 0;
        //    currentMaxValue = db.autoIncrement("SELECT ISNULL(MAX(CAST(" + Id.columnID + " as int)),0) FROM " + Id.table + "");
        //    return currentMaxValue;
        //}
       
       
        //public void delete_address(string addressID)
        //{
        //    try
        //    {
        //        SqlConnection conn = db.getConnection();
        //        conn.Open();
        //        SqlCommand cmd = new SqlCommand("sp_Supplier", conn);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@desc", "ADDRESS");
        //        cmd.Parameters.AddWithValue("@Id", "");
        //        cmd.Parameters.AddWithValue("@action", "DELETE");
        //       // cmd.Parameters.AddWithValue("@suppID", suppID);
        //        cmd.Parameters.AddWithValue("@addressID", addressID);

        //        string message = cmd.ExecuteScalar().ToString();
        //        conn.Close();
        //        MessageBox.Show(message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

       

        //============================================================>
        //Contact Information CRUD Operation
        public DataTable fetch_contact() {
            return db.getRecord("select * from vwContacts");
        }
        public DataTable getContactByID(string contactID) {

            return db.getRecord("select * from vwContacts where [contact ID] = '"+contactID+"'");
        }

        public DataTable searchContact(string name)
        {
            return db.getRecord("sp_Supplier 'SEARCHCONTACT','','CRUD','','','" + name + "'");
        }

        //Delete contact info
        public void delete_Contact(string contactID)
        {
            try
            {
                SqlConnection conn = db.getConnection();
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_Supplier", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@desc", "CONTACTINFO");
                cmd.Parameters.AddWithValue("@Id", "");
                cmd.Parameters.AddWithValue("@action", "DELETE");
                //cmd.Parameters.AddWithValue("@suppID", suppID);
                cmd.Parameters.AddWithValue("@contactID", contactID);
                string message = cmd.ExecuteScalar().ToString();
                conn.Close();
                MessageBox.Show(message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Delete supplier contact attached to it.
        //public void delete_SuppContact(string suppID,string contactID)
        //{
        //    try
        //    {
        //        SqlConnection conn = db.getConnection();
        //        conn.Open();
        //        SqlCommand cmd = new SqlCommand("sp_Supplier", conn);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@desc", "SUPPLIERCONTACT");
        //        cmd.Parameters.AddWithValue("@Id", "");
        //        cmd.Parameters.AddWithValue("@action", "DELETE");
        //        cmd.Parameters.AddWithValue("@suppID", suppID);
        //        cmd.Parameters.AddWithValue("@contactID", contactID);
        //        string message = cmd.ExecuteScalar().ToString();
        //        conn.Close();
        //        MessageBox.Show(message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}
        //=========================================================>
        //Address CRUD Operation
        public DataTable searchAddress(string name)
        {
            return db.getRecord("sp_Supplier 'SEARCHADDRESS','','CRUD','','','" + name + "'");
        }
        //get the specific address by their supplier ID
        public DataTable fetch_suppAddress()
        {
            return db.getRecord("SELECT * FROM addressDIR  where TID = '"+Id.suppID+"'");
        }
        //get the specific contact details by their supplier ID
        public DataTable fetch_ContactID()
        {
            return db.getRecord("SELECT * FROM contactDIR  where TID = '" + Id.suppID + "'");
        }
        public DataTable fetch_dbContact()
        {
            return db.getRecord("sp_Supplier 'FETCHCONTACT','','VIEW','"+Id.suppID+"'");
        }
        public DataTable getAddressbyID() {

            return db.getRecord("select * from addressDIR where addressID = '" + Id.addressID + "'");
        
        }

      
        //=============================================>
        //Record Type CRUD
        //public DataSet fetchRType() {
        //    return db.cbRecords("Select * From vwRecordType where rType != '' and rType = '" + Id.rType + "'", "tDesc");
        //}
        //public DataSet fetchCodeType()
        //{
        //    return db.cbRecords("Select * From vwRecordType where rType = ''","tDesc");
        //}

        //Payment Terms
        public void insert_payterms(string paydesc, string payday)
        {
            try
            {
                SqlConnection conn = db.getConnection();
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_Supplier", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@desc", "PAYMENTTERMS");
                cmd.Parameters.AddWithValue("@Id", "");
                cmd.Parameters.AddWithValue("@action", "CRUD");
                cmd.Parameters.AddWithValue("@paydesc", paydesc);
                cmd.Parameters.AddWithValue("@days", payday);
                string message = cmd.ExecuteScalar().ToString();
                conn.Close();
                MessageBox.Show(message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public DataSet showType()
        {
            return db.cbRecords("sp_Supplier", "contactType", "fetchContactType", "tDesc");
        }
  
        }
    }

    

