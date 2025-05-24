namespace Transacciones_C_
{
    partial class Registrador
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Registrador));
            txtBxNombre = new TextBox();
            txtBxIdentificacion = new TextBox();
            LblNombre = new Label();
            LblIdentificacion = new Label();
            LblNumeroC = new Label();
            LblSaldoI = new Label();
            txtBxNumeroC = new TextBox();
            txtBxSaldoI = new TextBox();
            btnRegistrar = new Button();
            LblPersonal = new Label();
            LblCuenta = new Label();
            PanelRegistrador = new Panel();
            PanelRegistrador.SuspendLayout();
            SuspendLayout();
            // 
            // txtBxNombre
            // 
            txtBxNombre.Location = new Point(146, 46);
            txtBxNombre.Name = "txtBxNombre";
            txtBxNombre.Size = new Size(171, 23);
            txtBxNombre.TabIndex = 0;
            // 
            // txtBxIdentificacion
            // 
            txtBxIdentificacion.Location = new Point(146, 75);
            txtBxIdentificacion.Name = "txtBxIdentificacion";
            txtBxIdentificacion.Size = new Size(171, 23);
            txtBxIdentificacion.TabIndex = 2;
            // 
            // LblNombre
            // 
            LblNombre.AutoSize = true;
            LblNombre.Font = new Font("Sitka Small", 9F);
            LblNombre.Location = new Point(17, 47);
            LblNombre.Name = "LblNombre";
            LblNombre.Size = new Size(122, 18);
            LblNombre.TabIndex = 3;
            LblNombre.Text = "Nombre Completo:";
            // 
            // LblIdentificacion
            // 
            LblIdentificacion.AutoSize = true;
            LblIdentificacion.Font = new Font("Sitka Small", 9F);
            LblIdentificacion.Location = new Point(84, 76);
            LblIdentificacion.Name = "LblIdentificacion";
            LblIdentificacion.Size = new Size(55, 18);
            LblIdentificacion.TabIndex = 4;
            LblIdentificacion.Text = "Cédula:";
            // 
            // LblNumeroC
            // 
            LblNumeroC.AutoSize = true;
            LblNumeroC.Font = new Font("Sitka Small", 9F);
            LblNumeroC.Location = new Point(12, 162);
            LblNumeroC.Name = "LblNumeroC";
            LblNumeroC.Size = new Size(128, 18);
            LblNumeroC.TabIndex = 5;
            LblNumeroC.Text = "Número de Cuenta:";
            // 
            // LblSaldoI
            // 
            LblSaldoI.AutoSize = true;
            LblSaldoI.Font = new Font("Sitka Small", 9F);
            LblSaldoI.Location = new Point(51, 195);
            LblSaldoI.Name = "LblSaldoI";
            LblSaldoI.Size = new Size(88, 18);
            LblSaldoI.TabIndex = 6;
            LblSaldoI.Text = "Saldo Inicial:";
            // 
            // txtBxNumeroC
            // 
            txtBxNumeroC.Location = new Point(146, 161);
            txtBxNumeroC.Name = "txtBxNumeroC";
            txtBxNumeroC.Size = new Size(171, 23);
            txtBxNumeroC.TabIndex = 7;
            // 
            // txtBxSaldoI
            // 
            txtBxSaldoI.Location = new Point(146, 190);
            txtBxSaldoI.Name = "txtBxSaldoI";
            txtBxSaldoI.Size = new Size(171, 23);
            txtBxSaldoI.TabIndex = 9;
            txtBxSaldoI.Text = "C$";
            txtBxSaldoI.TextChanged += txtBxSaldoI_TextChanged;
            // 
            // btnRegistrar
            // 
            btnRegistrar.BackColor = SystemColors.Highlight;
            btnRegistrar.Font = new Font("Sitka Small", 9F, FontStyle.Bold);
            btnRegistrar.ForeColor = SystemColors.ButtonFace;
            btnRegistrar.Location = new Point(131, 248);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(97, 35);
            btnRegistrar.TabIndex = 10;
            btnRegistrar.Text = "Registrar";
            btnRegistrar.UseVisualStyleBackColor = false;
            btnRegistrar.Click += btnRegistrar_Click;
            // 
            // LblPersonal
            // 
            LblPersonal.AutoSize = true;
            LblPersonal.Font = new Font("Sitka Small", 11.25F, FontStyle.Bold);
            LblPersonal.Location = new Point(96, 11);
            LblPersonal.Name = "LblPersonal";
            LblPersonal.Size = new Size(148, 23);
            LblPersonal.TabIndex = 11;
            LblPersonal.Text = "Datos Personales";
            // 
            // LblCuenta
            // 
            LblCuenta.AutoSize = true;
            LblCuenta.Font = new Font("Sitka Small", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblCuenta.Location = new Point(84, 123);
            LblCuenta.Name = "LblCuenta";
            LblCuenta.Size = new Size(160, 23);
            LblCuenta.TabIndex = 12;
            LblCuenta.Text = "Datos de la Cuenta";
            // 
            // PanelRegistrador
            // 
            PanelRegistrador.BackColor = SystemColors.ControlLight;
            PanelRegistrador.Controls.Add(LblPersonal);
            PanelRegistrador.Controls.Add(LblCuenta);
            PanelRegistrador.Controls.Add(txtBxNombre);
            PanelRegistrador.Controls.Add(txtBxIdentificacion);
            PanelRegistrador.Controls.Add(LblNombre);
            PanelRegistrador.Controls.Add(txtBxSaldoI);
            PanelRegistrador.Controls.Add(LblIdentificacion);
            PanelRegistrador.Controls.Add(txtBxNumeroC);
            PanelRegistrador.Controls.Add(LblNumeroC);
            PanelRegistrador.Controls.Add(LblSaldoI);
            PanelRegistrador.Location = new Point(12, 12);
            PanelRegistrador.Name = "PanelRegistrador";
            PanelRegistrador.Size = new Size(335, 230);
            PanelRegistrador.TabIndex = 13;
            // 
            // Registrador
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(359, 295);
            Controls.Add(PanelRegistrador);
            Controls.Add(btnRegistrar);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Registrador";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bancanet / Registrador";
            PanelRegistrador.ResumeLayout(false);
            PanelRegistrador.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TextBox txtBxNombre;
        private TextBox txtBxIdentificacion;
        private Label LblNombre;
        private Label LblIdentificacion;
        private Label LblNumeroC;
        private Label LblSaldoI;
        private TextBox txtBxNumeroC;
        private TextBox txtBxSaldoI;
        private Button btnRegistrar;
        private Label LblPersonal;
        private Label LblCuenta;
        private Panel PanelRegistrador;
    }
}