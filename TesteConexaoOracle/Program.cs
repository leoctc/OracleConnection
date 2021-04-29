using System;

namespace TesteConexaoOracle
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Listando um titular");
            Console.WriteLine("");

            GetTitular(19045900);

            Console.ReadKey();
        }


        public static void GetTitular(long cdTitular)
        {
            try
            {
                //chamando a conexão
                Conexao.Conectar();
                var con = Conexao.Conn;

                using (var comm = new Oracle.ManagedDataAccess.Client.OracleCommand())
                {
                    comm.Connection = con;
                    comm.CommandText = $"SELECT CD_TITULAR,NM_TITULAR,NM_CIDADE FROM ADAWEB.TITULAR T WHERE T.CD_TITULAR = {cdTitular}";

                    using (var reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine("CÓDIGO UBC: {0}", reader["CD_TITULAR"]);
                            Console.WriteLine("NOME COMPLETO: {0}", reader["NM_TITULAR"]);
                            Console.WriteLine("E-MAIL: {0}", reader["NM_CIDADE"]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Conexao.FecharConexao();
            }

        }
    }
}
