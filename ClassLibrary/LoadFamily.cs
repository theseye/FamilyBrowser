using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FamilyBrowser
{
    class LoadFamily : IExternalEventHandler
    {
        public void Execute(UIApplication app)
        {
            var fileName = Path.Combine(Path.GetTempPath(), "Bimcc", Form_browser.symbol_name) + ".rfa";

            if (File.Exists(fileName))
            {
                //
            }
            else
            {
                var http = new WebClient();

                http.DownloadFile("http://img01.pinming.cn/8a9b6c3d6209756f01621d38a19a01de.rfa?Expires=1532929251&OSSAccessKeyId=LTAI8ZbJOm3c5VVZ&Signature=dOA6DRrM2eQxtfg7qwjtYpvO73c%3D", fileName);
            }

            UIDocument uidoc = app.ActiveUIDocument;

            Document doc = uidoc.Document;

            using (Transaction trans = new Transaction(uidoc.Document, "载入族"))
            {
                trans.Start();

                uidoc.Document.LoadFamily(fileName);

                trans.Commit();
            }

            Family Family = new FilteredElementCollector(doc).OfClass(typeof(Family)).FirstOrDefault(e => e.Name.Equals(Form_browser.symbol_name)) as Family;

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
