using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccessLayer
{
    public static class ApplicationsData
    {
        public static bool GetApplicationByID(int ApplicationID, ref int ApplicantPersonID, ref DateTime ApplicationDate, ref int ApplicationTypeID, ref byte ApplicationStatus
            , ref DateTime LastStatusDate, ref float PaidFees, ref int CreatedByUserID)
        {
            bool isFound = false;

            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM Applications WHERE ApplicationID=@ApplicationID;";

            SqlCommand Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            try
            {
                Connection.Open();

                SqlDataReader reader = Command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    ApplicantPersonID = (int)reader["ApplicantPersonID"];
                    ApplicationDate = (DateTime)reader["ApplicationDate"];
                    ApplicationTypeID = (int)reader["ApplicationTypeID"];
                    ApplicationStatus = (byte)reader["ApplicationStatus"];
                    LastStatusDate = (DateTime)reader["LastStatusDate"];
                    PaidFees = (float)reader["PaidFees"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                isFound = false;
            }
            finally
            {
                Connection.Close();
            }

            return isFound;

        }
        public static int AddNewApplication(int ApplicantPersonID, DateTime ApplicationDate, int ApplicationTypeID, byte ApplicationStatus
            , DateTime LastStatusDate, float PaidFees, int CreatedByUserID)
        {
            int newApplicationID = -1;

            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = @"INSERT INTO Applications (ApplicantPersonID, ApplicationDate, ApplicationTypeID, ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID) 
                            VALUES (@ApplicantPersonID, @ApplicationDate, @ApplicationTypeID, @ApplicationStatus, @LastStatusDate, @PaidFees, @CreatedByUserID); 
                            SELECT SCOPE_IDENTITY();";

            SqlCommand Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
            Command.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);
            Command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            Command.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
            Command.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
            Command.Parameters.AddWithValue("@PaidFees", PaidFees);
            Command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try
            {
                Connection.Open();

                object result = Command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                    newApplicationID = insertedID;

            }
            catch (Exception ex)
            {
                newApplicationID = -1;
            }
            finally
            {
                Connection.Close();
            }

            return newApplicationID;
        }
        public static bool UpdateApplication(int ApplicationID, int ApplicantPersonID, DateTime ApplicationDate, int ApplicationTypeID, byte ApplicationStatus
            , DateTime LastStatusDate, float PaidFees, int CreatedByUserID)
        {
            int rowsAffected = 0;

            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = @"UPDATE Applications SET ApplicantPersonID=@ApplicantPersonID,
                                ApplicationDate=@ApplicationDate, ApplicationTypeID=@ApplicationTypeID,
                                ApplicationStatus=@ApplicationStatus, LastStatusDate=@LastStatusDate,
                                PaidFees=@PaidFees, CreatedByUserID=@CreatedByUserID,
                                WHERE ApplicationID=@ApplicationID";

            SqlCommand Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            Command.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
            Command.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);
            Command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            Command.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
            Command.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
            Command.Parameters.AddWithValue("@PaidFees", PaidFees);
            Command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);


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
        public static bool DeleteApplication(int ApplicationID)
        {
            int rowsAffected = 0;

            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = @"DELETE FROM Applications WHERE ApplicationID=@ApplicationID";

            SqlCommand Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

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
        public static bool UpdateApplicationStatus(int ApplicationID, byte ApplicationStatus )
        {
            int rowsAffected = 0;

            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = @"UPDATE Applications SET   ApplicationStatus=@ApplicationStatus  WHERE ApplicationID=@ApplicationID";

            SqlCommand Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            Command.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);



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
