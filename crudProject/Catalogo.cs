using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace crudProject
{
    public partial class Catalogo : Form
    {
        private MySqlConnection conn;
        private string data_source = "datasource=localhost;username=root;password=;database=db_products";
        public Catalogo()
        {
            InitializeComponent();

            ListProducts.View = View.Details;
            ListProducts.LabelEdit = true;
            ListProducts.AllowColumnReorder = true;
            ListProducts.FullRowSelect = true;
            ListProducts.GridLines = true;

            ListProducts.Columns.Add("ID", 30, HorizontalAlignment.Left);
            ListProducts.Columns.Add("Nome", 80, HorizontalAlignment.Left);
            ListProducts.Columns.Add("Preço", 80, HorizontalAlignment.Left);

            //Carregando os dados da tabela
            load_info();

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                // Criando conexão com o MySQL
                conn = new MySqlConnection(data_source);
                conn.Open();

                MySqlCommand cmd = new MySqlCommand();

                cmd.Connection = conn;

                // Executando comando INSERT
                cmd.CommandText = "INSERT INTO info (name, price) VALUES (@name, @price)";


                cmd.Parameters.AddWithValue("@name", txtNome.Text);
                cmd.Parameters.AddWithValue("@price", txtPreco.Text);

                cmd.Prepare();
                cmd.ExecuteNonQuery();

                MessageBox.Show("Produto inserido", "Sucesso",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);


                //Deixando os campos vazios após a execução do comando
                txtNome.Text = string.Empty;
                txtPreco.Text = string.Empty;           
                    
                // Exibindo os produtos atualizados
                load_info();

                cmd.Parameters.Clear();


            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error " + ex.Number + " has ocurred: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error has ocurred: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                conn.Close();
            }

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                // Criando conexão com o MySQL
                conn = new MySqlConnection(data_source);
                conn.Open();

                MySqlCommand cmd = new MySqlCommand();

                cmd.Connection = conn;

                // Executando comando UPDATE
                cmd.CommandText = "UPDATE info SET name = @name, price = @price WHERE id = @id";

                cmd.Parameters.AddWithValue("@name", txtBuscarNome.Text);
                cmd.Parameters.AddWithValue("@price", txtBuscarPreco.Text);
                cmd.Parameters.AddWithValue("@id", txtBuscarID.Text);

                cmd.Prepare();
                cmd.ExecuteNonQuery();

                MessageBox.Show("Produto atualizado", "Sucesso",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);

                
                //Deixando os campos vazios após a execução do comando
                txtBuscarID.Text = string.Empty;
                txtBuscarNome.Text = string.Empty;
                txtBuscarPreco.Text = string.Empty;

                //Exibindo os produtos atualizados
                load_info();
                
                cmd.Parameters.Clear();

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error " + ex.Number + " has ocurred: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error has ocurred: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                conn.Close();
            }
        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void listProducts_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lst_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void ListProducts_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {

                // Criando conexão com o MySQL
                conn = new MySqlConnection(data_source);
                conn.Open();

                MySqlCommand cmd = new MySqlCommand();

                cmd.Connection = conn;

                //string sqlDelete = "DELETE FROM info WHERE id = '" + txtBuscarID.Text 

                // Executando comando DELETE
                cmd.CommandText = "DELETE FROM info WHERE id = @id";

                cmd.Parameters.AddWithValue("@id", txtBuscarID.Text);

                cmd.Prepare();
                cmd.ExecuteNonQuery();

                MessageBox.Show("Produto deletado", "Sucesso",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);


                //Deixando os campos vazios após a execução do comando
                txtBuscarID.Text = string.Empty;
                txtBuscarNome.Text = string.Empty;
                txtBuscarPreco.Text = string.Empty;

                //Exibindo os produtos atualizados
                load_info();
                
                cmd.Parameters.Clear();

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error " + ex.Number + " has ocurred: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error has ocurred: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                conn.Close();
            }

        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {

        }

        private void load_info()
        {
            try
            {
                // Criando conexão com o MySQL
                conn = new MySqlConnection(data_source);
                conn.Open();

                MySqlCommand cmd = new MySqlCommand();

                cmd.Connection = conn;

                // Executando o comando SELECT 
                cmd.CommandText = "SELECT * FROM info";

                // Exibindo os dados coletados
                MySqlDataReader reader = cmd.ExecuteReader();

                ListProducts.Items.Clear();

                while (reader.Read())
                {
                    string[] row =
                    {
                        reader.GetString(0),
                        reader.GetString(1),
                        reader.GetString(2),
                    };

                    ListProducts.Items.Add(new ListViewItem(row));

                }

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error " + ex.Number + " has ocurred: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error has ocurred: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                conn.Close();

            }

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
