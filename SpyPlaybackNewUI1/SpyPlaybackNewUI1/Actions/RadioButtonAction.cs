using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace SimplePlayBack.Actions
{
    class RadioButtonAction : AbsAction
    {
        public override void DoExecute()
        {
            switch (PlaybackObject.action)
            {
                case "Click":
                    try
                    {
                        if (UiElement.AsRadioButton().IsChecked == false)
                        {
                            UiElement.AsRadioButton().Click();
                            Result = true;
                        }
                    }
                    catch (Exception)
                    {
                        Result = false;
                        throw;
                    }
                    break;
                default:
                    Result = false;
                    //Thread.Sleep(2000);
                    break;
            }
        }
    }
}
