namespace ActualizarPrecios
{
    partial class FrmPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
			this.BtnSearchProduct = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.TxtCodigo = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.lblDescripcion = new System.Windows.Forms.Label();
			this.lblPrecio = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.TxtPrecioNuevo = new System.Windows.Forms.TextBox();
			this.BtnUpdate = new System.Windows.Forms.Button();
			this.label7 = new System.Windows.Forms.Label();
			this.lblPrecioActualizado = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.lblCosto = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.lblMargen = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// BtnSearchProduct
			// 
			this.BtnSearchProduct.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BtnSearchProduct.Location = new System.Drawing.Point(574, 82);
			this.BtnSearchProduct.Name = "BtnSearchProduct";
			this.BtnSearchProduct.Size = new System.Drawing.Size(140, 35);
			this.BtnSearchProduct.TabIndex = 0;
			this.BtnSearchProduct.Text = "Buscar";
			this.BtnSearchProduct.UseVisualStyleBackColor = true;
			this.BtnSearchProduct.Click += new System.EventHandler(this.BtnSearchProduct_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Lucida Fax", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(99, 35);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(0, 32);
			this.label1.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(245, 87);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(80, 23);
			this.label2.TabIndex = 2;
			this.label2.Text = "Codigo";
			// 
			// TxtCodigo
			// 
			this.TxtCodigo.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TxtCodigo.Location = new System.Drawing.Point(329, 84);
			this.TxtCodigo.Name = "TxtCodigo";
			this.TxtCodigo.Size = new System.Drawing.Size(239, 31);
			this.TxtCodigo.TabIndex = 3;
			this.TxtCodigo.TextChanged += new System.EventHandler(this.TxtCodigo_TextChanged);
			this.TxtCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtCodigo_KeyPress);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(55, 155);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(125, 23);
			this.label3.TabIndex = 4;
			this.label3.Text = "Descripción";
			// 
			// lblDescripcion
			// 
			this.lblDescripcion.AutoSize = true;
			this.lblDescripcion.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblDescripcion.Location = new System.Drawing.Point(186, 155);
			this.lblDescripcion.Name = "lblDescripcion";
			this.lblDescripcion.Size = new System.Drawing.Size(0, 23);
			this.lblDescripcion.TabIndex = 5;
			// 
			// lblPrecio
			// 
			this.lblPrecio.AutoSize = true;
			this.lblPrecio.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblPrecio.Location = new System.Drawing.Point(367, 193);
			this.lblPrecio.Name = "lblPrecio";
			this.lblPrecio.Size = new System.Drawing.Size(0, 23);
			this.lblPrecio.TabIndex = 7;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(292, 193);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(69, 23);
			this.label5.TabIndex = 6;
			this.label5.Text = "Precio";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.Location = new System.Drawing.Point(245, 272);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(138, 23);
			this.label6.TabIndex = 8;
			this.label6.Text = "Nuevo Precio";
			// 
			// TxtPrecioNuevo
			// 
			this.TxtPrecioNuevo.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TxtPrecioNuevo.Location = new System.Drawing.Point(389, 269);
			this.TxtPrecioNuevo.Name = "TxtPrecioNuevo";
			this.TxtPrecioNuevo.Size = new System.Drawing.Size(139, 31);
			this.TxtPrecioNuevo.TabIndex = 9;
			this.TxtPrecioNuevo.TextChanged += new System.EventHandler(this.TxtPrecioNuevo_TextChanged);
			this.TxtPrecioNuevo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtPrecioNuevo_KeyPress);
			// 
			// BtnUpdate
			// 
			this.BtnUpdate.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BtnUpdate.Location = new System.Drawing.Point(534, 269);
			this.BtnUpdate.Name = "BtnUpdate";
			this.BtnUpdate.Size = new System.Drawing.Size(150, 32);
			this.BtnUpdate.TabIndex = 10;
			this.BtnUpdate.Text = "Actualizar";
			this.BtnUpdate.UseVisualStyleBackColor = true;
			this.BtnUpdate.Click += new System.EventHandler(this.BtnUpdate_Click);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label7.Location = new System.Drawing.Point(211, 26);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(507, 23);
			this.label7.TabIndex = 11;
			this.label7.Text = "Ingrese el producto al que se le cambiara el precio";
			// 
			// lblPrecioActualizado
			// 
			this.lblPrecioActualizado.AutoSize = true;
			this.lblPrecioActualizado.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblPrecioActualizado.Location = new System.Drawing.Point(352, 316);
			this.lblPrecioActualizado.Name = "lblPrecioActualizado";
			this.lblPrecioActualizado.Size = new System.Drawing.Size(0, 23);
			this.lblPrecioActualizado.TabIndex = 12;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(290, 227);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(66, 23);
			this.label4.TabIndex = 13;
			this.label4.Text = "Costo";
			// 
			// lblCosto
			// 
			this.lblCosto.AutoSize = true;
			this.lblCosto.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblCosto.Location = new System.Drawing.Point(367, 227);
			this.lblCosto.Name = "lblCosto";
			this.lblCosto.Size = new System.Drawing.Size(0, 23);
			this.lblCosto.TabIndex = 14;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label8.Location = new System.Drawing.Point(530, 193);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(84, 23);
			this.label8.TabIndex = 15;
			this.label8.Text = "Margen";
			// 
			// lblMargen
			// 
			this.lblMargen.AutoSize = true;
			this.lblMargen.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblMargen.Location = new System.Drawing.Point(620, 193);
			this.lblMargen.Name = "lblMargen";
			this.lblMargen.Size = new System.Drawing.Size(0, 23);
			this.lblMargen.TabIndex = 16;
			// 
			// FrmPrincipal
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(145)))), ((int)(((byte)(58)))));
			this.ClientSize = new System.Drawing.Size(986, 351);
			this.Controls.Add(this.lblMargen);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.lblCosto);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.lblPrecioActualizado);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.BtnUpdate);
			this.Controls.Add(this.TxtPrecioNuevo);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.lblPrecio);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.lblDescripcion);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.TxtCodigo);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.BtnSearchProduct);
			this.Name = "FrmPrincipal";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Actualizador de Precios";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnSearchProduct;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtCodigo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TxtPrecioNuevo;
        private System.Windows.Forms.Button BtnUpdate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblPrecioActualizado;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblCosto;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblMargen;
    }
}

