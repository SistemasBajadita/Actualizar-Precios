namespace ActualizarPrecios
{
    partial class FrmProducto
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			this.TxtFiltro = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.DgProductos = new System.Windows.Forms.DataGridView();
			this.label1 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.DgProductos)).BeginInit();
			this.SuspendLayout();
			// 
			// TxtFiltro
			// 
			this.TxtFiltro.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TxtFiltro.Location = new System.Drawing.Point(100, 24);
			this.TxtFiltro.Name = "TxtFiltro";
			this.TxtFiltro.Size = new System.Drawing.Size(646, 31);
			this.TxtFiltro.TabIndex = 6;
			this.TxtFiltro.TextChanged += new System.EventHandler(this.TxtFiltro_TextChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(33, 28);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(61, 23);
			this.label2.TabIndex = 5;
			this.label2.Text = "Filtro";
			// 
			// DgProductos
			// 
			this.DgProductos.AllowUserToAddRows = false;
			this.DgProductos.AllowUserToDeleteRows = false;
			this.DgProductos.AllowUserToResizeRows = false;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Lucida Sans", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
			this.DgProductos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			this.DgProductos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
			this.DgProductos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
			this.DgProductos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
			this.DgProductos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Lucida Sans", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.DgProductos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
			this.DgProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.DgProductos.EnableHeadersVisualStyles = false;
			this.DgProductos.Location = new System.Drawing.Point(12, 72);
			this.DgProductos.Name = "DgProductos";
			this.DgProductos.ReadOnly = true;
			this.DgProductos.RowHeadersVisible = false;
			this.DgProductos.RowHeadersWidth = 51;
			dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			dataGridViewCellStyle3.Font = new System.Drawing.Font("Lucida Sans", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
			this.DgProductos.RowsDefaultCellStyle = dataGridViewCellStyle3;
			this.DgProductos.RowTemplate.Height = 24;
			this.DgProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.DgProductos.Size = new System.Drawing.Size(773, 225);
			this.DgProductos.TabIndex = 7;
			this.DgProductos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgProductos_CellContentClick);
			this.DgProductos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DgProductos_KeyDown);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Lucida Sans", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(26, 305);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(348, 19);
			this.label1.TabIndex = 8;
			this.label1.Text = "*haz doble click o enter para seleccionar";
			// 
			// FrmProducto
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(145)))), ((int)(((byte)(58)))));
			this.ClientSize = new System.Drawing.Size(797, 330);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.DgProductos);
			this.Controls.Add(this.TxtFiltro);
			this.Controls.Add(this.label2);
			this.Name = "FrmProducto";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Buscar producto";
			this.Load += new System.EventHandler(this.FrmProducto_Load);
			((System.ComponentModel.ISupportInitialize)(this.DgProductos)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtFiltro;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView DgProductos;
        private System.Windows.Forms.Label label1;
    }
}