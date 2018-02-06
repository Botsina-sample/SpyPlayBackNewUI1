using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;
using System.Windows.Forms;
namespace SimplePlayBack.Actions
{
    class ComboBoxAction : AbsAction
    {
        public override void DoExecute()
        {
            AutomationElement a = UiElement.AutomationElement;

            //Console.WriteLine(a.Current.AutomationId);

            ExpandCollapsePattern expandCollapsePattern = a.GetCurrentPattern(ExpandCollapsePattern.Pattern) as ExpandCollapsePattern;
            expandCollapsePattern.Expand();
            var components = a.FindAll(TreeScope.Subtree, Condition.TrueCondition);

            var comboBoxEditItemCondition = new System.Windows.Automation.PropertyCondition(AutomationElement.ClassNameProperty, "ListBoxItem");
            var listItems = a.FindAll(TreeScope.Subtree, comboBoxEditItemCondition);//It can only get one item in the list (the first one).
            Console.WriteLine(listItems.Count.ToString());
            switch (PlaybackObject.action)
            {
                case "SetText":
                    try
                    {
                        (listItems[PlaybackObject.itemIndex].GetCurrentPattern(SelectionItemPattern.Pattern) as SelectionItemPattern).Select();
                        Result = true;
                    }
                    catch (Exception)
                    {
                        Result = false;
                        throw;
                    }
                    break;
                case "Select":
                    try
                    {
                        ((ValuePattern)a.GetCurrentPattern(ValuePattern.Pattern)).SetValue(PlaybackObject.text);
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
            
            expandCollapsePattern.Collapse();
        }
    }
}
