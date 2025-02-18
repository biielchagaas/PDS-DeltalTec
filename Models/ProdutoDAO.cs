using DentalTech.Database;
using DentalTech.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DentalTech.Models
{
    internal class ProdutoDAO
    {
        private static Conexao _conn = new Conexao();

        public void Insert(Produto produto)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "INSERT INTO Produto VALUES " +
                "(null, @nome);";

                comando.Parameters.AddWithValue("@nome", produto.Nome);
                comando.Parameters.AddWithValue("@valor", produto.Valor);



                var resultado = comando.ExecuteNonQuery();

                if (resultado == 0)
                {
                    throw new Exception("Ocorreram erros ao salvar as informações");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Produto> List()
        {
            try
            {
                var lista = new List<Produto>();
                var comando = _conn.Query();

                comando.CommandText = "SELECT * FROM Produto";

                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    var produto = new Produto();

                    produto.Id = reader.GetInt32("id_prod");
                    produto.Nome = DAOHelper.GetString(reader, "nome_prod");
                    produto.DataFabricao = DAOHelper.GetDateTime(reader, "dataFabricacao_prod");
                    produto.DataValidade = DAOHelper.GetDateTime(reader, "dataValidade_prod");
                    produto.CodigoBarras = DAOHelper.GetString(reader, "codigoBarras_prod");
                    produto.Valor = DAOHelper.GetDouble(reader, "valor_prod");
                    

                    lista.Add(produto);
                }
                reader.Close();
                return lista;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Delete(Produto t)
        {
            try
            {
                var comando = _conn.Query();
                comando.CommandText = "delete from Produto where id_prod = @id";

                comando.Parameters.AddWithValue("@id", t.Id);

                var resultado = comando.ExecuteNonQuery();

                if (resultado == 0)
                    throw new Exception("Registro não removido da base de dados." +
                        "Verifique e tente novamente");
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}