using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;



namespace Agenda.DAO
{
    class conexão
    {
        private String connectionString;
        public String getConnectionString()//função para chamada de conexão com bando de dados.
        {
            connectionString = ConfigurationManager.ConnectionStrings["SimplesCRUD.Properties.Settings.crudConnectionString"].ConnectionString;
            return connectionString;
        }
    }
}
