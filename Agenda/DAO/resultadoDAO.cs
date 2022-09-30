using System;
using System.Collections.Generic;
using System.Text;
using MySqlConnector;

namespace Agenda.DAO
{
    class resultadoDAO
    {
        private DAO.conexão db;
        private MySqlConnection con;
        public void InserirDados(string ageId, String ageNome, String ageEMail, int ageTelefone)
        {
            con = new MySqlConnection();//instancia mysql conexao
            db = new DAO.conexão();//instancia mysql conexao
            con.ConnectionString = db.getConnectionString();//chama caminho da conexao e direciona para bd mysql 
            string dados = "INSERT INTO inventario ( ageNome, ageEMail,ageTelefone)";//query sql para ser enviada ao bd
            dados += "(?ageId, ?ageNome, ?ageEMail,?ageTelefone)";//query sql para ser enviada ao bd
            try
            {
                con.Open();//abre conexao banco dados
                MySqlCommand cmd = new MySqlCommand(dados, con);//instancia passando sql e caminho do bd
                cmd.Parameters.AddWithValue("?ageId", ageId);//adiciona atributo
                cmd.Parameters.AddWithValue("?ageNome", ageNome);
                cmd.Parameters.AddWithValue("?ageEMail", ageEMail);
                cmd.Parameters.AddWithValue("?ageTelefone", ageTelefone);

                cmd.ExecuteNonQuery();//executa no banco
                cmd.Dispose();//limpa objeto instanciado }
            }
            finally
            {
                con.Close();//fecha conexao banco dados
            }
        }
        //metodo remove dados da tabela inventario
        public void RemoverDados(string ageId)
        {
            con = new MySqlConnection();
            db = new DAO.conexão();
            con.ConnectionString = db.getConnectionString();
            String dados = "DELETE FROM inventario ";
            dados += "(?ageId, ?ageNome, ?ageEMail,?ageTelefone)";
        
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(dados, con);
                cmd.Parameters.AddWithValue("?ageId", ageId);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
            }
        }


    }
}
