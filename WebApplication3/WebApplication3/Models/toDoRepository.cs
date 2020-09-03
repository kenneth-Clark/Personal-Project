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
        public Person Find(string key)
        {
            try
            {
                SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-IBEKIIEA\MSQLNEW2;Initial Catalog=locala;Persist Security Info=True;User ID=sa;Password=lig12345");
                conn.Open();

                SqlCommand command = new SqlCommand("select * from AnotherPersons where id = @id", conn);
                command.Parameters.AddWithValue("@id", key);
                int result = command.ExecuteNonQuery();
                var _myObject = new Person();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        _myObject.Id = reader["id"].ToString();
                        _myObject.name = reader["name"].ToString();
                        _myObject.middleName = reader["middleName"].ToString();
                        _myObject.lastName = reader["lastName"].ToString();
                        _myObject.Address = reader["Address"].ToString();
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
                using (SqlConnection connection = new SqlConnection(@"Data Source=LAPTOP-IBEKIIEA\MSQLNEW2;Initial Catalog=locala;Persist Security Info=True;User ID=sa;Password=lig12345"))
                {
                    connection.Open();
                    SqlTransaction mySqlTransaction = connection.BeginTransaction();
                    String query = "DELETE FROM AnotherPersons where id = @id";
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
                            return new MotherClass { responseCode = result.ToString(), responseMessage = "Success!" };
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                return new MotherClass { responseCode = "A12", responseMessage = ex.Message };
            }
        }
        public MotherClass Add(String name, String middleName, String LastName, String Address)
        {
            
            try
            {
                using (SqlConnection connection = new SqlConnection(@"Data Source=LAPTOP-IBEKIIEA\MSQLNEW2;Initial Catalog=locala;Persist Security Info=True;User ID=sa;Password=lig12345"))
                {
                    connection.Open();
                    SqlTransaction mySqlTransaction = connection.BeginTransaction();
                    String query = "INSERT INTO [dbo].anotherPErsons(name,middleName,lastName,Address)VALUES(@name,@middleName,@lastName,@Address)";
                    using (SqlCommand command = new SqlCommand(query, connection, mySqlTransaction))
                    {
                        command.Parameters.AddWithValue("@name", name);
                        command.Parameters.AddWithValue("@middleName", middleName);
                        command.Parameters.AddWithValue("@lastName", LastName);
                        command.Parameters.AddWithValue("@Address", Address);

                        
                        int result = command.ExecuteNonQuery();

                        if (result < 0)
                        {
                            mySqlTransaction.Rollback();
                            return new MotherClass { responseCode = result.ToString(), responseMessage = "Insertion Fail!" };
                        }
                        else
                        {
                            mySqlTransaction.Commit();
                            return new MotherClass { responseCode = result.ToString(), responseMessage = "Success!" };
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                return new MotherClass { responseCode = "A12", responseMessage = ex.Message };
            }
        }
        public MotherClass Update(String name, String middleName, String LastName, String Address, String id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(@"Data Source=LAPTOP-IBEKIIEA\MSQLNEW2;Initial Catalog=locala;Persist Security Info=True;User ID=sa;Password=lig12345"))
                {
                    connection.Open();
                    SqlTransaction mySqlTransaction = connection.BeginTransaction();
                    String query = "Update anotherPersons set name = @name, middleName = @middleName, lastName = @lastName , Address = @Address where id = @id";
                    using (SqlCommand command = new SqlCommand(query, connection, mySqlTransaction))
                    {
                        command.Parameters.AddWithValue("@name", name);
                        command.Parameters.AddWithValue("@middleName", middleName);
                        command.Parameters.AddWithValue("@lastName", LastName);
                        command.Parameters.AddWithValue("@Address", Address);
                        command.Parameters.AddWithValue("@id", id);

                        int result = command.ExecuteNonQuery();

                        if (result < 0)
                        {
                            mySqlTransaction.Rollback();
                            return new removeData { responseCode = result.ToString(), responseMessage = "Update transaction Fail!" };
                        }
                        else
                        {
                            mySqlTransaction.Commit();
                            return new MotherClass { responseCode = result.ToString(), responseMessage = "Success!" };
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                return new MotherClass { responseCode = "A12", responseMessage = ex.Message };
            }
        }
    }
}
