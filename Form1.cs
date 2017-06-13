using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;   //time
using System.Threading;     //time
namespace Small_World_Phenomenon
{
    public partial class Form1 : Form
    {
         public movies m=new movies();
         public int k=0;
        public Form1()
        {
            InitializeComponent();
           
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            v();
            m.writeinQuarysolution();
            stopWatch.Stop();
            // Get the elapsed time as a TimeSpan value.
            TimeSpan ts = stopWatch.Elapsed;

            // Format and display the TimeSpan value.
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            MessageBox.Show("RunTime " + elapsedTime);
        }


        public void v()
        {
            
            m.read_movie(); 
            m.intialize();
            m.read_query();
            for (int i = 0; i < m.actors.Count; i++)
            {
                  DataGridViewRow row2 = (DataGridViewRow)dataGridView1.Rows[0].Clone();
                  row2.Cells[0].Value = (i+1).ToString();
                  row2.Cells[1].Value = m.actors.ElementAt(i).Item1;
                  row2.Cells[2].Value = m.actors.ElementAt(i).Item2;
                  row2.Cells[3].Value = m.degrees.ElementAt(i);
                  row2.Cells[4].Value = m.relations.ElementAt(i);
                  row2.Cells[5].Value = m.finalChain.ElementAt(i);
                  dataGridView1.Rows.Add(row2);
             }
        }

     

    

      
    }
}
