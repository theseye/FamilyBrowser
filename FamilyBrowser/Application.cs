using Autodesk.Revit.DB.Events;
using Autodesk.Revit.UI;
using FamilyBrowser.Properties;
using FamliyBrowser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static FamilyBrowser.Family_browser;

namespace FamilyBrowser
{
    class Application : IExternalApplication
    {
        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }

        public Result OnStartup(UIControlledApplication application)
        {
            string Assembly_path = Assembly.GetExecutingAssembly().Location;

            application.CreateRibbonTab("筑云族库");

            RibbonPanel BimccRibbon = application.CreateRibbonPanel("筑云族库", "BIMCC Family");

            (BimccRibbon.AddItem(new PushButtonData("family_public", "公共族库", Assembly_path, "FamilyBrowser.Command")) as PushButton).LargeImage = Tools.GetImage(Resources.browser.GetHbitmap());

            application.ControlledApplication.DocumentOpened += ControlledApplication_DocumentOpened;

            return Result.Succeeded;
        }

        void ControlledApplication_DocumentOpened(object sender, DocumentOpenedEventArgs e)
        {
            Family_browser.Form_Browser = null;
        }
    }
}
