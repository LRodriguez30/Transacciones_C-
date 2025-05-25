namespace Transacciones_C_
{
    partial class Transferencia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Transferencia));
            txtBxBuscarACOrigen = new TextBox();
            cmbBxCOrigen = new ComboBox();
            txtBxBuscarACDestino = new TextBox();
            cmbBxCDestino = new ComboBox();
            txtBxSaldo = new TextBox();
            btnConfirmar = new Button();
            LblCOrigen = new Label();
            LblCDestino = new Label();
            lblCOrigenBuscarA = new Label();
            lblCDestinoBuscarA = new Label();
            PanelCOrigen = new Panel();
            lblCOrigenBuscarC = new Label();
            txtBxBuscarCCOrigen = new TextBox();
            lblCOrigenAlias = new Label();
            txtBxAliasCOrigen = new TextBox();
            lblCOrigenCuenta = new Label();
            LblSaldo = new Label();
            PanelCDestino = new Panel();
            lblCDestinoBuscarC = new Label();
            lblCDestinoAlias = new Label();
            txtBxBuscarCCDestino = new TextBox();
            txtBxAliasCDestino = new TextBox();
            lblCDestinoCuenta = new Label();
            PanelCOrigen.SuspendLayout();
            PanelCDestino.SuspendLayout();
            SuspendLayout();
            // 
            // txtBxBuscarACOrigen
            // 
            txtBxBuscarACOrigen.Location = new Point(144, 50);
            txtBxBuscarACOrigen.Name = "txtBxBuscarACOrigen";
            txtBxBuscarACOrigen.Size = new Size(127, 23);
            txtBxBuscarACOrigen.TabIndex = 0;
            txtBxBuscarACOrigen.TextChanged += txtBxBuscarACOrigen_TextChanged;
            // 
            // cmbBxCOrigen
            // 
            cmbBxCOrigen.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBxCOrigen.FormattingEnabled = true;
            cmbBxCOrigen.Location = new Point(144, 112);
            cmbBxCOrigen.Name = "cmbBxCOrigen";
            cmbBxCOrigen.Size = new Size(127, 23);
            cmbBxCOrigen.TabIndex = 1;
            cmbBxCOrigen.SelectedIndexChanged += cmbBxCOrigen_SelectedIndexChanged;
            // 
            // txtBxBuscarACDestino
            // 
            txtBxBuscarACDestino.Enabled = false;
            txtBxBuscarACDestino.Location = new Point(152, 50);
            txtBxBuscarACDestino.Name = "txtBxBuscarACDestino";
            txtBxBuscarACDestino.Size = new Size(127, 23);
            txtBxBuscarACDestino.TabIndex = 2;
            txtBxBuscarACDestino.TextChanged += txtBxBuscarACDestino_TextChanged;
            // 
            // cmbBxCDestino
            // 
            cmbBxCDestino.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBxCDestino.FormattingEnabled = true;
            cmbBxCDestino.Location = new Point(152, 107);
            cmbBxCDestino.Name = "cmbBxCDestino";
            cmbBxCDestino.Size = new Size(127, 23);
            cmbBxCDestino.TabIndex = 3;
            cmbBxCDestino.SelectedIndexChanged += cmbBxCDestino_SelectedIndexChanged;
            // 
            // txtBxSaldo
            // 
            txtBxSaldo.Location = new Point(144, 170);
            txtBxSaldo.Name = "txtBxSaldo";
            txtBxSaldo.Size = new Size(127, 23);
            txtBxSaldo.TabIndex = 4;
            txtBxSaldo.Text = "C$";
            txtBxSaldo.TextChanged += txtBxSaldo_TextChanged;
            // 
            // btnConfirmar
            // 
            btnConfirmar.BackColor = SystemColors.Highlight;
            btnConfirmar.Font = new Font("Sitka Small", 9F, FontStyle.Bold);
            btnConfirmar.ForeColor = SystemColors.ButtonFace;
            btnConfirmar.Location = new Point(409, 205);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.Size = new Size(105, 38);
            btnConfirmar.TabIndex = 5;
            btnConfirmar.Text = "Transferir";
            btnConfirmar.UseVisualStyleBackColor = false;
            btnConfirmar.Click += btnConfirmar_Click;
            // 
            // LblCOrigen
            // 
            LblCOrigen.AutoSize = true;
            LblCOrigen.Font = new Font("Sitka Small", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblCOrigen.Location = new Point(68, 15);
            LblCOrigen.Name = "LblCOrigen";
            LblCOrigen.Size = new Size(148, 23);
            LblCOrigen.TabIndex = 6;
            LblCOrigen.Text = "Cuenta de Origen";
            // 
            // LblCDestino
            // 
            LblCDestino.AutoSize = true;
            LblCDestino.Font = new Font("Sitka Small", 11.25F, FontStyle.Bold);
            LblCDestino.Location = new Point(34, 15);
            LblCDestino.Name = "LblCDestino";
            LblCDestino.Size = new Size(156, 23);
            LblCDestino.TabIndex = 7;
            LblCDestino.Text = "Cuenta de Destino";
            // 
            // lblCOrigenBuscarA
            // 
            lblCOrigenBuscarA.AutoSize = true;
            lblCOrigenBuscarA.Font = new Font("Sitka Small", 9F);
            lblCOrigenBuscarA.Location = new Point(26, 50);
            lblCOrigenBuscarA.Name = "lblCOrigenBuscarA";
            lblCOrigenBuscarA.Size = new Size(112, 18);
            lblCOrigenBuscarA.TabIndex = 8;
            lblCOrigenBuscarA.Text = "Buscar por Alias:";
            // 
            // lblCDestinoBuscarA
            // 
            lblCDestinoBuscarA.AutoSize = true;
            lblCDestinoBuscarA.Font = new Font("Sitka Small", 9F);
            lblCDestinoBuscarA.Location = new Point(34, 54);
            lblCDestinoBuscarA.Name = "lblCDestinoBuscarA";
            lblCDestinoBuscarA.Size = new Size(112, 18);
            lblCDestinoBuscarA.TabIndex = 9;
            lblCDestinoBuscarA.Text = "Buscar por Alias:";
            // 
            // PanelCOrigen
            // 
            PanelCOrigen.BackColor = SystemColors.ControlLight;
            PanelCOrigen.Controls.Add(lblCOrigenBuscarC);
            PanelCOrigen.Controls.Add(txtBxBuscarCCOrigen);
            PanelCOrigen.Controls.Add(lblCOrigenAlias);
            PanelCOrigen.Controls.Add(txtBxAliasCOrigen);
            PanelCOrigen.Controls.Add(lblCOrigenCuenta);
            PanelCOrigen.Controls.Add(LblSaldo);
            PanelCOrigen.Controls.Add(lblCOrigenBuscarA);
            PanelCOrigen.Controls.Add(LblCOrigen);
            PanelCOrigen.Controls.Add(txtBxBuscarACOrigen);
            PanelCOrigen.Controls.Add(cmbBxCOrigen);
            PanelCOrigen.Controls.Add(txtBxSaldo);
            PanelCOrigen.Location = new Point(12, 12);
            PanelCOrigen.Name = "PanelCOrigen";
            PanelCOrigen.Size = new Size(289, 231);
            PanelCOrigen.TabIndex = 10;
            // 
            // lblCOrigenBuscarC
            // 
            lblCOrigenBuscarC.AutoSize = true;
            lblCOrigenBuscarC.Font = new Font("Sitka Small", 9F);
            lblCOrigenBuscarC.Location = new Point(12, 79);
            lblCOrigenBuscarC.Name = "lblCOrigenBuscarC";
            lblCOrigenBuscarC.Size = new Size(126, 18);
            lblCOrigenBuscarC.TabIndex = 16;
            lblCOrigenBuscarC.Text = "Buscar por Cuenta:";
            // 
            // txtBxBuscarCCOrigen
            // 
            txtBxBuscarCCOrigen.Location = new Point(144, 79);
            txtBxBuscarCCOrigen.Name = "txtBxBuscarCCOrigen";
            txtBxBuscarCCOrigen.Size = new Size(127, 23);
            txtBxBuscarCCOrigen.TabIndex = 15;
            txtBxBuscarCCOrigen.TextChanged += txtBxCCOrigen_TextChanged;
            // 
            // lblCOrigenAlias
            // 
            lblCOrigenAlias.AutoSize = true;
            lblCOrigenAlias.Font = new Font("Sitka Small", 9F);
            lblCOrigenAlias.Location = new Point(94, 141);
            lblCOrigenAlias.Name = "lblCOrigenAlias";
            lblCOrigenAlias.Size = new Size(42, 18);
            lblCOrigenAlias.TabIndex = 14;
            lblCOrigenAlias.Text = "Alias:";
            // 
            // txtBxAliasCOrigen
            // 
            txtBxAliasCOrigen.Location = new Point(144, 141);
            txtBxAliasCOrigen.Name = "txtBxAliasCOrigen";
            txtBxAliasCOrigen.ReadOnly = true;
            txtBxAliasCOrigen.Size = new Size(127, 23);
            txtBxAliasCOrigen.TabIndex = 13;
            // 
            // lblCOrigenCuenta
            // 
            lblCOrigenCuenta.AutoSize = true;
            lblCOrigenCuenta.Font = new Font("Sitka Small", 9F);
            lblCOrigenCuenta.Location = new Point(82, 112);
            lblCOrigenCuenta.Name = "lblCOrigenCuenta";
            lblCOrigenCuenta.Size = new Size(56, 18);
            lblCOrigenCuenta.TabIndex = 11;
            lblCOrigenCuenta.Text = "Cuenta:";
            // 
            // LblSaldo
            // 
            LblSaldo.AutoSize = true;
            LblSaldo.Font = new Font("Sitka Small", 9F);
            LblSaldo.Location = new Point(39, 170);
            LblSaldo.Name = "LblSaldo";
            LblSaldo.Size = new Size(99, 18);
            LblSaldo.TabIndex = 12;
            LblSaldo.Text = "Monto en NIO:";
            // 
            // PanelCDestino
            // 
            PanelCDestino.BackColor = SystemColors.ControlLight;
            PanelCDestino.Controls.Add(lblCDestinoBuscarC);
            PanelCDestino.Controls.Add(lblCDestinoAlias);
            PanelCDestino.Controls.Add(txtBxBuscarCCDestino);
            PanelCDestino.Controls.Add(txtBxAliasCDestino);
            PanelCDestino.Controls.Add(lblCDestinoCuenta);
            PanelCDestino.Controls.Add(cmbBxCDestino);
            PanelCDestino.Controls.Add(lblCDestinoBuscarA);
            PanelCDestino.Controls.Add(LblCDestino);
            PanelCDestino.Controls.Add(txtBxBuscarACDestino);
            PanelCDestino.Location = new Point(319, 12);
            PanelCDestino.Name = "PanelCDestino";
            PanelCDestino.Size = new Size(297, 176);
            PanelCDestino.TabIndex = 11;
            // 
            // lblCDestinoBuscarC
            // 
            lblCDestinoBuscarC.AutoSize = true;
            lblCDestinoBuscarC.Font = new Font("Sitka Small", 9F);
            lblCDestinoBuscarC.Location = new Point(20, 79);
            lblCDestinoBuscarC.Name = "lblCDestinoBuscarC";
            lblCDestinoBuscarC.Size = new Size(126, 18);
            lblCDestinoBuscarC.TabIndex = 18;
            lblCDestinoBuscarC.Text = "Buscar por Cuenta:";
            // 
            // lblCDestinoAlias
            // 
            lblCDestinoAlias.AutoSize = true;
            lblCDestinoAlias.Font = new Font("Sitka Small", 9F);
            lblCDestinoAlias.Location = new Point(104, 137);
            lblCDestinoAlias.Name = "lblCDestinoAlias";
            lblCDestinoAlias.Size = new Size(42, 18);
            lblCDestinoAlias.TabIndex = 15;
            lblCDestinoAlias.Text = "Alias:";
            // 
            // txtBxBuscarCCDestino
            // 
            txtBxBuscarCCDestino.Enabled = false;
            txtBxBuscarCCDestino.Location = new Point(152, 79);
            txtBxBuscarCCDestino.Name = "txtBxBuscarCCDestino";
            txtBxBuscarCCDestino.Size = new Size(127, 23);
            txtBxBuscarCCDestino.TabIndex = 17;
            txtBxBuscarCCDestino.TextChanged += txtBxBuscarCCDestino_TextChanged;
            // 
            // txtBxAliasCDestino
            // 
            txtBxAliasCDestino.Location = new Point(152, 136);
            txtBxAliasCDestino.Name = "txtBxAliasCDestino";
            txtBxAliasCDestino.ReadOnly = true;
            txtBxAliasCDestino.Size = new Size(127, 23);
            txtBxAliasCDestino.TabIndex = 14;
            // 
            // lblCDestinoCuenta
            // 
            lblCDestinoCuenta.AutoSize = true;
            lblCDestinoCuenta.Font = new Font("Sitka Small", 9F);
            lblCDestinoCuenta.Location = new Point(90, 108);
            lblCDestinoCuenta.Name = "lblCDestinoCuenta";
            lblCDestinoCuenta.Size = new Size(56, 18);
            lblCDestinoCuenta.TabIndex = 10;
            lblCDestinoCuenta.Text = "Cuenta:";
            // 
            // Transferencia
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(628, 255);
            Controls.Add(PanelCDestino);
            Controls.Add(PanelCOrigen);
            Controls.Add(btnConfirmar);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Transferencia";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bancanet / Transferencia";
            PanelCOrigen.ResumeLayout(false);
            PanelCOrigen.PerformLayout();
            PanelCDestino.ResumeLayout(false);
            PanelCDestino.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TextBox txtBxBuscarACOrigen;
        private ComboBox cmbBxCOrigen;
        private TextBox txtBxBuscarACDestino;
        private ComboBox cmbBxCDestino;
        private TextBox txtBxSaldo;
        private Button btnConfirmar;
        private Label LblCOrigen;
        private Label LblCDestino;
        private Label lblCOrigenBuscarA;
        private Label lblCDestinoBuscarA;
        private Panel PanelCOrigen;
        private Panel PanelCDestino;
        private Label LblSaldo;
        private Label lblCOrigenCuenta;
        private Label lblCDestinoCuenta;
        private TextBox txtBxAliasCOrigen;
        private TextBox txtBxAliasCDestino;
        private Label lblCOrigenAlias;
        private Label lblCDestinoAlias;
        private Label lblCOrigenBuscarC;
        private TextBox txtBxBuscarCCOrigen;
        private Label lblCDestinoBuscarC;
        private TextBox txtBxBuscarCCDestino;
    }
}