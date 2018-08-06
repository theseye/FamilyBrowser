using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyBrowser
{
    public class Family_Data
    {
        public string parent_id { get; set; }

        public string folder_id { get; set; }

        public string folder_name { get; set; }

        public string family_name { get; set; }

        public string category_name { get; set; }

        public string symbol_name { get; set; }

        public FamilySymbol symbol { get; set; }
    }
}
