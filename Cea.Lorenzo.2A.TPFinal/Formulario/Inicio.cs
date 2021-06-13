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
                producto = GenerarProducto();

                fabrica += producto;
                lbxFabrica.Items.Add(producto);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private Producto GenerarProducto()
        {
            switch (lbxProducto.Text.ToLower())
            {
                case "celular":
                    return new Celular(txtModelo.Text, cbxRam.Text,
                        cbxRom.Text, cbxCamara.Text, lbxTamanio.Text, lbxProcesador.Text);
                case "tablet":
                    return new Tablet(txtModelo.Text, cbxRam.Text,
                        cbxRom.Text, cbxCamara.Text, lbxProcesador.Text);
                case "smartwatch":
                    return new SmartWatch(txtModelo.Text, cbxRam.Text,
                        cbxRom.Text, lbxProcesador.Text);
                default:
                    return null;
            }
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            Producto producto = (Producto)lbxFabrica.SelectedItem;
            lbxFabrica.Items.Remove(producto);
            try
            {
                fabrica -= producto;
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show("No ha seleccionado ningun objeto!", ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (RemoverObjetoException ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnFabricar_Click(object sender, EventArgs e)
        {

        }

        private void lbxProducto_Click(object sender, EventArgs e)
        {
            switch (lbxProducto.SelectedIndex)
            {
                case 0:
                    lbxTamanio.Enabled = true;
                    lbxProcesador.Enabled = true;
                    cbxCamara.Enabled = true;
                    cbxRam.Enabled = true;
                    cbxRom.Enabled = true;
                    break;
                case 1:
                    lbxTamanio.Enabled = false;
                    lbxProcesador.Enabled = true;
                    cbxCamara.Enabled = true;
                    cbxRam.Enabled = true;
                    cbxRom.Enabled = true;
                    break;
                case 2:
                    lbxTamanio.Enabled = false;
                    lbxProcesador.Enabled = true;
                    cbxCamara.Enabled = false;
                    cbxRam.Enabled = true;
                    cbxRom.Enabled = true;
                    break;
            }
        }
    }
}
