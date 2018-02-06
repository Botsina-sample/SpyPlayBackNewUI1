using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace SpyPlaybackNewUI1.Ultils
{
    class JsonInteraction
    {
        public static void readTestScriptJson(string path)
        {
            //string path = @"TestScript1.json";//sửa file test script
            string readText = File.ReadAllText(path);
            dynamic controls = JsonConvert.DeserializeObject(readText);
            //try
            //{
            //    Controllist = new Control[controls.Count];
            //    int i = 0;
            //    foreach (var control in controls)
            //    {
            //        Controllist[i] = new Control();
            //        Controllist[i].index = control.Control.index;
            //        Controllist[i].type = control.Control.type;
            //        Controllist[i].action = control.Control.action;
            //        Controllist[i].text = control.Control.text;
            //        Controllist[i].itemIndex = control.Control.itemIndex;

            //        Console.WriteLine("\n\n");
            //        Console.WriteLine("Controllist[{0}], index: {1}", i, Controllist[i].index);
            //        Console.WriteLine("Controllist[{0}], type: {1}", i, Controllist[i].type);
            //        Console.WriteLine("Controllist[{0}], action: {1}", i, Controllist[i].action);
            //        Console.WriteLine("Controllist[{0}], text: {1}", i, Controllist[i].text);
            //        Console.WriteLine("Controllist[{0}], itemIndex: {1}", i, Controllist[i].itemIndex);
            //        i++;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex);
            //}
        }
    }
}
