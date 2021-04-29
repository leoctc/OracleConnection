using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;

namespace TesteConexaoOracle
{
    public class Conexao
    {
        public Conexao()
        {
           
        }
       
        public static OracleConnection Conn { get; set; }
        
        public static void Conectar()
        {
            string uid = "adaweb";
            string passwd = "arquivox";
            string host = "192.168.0.202";
            int port1 = 1521;
            int port2 = 1526;
            string service = "webdsv";

            if (Conn != null)
            {
                if (Conn.State != ConnectionState.Closed)
                {
                    Conn.Close();
                    Conn.Dispose();
                }
            }

            string dataSource = string.Format(
                "(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST={0})(PORT={1}))(CONNECT_DATA=(SERVICE_NAME={2})))",
                host,
                port1,
                service);

            try
            {
                var ocsb = new OracleConnectionStringBuilder()
                {
                    UserID = uid,
                    Password = passwd,
                    DataSource = dataSource
                };

                Conn = new OracleConnection(ocsb.ConnectionString);
                Conn.Open();
            }
            catch (Exception ex)
            {               
              throw new Exception(ex.Message);
                
            }
        }

        /// <summary>
        /// Fechar conexão.
        /// </summary>
        public static void FecharConexao()
        {
            if (Conn != null)
            {
                Conn.Close();
                Conn.Dispose();
            }
        }
    }
}
