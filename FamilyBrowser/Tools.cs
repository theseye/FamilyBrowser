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
            System.Windows.MessageBox.Show(message);
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
    }
}
