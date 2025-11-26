namespace ProcessadorVendas
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
            btnCalcular = new Button();
            dataGridView1 = new DataGridView();
            label1 = new Label();
            gridVendas = new DataGridView();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridVendas).BeginInit();
            SuspendLayout();
            // 
            // btnCalcular
            // 
            btnCalcular.Location = new Point(758, 571);
            btnCalcular.Name = "btnCalcular";
            btnCalcular.Size = new Size(173, 29);
            btnCalcular.TabIndex = 0;
            btnCalcular.Text = "Calcular Comissões";
            btnCalcular.UseVisualStyleBackColor = true;
            btnCalcular.Click += btnCalcular_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 375);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(919, 190);
            dataGridView1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 352);
            label1.Name = "label1";
            label1.Size = new Size(183, 23);
            label1.TabIndex = 2;
            label1.Text = "Comissões calculadas:";
            // 
            // gridVendas
            // 
            gridVendas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridVendas.Location = new Point(12, 27);
            gridVendas.Name = "gridVendas";
            gridVendas.RowHeadersWidth = 51;
            gridVendas.Size = new Size(919, 299);
            gridVendas.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 1);
            label2.Name = "label2";
            label2.Size = new Size(220, 23);
            label2.TabIndex = 4;
            label2.Text = "Todas as vendas realizadas";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(943, 612);
            Controls.Add(label2);
            Controls.Add(gridVendas);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Controls.Add(btnCalcular);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "Processador Vendas";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridVendas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCalcular;
        private DataGridView dataGridView1;
        private Label label1;
        private DataGridView gridVendas;
        private Label label2;
    }
}
