using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using DiagnosticCenterBillManagementSystemApp.Models;

namespace DiagnosticCenterBillManagementSystemApp.DLL
{
    public class TestGateway
    {
        string connectionString = WebConfigurationManager.ConnectionStrings["DiagnosticBillManagementDBConnectionString"].ConnectionString;
        public int InsertTest(Test test)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO Test(testName, fee, testType, TestTypeId) VALUES('" + test.Name + "','" + test.Fee + "','" + test.TestType + "'," + test.TestTypeId + ")";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }
        public List<Test> GetAllTests()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM Test";
            SqlCommand command = new SqlCommand(query, connection);
            List<Test> testList = new List<Test>();
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id = int.Parse(reader["ID"].ToString());
                string testName = reader["TestName"].ToString();
                string fee = reader["Fee"].ToString();
                string testType = reader["TestType"].ToString();
                int TestTypeId = int.Parse(reader["TestTypeId"].ToString());
                Test test = new Test(id, testName, fee, testType, TestTypeId);
                testList.Add(test);
            }
            connection.Close();
            return testList;
        }
        public Test GetTestByTestType(string testType)
        {
 	        SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM Test WHERE TestType='" + testType + "'";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            Test test = null;

            if (reader.Read())
            {
                int id = int.Parse(reader["ID"].ToString());
                string testName = reader["TestName"].ToString();
                string fee = reader["Fee"].ToString();
                testType = reader["TestType"].ToString();
                int TestTypeId = int.Parse(reader["TestTypeId"].ToString());

                test = new Test(id, testName, fee, testType, TestTypeId);
            }

            return test;
}
        public int Update(Test test)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "UPDATE Test SET TestType='" + test.TestType + "',TestName='" + test.Name + "',Fee='" +
                           test.Fee + "'TestTypeId=" + test.TestTypeId + " WHERE ID=" + test.Id + "";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            int rowsAffected = command.ExecuteNonQuery();
            connection.Close();

            return rowsAffected;
        }
        public bool IsTestTypeExistsForOther(Test test)
        {
            bool isExists = false;
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM Test WHERE TestType='" + test.TestType + "' AND ID<>'" + test.Id +
                           "'";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();


            isExists = reader.HasRows;

            connection.Close();

            return isExists;

        }
    }
}