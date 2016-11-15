using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiagnosticCenterBillManagementSystemApp.Models.TestTypeModelView
{
    public class TestRequest
    {
        public TestRequest(int testRequestId, string patientName, DateTime dob, int mobileNo, string selectText)
        {
            this.TestRequestId = testRequestId;
            this.PatientName = patientName;

            this.DOB = dob;
            this.MobileNo = mobileNo;
            this.SelectText = selectText;

        }
        public int TestRequestId { get; set; }
        public string SelectText { get; set; }
        public int MobileNo { get; set; }
        public DateTime DOB { get; set; }
        public string PatientName { get; set; }
    }
}