using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_DataAccessLayer
{
    public static class TestAppointmentsData
    {
        
        public static bool GetTestAppointmentByID(int TestAppointmentID, ref int TestTypeID,
        ref int LocalDrivingLicenseApplicationID, ref DateTime AppointmentDate, ref float PaidFees,
        ref int CreatedByUserID, ref bool IsLocked, ref int RetakeTestApplicationID)
        {
            bool isFound = false;

            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM TestAppointments WHERE TestAppointmentID=@TestAppointmentID;";

            SqlCommand Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

            try
            {
                Connection.Open();

                SqlDataReader reader = Command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    TestTypeID = (int)reader["TestTypeID"];
                    LocalDrivingLicenseApplicationID = (int)reader["LocalDrivingLicenseApplicationID"];
                    AppointmentDate = (DateTime)reader["AppointmentDate"];
                    PaidFees = Convert.ToSingle(reader["PaidFees"]);
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    IsLocked = (bool)reader["IsLocked"];
                    RetakeTestApplicationID = reader["RetakeTestApplicationID"] == DBNull.Value ? -1 : (int)reader["RetakeTestApplicationID"]; //nullable
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
        public static bool GetLastTestAppointment(int LocalDrivingLicenseApplicationID, int TestTypeID,
        ref int TestAppointmentID, ref DateTime AppointmentDate, ref float PaidFees,
        ref int CreatedByUserID, ref bool IsLocked, ref int RetakeTestApplicationID)
        {
            bool isFound = false;

            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = @"SELECT TOP 1 * FROM TestAppointments 
                            WHERE LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID
                            AND TestTypeID=@TestTypeID
                            ORDER BY TestAppointmentID DESC;";

            SqlCommand Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            Command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                Connection.Open();

                SqlDataReader reader = Command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    TestAppointmentID = (int)reader["TestAppointmentID"];
                    AppointmentDate = (DateTime)reader["AppointmentDate"];
                    PaidFees = Convert.ToSingle(reader["PaidFees"]);
                    CreatedByUserID = (int)reader["ClassFees"];
                    IsLocked = (bool)reader["IsLocked"];
                    RetakeTestApplicationID = reader["RetakeTestApplicationID"] == DBNull.Value ? -1 : (int)reader["RetakeTestApplicationID"]; //nullable
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
        public static int AddNewTestAppointment(int TestTypeID, int LocalDrivingLicenseApplicationID, DateTime AppointmentDate, float PaidFees, int CreatedByUserID, 
            bool IsLocked, int RetakeTestApplicationID)
        {
            int newTestAppointmentID = -1;

            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = @"INSERT INTO TestAppointments (TestTypeID, LocalDrivingLicenseApplicationID, AppointmentDate, PaidFees, CreatedByUserID, IsLocked, RetakeTestApplicationID) 
                            VALUES (@TestTypeID, @LocalDrivingLicenseApplicationID, @AppointmentDate, @PaidFees, @CreatedByUserID, @IsLocked, @RetakeTestApplicationID); 
                            SELECT SCOPE_IDENTITY();";

            SqlCommand Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            Command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            Command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
            Command.Parameters.AddWithValue("@PaidFees", PaidFees);
            Command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            Command.Parameters.AddWithValue("@IsLocked", IsLocked);
            if (RetakeTestApplicationID != -1)
                Command.Parameters.AddWithValue("@RetakeTestApplicationID", RetakeTestApplicationID);
            else
                Command.Parameters.AddWithValue("@RetakeTestApplicationID", System.DBNull.Value);

            try
                {
                    Connection.Open();

                    object result = Command.ExecuteScalar();
                    if (result != null && int.TryParse(result.ToString(), out int insertedID))
                    newTestAppointmentID = insertedID;

                }
                catch (Exception ex)
                {
                newTestAppointmentID = -1;
                }
                finally
                {
                    Connection.Close();
                }

            return newTestAppointmentID;
        }
        public static bool UpdateTestAppointment(int TestAppointmentID, int TestTypeID, int LocalDrivingLicenseApplicationID, DateTime AppointmentDate, float PaidFees, int CreatedByUserID,
            bool IsLocked, int RetakeTestApplicationID)
        {
            int rowsAffected = 0;

            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = @"Update  TestAppointments  
                            set TestTypeID = @TestTypeID,
                                LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID,
                                AppointmentDate = @AppointmentDate,
                                PaidFees = @PaidFees,
                                CreatedByUserID = @CreatedByUserID,
                                IsLocked=@IsLocked,
                                RetakeTestApplicationID=@RetakeTestApplicationID
                                where TestAppointmentID = @TestAppointmentID";

            SqlCommand Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            Command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            Command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
            Command.Parameters.AddWithValue("@PaidFees", PaidFees);
            Command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            Command.Parameters.AddWithValue("@IsLocked", IsLocked);
            if (RetakeTestApplicationID != -1)
                Command.Parameters.AddWithValue("@RetakeTestApplicationID", RetakeTestApplicationID);
            else
                Command.Parameters.AddWithValue("@RetakeTestApplicationID", System.DBNull.Value);
            Command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);


            try
            {
                Connection.Open();
                rowsAffected = Command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                rowsAffected = 0;
            }
            finally
            {
                Connection.Close();
            }

            return (rowsAffected > 0);
        }
        public static bool DeleteTestAppointment(int TestAppointmentID)
        {
            int rowsAffected = 0;

            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = @"DELETE FROM TestAppointments WHERE LicenseClassID=@LicenseClassID";

            SqlCommand Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
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
        public static DataTable GetAllTestAppointmentsForLDLApplicationIDFilterByTestType(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            DataTable dt = new DataTable();

            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = @"SELECT TestAppointmentID, AppointmentDate, PaidFees ,IsLocked FROM TestAppointments 
                                WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID AND TestTypeID=@TestTypeID;";
            SqlCommand Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            Command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                Connection.Open();

                SqlDataReader reader = Command.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                reader.Close();

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
        public static int GetTestID(int TestAppointmentID)
        {
            int TestID = -1;

            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = @"Select TestID from Tests Where TestAppointmentID = @TestAppointmentID;";

            SqlCommand Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

            try
            {
                Connection.Open();

                object result = Command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                    TestID = insertedID;

            }
            catch (Exception ex)
            {
                TestID = -1;
            }
            finally
            {
                Connection.Close();
            }

            return TestID;
        }

    }
}

