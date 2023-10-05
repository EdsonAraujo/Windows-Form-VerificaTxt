namespace ComparacaoNomes
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            buttonComparaNome = new Button();
            textBox1 = new TextBox();
            buttonDocAtual = new Button();
            buttonDocNovo = new Button();
            buttonLimpar = new Button();
            textBox2 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            textBox3 = new TextBox();
            SuspendLayout();
            // 
            // buttonComparaNome
            // 
            buttonComparaNome.BackColor = Color.CadetBlue;
            buttonComparaNome.Font = new Font("Franklin Gothic Medium Cond", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            buttonComparaNome.ImageAlign = ContentAlignment.BottomCenter;
            buttonComparaNome.Location = new Point(153, 305);
            buttonComparaNome.Name = "buttonComparaNome";
            buttonComparaNome.Size = new Size(156, 66);
            buttonComparaNome.TabIndex = 0;
            buttonComparaNome.Text = "Verificar Nomes ";
            buttonComparaNome.UseVisualStyleBackColor = false;
            buttonComparaNome.Click += btn_ComparaNome;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            textBox1.Location = new Point(475, 37);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(463, 353);
            textBox1.TabIndex = 1;
            textBox1.TextChanged += textBox_Tela;
            // 
            // buttonDocAtual
            // 
            buttonDocAtual.BackColor = Color.Khaki;
            buttonDocAtual.Font = new Font("Franklin Gothic Medium Cond", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            buttonDocAtual.Location = new Point(124, 37);
            buttonDocAtual.Name = "buttonDocAtual";
            buttonDocAtual.Size = new Size(209, 59);
            buttonDocAtual.TabIndex = 2;
            buttonDocAtual.Text = "Carregar Arquivo \"DocAtual\"";
            buttonDocAtual.UseVisualStyleBackColor = false;
            buttonDocAtual.Click += btn_CarrArqDocAtual;
            // 
            // buttonDocNovo
            // 
            buttonDocNovo.BackColor = Color.Khaki;
            buttonDocNovo.Font = new Font("Franklin Gothic Medium Cond", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            buttonDocNovo.Location = new Point(124, 118);
            buttonDocNovo.Name = "buttonDocNovo";
            buttonDocNovo.Size = new Size(209, 59);
            buttonDocNovo.TabIndex = 3;
            buttonDocNovo.Text = "Carregar Arquivo \"DocNovo\"";
            buttonDocNovo.UseVisualStyleBackColor = false;
            buttonDocNovo.Click += btn_CarrArqDocNovo;
            // 
            // buttonLimpar
            // 
            buttonLimpar.BackColor = Color.Tomato;
            buttonLimpar.Font = new Font("Franklin Gothic Medium Cond", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            buttonLimpar.ImageAlign = ContentAlignment.BottomCenter;
            buttonLimpar.Location = new Point(153, 403);
            buttonLimpar.Name = "buttonLimpar";
            buttonLimpar.Size = new Size(156, 66);
            buttonLimpar.TabIndex = 4;
            buttonLimpar.Text = "Limpar Tela";
            buttonLimpar.UseVisualStyleBackColor = false;
            buttonLimpar.Click += btn_Limpar;
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Franklin Gothic Medium Cond", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            textBox2.Location = new Point(761, 440);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.RightToLeft = RightToLeft.No;
            textBox2.Size = new Size(177, 41);
            textBox2.TabIndex = 5;
            textBox2.TextAlign = HorizontalAlignment.Center;
            textBox2.TextChanged += textBox_Tela_Qtd_Nome;
            // 
            // label1
            // 
            label1.BackColor = Color.RosyBrown;
            label1.BorderStyle = BorderStyle.FixedSingle;
            label1.Font = new Font("Franklin Gothic Medium Cond", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(475, 440);
            label1.Name = "label1";
            label1.Size = new Size(280, 41);
            label1.TabIndex = 6;
            label1.Text = "Quantidade de Nomes Incluídos";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.BackColor = Color.RosyBrown;
            label2.BorderStyle = BorderStyle.FixedSingle;
            label2.Font = new Font("Franklin Gothic Medium Cond", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(475, 393);
            label2.Name = "label2";
            label2.Size = new Size(280, 41);
            label2.TabIndex = 7;
            label2.Text = "Quantidade de Nomes Iguais";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            label2.Click += label2_Click;
            // 
            // textBox3
            // 
            textBox3.Font = new Font("Franklin Gothic Medium Cond", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            textBox3.Location = new Point(761, 393);
            textBox3.Multiline = true;
            textBox3.Name = "textBox3";
            textBox3.RightToLeft = RightToLeft.No;
            textBox3.Size = new Size(177, 41);
            textBox3.TabIndex = 8;
            textBox3.TextAlign = HorizontalAlignment.Center;
            textBox3.TextChanged += textBox3_Tela_Qtd_Iguais;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = SystemColors.MenuHighlight;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(994, 519);
            Controls.Add(textBox3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox2);
            Controls.Add(buttonLimpar);
            Controls.Add(buttonDocNovo);
            Controls.Add(buttonDocAtual);
            Controls.Add(textBox1);
            Controls.Add(buttonComparaNome);
            Name = "Form1";
            Text = "Comparar Nomes ";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonComparaNome;
        private TextBox textBox1;
        private Button buttonDocAtual;
        private Button buttonDocNovo;
        private Button buttonLimpar;
        private TextBox textBox2;
        private Label label1;
        private Label label2;
        private TextBox textBox3;
    }
}