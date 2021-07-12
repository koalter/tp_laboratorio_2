using Archivos;
using Entidades;
using Excepciones;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Formulario
{
    public partial class Inicio : Form
    {
        Fabrica fabrica;
        List<Thread> hilos;

        public Inicio()
        {
            InitializeComponent();
            fabrica = new Fabrica();
            fabrica.CambiarStatusEvent += CambiarEstado;
            hilos = new List<Thread>();
        }

        private Producto GenerarProducto(string modelo, string ram, string rom, string camara,
            string tamanio, string procesador)
        {
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

        private void btnFabricar_Click(object sender, EventArgs e)
        {
            Producto producto;
            Thread thread;

            try
            {
                producto = GenerarProducto(txtModelo.Text, cbxRam.Text,
                        cbxRom.Text, cbxCamara.Text, lbxTamanio.Text, cbxMarca.Text);

                fabrica += producto;

                thread = new Thread(fabrica.CambiarStatus);
                hilos.Add(thread);
                thread.Start(producto);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void Inicio_Load(object sender, EventArgs e)
        {
            if (Fabrica.TestConnectionString() == false)
            {
                MessageBox.Show("No se pudo conectar a la base. Asegúrese de que la cadena de conexión tenga sus parámetros correctamente e intente nuevamente.", "Cadena de conexión incorrecta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }
        }

        private void Inicio_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (Thread hilo in hilos)
            {
                if (hilo.IsAlive)
                {
                    try
                    {
                        hilo.Abort();
                    }
                    catch
                    {

                    }
                }
            }
        }

        private void CambiarEstado(object producto)
        {
            lbxFabrica.Items.Add(producto);
            Thread.Sleep(2000);
            lbxFabrica.Items.Remove(producto);
            lbxEnCurso.Items.Add(producto);
            Thread.Sleep(2000);

            string fecha = DateTime.Now.ToFileTime().ToString();
            string ruta = $"{Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)}\\Productos\\{fecha}";

            Directory.CreateDirectory(ruta);
            if (Fabrica.GuardarComoTexto(ruta + "\\" + fecha, (Producto)producto) &&
                Fabrica.GuardarComoXml(ruta + "\\" + fecha, (Producto)producto) &&
                Fabrica.GuardarEnLaBase((Producto)producto))
            {
                lbxEnCurso.Items.Remove(producto);
                lbxHechos.Items.Add(producto);
            }
            
        }
    }
}
