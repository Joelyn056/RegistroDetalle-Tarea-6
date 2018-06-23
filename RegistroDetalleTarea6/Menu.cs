using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RegistroDetalleTarea6.UI.Consulta;
using RegistroDetalleTarea6.UI.Registro;

namespace RegistroDetalleTarea6
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void PersonastoolStripButton_Click(object sender, EventArgs e)
        {
            new rPersonas().Show();
        }

        private void ArticulostoolStripButton_Click(object sender, EventArgs e)
        {
            new rArticulos().Show();
        }

        private void CotizacionestoolStripButton_Click(object sender, EventArgs e)
        {
            new rCotizaciones().Show();
            
        }

        private void personasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new rPersonas().Show();
        }

        private void articulosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new rArticulos().Show();
        }

        private void cotizacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new rCotizaciones().Show();
        }

        private void personasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new cPersonas().Show();
        }

        private void articulosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new cArticulos().Show();
        }

        
    }
}
