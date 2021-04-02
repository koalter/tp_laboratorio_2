using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            lblResultado.Text = Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text).ToString();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            if (lblResultado.Text != string.Empty)
            {
                lblResultado.Text = Numero.DecimalBinario(lblResultado.Text);
            }
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            if (lblResultado.Text != string.Empty)
            {
                lblResultado.Text = Numero.BinarioDecimal(lblResultado.Text);
            }
        }

        private void Limpiar()
        {
            txtNumero1.ResetText();
            txtNumero2.ResetText();
            cmbOperador.ResetText();
        }

        private static double Operar(string numero1, string numero2, string operador)
        {
            return Calculadora.Operar(new Numero(numero1), new Numero(numero2), operador);
        }
    }
}
