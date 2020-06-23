using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace WebAppForms.Models
{
    public class DalPerson : IDalPerson
    {
        public SqlConnection Connection { get; }
        public DalPerson(SqlConnection connection)
        {
            Connection = connection;
        }

        public IEnumerable<Person> GetPerson()
        {
            using (SqlCommand command = Connection.CreateCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT Id, Name, CreatedAt, Active FROM Person ORDER BY Name ASC";
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            yield return new Person
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                CreatedAt = reader.GetDateTime(2),
                                Active = reader.GetBoolean(3)
                            };
                        }
                    }
                }
            }
        }

        public IEnumerable<Person> GetPerson(string name)
        {
            using (SqlCommand command = Connection.CreateCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT Id, Name, CreatedAt, Active FROM Person ";
                command.CommandText += " WHERE Name LIKE @Name ORDER BY Name ASC";
                command.Parameters.Add("@Name", SqlDbType.VarChar).Value = $"%{name}%";
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            yield return new Person
                            {
                                Id = int.Parse(reader["Id"].ToString()),
                                Name = reader["Name"].ToString(),
                                CreatedAt = DateTime.Parse(reader["CreatedAt"].ToString()),
                                Active = Boolean.Parse(reader["Active"].ToString())
                            };
                        }
                    }
                }
            }
        }

        public IEnumerable<Person> GetPerson(bool active)
        {
            List<Person> persons = null;
            using (SqlCommand command = Connection.CreateCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT Id, Name, CreatedAt, Active FROM Person ";
                command.CommandText += " WHERE Active = @Active ORDER BY Name ASC";
                command.Parameters.Add("@Active", SqlDbType.Bit).Value = active;
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        persons = new List<Person>();
                        while (reader.Read())
                        {
                            var p = new Person
                            {
                                Id = int.Parse(reader["Id"].ToString()),
                                Name = reader["Name"].ToString(),
                                CreatedAt = DateTime.Parse(reader["CreatedAt"].ToString()),
                                Active = Boolean.Parse(reader["Active"].ToString())
                            };
                            persons.Add(p);
                        }
                    }
                }
            }
            return persons;
        }
    }
}