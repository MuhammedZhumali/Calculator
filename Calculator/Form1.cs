using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Calculator
{
    public partial class Calculator : Form
    {
        bool plus = false;
        bool minus = false;
        bool multiply = false;
        bool divide = false;
        bool power = false;
        bool tnd = true;
        bool perm = false;
        bool comb = false;
        int a, b;

        Object obj = "", obj2 = "";

        public Calculator()
        {
            InitializeComponent();
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            calci.Text = calci.Text + "0";
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            calci.Text = calci.Text + "1";
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            calci.Text = calci.Text + "2";
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            calci.Text = calci.Text + "3";
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            calci.Text = calci.Text + "4";
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            calci.Text = calci.Text + "5";
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            calci.Text = calci.Text + "6";
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            calci.Text = calci.Text + "7";
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            calci.Text = calci.Text + "8";
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            calci.Text = calci.Text + "9";
        }

        private void C_Click(object sender, EventArgs e)
        {
            calci.Text = "";
            tbox1.Text = "";
            tbox2.Text = "";
            calci.Tag = "";
        }

        private void btnminus_Click(object sender, EventArgs e)
        {

            if (calci.Text == "" && tbox2.Text == "")
            {
                return;
            }
            else if (tbox2.Text != "")
            {

                minus = true;
                calci.Tag = tbox2.Text;
                tbox1.Visible = true;
                tbox1.Text = calci.Tag + "-";
                calci.Text = "";
                tbox2.Visible = true;
            }
            else
            {
                minus = true;
                calci.Tag = calci.Text;
                calci.Text = "";
                tbox1.Text = calci.Tag + "-";

                tbox1.Visible = true;
                tbox2.Visible = true;
            }

        }

        private void btnmulti_Click(object sender, EventArgs e)
        {

            if (calci.Text == "" && tbox2.Text == "")
            {
                return;
            }

            else if (tbox2.Text != "")
            {
                multiply = true;
                calci.Tag = tbox2.Text;
                tbox1.Visible = true;
                tbox1.Text = calci.Tag + "*";
                calci.Text = "";
                tbox2.Visible = true;
            }

            else
            {
                multiply = true;
                calci.Tag = calci.Text;

                tbox1.Text = calci.Tag + "*";
                calci.Text = "";
                tbox1.Visible = true;
                tbox2.Visible = true;
                tbox2.Text = "";
            }
        }

        private void btndiv_Click(object sender, EventArgs e)
        {

            if (calci.Text == "" && tbox2.Text == "")
            {
                return;
            }

            else if (tbox2.Text != "")
            {

                divide = true;
                calci.Tag = tbox2.Text;
                tbox1.Visible = true;
                tbox1.Text = calci.Tag + "/";
                calci.Text = "";
                tbox2.Visible = true;
            }

            else
            {
                divide = true;
                calci.Tag = calci.Text;

                tbox1.Text = calci.Tag + "/";
                calci.Text = "";
                tbox1.Visible = true;
                tbox2.Visible = true;
            }

        }

        private void btnplus_Click(object sender, EventArgs e)
        {

            if (calci.Text == "" && tbox2.Text == "")
            {
                return;
            }

            else if (tbox2.Text != "")
            {

                plus = true;
                calci.Tag = tbox2.Text;
                tbox1.Visible = true;
                tbox1.Text = calci.Tag + "+";
                calci.Text = "";
                tbox2.Visible = true;
            }

            else
            {
                plus = true;
                calci.Tag = calci.Text;
                tbox1.Text = calci.Tag + "+";
                calci.Text = "";
                tbox1.Visible = true;
                tbox2.Visible = true;

            }

        }

        private void btnequal_Click(object sender, EventArgs e)
        {
            try
            {
                if (calci.Text == "")
                {
                    return;
                }
                else if (plus)
                {


                    tbox2.Text = calci.Tag + "+";

                    decimal dec = Convert.ToDecimal(calci.Tag) + Convert.ToDecimal(calci.Text);
                    tbox2.Text = dec.ToString();
                    plus = false;

                }
                else if (minus)
                {

                    tbox2.Text = calci.Tag + "-";
                    decimal dec = Convert.ToDecimal(calci.Tag) - Convert.ToDecimal(calci.Text);
                    tbox2.Text = dec.ToString();
                    minus = false;

                }
                else if (multiply)
                {
                    tbox2.Text = calci.Tag + "*";
                    decimal dec = Convert.ToDecimal(calci.Tag) * Convert.ToDecimal(calci.Text);
                    tbox2.Text = dec.ToString();
                    multiply = false;

                }
                else if (divide)
                {
                    tbox2.Text = calci.Tag + "/";
                    decimal dec = Convert.ToDecimal(calci.Tag) / Convert.ToDecimal(calci.Text);
                    tbox2.Text = dec.ToString();
                    divide = false;

                }

                else if (power)
                {
                    Object obj = 1;
                    Double decx = Convert.ToDouble(calci.Tag);
                    Double sum = Convert.ToDouble(obj);
                    Double decy = Convert.ToDouble(calci.Text);
                    for (Double i = 1; i <= decy; i++)
                    {
                        sum = sum * decx;
                    }
                    Decimal dec = Convert.ToDecimal(sum);
                    tbox2.Text = dec.ToString();
                    power = false;
                }


                else if (perm)
                {

                    a = Convert.ToInt32(tbox1.Text);
                    b = Convert.ToInt32(calci.Text);
                    if (a < b)
                    {
                        MessageBox.Show("Math Error");
                        tbox1.Text = "";
                        tbox2.Text = "";
                        calci.Text = "";
                    }
                    else
                    {
                        long aFact = Factorial(a);
                        long bFact = Factorial(a - b);

                        long permAns = aFact / bFact;
                        tbox2.Text = permAns.ToString();
                    }
                }

                else if (comb)
                {
                    a = Convert.ToInt32(tbox1.Text);
                    b = Convert.ToInt32(calci.Text);
                    if (a < b)
                    {
                        MessageBox.Show("Math Error");
                        tbox1.Text = "";
                        tbox2.Text = "";
                        calci.Text = "";
                    }

                    else
                    {
                        long aFact = Factorial(a);
                        long bF = Factorial(b);

                        long aMbF = Factorial(a - b);
                        long bFact = bF * aMbF;

                        long combAns = aFact / bFact;
                        tbox2.Text = combAns.ToString();
                    }
                }

                else
                {
                    tbox2.Visible = true;
                    tbox2.Text = calci.Text;
                    calci.Text = "";
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                tbox1.Text = "";
                tbox2.Text = "";
                calci.Text = "";
            }

        }

        private void btndot_Click(object sender, EventArgs e)
        {

            if (calci.Text.Contains("."))
            {
                return;
            }
            else
            {
                calci.Text = calci.Text + ".";
            }

        }

        private void Calculator_Load(object sender, EventArgs e)
        {
            calci.Text = "";
            tbox1.Text = "";
            tbox2.Text = "";
        }

        private void calci_TextChanged(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tmrClock_Tick(object sender, EventArgs e)
        {
            lblClock.Text = DateTime.Now.ToLongTimeString();
        }

        private void btnpluseminus_Click(object sender, EventArgs e)
        {
            if (calci.Text == "" && tbox2.Text == "")
            {
                return;
            }
            else if (calci.Text == "" && tbox2.Text != "")
            {
                tbox2.Visible = true;
                tbox2.Tag = tbox2.Text;
                tbox2.Text = "";
                decimal dec = Convert.ToDecimal(tbox2.Tag) * Convert.ToDecimal(-1);
                tbox2.Text = dec.ToString();
                tbox1.Text = "";
                calci.Text = "";
            }
            else if (calci.Text != "" && tbox2.Text == "")
            {
                tbox2.Visible = true;
                tbox2.Tag = calci.Text;
                tbox2.Text = "";
                decimal dec = Convert.ToDecimal(tbox2.Tag) * Convert.ToDecimal(-1);
                tbox2.Text = dec.ToString();
                tbox1.Text = "";
                calci.Text = "";
            }
            else
            {
                tbox2.Visible = true;
                tbox2.Tag = tbox2.Text;
                tbox2.Text = "";
                decimal dec = Convert.ToDecimal(tbox2.Tag) * Convert.ToDecimal(-1);
                tbox2.Text = dec.ToString();
                tbox1.Text = "";
                calci.Text = "";
            }
        }

        private void btnmplus_Click(object sender, EventArgs e)
        {
            File.WriteAllText(@"memory.txt", tbox2.Text);
        }

        private void btnmr_Click(object sender, EventArgs e)
        {
            tbox2.Text = File.ReadAllText(@"memory.txt");
        }

        private void btnmc_Click(object sender, EventArgs e)
        {
            File.WriteAllText(@"memory.txt", null);
        }

        private void btnmminus_Click(object sender, EventArgs e)
        {
            File.WriteAllText(@"memory.txt", null);
        }

        private void btnpi_Click(object sender, EventArgs e)
        {
            tbox1.Visible = false;
            tbox2.Visible = false;
            Decimal pi = Convert.ToDecimal(3.14159265359);
            calci.Text = pi.ToString();

        }

        private void btne_Click(object sender, EventArgs e)
        {
            tbox1.Visible = false;
            tbox2.Visible = false;
            Decimal exp = Convert.ToDecimal(2.71828182846);
            calci.Text = exp.ToString();

        }

        private void btnpt_Click(object sender, EventArgs e)
        {

            if (calci.Text == "" || multiply == false)
            {
                return;
            }
            else
            {

                Decimal pt = (Convert.ToDecimal(calci.Tag) * Convert.ToDecimal(calci.Text)) / (Convert.ToDecimal(100));
                tbox2.Text = pt.ToString();
                calci.Text = calci.Text + "%";
                multiply = false;
            }



        }

        private void btnx2_Click(object sender, EventArgs e)
        {
            if (calci.Text == "")
            {
                return;
            }
            else
            {
                tbox2.Visible = true;
                tbox1.Visible = true;
                tbox1.Text = calci.Text + "^";
                Decimal dec = Convert.ToDecimal(calci.Text) * Convert.ToDecimal(calci.Text);
                tbox2.Text = dec.ToString();
                calci.Text = "2";

            }
        }        

        private void btnxy_Click(object sender, EventArgs e)
        {

            if (calci.Text == "")
            {
                return;
            }

            else
            {
                power = true;
                calci.Tag = calci.Text;
                tbox1.Text = calci.Tag + "^";
                calci.Text = "";
                tbox1.Visible = true;
                tbox2.Visible = true;

            }
        }

        private void button29_Click(object sender, EventArgs e)
        {

            if (calci.Text == "")
            {
                return;
            }

            else
            {
                tbox2.Visible = true;
                tbox1.Visible = true;
                tbox1.Text = calci.Text + " !";
                Object obj = 1;
                Double sum = Convert.ToDouble(obj);
                Double decx = Convert.ToDouble(calci.Text);
                for (Double i = decx; i >= 1; i--)
                {
                    sum = i * sum;
                }
                Decimal dec = Convert.ToDecimal(sum);
                tbox2.Text = dec.ToString();
                calci.Text = "";
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.panel2.Visible = false;
            this.lblClock.Visible = false;
            this.label2.Visible = false;
            //this.label3.Visible = false;
            this.Height = 360;
            this.Width = 277;
            this.closeToolStripMenuItem.Checked = true;
            this.openToolStripMenuItem.Checked = false;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Height = 360;
            this.Width = 514;
            this.panel2.Visible = true;
            this.lblClock.Visible = true;
            this.label2.Visible = true;
            //this.label3.Visible = true;
            this.Height = 360;
            this.Width = 514;
            this.closeToolStripMenuItem.Checked = false;
            this.openToolStripMenuItem.Checked = true;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            //this.label3.ForeColor = Color.Indigo;

        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            //this.label3.ForeColor = Color.LightSeaGreen;  
        }

        private void label3_MouseHover(object sender, EventArgs e)
        {
            // this.label3.ForeColor = Color.Brown;

        }

        private void btnbx_Click(object sender, EventArgs e)
        {
            if (calci.Text == "")
            {
                return;
            }

            else
            {
                tbox2.Visible = true;
                Decimal dec = Convert.ToDecimal(1) / Convert.ToDecimal(calci.Text);
                tbox2.Text = dec.ToString();
            }
        }



        private void btn10x_Click(object sender, EventArgs e)
        {


            if (calci.Text == "")
            {
                return;
            }

            else
            {

                tbox2.Visible = true;
                tbox1.Visible = true;
                tbox1.Text = "10^" + calci.Text;
                Object obj = 1;
                Object obj2 = 10;
                Double decy = Convert.ToDouble(obj2);
                Double sum = Convert.ToDouble(obj);
                Double decx = Convert.ToDouble(calci.Text);
                for (Double i = 1; i <= decx; i++)
                {
                    sum = decy * sum;
                }
                Decimal dec = Convert.ToDecimal(sum);
                tbox2.Text = dec.ToString();
                calci.Text = "";
            }
        }

        private void btnex_Click(object sender, EventArgs e)
        {


            if (calci.Text == "")
            {
                return;
            }

            else
            {

                tbox2.Visible = true;
                tbox1.Visible = true;
                tbox1.Text = "e^" + calci.Text;
                Object obj = 1;
                Object obj2 = 2.71828182846;
                Double decy = Convert.ToDouble(obj2);
                Double sum = Convert.ToDouble(obj);
                Double decx = Convert.ToDouble(calci.Text);
                for (Double i = 1; i <= decx; i++)
                {
                    sum = decy * sum;
                }
                Decimal dec = Convert.ToDecimal(sum);
                tbox2.Text = dec.ToString();
                calci.Text = "";
            }

        }

        private void tmrClock_Tick_1(object sender, EventArgs e)
        {
            lblClock.Text = DateTime.Now.ToLongTimeString();
        }

        private void btnsin_Click(object sender, EventArgs e)
        {

            if (calci.Text == "")
            {
                return;
            }

            else
            {
                tbox2.Visible = true;
                //tbox1.Visible = true;
                Double dec = Convert.ToDouble(calci.Text) * Convert.ToDouble(3.1416) / Convert.ToDouble(180);
                dec = Math.Sin(dec);
                tbox2.Text = dec.ToString();

            }
        }

        private void btncos_Click(object sender, EventArgs e)
        {

            if (calci.Text == "")
            {
                return;
            }

            else
            {
                tbox2.Visible = true;
                // tbox1.Visible = true;
                Double dec = Convert.ToDouble(calci.Text) * Convert.ToDouble(3.1416) / Convert.ToDouble(180);
                dec = Math.Cos(dec);
                tbox2.Text = dec.ToString();
            }

        }

        private void btntan_Click(object sender, EventArgs e)
        {
            if (calci.Text == "")
            {
                return;
            }

            else
            {

                tbox2.Visible = true;
                Double dec = Convert.ToDouble(calci.Text) * Convert.ToDouble(3.1416) / Convert.ToDouble(180);
                dec = Math.Tan(dec);
                tbox2.Text = dec.ToString();
            }
        }



        private void btnlog_Click(object sender, EventArgs e)
        {

            if (calci.Text == "")
            {
                return;
            }

            else
            {

                tbox2.Visible = true;
                Double dec = Convert.ToDouble(calci.Text);
                dec = Math.Log10(dec);
                tbox2.Text = dec.ToString();

            }
        }

        private void btnln_Click(object sender, EventArgs e)
        {

            if (calci.Text == "")
            {
                return;
            }

            else
            {
                tbox2.Visible = true;
                Double dec = Convert.ToDouble(calci.Text);
                dec = Math.Log(dec);
                tbox2.Text = dec.ToString();
            }
        }

        private void btnsininv_Click(object sender, EventArgs e)
        {
            if (calci.Text == "")
            {
                return;
            }

            else
            {
                tbox2.Visible = true;
                Double dec = Convert.ToDouble(calci.Text);
                dec = Math.Asin(dec);
                dec = dec * Convert.ToDouble(180) / Convert.ToDouble(3.141592654);
                tbox2.Text = dec.ToString();
            }

        }

        private void btncosinv_Click(object sender, EventArgs e)
        {

            if (calci.Text == "")
            {
                return;
            }

            else
            {
                tbox2.Visible = true;
                Double dec = Convert.ToDouble(calci.Text);
                dec = Math.Acos(dec);
                dec = dec * Convert.ToDouble(180) / Convert.ToDouble(3.141592654);
                tbox2.Text = dec.ToString();
            }

        }

        private void btntaninv_Click(object sender, EventArgs e)
        {
            if (calci.Text == "")
            {
                return;
            }

            else
            {
                tbox2.Visible = true;
                Double dec = Convert.ToDouble(calci.Text);
                dec = Math.Atan(dec);
                dec = dec * Convert.ToDouble(180) / Convert.ToDouble(3.141592654);
                tbox2.Text = dec.ToString();
            }
        }

        private void permut_Click(object sender, EventArgs e)
        {
            tbox1.Visible = true;
            tbox1.Text = calci.Text;
            calci.Text = null;
            perm = true;
            tbox2.Visible = true;
        }

        public static long Factorial(long number)
        {
            if (number <= 1)
                return 1;
            else
                return number * Factorial(number - 1);
        }

        
        private void xsqrty_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Calculator_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tbox1.Visible = true;
            tbox1.Text = calci.Text;
            calci.Text = null;
            comb = true;
            tbox2.Visible = true;
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Jubayer Khan\nCE-10037\nDept. of CSE\nMBSTU");
        }

    }
}
