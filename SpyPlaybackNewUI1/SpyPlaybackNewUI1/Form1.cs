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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process targetProcess = WindowInteraction.GetProcess(ProcessName);
            WindowInteraction.FocusWindow(targetProcess);
            App = Gu.Wpf.UiAutomation.Application.Attach(targetProcess.Id);
            MainWindow = App.MainWindow;
            ElementList = MainWindow.FindAll(TreeScope.Subtree,Condition.TrueCondition);

            SpyObjectList = new SpyObject[ElementList.Count];
            for(int i=0;i< ElementList.Count;i++)
            {
                SpyObjectList[i] = new SpyObject();
                SpyObjectList[i].index = i;
                SpyObjectList[i].automationId = ElementList[i].AutomationId;
                SpyObjectList[i].name = ElementList[i].Name;
                SpyObjectList[i].type = ElementList[i].ClassName;
                DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[i].Clone();
                row.Cells[1].Value = SpyObjectList[i].index;
                row.Cells[2].Value = SpyObjectList[i].automationId;
                row.Cells[3].Value = SpyObjectList[i].name;
                row.Cells[4].Value = SpyObjectList[i].type;
                dataGridView1.Rows.Add(row);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
