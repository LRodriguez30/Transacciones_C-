namespace Transacciones_C_
{
    partial class Bancanet
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Bancanet));
            grvBanco = new DataGridView();
            TlStripBanco = new ToolStrip();
            TlStrip_btnInfo = new ToolStripSplitButton();
            TlStrip_btnRegistrarC = new ToolStripMenuItem();
            TlStrip_Sep1 = new ToolStripSeparator();
            TlStrip_btnTransacciones = new ToolStripSplitButton();
            TlStrip_btn3MP = new ToolStripMenuItem();
            TlStrip_Sep2 = new ToolStripSeparator();
            TlStrip_btnMostrar = new ToolStripSplitButton();
            TlStrip_btnMClientes = new ToolStripMenuItem();
            TlStrip_btnMCuentas = new ToolStripMenuItem();
            TlStrip_btnMTransacciones = new ToolStripMenuItem();
            TlStrip_Sep3 = new ToolStripSeparator();
            TlStrip_prgBar = new ToolStripProgressBar();
            tbLyPanelBc = new TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)grvBanco).BeginInit();
            TlStripBanco.SuspendLayout();
            tbLyPanelBc.SuspendLayout();
            SuspendLayout();
            // 
            // grvBanco
            // 
            grvBanco.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grvBanco.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            grvBanco.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grvBanco.Dock = DockStyle.Fill;
            grvBanco.Location = new Point(25, 85);
            grvBanco.Margin = new Padding(25);
            grvBanco.Name = "grvBanco";
            grvBanco.Size = new Size(750, 340);
            grvBanco.TabIndex = 0;
            // 
            // TlStripBanco
            // 
            TlStripBanco.BackColor = SystemColors.ControlLightLight;
            TlStripBanco.Dock = DockStyle.Fill;
            TlStripBanco.Items.AddRange(new ToolStripItem[] { TlStrip_btnInfo, TlStrip_Sep1, TlStrip_btnTransacciones, TlStrip_Sep2, TlStrip_btnMostrar, TlStrip_Sep3, TlStrip_prgBar });
            TlStripBanco.Location = new Point(0, 0);
            TlStripBanco.Name = "TlStripBanco";
            TlStripBanco.RenderMode = ToolStripRenderMode.Professional;
            TlStripBanco.Size = new Size(800, 60);
            TlStripBanco.TabIndex = 1;
            // 
            // TlStrip_btnInfo
            // 
            TlStrip_btnInfo.AutoToolTip = false;
            TlStrip_btnInfo.DropDownItems.AddRange(new ToolStripItem[] { TlStrip_btnRegistrarC });
            TlStrip_btnInfo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            TlStrip_btnInfo.Image = (Image)resources.GetObject("TlStrip_btnInfo.Image");
            TlStrip_btnInfo.ImageTransparentColor = Color.Magenta;
            TlStrip_btnInfo.Name = "TlStrip_btnInfo";
            TlStrip_btnInfo.Size = new Size(93, 57);
            TlStrip_btnInfo.Text = "Cuentas";
            TlStrip_btnInfo.ButtonClick += TlStrip_btnInfo_ButtonClick;
            // 
            // TlStrip_btnRegistrarC
            // 
            TlStrip_btnRegistrarC.Font = new Font("Segoe UI", 9F);
            TlStrip_btnRegistrarC.Image = (Image)resources.GetObject("TlStrip_btnRegistrarC.Image");
            TlStrip_btnRegistrarC.Name = "TlStrip_btnRegistrarC";
            TlStrip_btnRegistrarC.Size = new Size(213, 22);
            TlStrip_btnRegistrarC.Text = "Registrar un nuevo cliente";
            TlStrip_btnRegistrarC.Click += TlStrip_btnRegistrarC_Click;
            // 
            // TlStrip_Sep1
            // 
            TlStrip_Sep1.Name = "TlStrip_Sep1";
            TlStrip_Sep1.Size = new Size(6, 60);
            // 
            // TlStrip_btnTransacciones
            // 
            TlStrip_btnTransacciones.AutoToolTip = false;
            TlStrip_btnTransacciones.DropDownItems.AddRange(new ToolStripItem[] { TlStrip_btn3MP });
            TlStrip_btnTransacciones.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            TlStrip_btnTransacciones.Image = (Image)resources.GetObject("TlStrip_btnTransacciones.Image");
            TlStrip_btnTransacciones.ImageTransparentColor = Color.Magenta;
            TlStrip_btnTransacciones.Name = "TlStrip_btnTransacciones";
            TlStrip_btnTransacciones.Size = new Size(133, 57);
            TlStrip_btnTransacciones.Text = "Transacciones";
            TlStrip_btnTransacciones.TextImageRelation = TextImageRelation.TextBeforeImage;
            TlStrip_btnTransacciones.ButtonClick += TlStrip_btnTransacciones_ButtonClick;
            // 
            // TlStrip_btn3MP
            // 
            TlStrip_btn3MP.Font = new Font("Segoe UI", 9F);
            TlStrip_btn3MP.Image = (Image)resources.GetObject("TlStrip_btn3MP.Image");
            TlStrip_btn3MP.Name = "TlStrip_btn3MP";
            TlStrip_btn3MP.Size = new Size(183, 22);
            TlStrip_btn3MP.Text = "Terceros mismo país";
            TlStrip_btn3MP.Click += TlStrip_btn3MP_Click;
            // 
            // TlStrip_Sep2
            // 
            TlStrip_Sep2.Name = "TlStrip_Sep2";
            TlStrip_Sep2.Size = new Size(6, 60);
            // 
            // TlStrip_btnMostrar
            // 
            TlStrip_btnMostrar.AutoToolTip = false;
            TlStrip_btnMostrar.DropDownItems.AddRange(new ToolStripItem[] { TlStrip_btnMClientes, TlStrip_btnMCuentas, TlStrip_btnMTransacciones });
            TlStrip_btnMostrar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            TlStrip_btnMostrar.Image = (Image)resources.GetObject("TlStrip_btnMostrar.Image");
            TlStrip_btnMostrar.ImageTransparentColor = Color.Magenta;
            TlStrip_btnMostrar.Name = "TlStrip_btnMostrar";
            TlStrip_btnMostrar.Size = new Size(79, 57);
            TlStrip_btnMostrar.Text = "Datos";
            TlStrip_btnMostrar.TextImageRelation = TextImageRelation.TextBeforeImage;
            TlStrip_btnMostrar.ButtonClick += TlStrip_btnMostrar_ButtonClick;
            // 
            // TlStrip_btnMClientes
            // 
            TlStrip_btnMClientes.Font = new Font("Segoe UI", 9F);
            TlStrip_btnMClientes.Image = (Image)resources.GetObject("TlStrip_btnMClientes.Image");
            TlStrip_btnMClientes.Name = "TlStrip_btnMClientes";
            TlStrip_btnMClientes.Size = new Size(212, 22);
            TlStrip_btnMClientes.Text = "Clientes";
            TlStrip_btnMClientes.Click += TlStrip_btnMClientes_Click;
            // 
            // TlStrip_btnMCuentas
            // 
            TlStrip_btnMCuentas.Font = new Font("Segoe UI", 9F);
            TlStrip_btnMCuentas.Image = (Image)resources.GetObject("TlStrip_btnMCuentas.Image");
            TlStrip_btnMCuentas.Name = "TlStrip_btnMCuentas";
            TlStrip_btnMCuentas.Size = new Size(212, 22);
            TlStrip_btnMCuentas.Text = "Cuentas";
            TlStrip_btnMCuentas.Click += TlStrip_btnMCuentas_Click;
            // 
            // TlStrip_btnMTransacciones
            // 
            TlStrip_btnMTransacciones.Font = new Font("Segoe UI", 9F);
            TlStrip_btnMTransacciones.Image = (Image)resources.GetObject("TlStrip_btnMTransacciones.Image");
            TlStrip_btnMTransacciones.Name = "TlStrip_btnMTransacciones";
            TlStrip_btnMTransacciones.Size = new Size(212, 22);
            TlStrip_btnMTransacciones.Text = "Historial de Transacciones";
            TlStrip_btnMTransacciones.Click += TlStrip_btnMTransacciones_Click;
            // 
            // TlStrip_Sep3
            // 
            TlStrip_Sep3.Name = "TlStrip_Sep3";
            TlStrip_Sep3.Size = new Size(6, 60);
            // 
            // TlStrip_prgBar
            // 
            TlStrip_prgBar.Margin = new Padding(15, 18, 1, 18);
            TlStrip_prgBar.Name = "TlStrip_prgBar";
            TlStrip_prgBar.Size = new Size(200, 24);
            // 
            // tbLyPanelBc
            // 
            tbLyPanelBc.ColumnCount = 1;
            tbLyPanelBc.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tbLyPanelBc.Controls.Add(TlStripBanco, 0, 0);
            tbLyPanelBc.Controls.Add(grvBanco, 0, 1);
            tbLyPanelBc.Dock = DockStyle.Fill;
            tbLyPanelBc.Location = new Point(0, 0);
            tbLyPanelBc.Name = "tbLyPanelBc";
            tbLyPanelBc.RowCount = 2;
            tbLyPanelBc.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            tbLyPanelBc.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tbLyPanelBc.Size = new Size(800, 450);
            tbLyPanelBc.TabIndex = 2;
            // 
            // Bancanet
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(800, 450);
            Controls.Add(tbLyPanelBc);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Bancanet";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bancanet";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)grvBanco).EndInit();
            TlStripBanco.ResumeLayout(false);
            TlStripBanco.PerformLayout();
            tbLyPanelBc.ResumeLayout(false);
            tbLyPanelBc.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView grvBanco;
        private ToolStrip TlStripBanco;
        private ToolStripSplitButton TlStrip_btnTransacciones;
        private ToolStripMenuItem TlStrip_btn3MP;
        private ToolStripSplitButton TlStrip_btnInfo;
        private ToolStripMenuItem TlStrip_btnRegistrarC;
        private ToolStripSeparator TlStrip_Sep2;
        private ToolStripSplitButton TlStrip_btnMostrar;
        private ToolStripMenuItem TlStrip_btnMClientes;
        private ToolStripMenuItem TlStrip_btnMCuentas;
        private ToolStripMenuItem TlStrip_btnMTransacciones;
        private ToolStripSeparator TlStrip_Sep3;
        private ToolStripProgressBar TlStrip_prgBar;
        private TableLayoutPanel tbLyPanelBc;
        private ToolStripSeparator TlStrip_Sep1;
    }
}
