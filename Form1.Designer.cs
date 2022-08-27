namespace WindowsFormsGaragem
{
    partial class FormGaragem
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.Tb_Placas = new System.Windows.Forms.TextBox();
            this.Bt_Saida = new System.Windows.Forms.Button();
            this.Tb_ListaEntrada = new System.Windows.Forms.TextBox();
            this.Tb_ListaHistorico = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.Tb_Cadastrar = new System.Windows.Forms.Button();
            this.Cb_TipoVeiculo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Lbl_NomeEstabelecimento = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 78);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Placa:";
            // 
            // Tb_Placas
            // 
            this.Tb_Placas.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Tb_Placas.Location = new System.Drawing.Point(113, 71);
            this.Tb_Placas.Margin = new System.Windows.Forms.Padding(4);
            this.Tb_Placas.Name = "Tb_Placas";
            this.Tb_Placas.Size = new System.Drawing.Size(187, 27);
            this.Tb_Placas.TabIndex = 3;
            // 
            // Bt_Saida
            // 
            this.Bt_Saida.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Bt_Saida.Location = new System.Drawing.Point(748, 130);
            this.Bt_Saida.Margin = new System.Windows.Forms.Padding(4);
            this.Bt_Saida.Name = "Bt_Saida";
            this.Bt_Saida.Size = new System.Drawing.Size(244, 61);
            this.Bt_Saida.TabIndex = 11;
            this.Bt_Saida.Text = "Saída: Valor a Pagar";
            this.Bt_Saida.UseVisualStyleBackColor = false;
            this.Bt_Saida.Click += new System.EventHandler(this.Bt_Saida_Click);
            // 
            // Tb_ListaEntrada
            // 
            this.Tb_ListaEntrada.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Tb_ListaEntrada.Enabled = false;
            this.Tb_ListaEntrada.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Tb_ListaEntrada.Location = new System.Drawing.Point(27, 236);
            this.Tb_ListaEntrada.Margin = new System.Windows.Forms.Padding(4);
            this.Tb_ListaEntrada.Multiline = true;
            this.Tb_ListaEntrada.Name = "Tb_ListaEntrada";
            this.Tb_ListaEntrada.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Tb_ListaEntrada.Size = new System.Drawing.Size(533, 264);
            this.Tb_ListaEntrada.TabIndex = 13;
            // 
            // Tb_ListaHistorico
            // 
            this.Tb_ListaHistorico.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Tb_ListaHistorico.Enabled = false;
            this.Tb_ListaHistorico.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Tb_ListaHistorico.ForeColor = System.Drawing.SystemColors.WindowText;
            this.Tb_ListaHistorico.Location = new System.Drawing.Point(588, 236);
            this.Tb_ListaHistorico.Margin = new System.Windows.Forms.Padding(4);
            this.Tb_ListaHistorico.Multiline = true;
            this.Tb_ListaHistorico.Name = "Tb_ListaHistorico";
            this.Tb_ListaHistorico.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Tb_ListaHistorico.Size = new System.Drawing.Size(525, 264);
            this.Tb_ListaHistorico.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 212);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(162, 20);
            this.label6.TabIndex = 15;
            this.label6.Text = "Veículos no Pátio:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(584, 212);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(170, 20);
            this.label7.TabIndex = 16;
            this.label7.Text = "Histórico Veículos:";
            // 
            // Tb_Cadastrar
            // 
            this.Tb_Cadastrar.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Tb_Cadastrar.Location = new System.Drawing.Point(183, 130);
            this.Tb_Cadastrar.Name = "Tb_Cadastrar";
            this.Tb_Cadastrar.Size = new System.Drawing.Size(244, 61);
            this.Tb_Cadastrar.TabIndex = 18;
            this.Tb_Cadastrar.Text = "Entrada";
            this.Tb_Cadastrar.UseVisualStyleBackColor = false;
            this.Tb_Cadastrar.Click += new System.EventHandler(this.Tb_Cadastrar_Click);
            // 
            // Cb_TipoVeiculo
            // 
            this.Cb_TipoVeiculo.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Cb_TipoVeiculo.ForeColor = System.Drawing.SystemColors.WindowText;
            this.Cb_TipoVeiculo.FormattingEnabled = true;
            this.Cb_TipoVeiculo.Location = new System.Drawing.Point(487, 70);
            this.Cb_TipoVeiculo.Name = "Cb_TipoVeiculo";
            this.Cb_TipoVeiculo.Size = new System.Drawing.Size(196, 28);
            this.Cb_TipoVeiculo.TabIndex = 22;
  
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(341, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 20);
            this.label4.TabIndex = 23;
            this.label4.Text = "Tipo Veículo:";
            // 
            // Lbl_NomeEstabelecimento
            // 
            this.Lbl_NomeEstabelecimento.AutoSize = true;
            this.Lbl_NomeEstabelecimento.Font = new System.Drawing.Font("Georgia", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_NomeEstabelecimento.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.Lbl_NomeEstabelecimento.Location = new System.Drawing.Point(376, 9);
            this.Lbl_NomeEstabelecimento.Name = "Lbl_NomeEstabelecimento";
            this.Lbl_NomeEstabelecimento.Size = new System.Drawing.Size(374, 32);
            this.Lbl_NomeEstabelecimento.TabIndex = 24;
            this.Lbl_NomeEstabelecimento.Text = "Nome do Establecimento";
            this.Lbl_NomeEstabelecimento.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // FormGaragem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1144, 537);
            this.Controls.Add(this.Lbl_NomeEstabelecimento);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Cb_TipoVeiculo);
            this.Controls.Add(this.Tb_Cadastrar);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Tb_ListaHistorico);
            this.Controls.Add(this.Tb_ListaEntrada);
            this.Controls.Add(this.Bt_Saida);
            this.Controls.Add(this.Tb_Placas);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormGaragem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Garagem: Estacionamento para Veículos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormGaragem_FormClosing);
            this.Load += new System.EventHandler(this.FormGaragem_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Tb_Placas;
        private System.Windows.Forms.Button Bt_Saida;
        private System.Windows.Forms.TextBox Tb_ListaEntrada;
        private System.Windows.Forms.TextBox Tb_ListaHistorico;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button Tb_Cadastrar;
        private System.Windows.Forms.ComboBox Cb_TipoVeiculo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label Lbl_NomeEstabelecimento;
    }
}

