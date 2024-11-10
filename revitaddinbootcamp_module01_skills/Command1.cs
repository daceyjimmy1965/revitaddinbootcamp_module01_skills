using System.CodeDom;

namespace revitaddinbootcamp_module01_skills
{
    [Transaction(TransactionMode.Manual)]
    public class Command1 : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            // this is a variable for the Revit application
            UIApplication uiapp = commandData.Application;

            // this is a variable for the current Revit model
            Document doc = uiapp.ActiveUIDocument.Document;

            // Your code goes here
            string text1 = "this is my text";
            string text2 = "this is my next text";
            string text3 = text1 + text2;
            string text4 = text1 + " " + text2 + "abcd";

            int number1 = 10;
            double number2 = 20.5;

            double number3 = number1 + number2;
            double number4 = number3 + number2;
            double number5 = number4 / number3;
            double number6 = number5 * number4;
            double number7 = (number6 + number5) / number4;

            double meters = 4;
            double metrsToFeet = meters * 3.28084;

            // create a transaction
            Transaction t = new Transaction(doc);
            t.Start("doing something in revit");

            // create a floor level
            double elevation = 100;
            Level newLevel = Level.Create(doc, elevation);
            newLevel.Name = "my new level";

            // create a floor plan

            FilteredElementCollector collector1 = new FilteredElementCollector(doc);
            collector1.OfClass(typeof(ViewFamilyType));







            t.Commit();
            t.Dispose();


























            return Result.Succeeded;








        }
        internal static PushButtonData GetButtonData()
        {
            // use this method to define the properties for this command in the Revit ribbon
            string buttonInternalName = "btnCommand1";
            string buttonTitle = "Button 1";
            string? methodBase = MethodBase.GetCurrentMethod().DeclaringType?.FullName;

            if (methodBase == null)
            {
                throw new InvalidOperationException("MethodBase.GetCurrentMethod().DeclaringType?.FullName is null");
            }
            else
            {
                Common.ButtonDataClass myButtonData1 = new Common.ButtonDataClass(
                    buttonInternalName,
                    buttonTitle,
                    methodBase,
                    Properties.Resources.Blue_32,
                    Properties.Resources.Blue_16,
                    "This is a tooltip for Button 1");

                return myButtonData1.Data;
            }
        }
    }

}
