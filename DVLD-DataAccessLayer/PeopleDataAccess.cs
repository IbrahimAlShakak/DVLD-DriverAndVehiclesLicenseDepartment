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
            string query = "SELECT * FROM People;";
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

    }
}
