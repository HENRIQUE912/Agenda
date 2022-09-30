//continuar fazer a  funções do botão adcionar LINHA 68
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlConnector;


namespace Agenda
{
    public partial class Menu : Form
    {
        private DAO.conexão db;//instancia classe conexao
        private MODELO.resultadoDAO cruds;

        //   private Modelo cruds;
        public Menu()
        {
            InitializeComponent();
        }

        private void carregaDados()
        {
            db = new DAO.conexão();//instancia classe conexao
            dataGridView1.DataSource = null;//cria datagridview vazia
            dataGridView1.Rows.Clear();//limpa todas colunas
            dataGridView1.Refresh();//atualiza datagridview

            string connectionString = db.getConnectionString(); //instancia caminho conexao banco dados
            string dados = "SELECT * FROM agenda";//sql para pesquisa na tabela inventario
            using (MySqlConnection conn = new MySqlConnection(connectionString))//instancia biblioteca mysql
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(dados, conn))//instancia dados no adapter
                {
                    try//tratamento de erro caso não preencha a tabela
                    {
                        //cria tabela
                        DataTable dataTable = new DataTable();
                        //relaciona a tabela com a pesquisa realizada
                        adapter.Fill(dataTable);
                        //preenche a tabela com os dados pesquisado
                        for (int i = 0; i < dataTable.Rows.Count; i++)
                        {
                            dataGridView1.Rows.Add(dataTable.Rows[i][0], dataTable.Rows[i][1], dataTable.Rows[i][2]);
                        }
                    }
                    catch (Exception ex)//caso erra exiba mensagem.
                    {
                        MessageBox.Show("Error" + ex);
                    }
                }// end using
            }

           
       
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            carregaDados();
        }

        private void but_add_Click(object sender, EventArgs e)
        {
         //cruds = new MODELO.age
                //cruds.itemcodigo = txtCItem.Text;//adiciona campo texto no objeto inventario
        }

        private void but_atualizar_Click(object sender, EventArgs e)
        {

        }
    }
}