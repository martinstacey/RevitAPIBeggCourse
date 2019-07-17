#region Namespaces
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Media.Imaging;



#endregion

namespace MyTest
{
    class App : IExternalApplication
    {
        public Result OnStartup(UIControlledApplication a)
        {
            RibbonPanel panel = ribbonPanel(a);
            string thisAssemblyPath = Assembly.GetExecutingAssembly().Location;
            PushButton button = panel.AddItem(new PushButtonData("Button","Test Button", thisAssemblyPath,"MyTest.Command")) as PushButton;
            button.ToolTip = "this is sample";
            var globePath = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location),"LACMA DOORS.png");
            Uri uriImage = new Uri(globePath);
            BitmapImage largeImage = new BitmapImage(uriImage);
            button.LargeImage = largeImage;
            return Result.Succeeded;
        }

        void a_Idling(object sender, Autodesk.Revit.UI.Events.IdlingEventArgs a)
        {



        }


        void a_ApplicationClosing(object sender, Autodesk.Revit.UI.Events.ApplicationClosingEventArgs a)
        {
            throw new NotImplementedException();

        }



        public RibbonPanel ribbonPanel(UIControlledApplication a)
        {
            string tab = "My Test Tab";
            RibbonPanel ribbonPanel = null;
            try
            {
                a.CreateRibbonPanel("My Test Tools");
            }
            catch { }
            try {
                a.CreateRibbonTab(tab);
            }
            catch { }
            try
            {
                RibbonPanel panel = a.CreateRibbonPanel(tab, "test");
            }
            catch { }

            List<RibbonPanel> panels =a.GetRibbonPanels(tab);
            foreach (RibbonPanel p in panels)
            {
                if (p.Name=="test")
                {
                    ribbonPanel = p;
                }
            }
            return ribbonPanel;
        }


        public Result OnShutdown(UIControlledApplication a)
        {
            return Result.Succeeded;
        }
    }
}
