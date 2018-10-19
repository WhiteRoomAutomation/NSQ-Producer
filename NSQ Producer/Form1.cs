using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

using NsqSharp;
using wwToolkit;

namespace NSQ_Producer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int iValCount = 150;
           List <wwValue> wwData = new List<wwValue>();

            for (int iCount = 0; iCount < iValCount; iCount ++)
            {
                
                for (int iNumber = 1; iNumber <= 6; iNumber ++)
                {
                    wwValue wwVal = new wwValue();
                    
                    wwVal.GenerateValue("Tester" + iNumber.ToString() +".MyTagName");
                    wwData.Add(wwVal);
                    System.Threading.Thread.Sleep(10);
                }
                
            }

            string output = JsonConvert.SerializeObject(wwData);
            var producer = new Producer("127.0.0.1:4150");        


            producer.Publish("test-topic-name", output);
            

            producer.Stop();
        }
    }
}
