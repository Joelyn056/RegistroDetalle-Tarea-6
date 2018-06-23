using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Linq.Expressions;
using RegistroDetalleTarea6.Entidades;
using System.Threading.Tasks;

namespace RegistroDetalleTarea6.UI.Consulta
{
    public partial class cArticulos : Form
    {
        public cArticulos()
        {
            InitializeComponent();
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            //Inicializando el filtro en True
            Expression<Func<Articulos, bool>> filtro = x => true;

            int id, precio;
            switch (filtrarcomboBox.SelectedIndex)
            {
                case 0://ID
                    id = Convert.ToInt32(CriteriotextBox.Text);
                    filtro = x => x.ArticuloId == id
                    && (x.FechaVencimiento >= DesdedateTimePicker.Value && x.FechaVencimiento <= HastadateTimePicker.Value);
                    break;
                case 1:// Descripcion
                    filtro = x => x.Descripcion.Contains(CriteriotextBox.Text)
                    && (x.FechaVencimiento >= DesdedateTimePicker.Value && x.FechaVencimiento <= HastadateTimePicker.Value);
                    break;
                case 2:// Precio
                    precio = Convert.ToInt32(CriteriotextBox.Text);
                    filtro = x => x.Precio == precio
                    && (x.FechaVencimiento >= DesdedateTimePicker.Value && x.FechaVencimiento <= HastadateTimePicker.Value);
                    break;
                case 3:// Cantidad cotizada
                    filtro = x => x.CantidadCotizada.Equals(CriteriotextBox.Text)
                    && (x.FechaVencimiento >= DesdedateTimePicker.Value && x.FechaVencimiento <= HastadateTimePicker.Value);
                    break;
            }
            ConsultadataGridView.DataSource = BLL.ArticulosBLL.GetList(filtro);
        }
    }
}
