using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyBrowser
{
    public class FamilyData
    {
        public string parent_id { get; set; }

        public string folder_id { get; set; }

        public string folder_name { get; set; }

        public string family_name { get; set; }

        public string category_name { get; set; }

        public string symbol_name { get; set; }

        public FamilySymbol family_symbol { get; set; }
    }
}
