﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DiagnosticCenterBillManagementSystemApp.DLL;
using DiagnosticCenterBillManagementSystemApp.Models;

namespace DiagnosticCenterBillManagementSystemApp.BLL
{
    public class TestManager
    {
        TestGateway _testGateway = new TestGateway();

        public string SaveTest(Test test)
        {
            if (IsTestExists(test))
            {
                return "Test Type Already Exists!";
            }
            var rowAffected = _testGateway.InsertTest(test);

            if (rowAffected > 0)
            {
                return "Saved Successfully!";
            }
            return "Insertion Failed!";
        }
        public bool IsTestExists(Test test)
        {
            var isTestExists = false;
            if (test == null)
            {
                return isTestExists;
            }

            var existingTest = _testGateway.GetTestByTestType(test.TestType);

            isTestExists = existingTest != null;

            return isTestExists;
        }
        public Test GetTestByTestType(string testType)
        {
            return _testGateway.GetTestByTestType(testType);
        }
        public List<Test> GetAllTests()
        {
            return _testGateway.GetAllTests();
        }


        public string UpdateTest(Test test)
        {
            bool isTestTypeExistsForOther = _testGateway.IsTestTypeExistsForOther(test);

            if (isTestTypeExistsForOther)
            {
                return "Test Type already exists! ";
            }
            var rowsAffected = _testGateway.Update(test);

            if (rowsAffected > 0)
            {
                return "Updated successfully";
            }

            return "Update Failed!";
        }
    }
}