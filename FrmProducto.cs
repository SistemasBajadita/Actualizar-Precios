using System;
using System.Configuration;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ActualizarPrecios
{
	public partial class FrmProducto : Form
	{
		public Action<string> SendProduct;
		private string Empresa;

		public FrmProducto(string empresa)
		{
			InitializeComponent();
			Empresa = empresa;
		}

		private async Task SetData(string query)
		{
			MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings[Empresa].ToString());
			MySqlDataAdapter ad = new MySqlDataAdapter(query, con);
			try
			{
				await con.OpenAsync();
				DataTable productos = new DataTable();
				await ad.FillAsync(productos);
				DgProductos.DataSource = productos;
			}
			catch (MySqlException ex)
			{
				MessageBox.Show("Ocurrio un error: " + ex.Message + "\n Abre la ventana de nuevo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				Close();
			}
			finally
			{
				await con.CloseAsync();
			}
		}

		private async void FrmProducto_Load(object sender, EventArgs e)
		{
			await SetData("select cod1_art as Codigo, des1_art as Descripcion from tblcatarticulos order by Descripcion asc;");
		}

		private async void TxtFiltro_TextChanged(object sender, EventArgs e)
		{
			await Task.Delay(1000);
			TxtFiltro.Enabled = false;
			await SetData("select cod1_art as Codigo, des1_art as Descripcion " +
				$"from tblcatarticulos where cod1_Art like '%{TxtFiltro.Text}%' or des1_art like '%{TxtFiltro.Text}%' order by Descripcion asc limit 50;");
			TxtFiltro.Enabled = true;
			TxtFiltro.Focus();
		}

		private void DgProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			string codigo = DgProductos.Rows[DgProductos.SelectedRows[0].Index].Cells[0].Value.ToString();
			SendProduct(codigo);
			Close();
		}

		private void DgProductos_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				string codigo = DgProductos.Rows[DgProductos.SelectedRows[0].Index].Cells[0].Value.ToString();
				SendProduct(codigo);
				Close();
			}
		}
	}
}
