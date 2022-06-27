// André Y. Terada - 20122 Rafael L.Silva - 20734

namespace CaminhosDeTrem
{
    partial class FrmCaminhosDeTrem
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
            this.pnlArvore = new System.Windows.Forms.Panel();
            this.pbxArvore = new System.Windows.Forms.PictureBox();
            this.btnIncluir = new System.Windows.Forms.Button();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.dlgAbrir = new System.Windows.Forms.OpenFileDialog();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.lbPorNiveis = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.tabPages = new System.Windows.Forms.TabControl();
            this.tbMain = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pbxMapa = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbOrigin = new System.Windows.Forms.ComboBox();
            this.cmbDest = new System.Windows.Forms.ComboBox();
            this.txtY = new System.Windows.Forms.TextBox();
            this.txtX = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.numPreco = new System.Windows.Forms.NumericUpDown();
            this.numDist = new System.Windows.Forms.NumericUpDown();
            this.lsbSaida = new System.Windows.Forms.ListBox();
            this.dgvGrafo = new System.Windows.Forms.DataGridView();
            this.btnCaminho = new System.Windows.Forms.Button();
            this.tbArvore = new System.Windows.Forms.TabPage();
            this.dlgCaminhos = new System.Windows.Forms.OpenFileDialog();
            this.pnlArvore.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxArvore)).BeginInit();
            this.tabPages.SuspendLayout();
            this.tbMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxMapa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPreco)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrafo)).BeginInit();
            this.tbArvore.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlArvore
            // 
            this.pnlArvore.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlArvore.AutoScroll = true;
            this.pnlArvore.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlArvore.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlArvore.Controls.Add(this.pbxArvore);
            this.pnlArvore.Location = new System.Drawing.Point(7, 7);
            this.pnlArvore.Margin = new System.Windows.Forms.Padding(4);
            this.pnlArvore.Name = "pnlArvore";
            this.pnlArvore.Size = new System.Drawing.Size(741, 468);
            this.pnlArvore.TabIndex = 1;
            // 
            // pbxArvore
            // 
            this.pbxArvore.Location = new System.Drawing.Point(3, 3);
            this.pbxArvore.Name = "pbxArvore";
            this.pbxArvore.Size = new System.Drawing.Size(1500, 1500);
            this.pbxArvore.TabIndex = 0;
            this.pbxArvore.TabStop = false;
            this.pbxArvore.Paint += new System.Windows.Forms.PaintEventHandler(this.pbxArvore_Paint);
            // 
            // btnIncluir
            // 
            this.btnIncluir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIncluir.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnIncluir.Location = new System.Drawing.Point(7, 9);
            this.btnIncluir.Margin = new System.Windows.Forms.Padding(4);
            this.btnIncluir.Name = "btnIncluir";
            this.btnIncluir.Size = new System.Drawing.Size(116, 41);
            this.btnIncluir.TabIndex = 8;
            this.btnIncluir.Text = "+ Cidade";
            this.btnIncluir.UseVisualStyleBackColor = true;
            this.btnIncluir.Click += new System.EventHandler(this.btnIncluir_Click);
            // 
            // txtNome
            // 
            this.txtNome.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNome.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtNome.Location = new System.Drawing.Point(7, 58);
            this.txtNome.Margin = new System.Windows.Forms.Padding(4);
            this.txtNome.MaxLength = 16;
            this.txtNome.Name = "txtNome";
            this.txtNome.PlaceholderText = "Nome Cidade";
            this.txtNome.Size = new System.Drawing.Size(242, 23);
            this.txtNome.TabIndex = 10;
            // 
            // dlgAbrir
            // 
            this.dlgAbrir.CheckFileExists = false;
            this.dlgAbrir.DefaultExt = "*.dat";
            this.dlgAbrir.InitialDirectory = "c:\\temp";
            this.dlgAbrir.Title = "Selecione o arquivo de Cidades";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscar.Location = new System.Drawing.Point(3, 71);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(475, 41);
            this.btnBuscar.TabIndex = 23;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // lbPorNiveis
            // 
            this.lbPorNiveis.AutoSize = true;
            this.lbPorNiveis.Location = new System.Drawing.Point(510, 113);
            this.lbPorNiveis.Name = "lbPorNiveis";
            this.lbPorNiveis.Size = new System.Drawing.Size(0, 16);
            this.lbPorNiveis.TabIndex = 30;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnDelete.Location = new System.Drawing.Point(131, 9);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(118, 41);
            this.btnDelete.TabIndex = 36;
            this.btnDelete.Text = "- Cidade";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // tabPages
            // 
            this.tabPages.AllowDrop = true;
            this.tabPages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabPages.Controls.Add(this.tbMain);
            this.tabPages.Controls.Add(this.tbArvore);
            this.tabPages.Location = new System.Drawing.Point(12, 12);
            this.tabPages.Name = "tabPages";
            this.tabPages.SelectedIndex = 0;
            this.tabPages.Size = new System.Drawing.Size(760, 511);
            this.tabPages.TabIndex = 37;
            // 
            // tbMain
            // 
            this.tbMain.Controls.Add(this.splitContainer1);
            this.tbMain.Location = new System.Drawing.Point(4, 25);
            this.tbMain.Name = "tbMain";
            this.tbMain.Padding = new System.Windows.Forms.Padding(3);
            this.tbMain.Size = new System.Drawing.Size(752, 482);
            this.tbMain.TabIndex = 0;
            this.tbMain.Text = "Mapa";
            this.tbMain.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Cursor = System.Windows.Forms.Cursors.VSplit;
            this.splitContainer1.Location = new System.Drawing.Point(6, 6);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pbxMapa);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.cmbOrigin);
            this.splitContainer1.Panel1.Controls.Add(this.cmbDest);
            this.splitContainer1.Panel1.Controls.Add(this.btnBuscar);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txtY);
            this.splitContainer1.Panel2.Controls.Add(this.txtX);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.numPreco);
            this.splitContainer1.Panel2.Controls.Add(this.numDist);
            this.splitContainer1.Panel2.Controls.Add(this.lsbSaida);
            this.splitContainer1.Panel2.Controls.Add(this.dgvGrafo);
            this.splitContainer1.Panel2.Controls.Add(this.btnIncluir);
            this.splitContainer1.Panel2.Controls.Add(this.btnCaminho);
            this.splitContainer1.Panel2.Controls.Add(this.txtNome);
            this.splitContainer1.Panel2.Controls.Add(this.btnDelete);
            this.splitContainer1.Size = new System.Drawing.Size(753, 470);
            this.splitContainer1.SplitterDistance = 481;
            this.splitContainer1.TabIndex = 42;
            // 
            // pbxMapa
            // 
            this.pbxMapa.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbxMapa.Image = global::CaminhosDeTrem.Properties.Resources.mapaEspanhaPortugal;
            this.pbxMapa.Location = new System.Drawing.Point(3, 118);
            this.pbxMapa.Name = "pbxMapa";
            this.pbxMapa.Size = new System.Drawing.Size(475, 350);
            this.pbxMapa.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxMapa.TabIndex = 48;
            this.pbxMapa.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 16);
            this.label4.TabIndex = 47;
            this.label4.Text = "Para:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 16);
            this.label3.TabIndex = 46;
            this.label3.Text = "De:";
            // 
            // cmbOrigin
            // 
            this.cmbOrigin.AccessibleDescription = "Destino Inicial";
            this.cmbOrigin.AccessibleName = "Destino Inicial";
            this.cmbOrigin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbOrigin.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbOrigin.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbOrigin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOrigin.FormattingEnabled = true;
            this.cmbOrigin.Location = new System.Drawing.Point(54, 9);
            this.cmbOrigin.Name = "cmbOrigin";
            this.cmbOrigin.Size = new System.Drawing.Size(424, 24);
            this.cmbOrigin.TabIndex = 40;
            // 
            // cmbDest
            // 
            this.cmbDest.AccessibleDescription = "Destino Inicial";
            this.cmbDest.AccessibleName = "Destino Inicial";
            this.cmbDest.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbDest.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDest.FormattingEnabled = true;
            this.cmbDest.Location = new System.Drawing.Point(54, 39);
            this.cmbDest.Name = "cmbDest";
            this.cmbDest.Size = new System.Drawing.Size(424, 24);
            this.cmbDest.TabIndex = 41;
            // 
            // txtY
            // 
            this.txtY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtY.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtY.Location = new System.Drawing.Point(131, 89);
            this.txtY.Margin = new System.Windows.Forms.Padding(4);
            this.txtY.MaxLength = 16;
            this.txtY.Name = "txtY";
            this.txtY.PlaceholderText = "Longitude (Y)";
            this.txtY.Size = new System.Drawing.Size(118, 23);
            this.txtY.TabIndex = 47;
            // 
            // txtX
            // 
            this.txtX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtX.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtX.Location = new System.Drawing.Point(7, 89);
            this.txtX.Margin = new System.Windows.Forms.Padding(4);
            this.txtX.MaxLength = 16;
            this.txtX.Name = "txtX";
            this.txtX.PlaceholderText = "Latitude (X) ";
            this.txtX.Size = new System.Drawing.Size(116, 23);
            this.txtX.TabIndex = 46;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(133, 163);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 16);
            this.label2.TabIndex = 45;
            this.label2.Text = "Preco:";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(112, 130);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 16);
            this.label1.TabIndex = 44;
            this.label1.Text = "Distancia:";
            // 
            // numPreco
            // 
            this.numPreco.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numPreco.Location = new System.Drawing.Point(187, 163);
            this.numPreco.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numPreco.Name = "numPreco";
            this.numPreco.Size = new System.Drawing.Size(62, 23);
            this.numPreco.TabIndex = 43;
            // 
            // numDist
            // 
            this.numDist.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numDist.Location = new System.Drawing.Point(187, 128);
            this.numDist.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numDist.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numDist.Name = "numDist";
            this.numDist.Size = new System.Drawing.Size(62, 23);
            this.numDist.TabIndex = 42;
            this.numDist.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lsbSaida
            // 
            this.lsbSaida.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lsbSaida.FormattingEnabled = true;
            this.lsbSaida.ItemHeight = 16;
            this.lsbSaida.Location = new System.Drawing.Point(7, 368);
            this.lsbSaida.Name = "lsbSaida";
            this.lsbSaida.Size = new System.Drawing.Size(242, 100);
            this.lsbSaida.TabIndex = 41;
            // 
            // dgvGrafo
            // 
            this.dgvGrafo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvGrafo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGrafo.Location = new System.Drawing.Point(7, 192);
            this.dgvGrafo.Name = "dgvGrafo";
            this.dgvGrafo.RowTemplate.Height = 25;
            this.dgvGrafo.Size = new System.Drawing.Size(242, 172);
            this.dgvGrafo.TabIndex = 40;
            // 
            // btnCaminho
            // 
            this.btnCaminho.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCaminho.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCaminho.Location = new System.Drawing.Point(7, 130);
            this.btnCaminho.Margin = new System.Windows.Forms.Padding(4);
            this.btnCaminho.Name = "btnCaminho";
            this.btnCaminho.Size = new System.Drawing.Size(98, 49);
            this.btnCaminho.TabIndex = 37;
            this.btnCaminho.Text = "+ Caminho";
            this.btnCaminho.UseVisualStyleBackColor = true;
            this.btnCaminho.Click += new System.EventHandler(this.btnCaminho_Click);
            // 
            // tbArvore
            // 
            this.tbArvore.Controls.Add(this.pnlArvore);
            this.tbArvore.Location = new System.Drawing.Point(4, 25);
            this.tbArvore.Name = "tbArvore";
            this.tbArvore.Padding = new System.Windows.Forms.Padding(3);
            this.tbArvore.Size = new System.Drawing.Size(752, 482);
            this.tbArvore.TabIndex = 1;
            this.tbArvore.Text = "Arvore";
            this.tbArvore.UseVisualStyleBackColor = true;
            // 
            // dlgCaminhos
            // 
            this.dlgCaminhos.CheckFileExists = false;
            this.dlgCaminhos.DefaultExt = "*.dat";
            this.dlgCaminhos.InitialDirectory = "c:\\temp";
            this.dlgCaminhos.Title = "Selecione o arquivo de Caminhos";
            // 
            // FrmCaminhosDeTrem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 526);
            this.Controls.Add(this.tabPages);
            this.Controls.Add(this.lbPorNiveis);
            this.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmCaminhosDeTrem";
            this.Text = "Caminhos de Trem";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmArvore_FormClosing);
            this.Load += new System.EventHandler(this.FrmArvore_Load);
            this.pnlArvore.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxArvore)).EndInit();
            this.tabPages.ResumeLayout(false);
            this.tbMain.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxMapa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPreco)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrafo)).EndInit();
            this.tbArvore.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel pnlArvore;
        private System.Windows.Forms.Button btnIncluir;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.OpenFileDialog dlgAbrir;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label lbPorNiveis;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.PictureBox pbxArvore;
        private System.Windows.Forms.TabControl tabPages;
        private System.Windows.Forms.TabPage tbMain;
        private System.Windows.Forms.TabPage tbArvore;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ComboBox cmbOrigin;
        private System.Windows.Forms.ComboBox cmbDest;
        private System.Windows.Forms.Button btnCaminho;
        private System.Windows.Forms.DataGridView dgvGrafo;
        private System.Windows.Forms.ListBox lsbSaida;
        private System.Windows.Forms.OpenFileDialog dlgCaminhos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numPreco;
        private System.Windows.Forms.NumericUpDown numDist;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtY;
        private System.Windows.Forms.TextBox txtX;
        private System.Windows.Forms.PictureBox pbxMapa;
    }
}

