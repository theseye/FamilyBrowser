using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static FamilyBrowser.Family_Browser;

namespace FamilyBrowser
{
    class LoadFamily : IExternalEventHandler
    {
        public void Execute(UIApplication app)
        {
            UIDocument uidoc = app.ActiveUIDocument;

            Document doc = uidoc.Document;

            Family Family;

            //载入族
            using (Transaction trans = new Transaction(uidoc.Document, "载入族"))
            {
                trans.Start();

                uidoc.Document.LoadFamily(Family_Browser.fileName, out Family);

                trans.Commit();
            }

            //找到所有指定名称的族

            ISet<ElementId> FamilySymbolIds = Family.GetFamilySymbolIds();

            var symbols = new List<FamilyData>();

            //把Symbol的name,symbol储存在symbols里，以便调用
            foreach (var FamilySymbolId in FamilySymbolIds)
            {
                var FamilyData = new FamilyData();

                FamilyData.symbol = Family.Document.GetElement(FamilySymbolId) as FamilySymbol;

                FamilyData.symbol_name = FamilyData.symbol.Name;

                symbols.Add(FamilyData);
            }

            if (symbols.Count == 1)
            {
                uidoc.PostRequestForElementTypePlacement(symbols[0].symbol);
            }
            //如果族类型数量大于1，就出现选择窗体
            else
            {
                new Symbol_Choose(uidoc, symbols).ShowDialog();
            }
        }

        public string GetName()
        {
            throw new NotImplementedException();
        }
    }
}
