using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace _002_HelloWorld
{
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    public class A002_SelectElement : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            ICollection<Element> selectElements = (ICollection<Element>)uidoc.Selection.GetElementIds();

            int totalCount = selectElements.Count;
            MessageBox.Show("Ban da chon" + totalCount.ToString() + "elements" ;
            return Result.Succeeded;
        }
    }
}
