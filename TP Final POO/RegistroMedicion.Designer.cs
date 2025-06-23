namespace TP_Final_POO
{
    partial class RegistroMedicion
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
            this.dtpFechaHora = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtResponsable = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.numCantidadAgua = new System.Windows.Forms.NumericUpDown();
            this.dgvMediciones = new System.Windows.Forms.DataGridView();
            this.Eliminar = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.numCantidadAgua)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMediciones)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbLocalidades
            // 
            this.cmbLocalidades.FormattingEnabled = true;
            this.cmbLocalidades.Location = new System.Drawing.Point(16, 41);
            this.cmbLocalidades.Name = "cmbLocalidades";
            this.cmbLocalidades.Size = new System.Drawing.Size(121, 21);
            this.cmbLocalidades.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Seleccione la localidad:";
            // 
            // dtpFechaHora
            // 
            this.dtpFechaHora.Location = new System.Drawing.Point(16, 81);
            this.dtpFechaHora.Name = "dtpFechaHora";
            this.dtpFechaHora.Size = new System.Drawing.Size(200, 20);
            this.dtpFechaHora.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Dia y fecha de medición:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Cantidad agua caida:";
            // 
            // txtResponsable
            // 
            this.txtResponsable.Enabled = false;
            this.txtResponsable.Location = new System.Drawing.Point(141, 152);
            this.txtResponsable.Name = "txtResponsable";
            this.txtResponsable.Size = new System.Drawing.Size(100, 20);
            this.txtResponsable.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 26);
            this.label4.TabIndex = 7;
            this.label4.Text = "Nombre del \r\nresponsable del registro:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(38, 195);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 9;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(141, 195);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(109, 23);
            this.btnVolver.TabIndex = 10;
            this.btnVolver.Text = "Volver al Menú";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.button2_Click);
            // 
            // numCantidadAgua
            // 
            this.numCantidadAgua.Location = new System.Drawing.Point(130, 112);
            this.numCantidadAgua.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numCantidadAgua.Name = "numCantidadAgua";
            this.numCantidadAgua.Size = new System.Drawing.Size(120, 20);
            this.numCantidadAgua.TabIndex = 11;
            // 
            // dgvMediciones
            // 
            this.dgvMediciones.AllowUserToAddRows = false;
            this.dgvMediciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMediciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMediciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Eliminar});
            this.dgvMediciones.Location = new System.Drawing.Point(356, 22);
            this.dgvMediciones.Name = "dgvMediciones";
            this.dgvMediciones.ReadOnly = true;
            this.dgvMediciones.Size = new System.Drawing.Size(524, 346);
            this.dgvMediciones.TabIndex = 12;
            this.dgvMediciones.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMediciones_CellContentClick);
            // 
            // Eliminar
            // 
            this.Eliminar.HeaderText = "Eliminar";
            this.Eliminar.Name = "Eliminar";
            this.Eliminar.ReadOnly = true;
            this.Eliminar.UseColumnTextForButtonValue = true;
            // 
            // RegistroMedicion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(904, 446);
            this.Controls.Add(this.dgvMediciones);
            this.Controls.Add(this.numCantidadAgua);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtResponsable);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpFechaHora);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbLocalidades);
            this.Name = "RegistroMedicion";
            this.Text = "RegistroMedicion";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.RegistroMedicion_FormClosed_1);
            this.Load += new System.EventHandler(this.RegistroMedicion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numCantidadAgua)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMediciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbLocalidades;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpFechaHora;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtResponsable;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.NumericUpDown numCantidadAgua;
        private System.Windows.Forms.DataGridView dgvMediciones;
        private System.Windows.Forms.DataGridViewButtonColumn Eliminar;
    }
}