using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static FamilyBrowser.Family_browser;

namespace FamilyBrowser
{
    class LoadFamily_local : IExternalEventHandler
    {
        public void Execute(UIApplication app)
        {
            UIDocument uidoc = app.ActiveUIDocument;

            Document doc = uidoc.Document;

            using (Transaction trans = new Transaction(uidoc.Document, "载入族"))
            {
                trans.Start();

                uidoc.Document.LoadFamily(Family_browser.family_path);

                trans.Commit();
            }

            var name = Family_browser.family_path.Substring(Family_browser.family_path.LastIndexOf("\\") + 1);

            name = name.Remove(name.LastIndexOf("."));

            Family Family = new FilteredElementCollector(doc).OfClass(typeof(Family)).FirstOrDefault(e => e.Name.Equals(name)) as Family;

            ISet<ElementId> FamilySymbolIds = Family.GetFamilySymbolIds();

            var symbols = new List<FamilyData>();

            foreach (var FamilySymbolId in FamilySymbolIds)
            {
                var FamilyData = new FamilyData();

                FamilyData.symbol = Family.Document.GetElement(FamilySymbolId) as FamilySymbol;

                FamilyData.symbol_name = Family.Document.GetElement(FamilySymbolId).Name;

                symbols.Add(FamilyData);
            }

            if (symbols.Count == 1)
            {
                uidoc.PostRequestForElementTypePlacement(symbols[0].symbol);
            }
            else
            {
                new symbol_choose(uidoc, symbols).ShowDialog();
            }
        }

        public string GetName()
        {
            throw new NotImplementedException();
        }
    }
}
