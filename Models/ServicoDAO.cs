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
    internal class ServicoDAO
    {
        private static Conexao _conn = new Conexao();

        public void Insert(Servico servico)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "INSERT INTO Servico VALUES " +
                "(null, @nome);";

                comando.Parameters.AddWithValue("@nome", servico.Nome);
                comando.Parameters.AddWithValue("@valor", servico.Valor);
                comando.Parameters.AddWithValue("@descricao", servico.Descricao);
               
                comando.Parameters.AddWithValue("@idFuncionario", servico.Funcionario.Id);

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

        public List<Servico> List()
        {
            try
            {
                var lista = new List<Servico>();
                var comando = _conn.Query();

                comando.CommandText = "SELECT * FROM Servico";

                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    var servico = new Servico();

                    servico.Id = reader.GetInt32("id_serv");
                    servico.Nome = DAOHelper.GetString(reader, "nome_serv");
                    servico.Valor = DAOHelper.GetDouble(reader, "valor_serv");
                    servico.Descricao = DAOHelper.GetString(reader, "descricao_serv");
                    servico.FuncionarioServico = DAOHelper.GetString(reader, "funcionario_serv");
                    servico.Funcionario = new Servico
                    {
                        Id = DAOHelper.GetInt(reader, "id_func_fk"),
                    };


                    lista.Add(servico);
                }
                reader.Close();
                return lista;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Delete(Servico t)
        {
            try
            {
                var comando = _conn.Query();
                comando.CommandText = "delete from Servico where id_serv = @id";

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
