using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System.Collections.Generic;
using Autodesk.Revit.UI.Selection;

namespace _002_HelloWorld
{
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    public class A002_SelectElement : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;

            // Lấy danh sách ElementId
            List<ElementId> selectedElementIds = uidoc.Selection.GetElementIds().ToList();

            // Chuyển đổi ElementId thành Element
            List<Element> selectElements = selectedElementIds
                .Select(id => doc.GetElement(id)) // Lấy Element từ ElementId
                .Where(el => el != null) // Lọc bỏ phần tử null
                .ToList(); // Chuyển thành danh sách

            int totalCount = selectElements.Count;
            MessageBox.Show("Bạn đã chọn " + totalCount.ToString() + " elements");

            return Result.Succeeded;
        }
        namespace A003_SelectEdge
    {
        [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
        public class Class1 : IExternalCommand
        {
            public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
            {
                UIDocument uidoc = commandData.Application.ActiveUIDocument;
                IList<Reference> referenceCollection = uidoc.Selection.PickObjects(ObjectType.Edge);
                MessageBox.Show("You have selected total " + referenceCollection.Count.ToString() + " Edges.");

                return Result.Succeeded;
            }
        }
    }


}

}
