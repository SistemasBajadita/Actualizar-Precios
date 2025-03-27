using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Drawing;
using System.Data;

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
			FrmProducto frm = new FrmProducto(rbJardines.Checked ? "labajadita1" : "labajadita2")
			{
				SendProduct = GetProduct
			};
			frm.ShowDialog();
		}

		private void AplicarFiltros()
		{
			dataGridView1.Columns[0].ReadOnly = true;
			dataGridView1.Columns[2].ReadOnly = true;

			dataGridView1.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
			dataGridView1.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
			dataGridView1.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
		}

		decimal costoUCO = 0;

		public async Task SetProduct(string codigo)
		{
			TxtPrecioNuevo.Text = "";
			MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings[rbJardines.Checked ? "labajadita1" : "labajadita2"].ToString());
			try
			{
				await con.OpenAsync();

				//Con esto recupero el precio base
				MySqlCommand cmd = new MySqlCommand("select tblcatarticulos.cod1_art, des1_art, pre_iva, cos_uco " +
					"from tblcatarticulos " +
					"inner join tblundcospreart on tblcatarticulos.cod1_art=tblundcospreart.cod1_art " +
					"left join tblcodarticuloextra on tblcodarticuloextra.COD_ART=tblcatarticulos.COD1_ART " +
					$"where (tblcatarticulos.cod1_Art='{codigo}' or tblcodarticuloextra.CODART_EXTRA='{codigo}');", con);

				MySqlDataReader result = (MySqlDataReader)await cmd.ExecuteReaderAsync();

				if (result.Read())
				{
					decimal precioVenta = decimal.Parse(result.GetString(2));
					costoUCO = decimal.Parse(result.GetString(3));

					TxtCodigo.Text = result.GetString(0);
					lblDescripcion.Text = result.GetString(1);
					lblPrecio.Text = "$" + precioVenta.ToString();
					lblCosto.Text = "$" + costoUCO.ToString();

					decimal margen = ((precioVenta - costoUCO) / precioVenta) * 100;
					lblMargen.Text = margen.ToString("N2") + "%";
					result.Close();

					//Aqui cargo la lista de precios
					cmd.CommandText = "select case when Cod_Precio = '' then 'General' else cod_precio end as Lista ,precios.pre_iva as Precio, round( ((precios.PRE_IVA- cos.COS_UCO)/precios.Pre_iva)*100,2) as Margen " +
						"from tblprecios precios " +
						"inner join tblundcospreart cos on cos.cod1_art=precios.COD1_ART " +
						$"where precios.COD1_ART='{TxtCodigo.Text}';";

					DataTable precios = new DataTable();

					MySqlDataAdapter ad = new MySqlDataAdapter(cmd);

					ad.Fill(precios);

					//Por ultimo, muestro los precios
					dataGridView1.DataSource = precios;
					AplicarFiltros();

					TxtPrecioNuevo.Focus();
				}
				else
				{
					dataGridView1.DataSource = null;
					lblDescripcion.Text = "Producto no encontrado";
					lblPrecio.Text = "";
					lblCosto.Text = "";
					lblMargen.Text = "";
				}

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
			await SetProduct(TxtCodigo.Text);
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
												  $"WHERE COD1_ART = '{TxtCodigo.Text}'; ";
								/*+
								$"UPDATE tblprecios " +
								$"SET PRE_ART = {precioBase}, PRE_IVA = {TxtPrecioNuevo.Text} " +
								$"WHERE COD1_ART = '{TxtCodigo.Text}' AND COD_LISTA = 1;";
								*/

								int principal = await cmd.ExecuteNonQueryAsync();

								if (principal == 0)
								{
									throw new Exception($"No se realizaron cambios para el código {TxtCodigo.Text}.");
								}


								//ahora actualizo las listas de precios
								for (int i = 1; i < dataGridView1.Rows.Count; i++)
								{
									precioBase = double.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString()) / (1 + (imp / 100));

									cmd.CommandText = $"UPDATE tblprecios set pre_art={precioBase}," +
										$"pre_iva={dataGridView1.Rows[i].Cells[3].Value} where cod1_art='{TxtCodigo.Text}' and cod_precio='{dataGridView1.Rows[i].Cells[0].Value}';";
									int result = await cmd.ExecuteNonQueryAsync();
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

		private async void TxtPrecioNuevo_TextChanged(object sender, EventArgs e)
		{
			MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["labajadita1"].ConnectionString);

			if (dataGridView1.Columns.Count > 3)
			{
				dataGridView1.Columns.RemoveAt(3);
				dataGridView1.Columns.RemoveAt(3);
			}

			if (TxtPrecioNuevo.Text == "")
			{
				return;
			}

			if (dataGridView1.DataSource != null)
			{
				dataGridView1.Columns.Add("Column4", "Nuevo Precio");
				dataGridView1.Columns.Add("Column5", "Nuevo Margen");
			}

			decimal precio = decimal.Parse(TxtPrecioNuevo.Text);

			try
			{
				await con.OpenAsync();

				MySqlCommand cmd = con.CreateCommand();

				for (int i = 0; i < dataGridView1.Rows.Count; i++)
				{
					cmd.CommandText = "select des_precio " +
						"from tblprecios pre " +
						"inner join tblcatprecios listas on listas.COD_PRECIO=pre.COD_PRECIO " +
						$"where pre.cod1_art='{TxtCodigo.Text}' and pre.cod_precio='{dataGridView1.Rows[i].Cells[0].Value}';";

					var porcentaje = await cmd.ExecuteScalarAsync();

					if (decimal.TryParse(porcentaje == null ? "1" : porcentaje.ToString(), out decimal porc))
					{
						decimal precioNuevo = precio * porc;
						if (precio - precioNuevo >= 1)
						{
							precioNuevo = precio - 1;
						}

						decimal margenNuevo = (precioNuevo - costoUCO) / precioNuevo;

						dataGridView1.Rows[i].Cells[3].Value = precioNuevo;
						dataGridView1.Rows[i].Cells[4].Value = (margenNuevo * 100).ToString("N2");
					}
					else
					{
						decimal precioNuevo = decimal.Parse(TxtPrecioNuevo.Text);
						decimal margen = ((precioNuevo - costoUCO) / precioNuevo) * 100;

						dataGridView1.Rows[i].Cells[3].Value = precioNuevo;
						dataGridView1.Rows[i].Cells[4].Value = (margen).ToString("N2");
					}
				}
			}
			catch (ArgumentOutOfRangeException) { }
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			finally
			{
				await con.CloseAsync();
			}
		}

		private void TxtCodigo_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == '\'')
			{
				e.Handled = true;
			}
		}

		private void FrmPrincipal_Load(object sender, EventArgs e)
		{

		}

		object valorCeldaOriginal;

		private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			// Obtener el precio base
			decimal PrecioBase = decimal.Parse(lblPrecio.Text.Substring(1));

			// Obtener el valor de la segunda columna en la fila editada
			object lista = dataGridView1.Rows[e.RowIndex].Cells[0].Value;
			object valorCelda = dataGridView1.Rows[e.RowIndex].Cells[3].Value;
			if (valorCelda != null && decimal.TryParse(valorCelda.ToString(), out decimal precioSeleccionado))
			{
				if (lista.ToString() == "ABARREY" || lista.ToString() == "General")
					return;
				if (PrecioBase - precioSeleccionado >= 1)
				{
					MessageBox.Show("El precio introducido supera el limite de descuento", "LA BAJADITA - No se puede asignar ese precio",
						MessageBoxButtons.OK, MessageBoxIcon.Warning);
					dataGridView1.Rows[e.RowIndex].Cells[3].Value = valorCeldaOriginal.ToString();
					return;
				}
			}
			else
			{
				MessageBox.Show("El valor de la celda no es válido.");
			}
		}

		private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
		{
			try
			{
				valorCeldaOriginal = dataGridView1.Rows[e.RowIndex].Cells[3].Value;
			}
			catch (ArgumentOutOfRangeException) { }
		}
	}
}
