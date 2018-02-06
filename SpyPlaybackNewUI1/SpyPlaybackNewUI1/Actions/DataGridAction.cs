using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;
using Gu.Wpf.UiAutomation;
namespace SimplePlayBack.Actions
{
    class DataGridAction : AbsAction
    {
        public override void DoExecute()
        {

            //UiElement.AsDataGrid().Row(1).Select();

            switch (PlaybackObject.action)
            {
                case "Select":
                    try
                    {
                        var selectedItem = UiElement.AsDataGrid().Row(PlaybackObject.itemIndex);
                        if (selectedItem.FindFirst(TreeScope.Subtree, new System.Windows.Automation.PropertyCondition(AutomationElement.ClassNameProperty, "CheckBox")).AsCheckBox().IsChecked == false)
                        {
                            UiElement.AsDataGrid().Select(PlaybackObject.itemIndex);
                            Result = true;
                        }
                        else
                            Result = false;
                    }
                    catch (Exception)
                    {
                        Result = false;
                        throw;
                    }
                    break;
                case "Unselect":
                    try
                    {
                        var selectedItem = UiElement.AsDataGrid().Row(PlaybackObject.itemIndex);
                        if (selectedItem.FindFirst(TreeScope.Subtree, new System.Windows.Automation.PropertyCondition(AutomationElement.ClassNameProperty, "CheckBox")).AsCheckBox().IsChecked == true)
                        {
                            UiElement.AsDataGrid().Select(PlaybackObject.itemIndex);
                            Result = true;
                        }
                        else
                            Result = false;
                    }
                    catch (Exception)
                    {
                        Result = false;
                        throw;
                    }
                    break;
                case "DoubleClick":
                    try
                    {
                        var cells = UiElement.AsDataGrid().Row(PlaybackObject.itemIndex).Cells;
                        cells[0].AsGridCell().DoubleClick();
                        Result = true;
                    }
                    catch (Exception)
                    {
                        Result = false;
                        throw;
                    }
                    break;

                default:
                    Result = false;
                    break;
            }
        }
     }
}
