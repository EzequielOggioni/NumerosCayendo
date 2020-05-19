using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NumerosCayendo
{
    public partial class frmPrincipal : Form
    {
        Random rdm;
        int lapso = 0;
        List<Numero> numeros;

        public frmPrincipal()
        {
            rdm = new Random(DateTime.UtcNow.Millisecond);
            numeros = new List<Numero>();
            InitializeComponent();
            Numero.maxY = this.Height;
            this.timer1.Interval = 50;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.label1.Left++;
            this.label1.Top++;


            lapso++;

            try
            {

                foreach (Numero item in numeros)
                {
                    item.mover();
                }

            }
            catch (NumeroPerdidoException)
            {
                MessageBox.Show("Perdiste");
                numeros.Clear();
                timer1.Enabled = false;
            }
            finally {
                this.Refresh();
            }

            if (lapso > 12)
            {
                numeros.Add(new Numero(rdm.Next(0, this.Width - 1)));
                lapso = 0;
            }
        }

        private void frmPrincipal_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (Char.IsNumber(e.KeyChar))
            {

                for (int i = 0; i < numeros.Count; i++)
                {
                    if (numeros[i] == int.Parse(e.KeyChar.ToString()))
                    {
                        numeros.Remove(numeros[i]);
                        return;
                    }
                }
            }


        }

        private void frmPrincipal_Paint(object sender, PaintEventArgs e)
        {
            foreach (Numero item in numeros)
            {
                TextRenderer.DrawText(e.Graphics, item.Valor.ToString(), new Font("Arial", 8, FontStyle.Regular), new Point(item.X, item.Y), Color.White);
            }
        }
    }
}
