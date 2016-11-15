using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using DiagnosticCenterBillManagementSystemApp.BLL;

namespace DiagnosticCenterBillManagementSystemApp.DLL
{
    public class TestTypeGateway
    {
        string connectionString = WebConfigurationManager.ConnectionStrings["DiagnosticBillManagementDBConnectionString"].ConnectionString;
        public List<TestType> GetAllTestTypes()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT *FROM TestType";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<TestType> testTypeList = new List<TestType>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    TestType testType = new TestType();
                    testType.SL = int.Parse(reader["SL"].ToString());
                    testType.typeName= reader["TypeName"].ToString();
                    testTypeList.Add(testType);
                    
                }
                reader.Close();               
            }
            connection.Close();
            return testTypeList;
        }
        public TestType GetTestBytypeName(string Name)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM TestType WHERE TypeName='" + Name + "'";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            TestType testType = null;
            if (reader.Read())
            {
                int id = int.Parse(reader["ID"].ToString());
                int SL = int.Parse(reader["SL"].ToString());
                string typeName = reader["Name"].ToString();
                testType = new TestType(id,SL,typeName);
            }
            return testType;
        }
        public int InsertTestType(TestType testType)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO TestType(SL,TypeName) VALUES(" + testType.SL + ",'" + testType.typeName + "')";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }
    }
}