using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace WebApplication3.Models
{
    public class toDoRepository : ITodoRepository
    {
        private static ConcurrentDictionary<string, toDoList> _todos =
             new ConcurrentDictionary<string, toDoList>();

        private static ConcurrentDictionary<string, Person> _todos2 =
     new ConcurrentDictionary<string, Person>();
        public toDoRepository()
        {
            //Add(new toDoList { Name = "Item1" });
        }

        public IEnumerable<Person> GetAll()
        {
            return _todos2.Values;
        }
        public User Login(String uname, String upassword)
        {
            try
            {  //Server=DESKTOP-UAPGGGC\MYMSSQLSERVER;Provider=sqloledb;Database=localb;User ID=IUSR;Password=mlinc123456;
                SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-UAPGGGC\MYMSSQLSERVER;Initial Catalog=master;Persist Security Info=True;User ID=IUSR;Password=mlinc123456");
                conn.Open();

                SqlCommand command = new SqlCommand("select * from my_User_info where user_UserName = @uname and user_Password = @uPassword", conn);
                command.Parameters.AddWithValue("@uname", uname);
                command.Parameters.AddWithValue("@uPassword", upassword);
                int result = command.ExecuteNonQuery();
                var _myObject = new User();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        //_myObject.userName = reader["memberId"].ToString();
                        _myObject.userPassword = reader["user_Name"].ToString();
                        _myObject.responseCode = "1";
                        _myObject.responseMessage = "Access Granted!";
                    }
                    else
                    {
                        _myObject.responseCode = "0";
                        _myObject.responseMessage = "Access Denied!";
                    }

                }

                conn.Close();
                return new User
                {
                    userName = _myObject.userName,
                    userPassword = _myObject.userPassword,                
                    responseCode = _myObject.responseCode,
                    responseMessage = _myObject.responseMessage
                };
            }
            catch (Exception ex)
            {
                return new User
                {
                    responseCode = "A12",
                    responseMessage = ex.Message
                };
            }
        }
        public Person Find(string key)
        {
            try
            {  //Server=DESKTOP-UAPGGGC\MYMSSQLSERVER;Provider=sqloledb;Database=localb;User ID=IUSR;Password=mlinc123456;
                SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-UAPGGGC\MYMSSQLSERVER;Initial Catalog=master;Persist Security Info=True;User ID=IUSR;Password=mlinc123456");
                conn.Open();

                SqlCommand command = new SqlCommand("select * from my_MemBer_Info where memberid = @id", conn);
                command.Parameters.AddWithValue("@id", key);
                int result = command.ExecuteNonQuery();
                var _myObject = new Person();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        _myObject.Id = reader["memberId"].ToString();
                        _myObject.lastName = (reader["lastname"].ToString());
                        _myObject.middleName = reader["middlename"].ToString();
                        _myObject.name = reader["firstname"].ToString();
                        _myObject.Address = reader["address"].ToString();
                        _myObject.contactNumber = reader["contact_number"].ToString();
                        _myObject.spouse = reader["spouse"].ToString();
                        _myObject.mother_name = reader["mother_name"].ToString();
                        _myObject.father_name = reader["father_name"].ToString();
                        _myObject.age = reader["age"].ToString();
                        _myObject.occupation = reader["occupation"].ToString();
                        _myObject.responseCode = "1";
                        _myObject.responseMessage = "Success!";
                    }
                    else
                    {
                        _myObject.responseCode = "0";
                        _myObject.responseMessage = "No data Found!";
                    }

                }

                conn.Close();
                return new Person
                {
                    Id = _myObject.Id,
                    name = _myObject.name,
                    middleName = _myObject.middleName,
                    lastName = _myObject.lastName,
                    Address = _myObject.Address,
                    spouse = _myObject.spouse,
                    mother_name = _myObject.mother_name,
                    father_name = _myObject.father_name,
                    age = _myObject.age,
                    occupation = _myObject.occupation,
                    contactNumber = _myObject.contactNumber,
                    responseCode = _myObject.responseCode,
                    responseMessage = _myObject.responseMessage
                };
            }
            catch (Exception ex)
            {
                return new Person
                {
                    responseCode = "A12",
                    responseMessage = ex.Message
                };
            }
        }
        public MotherClass Remove(string key)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-UAPGGGC\MYMSSQLSERVER;Initial Catalog=master;Persist Security Info=True;User ID=IUSR;Password=mlinc123456"))
                {
                    connection.Open();
                    SqlTransaction mySqlTransaction = connection.BeginTransaction();
                    String query = "DELETE FROM my_MemBer_Info where memberid = @id";
                    using (SqlCommand command = new SqlCommand(query, connection, mySqlTransaction))
                    {
                        command.Parameters.AddWithValue("@id", key);

                        int result = command.ExecuteNonQuery();

                        if (result < 0)
                        {
                            mySqlTransaction.Rollback();
                            return new removeData { responseCode = result.ToString(), responseMessage = "Remove transaction Fail!" };
                        }
                        else
                        {
                            mySqlTransaction.Commit();
                            return new MotherClass { responseCode = result.ToString(), responseMessage = "User successfullly Removed!" };
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                return new MotherClass { responseCode = "A12", responseMessage = ex.Message };
            }
        }
        public MotherClass Add(String name, String middleName, String lastName, String Address, String id, String ContactNumber, String Spouse, String Mother, String Father, String Age, String Occupation)
        {
            
            try
            {
                using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-UAPGGGC\MYMSSQLSERVER;Initial Catalog=master;Persist Security Info=True;User ID=IUSR;Password=mlinc123456"))
                {
                    connection.Open();
                    SqlTransaction mySqlTransaction = connection.BeginTransaction();
                    String query = "INSERT INTO [dbo].my_MemBer_Info(lastname,middleName,firstname,address,contact_number,spouse,mother_name,father_name,age,occupation)VALUES(@lastname,@middleName,@firstname,@address,@contact_number,@spouse,@mother_name,@father_name,@age,@occupation)";
                    using (SqlCommand command = new SqlCommand(query, connection, mySqlTransaction))
                    {
                        command.Parameters.AddWithValue("@lastname", lastName);
                        command.Parameters.AddWithValue("@middleName", middleName);
                        command.Parameters.AddWithValue("@firstname", name);
                        command.Parameters.AddWithValue("@address", Address);
                        command.Parameters.AddWithValue("@contact_number", ContactNumber);
                        command.Parameters.AddWithValue("@spouse", Spouse);
                        command.Parameters.AddWithValue("@mother_name", Mother);
                        command.Parameters.AddWithValue("@father_name", Father);
                        command.Parameters.AddWithValue("@age", Age);
                        command.Parameters.AddWithValue("@occupation", Occupation);

                        int result = command.ExecuteNonQuery();

                        if (result < 0)
                        {
                            mySqlTransaction.Rollback();
                            return new MotherClass { responseCode = result.ToString(), responseMessage = "Insertion Fail!" };
                        }
                        else
                        {
                            mySqlTransaction.Commit();
                            return new MotherClass { responseCode = result.ToString(), responseMessage = "User successfullly Added!" };
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                return new MotherClass { responseCode = "A12", responseMessage = ex.Message };
            }
        }
        public MotherClass Update(String name, String middleName, String lastName, String Address, String id, String ContactNumber, String Spouse, String Mother, String Father, String Age, String Occupation)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-UAPGGGC\MYMSSQLSERVER;Initial Catalog=master;Persist Security Info=True;User ID=IUSR;Password=mlinc123456"))
                {
                    connection.Open();
                    SqlTransaction mySqlTransaction = connection.BeginTransaction();
                    String query = "UPDATE[dbo].[my_MEMBER_INFO] SET[lastName] = @lastname ,[middleName] = @middleName ,[firstName] = @firstname,[address] = @address ,[contact_number] = @contact_number,[spouse] = @spouse ,[mother_name] = @mother_name,[father_name] = @father_name,[age] = @age ,[occupation] = @occupation WHERE memberid = @memberid";//"Update anotherPersons set name = @name, middleName = @middleName, lastName = @lastName , Address = @Address where id = @id";
                    using (SqlCommand command = new SqlCommand(query, connection, mySqlTransaction))
                    {
                       
                        command.Parameters.AddWithValue("@lastname",lastName);
                        command.Parameters.AddWithValue("@middleName", middleName);
                        command.Parameters.AddWithValue("@firstname", name);
                        command.Parameters.AddWithValue("@address", Address);
                        command.Parameters.AddWithValue("@contact_number", ContactNumber);
                        command.Parameters.AddWithValue("@spouse", Spouse);
                        command.Parameters.AddWithValue("@mother_name", Mother);
                        command.Parameters.AddWithValue("@father_name", Father);
                        command.Parameters.AddWithValue("@age", Age);
                        command.Parameters.AddWithValue("@occupation", Occupation);
                        command.Parameters.AddWithValue("@memberid", id);
                        int result = command.ExecuteNonQuery();

                        if (result < 0)
                        {
                            mySqlTransaction.Rollback();
                            return new removeData { responseCode = result.ToString(), responseMessage = "Update transaction Fail!" };
                        }
                        else
                        {
                            mySqlTransaction.Commit();
                            return new MotherClass { responseCode = result.ToString(), responseMessage = "Data Successfully Upated!" };
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                return new MotherClass { responseCode = "A12", responseMessage = ex.Message };
            }
        }
        public PersonList FindAll()
        {
            try
            {  //Server=DESKTOP-UAPGGGC\MYMSSQLSERVER;Provider=sqloledb;Database=localb;User ID=IUSR;Password=mlinc123456;
                SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-UAPGGGC\MYMSSQLSERVER;Initial Catalog=master;Persist Security Info=True;User ID=IUSR;Password=mlinc123456");
                conn.Open();

                SqlCommand command = new SqlCommand("select * from my_MemBer_Info", conn);
               // command.Parameters.AddWithValue("@id", key);
                int result = command.ExecuteNonQuery();
                var _myObject = new PersonList();
                _myObject.Id = new List<string>();
                _myObject.name = new List<string>();
                _myObject.middleName = new List<string>();
                _myObject.Address = new List<string>();
                _myObject.contactNumber = new List<string>();
                _myObject.lastName = new List<string>();
                _myObject.spouse = new List<string>();
                _myObject.mother_name = new List<string>();
                _myObject.father_name = new List<string>();
                _myObject.age = new List<string>();
                _myObject.occupation = new List<string>();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while( reader.Read())
                        {

                            _myObject.Id.Add(reader["memberId"].ToString());
                            _myObject.lastName.Add(reader["lastname"].ToString());
                            _myObject.middleName.Add(reader["middlename"].ToString());
                            _myObject.name.Add(reader["firstname"].ToString());
                            _myObject.Address.Add(reader["address"].ToString());
                            _myObject.contactNumber.Add(reader["contact_number"].ToString());
                            _myObject.spouse.Add(reader["spouse"].ToString());
                            _myObject.mother_name.Add(reader["mother_name"].ToString());
                            _myObject.father_name.Add(reader["father_name"].ToString());
                            _myObject.age.Add(reader["age"].ToString());
                            _myObject.occupation.Add(reader["occupation"].ToString());
                            _myObject.responseCode = "1";
                            _myObject.responseMessage = "Success!";
                        }
                    }
                    else
                    {
                        _myObject.responseCode = "0";
                        _myObject.responseMessage = "No data Found!";
                    }

                }

                conn.Close();
                return new PersonList
                {
                    Id = _myObject.Id,
                    name = _myObject.name,
                    middleName = _myObject.middleName,
                    lastName = _myObject.lastName,
                    Address = _myObject.Address,
                    spouse = _myObject.spouse,
                    mother_name = _myObject.mother_name,
                    father_name = _myObject.father_name,
                    age = _myObject.age,
                    occupation = _myObject.occupation,
                    contactNumber = _myObject.contactNumber,
                    responseCode = _myObject.responseCode,
                    responseMessage = _myObject.responseMessage
                };
            }
            catch (Exception ex)
            {
                return new PersonList
                {
                    responseCode = "A12",
                    responseMessage = ex.Message
                };
            }
        }
    }
}
