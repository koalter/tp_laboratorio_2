using Entidades;
using Excepciones;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Formulario
{
    public partial class Inicio : Form
    {
        Fabrica<Producto> fabrica;

        public Inicio()
        {
            InitializeComponent();
            fabrica = new Fabrica<Producto>(10);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Producto producto;

            try
            {
                switch (lblProducto.Text.ToLower())
                {
                    case "celular":
                        producto = new Celular(lblModelo.Text, int.Parse(lblRam.Text),
                            int.Parse(lblRom.Text), int.Parse(lblCamara.Text),
                            (ETamanio)Enum.Parse(typeof(ETamanio), lblTamanio.Text),
                            (EMarca)Enum.Parse(typeof(EMarca), lblProcesador.Text));
                        break;
                    case "tablet":
                        producto = new Tablet(lblModelo.Text, int.Parse(lblRam.Text),
                            int.Parse(lblRom.Text), int.Parse(lblCamara.Text),
                            (EMarca)Enum.Parse(typeof(EMarca), lblProcesador.Text));
                        break;
                    case "smartwatch":
                        producto = new SmartWatch(lblModelo.Text,
                            int.Parse(lblRam.Text), int.Parse(lblRom.Text),
                            (EMarca)Enum.Parse(typeof(EMarca), lblProcesador.Text));
                        break;
                    default:
                        producto = null;
                        break;
                }

                fabrica += producto;
            }
            catch (Exception ex)
            {
                throw new ValorInvalidoException(ex);
            }
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {

        }

        private void btnFabricar_Click(object sender, EventArgs e)
        {

        }

        private bool VerificarCampos()
        {
            if (string.IsNullOrWhiteSpace(lblModelo.Text)
                && int.TryParse(lblRam.Text, out int Ram)
                && int.TryParse(lblRom.Text, out int Rom)
                && int.TryParse(lblCamara.Text, out int Camara)
                && Ram > 0
                && Rom > 0
                && Camara > 0)
            {
                return true;
            }

            throw new ValorInvalidoException();
        }
    }
}
