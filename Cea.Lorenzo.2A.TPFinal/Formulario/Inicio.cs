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
        const string archivoTexto = "Productos.txt";
        const string archivoXml = "Productos.xml";

        public Inicio()
        {
            InitializeComponent();
            fabrica = new Fabrica<Producto>();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Producto producto;

            try
            {
                producto = GenerarProducto(txtModelo.Text, cbxRam.Text,
                        cbxRom.Text, cbxCamara.Text, lbxTamanio.Text, cbxMarca.Text);

                fabrica += producto;
                lbxFabrica.Items.Add(producto);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private Producto GenerarProducto(string modelo, string ram, string rom, string camara,
            string tamanio, string procesador)
        {
            if (!procesador.ToLower().Equals("snapdragon") && 
                !procesador.ToLower().Equals("exynos") &&
                !procesador.ToLower().Equals("helio"))
            {
                procesador = "Generico";
            }

            switch (lbxProducto.Text.ToLower())
            {
                case "celular":
                    return new Celular(modelo, ram,
                        rom, camara, tamanio, procesador);
                case "tablet":
                    return new Tablet(modelo, ram,
                        rom, camara, procesador);
                case "smartwatch":
                    return new SmartWatch(modelo, ram,
                        rom, procesador);
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
            if (fabrica.GuardarComoTexto(archivoTexto) && fabrica.GuardarComoXml(archivoXml))
            {
                lbxFabrica.Items.Clear();
                MessageBox.Show($"Hecho! Los productos están en {archivoTexto} y {archivoXml}", "Productos fabricados", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Hubo un error al guardar archivos.", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void lbxProducto_Click(object sender, EventArgs e)
        {
            switch (lbxProducto.SelectedIndex)
            {
                case 0:
                    lbxTamanio.Enabled = true;
                    cbxMarca.Enabled = true;
                    cbxCamara.Enabled = true;
                    cbxRam.Enabled = true;
                    cbxRom.Enabled = true;
                    break;
                case 1:
                    lbxTamanio.Enabled = false;
                    cbxMarca.Enabled = true;
                    cbxCamara.Enabled = true;
                    cbxRam.Enabled = true;
                    cbxRom.Enabled = true;
                    break;
                case 2:
                    lbxTamanio.Enabled = false;
                    cbxMarca.Enabled = true;
                    cbxCamara.Enabled = false;
                    cbxRam.Enabled = true;
                    cbxRom.Enabled = true;
                    break;
            }
        }
    }
}
