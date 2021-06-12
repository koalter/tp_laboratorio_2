
namespace Formulario
{
    partial class Inicio
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbxProductos = new System.Windows.Forms.ListBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnRemover = new System.Windows.Forms.Button();
            this.btnFabricar = new System.Windows.Forms.Button();
            this.lblModelo = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblProducto = new System.Windows.Forms.Label();
            this.lbxProducto = new System.Windows.Forms.ListBox();
            this.lbxProcesador = new System.Windows.Forms.ListBox();
            this.lblProcesador = new System.Windows.Forms.Label();
            this.lblRam = new System.Windows.Forms.Label();
            this.lblRom = new System.Windows.Forms.Label();
            this.lblCamara = new System.Windows.Forms.Label();
            this.cbxRam = new System.Windows.Forms.ComboBox();
            this.cbxRom = new System.Windows.Forms.ComboBox();
            this.cbxCamara = new System.Windows.Forms.ComboBox();
            this.lblTamanio = new System.Windows.Forms.Label();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lbxProductos
            // 
            this.lbxProductos.FormattingEnabled = true;
            this.lbxProductos.ItemHeight = 16;
            this.lbxProductos.Items.AddRange(new object[] {
            "Producto, Modelo, Tamaño, Procesador, RAM, ROM, Cámara"});
            this.lbxProductos.Location = new System.Drawing.Point(405, 26);
            this.lbxProductos.Name = "lbxProductos";
            this.lbxProductos.Size = new System.Drawing.Size(383, 244);
            this.lbxProductos.TabIndex = 0;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(277, 80);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(100, 25);
            this.btnAgregar.TabIndex = 1;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnRemover
            // 
            this.btnRemover.Location = new System.Drawing.Point(277, 125);
            this.btnRemover.Name = "btnRemover";
            this.btnRemover.Size = new System.Drawing.Size(100, 25);
            this.btnRemover.TabIndex = 2;
            this.btnRemover.Text = "Remover";
            this.btnRemover.UseVisualStyleBackColor = true;
            this.btnRemover.Click += new System.EventHandler(this.btnRemover_Click);
            // 
            // btnFabricar
            // 
            this.btnFabricar.Location = new System.Drawing.Point(277, 169);
            this.btnFabricar.Name = "btnFabricar";
            this.btnFabricar.Size = new System.Drawing.Size(100, 25);
            this.btnFabricar.TabIndex = 3;
            this.btnFabricar.Text = "Fabricar";
            this.btnFabricar.UseVisualStyleBackColor = true;
            this.btnFabricar.Click += new System.EventHandler(this.btnFabricar_Click);
            // 
            // lblModelo
            // 
            this.lblModelo.AutoSize = true;
            this.lblModelo.Location = new System.Drawing.Point(223, 29);
            this.lblModelo.Name = "lblModelo";
            this.lblModelo.Size = new System.Drawing.Size(54, 17);
            this.lblModelo.TabIndex = 4;
            this.lblModelo.Text = "Modelo";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(277, 26);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 5;
            // 
            // lblProducto
            // 
            this.lblProducto.AutoSize = true;
            this.lblProducto.Location = new System.Drawing.Point(32, 26);
            this.lblProducto.Name = "lblProducto";
            this.lblProducto.Size = new System.Drawing.Size(65, 17);
            this.lblProducto.TabIndex = 6;
            this.lblProducto.Text = "Producto";
            // 
            // lbxProducto
            // 
            this.lbxProducto.FormattingEnabled = true;
            this.lbxProducto.ItemHeight = 16;
            this.lbxProducto.Items.AddRange(new object[] {
            "Celular",
            "Tablet",
            "SmartWatch"});
            this.lbxProducto.Location = new System.Drawing.Point(103, 26);
            this.lbxProducto.Name = "lbxProducto";
            this.lbxProducto.Size = new System.Drawing.Size(104, 52);
            this.lbxProducto.TabIndex = 7;
            // 
            // lbxProcesador
            // 
            this.lbxProcesador.FormattingEnabled = true;
            this.lbxProcesador.ItemHeight = 16;
            this.lbxProcesador.Items.AddRange(new object[] {
            "Snapdragon",
            "Exynos",
            "Helio"});
            this.lbxProcesador.Location = new System.Drawing.Point(103, 142);
            this.lbxProcesador.Name = "lbxProcesador";
            this.lbxProcesador.Size = new System.Drawing.Size(104, 52);
            this.lbxProcesador.TabIndex = 9;
            // 
            // lblProcesador
            // 
            this.lblProcesador.AutoSize = true;
            this.lblProcesador.Location = new System.Drawing.Point(16, 142);
            this.lblProcesador.Name = "lblProcesador";
            this.lblProcesador.Size = new System.Drawing.Size(81, 17);
            this.lblProcesador.TabIndex = 8;
            this.lblProcesador.Text = "Procesador";
            // 
            // lblRam
            // 
            this.lblRam.AutoSize = true;
            this.lblRam.Location = new System.Drawing.Point(18, 212);
            this.lblRam.Name = "lblRam";
            this.lblRam.Size = new System.Drawing.Size(38, 17);
            this.lblRam.TabIndex = 10;
            this.lblRam.Text = "RAM";
            // 
            // lblRom
            // 
            this.lblRom.AutoSize = true;
            this.lblRom.Location = new System.Drawing.Point(113, 212);
            this.lblRom.Name = "lblRom";
            this.lblRom.Size = new System.Drawing.Size(40, 17);
            this.lblRom.TabIndex = 12;
            this.lblRom.Text = "ROM";
            // 
            // lblCamara
            // 
            this.lblCamara.AutoSize = true;
            this.lblCamara.Location = new System.Drawing.Point(96, 251);
            this.lblCamara.Name = "lblCamara";
            this.lblCamara.Size = new System.Drawing.Size(57, 17);
            this.lblCamara.TabIndex = 14;
            this.lblCamara.Text = "Cámara";
            // 
            // cbxRam
            // 
            this.cbxRam.FormattingEnabled = true;
            this.cbxRam.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.cbxRam.Location = new System.Drawing.Point(58, 209);
            this.cbxRam.Name = "cbxRam";
            this.cbxRam.Size = new System.Drawing.Size(49, 24);
            this.cbxRam.TabIndex = 15;
            // 
            // cbxRom
            // 
            this.cbxRom.FormattingEnabled = true;
            this.cbxRom.Items.AddRange(new object[] {
            "16",
            "32",
            "64",
            "128"});
            this.cbxRom.Location = new System.Drawing.Point(159, 209);
            this.cbxRom.Name = "cbxRom";
            this.cbxRom.Size = new System.Drawing.Size(49, 24);
            this.cbxRom.TabIndex = 16;
            // 
            // cbxCamara
            // 
            this.cbxCamara.FormattingEnabled = true;
            this.cbxCamara.Items.AddRange(new object[] {
            "8",
            "13",
            "48",
            "64"});
            this.cbxCamara.Location = new System.Drawing.Point(159, 248);
            this.cbxCamara.Name = "cbxCamara";
            this.cbxCamara.Size = new System.Drawing.Size(49, 24);
            this.cbxCamara.TabIndex = 17;
            // 
            // lblTamanio
            // 
            this.lblTamanio.AutoSize = true;
            this.lblTamanio.Location = new System.Drawing.Point(37, 84);
            this.lblTamanio.Name = "lblTamanio";
            this.lblTamanio.Size = new System.Drawing.Size(60, 17);
            this.lblTamanio.TabIndex = 18;
            this.lblTamanio.Text = "Tamaño";
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 16;
            this.listBox2.Items.AddRange(new object[] {
            "Chico",
            "Mediano",
            "Grande"});
            this.listBox2.Location = new System.Drawing.Point(103, 84);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(104, 52);
            this.listBox2.TabIndex = 19;
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 295);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.lblTamanio);
            this.Controls.Add(this.cbxCamara);
            this.Controls.Add(this.cbxRom);
            this.Controls.Add(this.cbxRam);
            this.Controls.Add(this.lblCamara);
            this.Controls.Add(this.lblRom);
            this.Controls.Add(this.lblRam);
            this.Controls.Add(this.lbxProcesador);
            this.Controls.Add(this.lblProcesador);
            this.Controls.Add(this.lbxProducto);
            this.Controls.Add(this.lblProducto);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lblModelo);
            this.Controls.Add(this.btnFabricar);
            this.Controls.Add(this.btnRemover);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.lbxProductos);
            this.Name = "Inicio";
            this.Text = "Lorenzo Nahuel Cea Ko, 2A";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbxProductos;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnRemover;
        private System.Windows.Forms.Button btnFabricar;
        private System.Windows.Forms.Label lblModelo;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lblProducto;
        private System.Windows.Forms.ListBox lbxProducto;
        private System.Windows.Forms.ListBox lbxProcesador;
        private System.Windows.Forms.Label lblProcesador;
        private System.Windows.Forms.Label lblRam;
        private System.Windows.Forms.Label lblRom;
        private System.Windows.Forms.Label lblCamara;
        private System.Windows.Forms.ComboBox cbxRam;
        private System.Windows.Forms.ComboBox cbxRom;
        private System.Windows.Forms.ComboBox cbxCamara;
        private System.Windows.Forms.Label lblTamanio;
        private System.Windows.Forms.ListBox listBox2;
    }
}

