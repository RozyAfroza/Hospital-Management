using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiagnosticCenterBillManagementSystemApp.Models
{
    public class Test
    {

        public Test(int serialNo, string testName, string fee, string testType,int testTypeId)
        {
            this.SerialNo = serialNo;
            this.Name = testName;
            this.Fee = fee;
            this.TestType= testType;
            this.TestTypeId = testTypeId;

        }



        public Test(int id,int serialNo, string testName, string fee, string testType, int testTypeId): this(serialNo,testName, fee, testType, testTypeId)
        {
            Id = id;
        }

        public Test(string testName, string fee, string testType, int testTypeId)
        {
            this.Name = testName;
            this.Fee = fee;
            this.TestType = testType;
            this.TestTypeId = testTypeId;
        }
        public int SerialNo { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Fee { get; set; }
        public string TestType { get; set; }
        public int TestTypeId { get; set; }
    }
}