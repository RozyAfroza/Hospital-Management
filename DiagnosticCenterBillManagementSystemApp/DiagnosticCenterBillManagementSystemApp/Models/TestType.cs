using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiagnosticCenterBillManagementSystemApp.BLL
{
    public class TestType
    {
        private int ID;
        public int SL;
        public string Name;
        public string typeName { get; set; }

        public TestType(int SL, string typeName)
        {
            this.SL = SL;
            this.typeName = typeName;
        }

        public TestType(string typeName)
        {
            this.typeName = typeName;
        }

        public TestType()
        {
         
        }

        public TestType(int ID, int SL, string Name)
        {
            // TODO: Complete member initialization
            this.ID = ID;
            this.SL = SL;
            this.Name = Name;
        }
    }
}