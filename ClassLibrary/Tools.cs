using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using FamilyBrowser;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media.Imaging;

namespace FamliyBrowser
{
    public class Tools
    {
        public static void ShowMessageBox(string message)
        {
            MessageBox.Show(message);
        }

        public static BitmapSource GetImage(IntPtr bm)
        {
            BitmapSource bmSource = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
                bm,
                IntPtr.Zero,
                Int32Rect.Empty,
                BitmapSizeOptions.FromEmptyOptions());
            return bmSource;
        }

        public static void LoadFamily(UIDocument uidoc, string SelectedItem_Text)
        {
            var fileName = Path.Combine(Path.GetTempPath(), "Bimcc", SelectedItem_Text) + ".rfa";

            if (File.Exists(fileName))
            {
                //
            }
            else
            {
                var http = new WebClient();

                http.DownloadFile("http://img01.pinming.cn/8a9b6c3d6209756f01621d38a19a01de.rfa?Expires=1532929251&OSSAccessKeyId=LTAI8ZbJOm3c5VVZ&Signature=dOA6DRrM2eQxtfg7qwjtYpvO73c%3D", fileName);
            }


            using (Transaction trans = new Transaction(uidoc.Document, "载入族"))
            {
                trans.Start();

                uidoc.Document.LoadFamily(fileName);

                trans.Commit();
            }
        }
    }
}
