using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace SimplePlayBack.Actions
{
    class TextBoxAction : AbsAction
    {
        public override void DoExecute()
        {
            switch (PlaybackObject.action)
            {
                case "SetText":
                    try
                    {
                        if (UiElement.AsTextBox().Text == "__/__/____")
                        {
                            if (PlaybackObject.text.Count() == 8)
                            {
                                string str1 = PlaybackObject.text.Substring(0, 2);
                                string str2 = PlaybackObject.text.Substring(2, 2);
                                string str3 = PlaybackObject.text.Substring(4, 4);
                                string date = str1 + "/" + str2 + "/" + str3;
                                UiElement.AsTextBox().Enter(PlaybackObject.text);
                                if (UiElement.AsTextBox().Text == date)
                                {
                                    //Console.WriteLine(date);
                                    Result = true;
                                }
                                else
                                {
                                    Result = false;
                                }
                            }
                            else
                            {
                                Console.WriteLine("You have to enter exactly DD/MM/YYYY");
                                Result = false;
                            }
                        }
                        else
                        {
                            UiElement.AsTextBox().Enter(PlaybackObject.text);
                            if (PlaybackObject.text != "" && UiElement.AsTextBox().Text == "")
                                Result = false;
                            else if (PlaybackObject.text.ToUpper() == UiElement.AsTextBox().Text)
                                Result = true;
                            else
                                Result = true;
                        }

                        //Console.WriteLine(UiElement.AsTextBox().Text);
                        int n;
                        bool isNumeric = int.TryParse(PlaybackObject.text, out n);
                        //if (isNumeric == true)
                        //{
                        //    
                        //}
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
