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
    public static class LocalDrivingLicensesData
    {
        public static bool GetLocalDrivingLicenseByID(int LocalDrivingLicenseApplicationID, ref int ApplicationID, ref int LicenseClassID)
        {
            bool isFound = false;

            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM LocalDrivingLicenseApplications WHERE LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID;";

            SqlCommand Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

            try
            {
                Connection.Open();

                SqlDataReader reader = Command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    LicenseClassID = (int)reader["LicenseClassID"];
                    ApplicationID = (int)reader["ApplicationID"];
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
        public static bool GetLocalDrivingLicenseByApplicationID(int ApplicationID, ref int LocalDrivingLicenseApplicationID, ref int LicenseClassID)
        {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = @"SELECT * FROM LocalDrivingLicenseApplications WHERE ApplicationID=@ApplicationID;";

            SqlCommand Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            try
            {
                Connection.Open();

                SqlDataReader reader = Command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    LocalDrivingLicenseApplicationID = (int)reader["LocalDrivingLicenseApplicationID"];
                    LicenseClassID = (int)reader["LicenseClassID"];
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
        public static int AddNewLocalDrivingLicenseApplication(int ApplicationID, int LicenseClassID)
        {
            int newApplicationID = -1;

            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = @"INSERT INTO LocalDrivingLicenseApplications (ApplicationID, LicenseClassID) 
                            VALUES (@ApplicationID, @LicenseClassID); 
                            SELECT SCOPE_IDENTITY();";

            SqlCommand Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            Command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);


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
        public static bool UpdateLocalDrivingLicenseApplication(int LocalDrivingLicenseApplicationID, int ApplicationID, int LicenseClassID)
        {
            int rowsAffected = 0;

            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = @"UPDATE LocalDrivingLicenseApplications SET ApplicationID=@ApplicationID, LicenseClassID=@LicenseClassID 
                                WHERE LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID";

            SqlCommand Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            Command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);


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
        public static bool DeleteLocalDrivingLicenseApplication(int LocalDrivingLicenseApplicationID)
        {
            int rowsAffected = 0;

            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = @"DELETE FROM LocalDrivingLicenseApplications WHERE LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID";

            SqlCommand Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

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
        public static DataTable GetLocalDrivingApplicationsList()
        {
            DataTable dt = new DataTable();
            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = @" SELECT * FROM LocalDrivingLicenseApplications_View ";
            SqlCommand Command = new SqlCommand(query, Connection);
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
        public static int GetNumberOfTestsPassed(int LocalDrivingLicenseApplicationID)
        {
            int resultNumer = -1;
            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = @"Select PassedTestCount from LocalDrivingLicenseApplications_View WHERE LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID;";
            SqlCommand Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            try
            {
                Connection.Open();
                object result = Command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int NumberOfTests))
                    resultNumer = NumberOfTests;
            }
            catch (Exception ex)
            {
                resultNumer = -1;
            }
            finally
            {
                Connection.Close();
            }
            return resultNumer;
        }
        public static bool DoesPassedAllThreeTests(int LocalDrivingLicenseApplicationID, int LicenseClassID)
        {
            bool isPassed = false;
            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = @" SELECT COUNT(*) FROM LocalDrivingLicenseApplications
                              INNER JOIN TestAppointments ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID
                              INNER JOIN Tests ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID
                              WHERE 
                              LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID 
                              AND LocalDrivingLicenseApplications.LicenseClassID=@LicenseClassID
                              AND Tests.TestResult = 1;";
            SqlCommand Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            Command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            try
            {
                Connection.Open();
                object result = Command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int NumberOfPassedTests))
                {
                    isPassed = (NumberOfPassedTests == 3);
                }
            }
            catch (Exception ex)
            {
                isPassed = false;
            }
            finally
            {
                Connection.Close();
            }
            return isPassed;
        }
        public static bool DidPassTest(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = @" SELECT x=1 FROM LocalDrivingLicenseApplications
                              INNER JOIN TestAppointments ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID
                              INNER JOIN Tests ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID
                              WHERE 
                              LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID 
                              AND TestAppointments.TestTypeID=@TestTypeID and Tests.TestResult = 1;";
            SqlCommand Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            Command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            try
            {
                Connection.Open();
                SqlDataReader reader = Command.ExecuteReader();
                isFound = reader.HasRows;
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
        public static bool DidAttendTest(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = @" SELECT top 1 Found=1
                            FROM LocalDrivingLicenseApplications INNER JOIN
                                 TestAppointments ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID INNER JOIN
                                 Tests ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID
                            WHERE
                            (LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID) 
                            AND(TestAppointments.TestTypeID = @TestTypeID)
                            ORDER BY TestAppointments.TestAppointmentID desc";
            SqlCommand Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            Command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            try
            {
                Connection.Open();
                SqlDataReader reader = Command.ExecuteReader();
                isFound = reader.HasRows;
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
        public static byte TotalTrialsPerTest(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            byte TotalTrialsPerTest = 0;
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = @" SELECT TotalTrialsPerTest = count(TestID)
                            FROM LocalDrivingLicenseApplications INNER JOIN
                                 TestAppointments ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID INNER JOIN
                                 Tests ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID
                            WHERE
                            (LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID) 
                            AND(TestAppointments.TestTypeID = @TestTypeID);";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && byte.TryParse(result.ToString(), out byte Trials))
                {
                    TotalTrialsPerTest = Trials;
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                connection.Close();
            }
            return TotalTrialsPerTest;
        }
        public static bool IsThereAnActiveScheduledTest(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {

            bool Result = false;
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = @" SELECT top 1 Found=1
                            FROM LocalDrivingLicenseApplications INNER JOIN
                                 TestAppointments ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID 
                            WHERE
                            (LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID)  
                            AND(TestAppointments.TestTypeID = @TestTypeID) and isLocked=0
                            ORDER BY TestAppointments.TestAppointmentID desc";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null)
                {
                    Result = true;
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                connection.Close();
            }
            return Result;
        }
    }
}
