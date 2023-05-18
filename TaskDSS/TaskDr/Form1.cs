using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskDr
{
    public partial class Form1 : Form
    {
        //

        ///

        
        private int[] GetInputValues()
        {
            int arec = Convert.ToInt32(paRec.Text);
            int anorm = Convert.ToInt32(paNorm.Text);
            int aboom = Convert.ToInt32(paBoom.Text);
            int brec = Convert.ToInt32(pbRec.Text);
            int bnorm = Convert.ToInt32(pbNorm.Text);
            int bboom = Convert.ToInt32(pbBoom.Text);
            int crec = Convert.ToInt32(pcRec.Text);
            int cnorm = Convert.ToInt32(pcNorm.Text);
            int cboom = Convert.ToInt32(pcBoom.Text);
           
      
            return new int[] { arec, anorm, aboom, brec, bnorm, bboom, crec, cnorm, cboom };
           
        }




        public Form1()
        {
            InitializeComponent();






        }

        private void Form1_Load(object sender, EventArgs e)
        {


        }



        private void maximax_Click(object sender, EventArgs e)
        {

            int[] inputs = GetInputValues();
            int maxa1 = Math.Max(inputs[0], inputs[1]);
            int maxa2 = Math.Max(maxa1, inputs[2]);
            pax.Text = maxa2.ToString();

            int maxb1 = Math.Max(inputs[3], inputs[4]);
            int maxb2 = Math.Max(maxb1, inputs[5]);
            pbx.Text = maxb2.ToString();

            int maxc1 = Math.Max(inputs[6], inputs[7]);
            int maxc2 = Math.Max(maxc1, inputs[8]);
            pcx.Text = maxc2.ToString();

            int maxx1 = Math.Max(maxa2, maxb2);
            int maxx2 = Math.Max(maxx1, maxc2);
            Result.Text = maxx2.ToString();

        }

        private void paRec_TextChanged(object sender, EventArgs e)
        {

        }

        private void maximin_Click(object sender, EventArgs e)
        {
            int[] inputs = GetInputValues();
            int maxa1 = Math.Min(inputs[0], inputs[1]);
            int maxa2 = Math.Min(maxa1, inputs[2]);
            pax.Text = maxa2.ToString();

            int maxb1 = Math.Min(inputs[3], inputs[4]);
            int maxb2 = Math.Min(maxb1, inputs[5]);
            pbx.Text = maxb2.ToString();

            int maxc1 = Math.Min(inputs[6], inputs[7]);
            int maxc2 = Math.Min(maxc1, inputs[8]);
            pcx.Text = maxc2.ToString();
            int maxx1 = Math.Max(maxa2, maxb2);
            int maxx2 = Math.Max(maxx1, maxc2);
            Result.Text = maxx2.ToString();
        }

        private void regret_Click(object sender, EventArgs e)
        {
            int[] inputs = GetInputValues();
            int maxa1 = Math.Max(inputs[0], inputs[3]);
            int maxa2 = Math.Max(maxa1, inputs[6]);
            paRec.Text = (maxa2 - inputs[0]).ToString();
            pbRec.Text = (maxa2 - inputs[3]).ToString();
            pcRec.Text = (maxa2 - inputs[6]).ToString();

            int maxb1 = Math.Max(inputs[1], inputs[4]);
            int maxb2 = Math.Max(maxb1, inputs[7]);
            paNorm.Text = (maxb2 - inputs[1]).ToString();
            pbNorm.Text = (maxb2 - inputs[4]).ToString();
            pcNorm.Text = (maxb2 - inputs[7]).ToString();

            int maxc1 = Math.Max(inputs[2], inputs[5]);
            int maxc2 = Math.Max(maxc1, inputs[8]);
            paBoom.Text = (maxc2 - inputs[2]).ToString();
            pbBoom.Text = (maxc2 - inputs[5]).ToString();
            pcBoom.Text = (maxc2 - inputs[8]).ToString();

            int maxaa1 = Math.Max(inputs[0], inputs[1]);
            int maxaa2 = Math.Max(maxaa1, inputs[2]);
            pax.Text = maxa2.ToString();

            int maxbb1 = Math.Max(inputs[3], inputs[4]);
            int maxbb2 = Math.Max(maxbb1, inputs[5]);
            pbx.Text = maxb2.ToString();

            int maxcc1 = Math.Max(inputs[6], inputs[7]);
            int maxcc2 = Math.Max(maxcc1, inputs[8]);
            pcx.Text = maxc2.ToString();

            int maxx1 = Math.Max(maxaa2, maxbb2);
            int maxx2 = Math.Max(maxx1, maxcc2);
            Result.Text = maxx2.ToString();


        }


        private void equally_Click(object sender, EventArgs e)
        {
            int[] inputs = GetInputValues();
            int maxa = ((inputs[0] + inputs[1] + inputs[2]) / 3);
            pax.Text = maxa.ToString();
            int maxb = ((inputs[3] + inputs[4] + inputs[5]) / 3);
            pbx.Text = maxb.ToString();
            int maxc = ((inputs[6] + inputs[7] + inputs[8]) / 3);
            pcx.Text = maxc.ToString();
            int maxx1 = Math.Max(maxa, maxb);
            int maxx2 = Math.Max(maxx1, maxc);
            Result.Text = maxx2.ToString();

        }

        private void Clear_Click(object sender, EventArgs e)
        {
            paRec.Text = ""; pbRec.Text = ""; pcRec.Text = "";
            paNorm.Text = ""; pbNorm.Text = ""; pcNorm.Text = "";
            paBoom.Text = ""; pbBoom.Text = ""; pcBoom.Text = "";
            pax.Text = pbx.Text = pcx.Text = Result.Text = alpha.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            alpha.Visible = true;
        }

        private void realism_Click(object sender, EventArgs e)
        {


            double alphaa = double.Parse(alpha.Text);

            int[] inputs = GetInputValues();
            int maxa1 = Math.Max(inputs[0], inputs[1]);
            int maxa2 = Math.Max(maxa1, inputs[2]);
            int mina1 = Math.Min(inputs[0], inputs[1]);
            int mina2 = Math.Min(mina1, inputs[2]);
            double axc = ((alphaa * maxa2) + ((1 - alphaa) * mina2));
            pax.Text = axc.ToString();

            int maxb1 = Math.Max(inputs[3], inputs[4]);
            int maxb2 = Math.Max(maxb1, inputs[5]);
            int minb1 = Math.Min(inputs[3], inputs[4]);
            int minb2 = Math.Min(minb1, inputs[5]);
            double bxc = ((alphaa * maxb2) + ((1 - alphaa) * minb2));
            pbx.Text = bxc.ToString();

            int maxc1 = Math.Max(inputs[6], inputs[7]);
            int maxc2 = Math.Max(maxc1, inputs[8]);
            int minc1 = Math.Min(inputs[6], inputs[7]);
            int minc2 = Math.Min(minc1, inputs[8]);
            double cxc = ((alphaa * maxc2) + ((1 - alphaa) * minc2));
            pcx.Text = cxc.ToString();

            double maxx1 = Math.Max(axc, bxc);
            double maxx2 = Math.Max(maxx1, cxc);
            Result.Text = maxx2.ToString();

        }

        
    }
  }
