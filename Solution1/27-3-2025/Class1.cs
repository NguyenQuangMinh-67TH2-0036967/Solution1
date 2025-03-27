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
    namespace A005_TaoListElements
    {
        [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
        public class Class1 : IExternalCommand
        {
            public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
            {
                UIDocument uidoc = commandData.Application.ActiveUIDocument;
                ICollection<ElementId> selectedIds = uidoc.Selection.GetElementIds();
                TaskDialog.Show("Revit", "Số lượng đối tượng được chọn: " + selectedIds.Count.ToString());

                ICollection<ElementId> selectedWallIds = new List<ElementId>();
                foreach (ElementId id in selectedIds)
                {
                    Element element1 = uidoc.Document.GetElement(id);
                    if (element1 is Wall)
                    {
                        selectedWallIds.Add(id);
                    }
                }

                // Set the created element set as current select element set.
                uidoc.Selection.SetElementIds(selectedWallIds);
                if (0 != selectedWallIds.Count)
                {
                    TaskDialog.Show("Revit", selectedWallIds.Count.ToString() + " Đối tượng Tường đã được chọn!");
                }
                else
                {
                    TaskDialog.Show("Revit", "Không có đối tượng tường nào được chọn!");
                }

                return Result.Succeeded;
            }
        }
    }



}

}
