using DiagnosticCenterBillManagementSystemApp.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DiagnosticCenterBillManagementSystemApp.Models;

namespace DiagnosticCenterBillManagementSystemApp.UI
{
    public partial class TestUI : System.Web.UI.Page
    {
        TestManager _testManager = new TestManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["testType"] != null)
                {
                    string testType = Request.QueryString["testType"];
                    Test test = _testManager.GetTestByTestType(testType);
                    testNameTextBox.Text = test.Name;
                    feeTextBox.Text = test.Fee;
                    testTypeDropDownList.Text = test.TestType;
                    testIdHiddenField.Value = test.Id.ToString();
                    testTypeDropDownList.SelectedValue = test.TestTypeId.ToString();
                    saveButton.Text = "Update";
                }
                FillAllTest();
                LoadTestTypeDropdown();
            }
        }
        private void LoadTestTypeDropdown()
        {
            TestTypeManager testTypeManager = new TestTypeManager();
            List<TestType> testTypes = testTypeManager.GetAllTestTypes();
            testTypeDropDownList.DataSource = testTypes;
            testTypeDropDownList.DataTextField = "TypeName";
            testTypeDropDownList.DataValueField = "TypeName";
            testTypeDropDownList.DataBind();
        }
        protected void saveButton_Click(object sender, EventArgs e)
        {
            string testName = testNameTextBox.Text;
            string fee = feeTextBox.Text;
            string testType = testTypeDropDownList.Text;
            int testTypeId = Convert.ToInt32(testTypeDropDownList.SelectedValue);
            Test test = null;
            if (testIdHiddenField.Value != "")
            {
                int testId = Convert.ToInt32(testIdHiddenField.Value);
                test = new Test(testId, testName, fee, testType, testTypeId);
            }
            else
            {
                test = new Test(testName, fee, testType, testTypeId);
            }

            string message = "";
            if (saveButton.Text == "Update")
            {
                message = _testManager.UpdateTest(test);
            }
            else
            {
                message = _testManager.SaveTest(test);
            }
            Response.Write(message);
            FillAllTest();
        }
        private void FillAllTest()
        {
            List<Test> tests = _testManager.GetAllTests();
            testSetupGridView.DataSource = tests;
            testSetupGridView.DataBind();
        }
    }
}