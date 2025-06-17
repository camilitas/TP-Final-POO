namespace TP_Final_POO
{
    partial class ConsultarMedicion
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
            this.cmbLocalidades = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpFechaDesde = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.dgvResultados = new System.Windows.Forms.DataGridView();
            this.btnVolver = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpFechaHasta = new System.Windows.Forms.DateTimePicker();
            this.lblTotalLluvia = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblResultadoHora = new System.Windows.Forms.Label();
            this.btnBuscarMaxPorHora = new System.Windows.Forms.Button();
            this.numHora = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultados)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numHora)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbLocalidades
            // 
            this.cmbLocalidades.FormattingEnabled = true;
            this.cmbLocalidades.Location = new System.Drawing.Point(12, 37);
            this.cmbLocalidades.Name = "cmbLocalidades";
            this.cmbLocalidades.Size = new System.Drawing.Size(136, 21);
            this.cmbLocalidades.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Localidades:";
            // 
            // dtpFechaDesde
            // 
            this.dtpFechaDesde.Location = new System.Drawing.Point(12, 91);
            this.dtpFechaDesde.Name = "dtpFechaDesde";
            this.dtpFechaDesde.Size = new System.Drawing.Size(228, 20);
            this.dtpFechaDesde.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Fecha desde:";
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Location = new System.Drawing.Point(15, 211);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(90, 32);
            this.btnFiltrar.TabIndex = 4;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = true;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // dgvResultados
            // 
            this.dgvResultados.AllowUserToAddRows = false;
            this.dgvResultados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvResultados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResultados.Location = new System.Drawing.Point(405, 21);
            this.dgvResultados.Name = "dgvResultados";
            this.dgvResultados.ReadOnly = true;
            this.dgvResultados.Size = new System.Drawing.Size(514, 189);
            this.dgvResultados.TabIndex = 5;
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(118, 211);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(90, 32);
            this.btnVolver.TabIndex = 6;
            this.btnVolver.Text = "Volver al Menú";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.button2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Fecha hasta:";
            // 
            // dtpFechaHasta
            // 
            this.dtpFechaHasta.Location = new System.Drawing.Point(12, 166);
            this.dtpFechaHasta.Name = "dtpFechaHasta";
            this.dtpFechaHasta.Size = new System.Drawing.Size(215, 20);
            this.dtpFechaHasta.TabIndex = 8;
            // 
            // lblTotalLluvia
            // 
            this.lblTotalLluvia.AutoSize = true;
            this.lblTotalLluvia.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalLluvia.Location = new System.Drawing.Point(464, 235);
            this.lblTotalLluvia.Name = "lblTotalLluvia";
            this.lblTotalLluvia.Size = new System.Drawing.Size(304, 37);
            this.lblTotalLluvia.TabIndex = 9;
            this.lblTotalLluvia.Text = "Total de lluvia: 0mm";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblResultadoHora);
            this.groupBox1.Controls.Add(this.btnBuscarMaxPorHora);
            this.groupBox1.Controls.Add(this.numHora);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(370, 295);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(579, 158);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Consulta por hora";
            // 
            // lblResultadoHora
            // 
            this.lblResultadoHora.AutoSize = true;
            this.lblResultadoHora.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResultadoHora.Location = new System.Drawing.Point(-3, 121);
            this.lblResultadoHora.Name = "lblResultadoHora";
            this.lblResultadoHora.Size = new System.Drawing.Size(79, 18);
            this.lblResultadoHora.TabIndex = 3;
            this.lblResultadoHora.Text = "Resultado:";
            // 
            // btnBuscarMaxPorHora
            // 
            this.btnBuscarMaxPorHora.Location = new System.Drawing.Point(243, 34);
            this.btnBuscarMaxPorHora.Name = "btnBuscarMaxPorHora";
            this.btnBuscarMaxPorHora.Size = new System.Drawing.Size(174, 41);
            this.btnBuscarMaxPorHora.TabIndex = 2;
            this.btnBuscarMaxPorHora.Text = "Buscar Máximo";
            this.btnBuscarMaxPorHora.UseVisualStyleBackColor = true;
            this.btnBuscarMaxPorHora.Click += new System.EventHandler(this.btnBuscarMaxPorHora_Click);
            // 
            // numHora
            // 
            this.numHora.Location = new System.Drawing.Point(47, 66);
            this.numHora.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.numHora.Name = "numHora";
            this.numHora.Size = new System.Drawing.Size(120, 24);
            this.numHora.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(177, 18);
            this.label4.TabIndex = 0;
            this.label4.Text = "Seleccione la hora (0-23):";
            // 
            // ConsultarMedicion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(1037, 477);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblTotalLluvia);
            this.Controls.Add(this.dtpFechaHasta);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.dgvResultados);
            this.Controls.Add(this.btnFiltrar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpFechaDesde);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbLocalidades);
            this.Name = "ConsultarMedicion";
            this.Text = "ConsultarMedicion";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ConsultarMedicion_FormClosed);
            this.Load += new System.EventHandler(this.ConsultarMedicion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultados)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numHora)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbLocalidades;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpFechaDesde;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.DataGridView dgvResultados;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpFechaHasta;
        private System.Windows.Forms.Label lblTotalLluvia;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblResultadoHora;
        private System.Windows.Forms.Button btnBuscarMaxPorHora;
        private System.Windows.Forms.NumericUpDown numHora;
        private System.Windows.Forms.Label label4;
    }
}