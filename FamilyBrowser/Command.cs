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


namespace FamilyBrowser
{
    [Transaction(TransactionMode.Manual)]

    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;

            //找到当前文档所有族
            var FamilyCollector = new FilteredElementCollector(uidoc.Document).OfClass(typeof(Family));

            //收集所有FamilyData的信息，并储存在Data里
            var Data = new List<FamilyData>();

            foreach (Family item in FamilyCollector)
            {
                foreach (var symbolId in item.GetFamilySymbolIds())
                {
                    var symbol = item.Document.GetElement(symbolId) as FamilySymbol;

                    var FamilyData = new FamilyData
                    {
                        family_name = item.Name,

                        symbol_name = symbol.Name,

                        category_name = symbol.Category.Name,

                        family_symbol = symbol
                    };

                    Data.Add(FamilyData);
                }
            }

            var exEvent = ExternalEvent.Create(new FamilyLoad());

            if (FamilyBrowser.Family_browser == null)
            {
                var browser = new FamilyBrowser(uidoc, exEvent, Data);

                browser.ShowDialog();
            }
            else
            {
                FamilyBrowser.Family_browser.ShowDialog();
            }

            return Result.Succeeded;
        }
    }
}
