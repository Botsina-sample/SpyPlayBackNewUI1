using Gu.Wpf.UiAutomation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SpyPlaybackNewUI1.SpyPlaybackObjects;
using SpyPlaybackNewUI1.Ultils;
using SimplePlayBack.Actions;
using System.Windows.Automation;
namespace SpyPlaybackNewUI1
{
    public partial class Form1 : Form
    {
        static string ProcessName = "WpfApplication1";//nhớ sửa lại bỏ vào AUT path
        static Gu.Wpf.UiAutomation.Application App;
        static IReadOnlyList<UiElement> ElementList;
        static Gu.Wpf.UiAutomation.Window MainWindow;
        static SpyObject[] SpyObjectList;
        static PlaybackObject[] PlaybackObjectList;
        public Form1()
        { 
            InitializeComponent();
            dataGridView1.RowHeadersVisible = false;

            dataGridView2.RowHeadersVisible = false;
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process targetProcess = WindowInteraction.GetProcess(ProcessName);
            WindowInteraction.FocusWindow(targetProcess);
            App = Gu.Wpf.UiAutomation.Application.Attach(targetProcess.Id);
            MainWindow = App.MainWindow;
            ElementList = MainWindow.FindAll(TreeScope.Descendants, new PropertyCondition(AutomationElement.FrameworkIdProperty, "WPF"));
            dataGridView1.AllowUserToAddRows = true;
            SpyObjectList = new SpyObject[ElementList.Count];
            int SpyObjectIndex = 0;
            for(int i=0;i<ElementList.Count;i++)
            {

                    
                    SpyObjectList[SpyObjectIndex] = new SpyObject();
                    SpyObjectList[SpyObjectIndex].index = SpyObjectIndex;
                    if (ElementList[i].AutomationId == "" && SpyObjectIndex-1>0 && ElementList[i - 1].Name!="")
                        SpyObjectList[SpyObjectIndex].automationId = (ElementList[i-1].Name + "_"+ElementList[i].ClassName).Replace(" ","_").Replace(":","");
                    else
                        SpyObjectList[SpyObjectIndex].automationId = ElementList[i].AutomationId;
                    SpyObjectList[SpyObjectIndex].name = ElementList[i].Name;
                    SpyObjectList[SpyObjectIndex].type = ElementList[i].ClassName;
                    DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[i].Clone();
                    row.Cells[1].Value = SpyObjectList[SpyObjectIndex].index;
                    row.Cells[2].Value = SpyObjectList[SpyObjectIndex].automationId;
                    row.Cells[3].Value = SpyObjectList[SpyObjectIndex].name;
                    row.Cells[4].Value = SpyObjectList[SpyObjectIndex].type;
                    dataGridView1.Rows.Add(row);
                    SpyObjectIndex++;
                
            }
            dataGridView1.AllowUserToAddRows = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //for (int i = 0; i < Controllist.Count(); i++)
            //{
            //    switch (Controllist[i].type)
            //    {
            //        case "Button":
            //            AbsAction ButtonAction = new Actions.ButtonAction();
            //            ButtonAction.Control = Controllist[i];
            //            ButtonAction.UiElement = Element[Controllist[i].index];
            //            ButtonAction.DoExecute();
            //            Console.WriteLine("\nResult of test step {0} on Button {1} is {2}", i + 1, Controllist[i].index, ButtonAction.Result);
            //            break;
            //        case "RadioButton":
            //            AbsAction RadioButtonAction = new Actions.RadioButtonAction();
            //            RadioButtonAction.Control = Controllist[i];
            //            RadioButtonAction.UiElement = Element[Controllist[i].index];
            //            RadioButtonAction.DoExecute();
            //            Console.WriteLine("\nResult of test step {0} on RadioButton {1} is {2}", i + 1, Controllist[i].index, RadioButtonAction.Result);
            //            break;
            //        case "TextBox":
            //            AbsAction TextBoxAction = new Actions.TextBoxAction();
            //            TextBoxAction.Control = Controllist[i];
            //            TextBoxAction.UiElement = Element[Controllist[i].index];
            //            TextBoxAction.DoExecute();
            //            Console.WriteLine("\nResult of test step {0} on TextBox {1} is {2}", i + 1, Controllist[i].index, TextBoxAction.Result);
            //            break;
            //        case "ComboBox":
            //            AbsAction ComboBoxAction = new Actions.ComboBoxAction();
            //            ComboBoxAction.Control = Controllist[i];
            //            ComboBoxAction.UiElement = Element[Controllist[i].index];
            //            ComboBoxAction.DoExecute();
            //            Console.WriteLine("\nResult of test step {0} on ComboBox {1} is {2}", i + 1, Controllist[i].index, ComboBoxAction.Result);
            //            break;
            //        case "ComboBoxEdit":
            //            AbsAction ComboBoxEditAction = new Actions.ComboBoxEditAction();
            //            ComboBoxEditAction.Control = Controllist[i];
            //            ComboBoxEditAction.UiElement = Element[Controllist[i].index];
            //            ComboBoxEditAction.DoExecute();
            //            Console.WriteLine("\nResult of test step {0} on ComboBoxEdit {1} is {2}", i + 1, Controllist[i].index, ComboBoxEditAction.Result);
            //            break;
            //        case "DataGrid":
            //            AbsAction DataGridAction = new Actions.DataGridAction();
            //            DataGridAction.Control = Controllist[i];
            //            DataGridAction.UiElement = Element[Controllist[i].index];
            //            DataGridAction.DoExecute();
            //            Console.WriteLine("\nResult of test step {0} on DataGrid {1} is {2}", i + 1, Controllist[i].index, DataGridAction.Result);
            //            break;
            //        default:
            //            break;
            //    }
            //}
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView2.AllowUserToAddRows = true;
            int count=0;
           foreach (DataGridViewRow row in dataGridView1.Rows)
           {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
                if (chk.Value!=chk.TrueValue)
                {
                   count++;
                }
            }
            int[] rowIndex = new int[count];
            int index = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
                if (chk.Value != chk.TrueValue)
                {
                    rowIndex[index]=(int)row.Cells[1].Value;
                    index++;
                }
            }
            int contIndex = dataGridView2.Rows.Count;
            for (int i = 0; i < count; i++)
            {

                DataGridViewRow row = (DataGridViewRow)dataGridView2.Rows[i].Clone();
           
                if (dataGridView2.Rows.Count > 0)
                {
                    row.Cells[0].Value = contIndex;
                }
                else
                {
                    row.Cells[0].Value = i+1;
                }
                row.Cells[1].Value = SpyObjectList[rowIndex[i]].index;
                row.Cells[2].Value = SpyObjectList[rowIndex[i]].automationId;
                row.Cells[3].Value = SpyObjectList[rowIndex[i]].name;
                row.Cells[4].Value = SpyObjectList[rowIndex[i]].type;
                
                switch (row.Cells[4].Value)
                {
                    case "Button":
                        ((DataGridViewComboBoxCell)row.Cells[5]).Items.Add("Click");
                        break;
                    case "RadioButton":
                        ((DataGridViewComboBoxCell)row.Cells[5]).Items.Add("Click");
                        break;
                    case "TextBox":
                        ((DataGridViewComboBoxCell)row.Cells[5]).Items.Add("SetText");
                        break;
                    case "ComboBox":
                        ((DataGridViewComboBoxCell)row.Cells[5]).Items.Add("SetText");
                        ((DataGridViewComboBoxCell)row.Cells[5]).Items.Add("Select");
                        break;
                    case "ComboBoxEdit":
                        ((DataGridViewComboBoxCell)row.Cells[5]).Items.Add("SetText");
                        ((DataGridViewComboBoxCell)row.Cells[5]).Items.Add("Select");
                        break;
                    case "DataGrid":
                        ((DataGridViewComboBoxCell)row.Cells[5]).Items.Add("Select");
                        ((DataGridViewComboBoxCell)row.Cells[5]).Items.Add("UnSelect");
                        break;
                    default:
                        break;
                }
                dataGridView2.Rows.Add(row);
                contIndex++;
      
            }
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {

                DataGridViewCheckBoxCell cb = (DataGridViewCheckBoxCell)row.Cells[0];
                if (cb != null && cb.Value !=cb.TrueValue)
                {
                    cb.Value = false;
                    cb.Value = cb.TrueValue;
                }
            }
            dataGridView2.AllowUserToAddRows = false;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if(row.Selected==true)
                {
                    dataGridView2.Rows.RemoveAt(row.Index);
                }
            }
        }
    }
}
