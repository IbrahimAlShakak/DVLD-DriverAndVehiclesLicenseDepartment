using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_DataAccessLayer
{
    public static class DetainedLicensesData
    {
        public static bool GetDetainedLicenseInfoByID(int DetainID, ref int LicenseID, ref DateTime DetainDate, ref float FineFees,
            ref int CreatedByUserID, ref bool IsReleased, ref DateTime ? ReleaseDate, ref int ReleasedByUserID,
            ref int ReleaseApplicationID)
        {
            bool isFound = false;

            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = "SELECT TOP(1) * FROM DetainedLicenses WHERE DetainID=@DetainID ORDER BY DetainID DESC;";

            SqlCommand Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@DetainID", DetainID);

            try
            {
                Connection.Open();
                SqlDataReader reader = Command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;

                    LicenseID = (int)reader["LicenseID"];
                    DetainDate = (DateTime)reader["DetainDate"];
                    FineFees = Convert.ToSingle(reader["FineFees"]);
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    IsReleased = (bool)reader["IsReleased"];
                    ReleaseDate = reader["ReleaseDate"] == DBNull.Value ? (DateTime?)null : (DateTime)reader["ReleaseDate"];
                    ReleasedByUserID = reader["ReleasedByUserID"] == DBNull.Value ? -1 : (int)reader["ReleasedByUserID"];
                    ReleaseApplicationID = reader["ReleaseApplicationID"] == DBNull.Value ? -1 : (int)reader["ReleaseApplicationID"];
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
        public static bool GetDetainedLicenseInfoByLicneseID(int LicenseID, ref int DetainID , ref DateTime DetainDate, ref float FineFees,
            ref int CreatedByUserID, ref bool IsReleased, ref DateTime? ReleaseDate, ref int ReleasedByUserID,
            ref int ReleaseApplicationID)
        {
            bool isFound = false;

            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = "SELECT TOP(1) * FROM DetainedLicenses WHERE LicenseID=@LicenseID ORDER BY DetainID DESC;";

            SqlCommand Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@LicenseID", LicenseID);

            try
            {
                Connection.Open();
                SqlDataReader reader = Command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;

                    DetainID = (int)reader["DetainID"];
                    DetainDate = (DateTime)reader["DetainDate"];
                    FineFees = Convert.ToSingle(reader["FineFees"]);
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    IsReleased = (bool)reader["IsReleased"];
                    ReleaseDate = reader["ReleaseDate"] == DBNull.Value ? (DateTime?)null : (DateTime)reader["ReleaseDate"];
                    ReleasedByUserID = reader["ReleasedByUserID"] == DBNull.Value ? -1 : (int)reader["ReleasedByUserID"];
                    ReleaseApplicationID = reader["ReleaseApplicationID"] == DBNull.Value ? -1 : (int)reader["ReleaseApplicationID"];
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
        public static int AddNewDetainedLicense(int LicenseID, DateTime DetainDate, float FineFees, int CreatedByUserID, 
            bool IsReleased, DateTime? ReleaseDate, int ReleasedByUserID, int ReleaseApplicationID)
        {
            int newDetainedLicenseID = -1;


            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = @"INSERT INTO DetainedLicenses (LicenseID, DetainDate, FineFees, CreatedByUserID, IsReleased,
                                        ReleaseDate, ReleasedByUserID, ReleaseApplicationID) 
                            VALUES (@LicenseID, @DetainDate, @FineFees, @CreatedByUserID, @IsReleased, 
                                    @ReleaseDate, @ReleasedByUserID, @ReleaseApplicationID); 
                            SELECT SCOPE_IDENTITY();";
            SqlCommand Command = new SqlCommand(query, Connection);

            Command.Parameters.AddWithValue("@LicenseID", LicenseID);
            Command.Parameters.AddWithValue("@DetainDate", DetainDate);
            Command.Parameters.AddWithValue("@FineFees", FineFees);
            Command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            Command.Parameters.AddWithValue("@IsReleased", IsReleased);

            if (ReleaseDate != null)
                Command.Parameters.AddWithValue("@ReleaseDate", ReleaseDate);
            else
                Command.Parameters.AddWithValue("@ReleaseDate", System.DBNull.Value);

            if (ReleasedByUserID != -1)
                Command.Parameters.AddWithValue("@ReleasedByUserID", ReleasedByUserID);
            else
                Command.Parameters.AddWithValue("@ReleasedByUserID", System.DBNull.Value);

            if (ReleaseApplicationID != -1)
                Command.Parameters.AddWithValue("@ReleaseApplicationID", ReleaseApplicationID);
            else
                Command.Parameters.AddWithValue("@ReleaseApplicationID", System.DBNull.Value);

            try
            {
                Connection.Open();

                object result = Command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    newDetainedLicenseID = insertedID;
                }

            }
            catch (Exception ex)
            {
                newDetainedLicenseID = -1;
            }
            finally
            {
                Connection.Close();
            }
            return newDetainedLicenseID;
        }
        public static bool UpdateDetainedLicense(int DetainID, int LicenseID, DateTime DetainDate, float FineFees, int CreatedByUserID,
            bool IsReleased, DateTime? ReleaseDate, int ReleasedByUserID, int ReleaseApplicationID)
        {
            int rowsAffected = 0;

            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = @"UPDATE DetainedLicenses
                            SET LicenseID=@LicenseID, DetainDate=@DetainDate, FineFees=@FineFees, CreatedByUserID=@CreatedByUserID, 
                                IsReleased=@IsReleased, ReleaseDate=@ReleaseDate,
                                ReleasedByUserID=@ReleasedByUserID, ReleaseApplicationID=@ReleaseApplicationID 
                                WHERE DetainID=@DetainID";
            SqlCommand Command = new SqlCommand(query, Connection);

            Command.Parameters.AddWithValue("@DetainID", DetainID);
            Command.Parameters.AddWithValue("@LicenseID", LicenseID);
            Command.Parameters.AddWithValue("@DetainDate", DetainDate);
            Command.Parameters.AddWithValue("@FineFees", FineFees);
            Command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            Command.Parameters.AddWithValue("@IsReleased", IsReleased);

            if (ReleaseDate != null)
                Command.Parameters.AddWithValue("@ReleaseDate", ReleaseDate);
            else
                Command.Parameters.AddWithValue("@ReleaseDate", System.DBNull.Value);

            if (ReleasedByUserID != -1)
                Command.Parameters.AddWithValue("@ReleasedByUserID", ReleasedByUserID);
            else
                Command.Parameters.AddWithValue("@ReleasedByUserID", System.DBNull.Value);

            if (ReleaseApplicationID != -1)
                Command.Parameters.AddWithValue("@ReleaseApplicationID", ReleaseApplicationID);
            else
                Command.Parameters.AddWithValue("@ReleaseApplicationID", System.DBNull.Value);


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
        public static DataTable GetAllDetainedLicenses()
        {
            DataTable dt = new DataTable();

            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = "SELECT * FROM DetainedLicenses_View";
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
        public static bool IsLicenseDetained(int LicenseID)
        {
            bool IsDetained = false;

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = @"select IsDetained=1 
                            from DetainedLicenses 
                            where 
                            LicenseID=@LicenseID 
                            and IsReleased=0;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseID", LicenseID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null)
                {
                    IsDetained = Convert.ToBoolean(result);
                }
            }

            catch (Exception ex)
            {
                IsDetained = false;
            }
            finally
            {
                connection.Close();
            }
            return IsDetained;
        }
    }
}
