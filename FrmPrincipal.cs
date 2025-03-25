using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Drawing;

namespace ActualizarPrecios
{
	public partial class FrmPrincipal : Form
	{
		private static readonly List<MySqlConnection> mySqlConnections = new List<MySqlConnection>()
		{
			new MySqlConnection(ConfigurationManager.ConnectionStrings["labajadita1"].ToString()),
			new MySqlConnection(ConfigurationManager.ConnectionStrings["labajadita2"].ToString())
		};

		readonly List<MySqlConnection> empresas = mySqlConnections;

		public FrmPrincipal()
		{
			InitializeComponent();
		}

		private void BtnSearchProduct_Click(object sender, EventArgs e)
		{
			FrmProducto frm = new FrmProducto
			{
				SendProduct = GetProduct
			};
			frm.ShowDialog();
		}

		double costoUCO = 0;

		public async Task SetProduct(string codigo)
		{
			TxtPrecioNuevo.Text = "";
			MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["labajadita1"].ToString());
			try
			{
				await con.OpenAsync();
				MySqlCommand cmd = new MySqlCommand("select tblcatarticulos.cod1_art, des1_art, pre_iva, cos_uco " +
					"from tblcatarticulos " +
					"inner join tblundcospreart on tblcatarticulos.cod1_art=tblundcospreart.cod1_art " +
					"left join tblcodarticuloextra on tblcodarticuloextra.COD_ART=tblcatarticulos.COD1_ART " +
					$"where (tblcatarticulos.cod1_Art='{codigo}' or tblcodarticuloextra.CODART_EXTRA='{codigo}');", con);

				MySqlDataReader result = (MySqlDataReader)await cmd.ExecuteReaderAsync();

				if (result.Read())
				{
					double precioVenta = double.Parse(result.GetString(2));
					costoUCO = double.Parse(result.GetString(3));

					TxtCodigo.Text = result.GetString(0);
					lblDescripcion.Text = result.GetString(1);
					lblPrecio.Text = "$" + precioVenta.ToString();
					lblCosto.Text = "$" + costoUCO.ToString();

					double margen = ((precioVenta - costoUCO) / precioVenta) * 100;
					lblMargen.Text = margen.ToString("N2") + "%";
				}
				else
				{
					lblDescripcion.Text = "Producto no encontrado";
					lblPrecio.Text = "";
					lblCosto.Text = "";
					lblMargen.Text = "";
				}
				result.Close();
			}
			catch (MySqlException ex)
			{
				MessageBox.Show(ex.Message);
			}
			finally
			{
				await con.CloseAsync();
			}
		}

		private async void GetProduct(string codigo)
		{
			await SetProduct(codigo);
		}

		private async void TxtCodigo_TextChanged(object sender, EventArgs e)
		{
			await Task.Delay(1000);
			TxtCodigo.Enabled = false;
			await SetProduct(TxtCodigo.Text);
			TxtCodigo.Enabled = true;
			TxtCodigo.Focus();
		}

		private async void BtnUpdate_Click(object sender, EventArgs e)
		{
			//Desahibilito los controles
			for (int i = 0; i < Controls.Count; i++)
			{
				Controls[i].Enabled = false;
			}

			if (string.IsNullOrWhiteSpace(TxtPrecioNuevo.Text))
			{
				MessageBox.Show("No dejes el cuadro del precio nuevo vacío si quieres cambiar el precio", "Cuidado",
					MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			try
			{
				foreach (var empresa in empresas)
				{
					using (var connection = empresa)
					{
						await connection.OpenAsync();

						using (var transaction = connection.BeginTransaction())
						{
							try
							{
								var cmd = connection.CreateCommand();
								cmd.Transaction = transaction;

								// Obtener el impuesto
								cmd.CommandText = "SELECT por_imp " +
												  "FROM tblimpuestos imp " +
												  "INNER JOIN tblcatarticulos art ON art.COD_IMP = imp.COD_IMP " +
												  $"WHERE COD1_ART = '{TxtCodigo.Text}';";

								var impuestoResult = await cmd.ExecuteScalarAsync();
								if (impuestoResult == null)
								{
									throw new Exception($"No existe el código {TxtCodigo.Text} en la base de datos de {connection.DataSource}");
								}

								double imp = double.Parse(impuestoResult.ToString());

								// Actualizar los precios
								double precioBase = double.Parse(TxtPrecioNuevo.Text) / (1 + (imp / 100));

								cmd.CommandText = $"UPDATE tblundcospreart " +
												  $"SET PRE_UND = {precioBase}, PRE_IVA = {TxtPrecioNuevo.Text} " +
												  $"WHERE COD1_ART = '{TxtCodigo.Text}'; " +
												  $"UPDATE tblprecios " +
												  $"SET PRE_ART = {precioBase}, PRE_IVA = {TxtPrecioNuevo.Text} " +
												  $"WHERE COD1_ART = '{TxtCodigo.Text}' AND COD_LISTA = 1;";

								int afectados = await cmd.ExecuteNonQueryAsync();

								if (afectados == 0)
								{
									throw new Exception($"No se realizaron cambios para el código {TxtCodigo.Text}.");
								}

								// Confirmar transacción
								await transaction.CommitAsync();
							}
							catch (Exception ex)
							{
								// Revertir transacción en caso de error
								await transaction.RollbackAsync();
								MessageBox.Show($"Error al actualizar la base de datos: {ex.Message}", "Error",
									MessageBoxButtons.OK, MessageBoxIcon.Error);

								for (int i = 0; i < Controls.Count; i++)
								{
									Controls[i].Enabled = true;
								}

								return;
							}
						}
					}
				}

				// Habilitar los controles, y luego mostrar mensajes
				for (int i = 0; i < Controls.Count; i++)
				{
					Controls[i].Enabled = true;
				}

				await MostrarMensaje();
				await SetProduct(TxtCodigo.Text);
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Error general: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private async Task MostrarMensaje()
		{
			lblPrecioActualizado.Text = "Precio Actualizado!";
			lblPrecioActualizado.ForeColor = ColorTranslator.FromHtml("#A3BFD9");
			await Task.Delay(3000);
			lblPrecioActualizado.ForeColor = Color.Black;
			lblPrecioActualizado.Text = "";
		}

		private void TxtPrecioNuevo_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != (char)Keys.Back)
			{
				e.Handled = true;
			}

			if (e.KeyChar == '.' && TxtPrecioNuevo.Text.Contains("."))
			{
				e.Handled = true;
			}
		}

		private void TxtPrecioNuevo_TextChanged(object sender, EventArgs e)
		{
			if (TxtPrecioNuevo.Text != "")
			{
				double precioNuevo = double.Parse(TxtPrecioNuevo.Text);
				lblPrecioActualizado.Text = $"Nuevo margen: {(((precioNuevo - costoUCO) / precioNuevo) * 100).ToString("N2")}%";
			}
		}

		private void TxtCodigo_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == '\'')
			{
				e.Handled = true;
			}
		}
	}
}
