using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data.SqlClient;
using System.Web;
using System.Web.Script.Serialization;
using System.Data;
using System.ServiceModel.Channels;

using Newtonsoft.Json;
using System.Collections;

namespace MyWcfWebApplication
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public object JsonConvert { get; private set; }
        public object Newtonsoft { get; private set; }

        String DataSource = @"DESKTOP-RJQPENS\MY_NEW_SQLSERVER";
        String DataBaseName = "localb";
        String DataBaseUserName = "sa";
        String DataBaseUesrPassWord = "Admin123!";

        public MotherClass GetData(String FirstName, String MiddleName, String LastName)
        {
            MotherClass MyClassObject = new MotherClass();
            using (SqlConnection connection = new SqlConnection())
            {                
                try
                {
                    connection.ConnectionString = $"Data Source ={DataSource}; Initial Catalog = {DataBaseName}; User ID = {DataBaseUserName}; Password = {DataBaseUesrPassWord};Trusted_Connection=true";
                    connection.Open();

                    SqlCommand command = new SqlCommand("INSERT INTO PersonInformationTable "
                        + "(FirstName, MiddleName, LastName, Address, Age) VALUES "
                        + "('"+FirstName+"', '"+MiddleName+"','"+LastName+"','null', '150')", connection);

                    command.Connection = connection;
                    command.ExecuteReader();
                }
                catch (Exception ex)
                {

                    return new MotherClass { ResponseCode = "0", ResponseMessage = ex.Message };
                }
            }
            return new MotherClass { ResponseCode = "1", ResponseMessage ="Information Saved!" };
        }

        public MotherClass Login(String UserName, String PassWord)
        {
            MotherClass MyClassObject = new MotherClass();
            using (SqlConnection connection = new SqlConnection())
            {
                try
                {
                    connection.ConnectionString = $"Data Source ={DataSource}; Initial Catalog = {DataBaseName}; User ID = {DataBaseUserName}; Password = {DataBaseUesrPassWord};Trusted_Connection=true";
                    connection.Open();

                    SqlCommand command = new SqlCommand("Select * from UserTable where UserName = '"+UserName+"' And PassWord = '"+PassWord+"'", connection);

                    command.Connection = connection;
                    var x = command.ExecuteReader();
                    if (x.HasRows == true)
                    {
                        return new MotherClass { ResponseCode = "1", ResponseMessage = "Welcome Negga!" };
                    }
                    else
                    {
                        return new MotherClass { ResponseCode = "0", ResponseMessage = "Access Denied Negga!" };
                    }
                }
                catch (Exception ex)
                {

                    return new MotherClass { ResponseCode = "0", ResponseMessage = ex.Message };
                }
            }
            
        }

        public MotherClass UpdateData(String FirstName, String MiddleName, String LastName, String Id)
        {
           // MotherClass MyClassObject = new MotherClass();
            using (SqlConnection connection = new SqlConnection())
            {
                try
                {
                    connection.ConnectionString = $"Data Source ={DataSource}; Initial Catalog = {DataBaseName}; User ID = {DataBaseUserName}; Password = {DataBaseUesrPassWord};Trusted_Connection=true";
                    connection.Open();

                    SqlCommand command = new SqlCommand("UPDATE PersonInformationTable SET FirstName = '"+ FirstName + "', MiddleName = '"+ MiddleName + "', LastName = '"+LastName+"' WHERE Personid = '"+ Id + "'", connection);

                    command.Connection = connection;
                    command.ExecuteReader();
                }
                catch (Exception ex)
                {

                    return new MotherClass { ResponseCode = "0", ResponseMessage = ex.Message };
                }
            }
            return new MotherClass { ResponseCode = "1", ResponseMessage = "Information Updated!" };
        }

        public MotherClass DeleteData(String Id)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                try
                {
                    connection.ConnectionString = $"Data Source ={DataSource}; Initial Catalog = {DataBaseName}; User ID = {DataBaseUserName}; Password = {DataBaseUesrPassWord};Trusted_Connection=true";
                    connection.Open();

                    SqlCommand command = new SqlCommand("DELETE FROM PersonInformationTable WHERE PersonId ='"+ Id + "'", connection);

                    command.Connection = connection;
                    command.ExecuteReader();
                }
                catch (Exception ex)
                {

                    return new MotherClass { ResponseCode = "0", ResponseMessage = ex.Message };
                }
            }
            return new MotherClass { ResponseCode = "1", ResponseMessage = "Information Deleted!" };
        }

        public ClassToList GetAllPersonInformation()
        {
            try
            {
                List<AllPersonInformation> myClassAlias = new List<AllPersonInformation>();

                using (SqlConnection connection = new SqlConnection())
                {
                        var MyDataTable = new DataTable();
                        connection.ConnectionString = $"Data Source ={DataSource}; Initial Catalog = {DataBaseName}; User ID = {DataBaseUserName}; Password = {DataBaseUesrPassWord};Trusted_Connection=true";
                        connection.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM PersonInformationTable", connection);
                        adapter.Fill(MyDataTable);
                        foreach (DataRow row in MyDataTable.Rows)
                        { 
                            myClassAlias.Add(new AllPersonInformation { FirstName = row["FirstName"].ToString(), MiddleName = row["MiddleName"].ToString(), LastName = row["LastName"].ToString(), Address = row["Address"].ToString(), Age = row["Age"].ToString() });
                        }
                }

                return new ClassToList { ResponseMessage = "All good", ResponseCode = "1", AllPersonInformation = myClassAlias };
            }
            catch (Exception ex)
            {

                return new ClassToList { ResponseCode = "0", ResponseMessage = ex.Message};
            }
        }

        public AllPersonInformationList GetAllPersonInformationList()
        {
            try
            {
                AllPersonInformationList myClassAlias = new AllPersonInformationList();
                myClassAlias.Id = new List<string>();
                myClassAlias.FirstName = new List<string>();
                myClassAlias.MiddleName = new List<string>();
                myClassAlias.LastName = new List<string>();
                using (SqlConnection connection = new SqlConnection())
                {
                    var MyDataTable = new DataTable();
                    connection.ConnectionString = $"Data Source ={DataSource}; Initial Catalog = {DataBaseName}; User ID = {DataBaseUserName}; Password = {DataBaseUesrPassWord};Trusted_Connection=true";
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM PersonInformationTable", connection);
                    adapter.Fill(MyDataTable);
                    foreach (DataRow row in MyDataTable.Rows)
                    {
                        myClassAlias.Id.Add(row["PersonId"].ToString());
                        myClassAlias.FirstName.Add(row["FirstName"].ToString());
                        myClassAlias.MiddleName.Add(row["MiddleName"].ToString());
                        myClassAlias.LastName.Add(row["LastName"].ToString());
                    }
                }

                return new AllPersonInformationList { ResponseMessage = "All good", ResponseCode = "1", Id  = myClassAlias.Id, FirstName = myClassAlias.FirstName,MiddleName = myClassAlias.MiddleName, LastName = myClassAlias.LastName };
            }
            catch (Exception ex)
            {

                return new AllPersonInformationList { ResponseCode = "0", ResponseMessage = ex.Message };
            }
        }

        public SingleInformation SearcInformationById(String Id)
        {
            try
            {
                var myClassAlias = new SingleInformation();
                using (SqlConnection connection = new SqlConnection())
                {
                    var MyDataTable = new DataTable();

                    connection.ConnectionString = $"Data Source ={DataSource}; Initial Catalog = {DataBaseName}; User ID = {DataBaseUserName}; Password = {DataBaseUesrPassWord};Trusted_Connection=true";
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM PersonInformationTable where PersonId =" +Id, connection);
                    adapter.Fill(MyDataTable);
                    if (MyDataTable.Rows.Count != 0)
                    {
                        foreach (DataRow row in MyDataTable.Rows)
                        {
                            myClassAlias.Id = row["PersonId"].ToString();
                            myClassAlias.FirstName = row["FirstName"].ToString();
                            myClassAlias.MiddleName = row["MiddleName"].ToString();
                            myClassAlias.LastName = row["LastName"].ToString();
                        }
                    }
                    else
                    {
                        return new SingleInformation { ResponseCode = "0", ResponseMessage = "No data Found!" };
                    }
                }

                return new SingleInformation { ResponseMessage = "All good", ResponseCode = "1", Id = myClassAlias.Id, FirstName = myClassAlias.FirstName, MiddleName = myClassAlias.MiddleName, LastName = myClassAlias.LastName };
            }
            catch (Exception ex)
            {

                return new SingleInformation { ResponseCode = "0", ResponseMessage = ex.Message };
            }
        }


    }



}

public class MotherClass
{
    public String ResponseCode;
    public String ResponseMessage;
}

public class PersonInformation : MotherClass
{
    public String FirstName;
    public String MiddleName;
    public String LastName;
}
public class ClassToList : MotherClass
{
    public List<AllPersonInformation> AllPersonInformation;
}
public class AllPersonInformation
{
    public String FirstName;
    public String MiddleName;
    public String LastName;
    public String Address;
    public String Age;
}

public class AllPersonInformationList : MotherClass
{
    public List<String> Id;
    public List<String> FirstName;
    public List<String> MiddleName;
    public List<String> LastName;
}
public class SingleInformation : MotherClass
{
    public String Id;
    public String FirstName;
    public String MiddleName;
    public String LastName;
}