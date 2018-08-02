using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Structure;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static FamilyBrowser.Family_browser;


namespace FamilyBrowser
{
    [Transaction(TransactionMode.Manual)]

    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;

            UIDocument uidoc = commandData.Application.ActiveUIDocument;

            var family_collect = new FilteredElementCollector(uidoc.Document).OfClass(typeof(Family));

            var Data = new List<FamilyData>();

            foreach (var item in family_collect)
            {
                var family = item as Family;

                foreach (var symbol_id in family.GetFamilySymbolIds())
                {
                    var FamilyData = new FamilyData();

                    FamilyData.family_name = family.Name;

                    var symbol = family.Document.GetElement(symbol_id) as FamilySymbol;

                    FamilyData.symbol_name = symbol.Name;

                    FamilyData.category_name = symbol.Category.Name;

                    FamilyData.symbol = symbol;

                    Data.Add(FamilyData);
                }
            }

            ExternalEvent exEvent = ExternalEvent.Create(new LoadFamily());

            ExternalEvent exEvent_local = ExternalEvent.Create(new LoadFamily_local());

            if (Form_Browser == null)
            {
                var Form_browser = new Family_browser(uidoc, exEvent, Data, exEvent_local);

                Form_browser.Show();
            }
            else
            {
                Form_Browser.Show();
            }

            return Result.Succeeded;
        }

        private Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            var filename = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            if (args.Name.Contains("EasyHttp"))
            {
                filename = Path.Combine(filename, "EasyHttp.dll");

                if (File.Exists(filename))
                {
                    return Assembly.LoadFrom(filename);
                }
            }
            else if (args.Name.Contains("JsonFx"))
            {
                filename = Path.Combine(filename, "JsonFx.dll");

                if (File.Exists(filename))
                {
                    return System.Reflection.Assembly.LoadFrom(filename);
                }
            }
            else if (args.Name.Contains("Newtonsoft.Json"))
            {
                filename = Path.Combine(filename, "Newtonsoft.Json.dll");

                if (File.Exists(filename))
                {
                    return Assembly.LoadFrom(filename);
                }
            }
            return null;
        }
    }
}
