using System;
using System.Data;
using System.Data.SqlClient ;
using System.Security.Policy;


namespace DVLD_DataAccessLayer
{
    public static class PeopleDataAccess
    {
        public static DataTable GetAllPeopleList()
        {
            DataTable dt = new DataTable();

            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = "SELECT  " +
                "p.PersonID, " +
                "p.NationalNo, " +
                "p.FirstName, " +
                "p.SecondName, " +
                "p.ThirdName, " +
                "p.LastName, " +
                "CASE p.Gender " +
                "WHEN 0 THEN 'Male' " +
                "WHEN 1 THEN 'Female'" +
                " END AS Gender, " +
                "CONVERT(varchar, p.DateOfBirth, 22) AS [Date Of Birth], " +
                "c.CountryName AS Nationality, " +
                "p.Phone, " +
                "p.Email " +
                "FROM  People p " +
                "JOIN  Countries c ON p.NationalityCountryID = c.CountryID";
            SqlCommand Command = new SqlCommand(query, Connection);

            try
            {
                Connection.Open();

                SqlDataReader reader = Command.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }

            }
            catch (Exception ex)
            {
               
            }
            finally
            {
                Connection.Close();
            }

            return dt;
        }
        public static DataTable GetAllCountries()
        {
            DataTable dt = new DataTable();

            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = "SELECT * FROM Countries;";
            SqlCommand Command = new SqlCommand(query, Connection);

            try
            {
                Connection.Open();

                SqlDataReader reader = Command.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }

            }
            catch (Exception ex)
            {
                
            }
            finally
            {
                Connection.Close();
            }
            return dt;
        }
        public static bool isNationNoUsed(string NationalNo)
        { 
            bool isUsed = false;

            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = "SELECT NationalNo FROM PEOPLE WHERE NationalNo=@NationalNo;";
            SqlCommand Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@NationalNo", NationalNo);

            try
            {
                Connection.Open();

                var result = Command.ExecuteScalar();
                if (result != null)
                {
                     isUsed = true;
                }
            }
            catch (Exception ex)
            {
                isUsed = false; 
            }
            finally
            {
                Connection.Close();
            }
            return isUsed;
        }
        public static bool GetPersonInfoByID(int PersonID, ref string NationalNo, ref string FirstName, ref string SecondName, ref string LastName, ref DateTime DateOfBirth, ref byte Gender,
            ref string Address, ref string Phone, ref int NationalityCountryID, ref string ImagePath, ref string ThirdName, ref string Email)
        {
            bool isFound = false;

            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = "SELECT * FROM PEOPLE WHERE PersonID=@PersonID;";

            SqlCommand Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                Connection.Open();
                SqlDataReader reader = Command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    NationalNo = (string)reader["NationalNo"];
                    FirstName = (string)reader["FirstName"];
                    SecondName = (string)reader["SecondName"];
                    ThirdName = reader["ThirdName"] == DBNull.Value ? "" : reader["ThirdName"].ToString();
                    LastName = (string)reader["LastName"];
                    Email = reader["Email"] == DBNull.Value ? "" : reader["Email"].ToString();
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    Gender = (byte)reader["Gender"];
                    Phone = (string)reader["Phone"];
                    Address = (string)reader["Address"];
                    NationalityCountryID = (int)reader["NationalityCountryID"];
                    ImagePath = reader["ImagePath"] == DBNull.Value ? "" : reader["ImagePath"].ToString();
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                isFound = false;
            }
            finally
            {
                Connection.Close();
            }
            return isFound;
        }

        public static int AddNewPersonToDB(string NationalNo, string FirstName, string SecondName, string LastName, DateTime DateOfBirth, byte Gender,
            string Address, string Phone, int NationalityCountryID, string ImagePath = null, string ThirdName = null, string Email = null)
        {
            int newPersonID = -1;


            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = "INSERT INTO People (FirstName, SecondName, ThirdName, LastName, Email, Phone, Address, DateOfBirth, NationalityCountryID, ImagePath, NationalNo, Gender) " +
                            "VALUES (@FirstName, @SecondName, @ThirdName, @LastName, @Email, @Phone, @Address, @DateOfBirth, @NationalityCountryID, @ImagePath, @NationalNo, @Gender); " +
                            "SELECT SCOPE_IDENTITY();";
            SqlCommand Command = new SqlCommand(query, Connection);

            Command.Parameters.AddWithValue("@FirstName", FirstName);
            Command.Parameters.AddWithValue("@SecondName", SecondName);
            Command.Parameters.AddWithValue("@LastName", LastName);
            Command.Parameters.AddWithValue("@NationalNo", NationalNo);
            Command.Parameters.AddWithValue("@Phone", Phone);
            Command.Parameters.AddWithValue("@Address", Address);
            Command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            Command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);
            Command.Parameters.AddWithValue("@Gender", Gender);

            if (Email != "")
                Command.Parameters.AddWithValue("@Email", Email);
            else
                Command.Parameters.AddWithValue("@Email", System.DBNull.Value);
            if (ThirdName != "")
                Command.Parameters.AddWithValue("@ThirdName", ThirdName);
            else
                Command.Parameters.AddWithValue("@ThirdName", System.DBNull.Value);
            if (ImagePath != "")
                Command.Parameters.AddWithValue("@ImagePath", ImagePath);
            else
                Command.Parameters.AddWithValue("@ImagePath", System.DBNull.Value);

            try
            {
                Connection.Open();

                object result = Command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    newPersonID = insertedID;
                }

            }
            catch (Exception ex)
            {
                newPersonID = -1;
            }
            finally
            {
                Connection.Close();
            }
            return newPersonID;
        }
        public static bool UpdatePersonInfo(int PersonID, string NationalNo, string FirstName, string SecondName, string LastName, DateTime DateOfBirth, byte Gender,
            string Address, string Phone, int NationalityCountryID, string ImagePath = null, string ThirdName = null, string Email = null)
        {
            int rowsAffected = 0;

            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = "UPDATE People SET NationalNo=@NationalNo, FirstName=@FirstName, SecondName=@SecondName, ThirdName=@ThirdName, LastName=@LastName, Email=@Email," +
                           " Phone=@Phone, Address=@Address, DateOfBirth=@DateOfBirth, NationalityCountryID=@NationalityCountryID, ImagePath=@ImagePath, Gender=@Gender " +
                           "WHERE PersonID=@PersonID";
            SqlCommand Command = new SqlCommand(query, Connection);

            Command.Parameters.AddWithValue("@PersonID", PersonID);
            Command.Parameters.AddWithValue("@FirstName", FirstName);
            Command.Parameters.AddWithValue("@SecondName", SecondName);
            Command.Parameters.AddWithValue("@LastName", LastName);
            Command.Parameters.AddWithValue("@NationalNo", NationalNo);
            Command.Parameters.AddWithValue("@Phone", Phone);
            Command.Parameters.AddWithValue("@Address", Address);
            Command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            Command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);
            Command.Parameters.AddWithValue("@Gender", Gender);

            if (Email != "")
                Command.Parameters.AddWithValue("@Email", Email);
            else
                Command.Parameters.AddWithValue("@Email", System.DBNull.Value);
            if (ThirdName != "")
                Command.Parameters.AddWithValue("@ThirdName", ThirdName);
            else
                Command.Parameters.AddWithValue("@ThirdName", System.DBNull.Value);
            if (ImagePath != "")
                Command.Parameters.AddWithValue("@ImagePath", ImagePath);
            else
                Command.Parameters.AddWithValue("@ImagePath", System.DBNull.Value);


            try
            {
                Connection.Open();

                rowsAffected = Command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                rowsAffected = 0;
            }
            finally
            {
                Connection.Close();
            }

            return (rowsAffected > 0);
        }
        public static bool DeletePersonWithID(int PersonID)
        {
            int rowsAffected = 0;

            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = "DELETE FROM PEOPLE WHERE PersonID=@PersonID";
            SqlCommand Command = new SqlCommand(query, Connection);

            Command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                Connection.Open();

                rowsAffected = Command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                rowsAffected = 0;
            }
            finally
            {
                Connection.Close();
            }

            return (rowsAffected > 0);
        }
    }
}
