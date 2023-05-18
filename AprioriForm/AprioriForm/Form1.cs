using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AprioriForm
{
    public partial class Form1 : Form
    {

        //string[] items = { "Milk", "Cheese", "Bread", "Apple", "Pie" };
        string[] items = { "A", "B", "C", "E", "D" };

        string[,] frequent = new string[5, 2];
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("id");
            dt.Columns.Add("item1");
            dt.Columns.Add("item2");
            dt.Columns.Add("item3");
            dt.Columns.Add("item4");
            dt.Columns.Add("item5");

            //dt.Rows.Add(1, "Milk", "Cheese", "Bread", "", "");
            //dt.Rows.Add(2, "Milk", "Cheese", "Bread", "Apple", "Pie");
            //dt.Rows.Add(3, "Milk", "Cheese", "Apple", "", "");
            //dt.Rows.Add(4, "Milk", "Cheese", "Bread", "", "");
            //dt.Rows.Add(5, "Milk", "Apple", "", "", "");

            dt.Rows.Add(1, "A", "C", "D", "", "");
            dt.Rows.Add(2, "B", "C", "E", "", "");
            dt.Rows.Add(3, "A", "B", "C", "E", "");
            dt.Rows.Add(4, "B", "E", "", "", "");
            dt.Rows.Add(5, "", "", "", "", "");

            dataGridView1.DataSource = dt;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();
            int threshold = Convert.ToInt32(textBox1.Text);
            int f = -1, r, count = 0, i, j;
            string it = "";

            for (r = 0; r < items.Length; r++)
            {
                count = 0;
                it = items[r];

                for (i = 0; i < dataGridView1.Rows.Count - 1 ; i++)
                {
                    for (j = 1; j < dataGridView1.Columns.Count; j++)
                        if (it == dataGridView1.Rows[i].Cells[j].Value.ToString())
                        {
                            count++;
                            break;
                        }
                }
                if (count >= threshold)
                {
                    ++f;
                    frequent[f, 0] = it;
                    frequent[f, 1] = count.ToString();
                    dataGridView2.Rows.Add(frequent[f, 0], frequent[f, 1]);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView3.Rows.Clear();
            int i, j, k, h, m;
            string it1, it2;
            double countOf2Items;
            int threshorld = int.Parse(textBox1.Text);
            
            for(i = 0 ;i<frequent.Length/2;i++ )
            {
                it1 = frequent[i, 0];

                for(j=i+1;j<frequent.Length/2;j++)
                {
                    it2 = frequent[j, 0];
                    countOf2Items = 0;

                    for(k=0; k<dataGridView1.Rows.Count-1;k++)
                    {
                        for(h=1;h< dataGridView1.Columns.Count;h++)
                        {
                            if(it1 == dataGridView1.Rows[k].Cells[h].Value.ToString())
                            {
                                for (m = h + 1; m < dataGridView1.Columns.Count; m++)
                                    if (it2 == dataGridView1.Rows[k].Cells[m].Value.ToString())
                                        countOf2Items++;
                            }
                        }
                    }
                    if (countOf2Items >= threshorld)
                        dataGridView3.Rows.Add(it1 + " " + it2, countOf2Items.ToString());
                }
            }
        }
    }
}
