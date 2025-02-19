using DentalTech.Database;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using DentalTech.Helpers;

namespace DentalTech.Models
{
    internal class OrcamentoDAO
    {
        private static Conexao _conn = new Conexao();

        public void Insert(Orcamento orcamento)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "INSERT INTO Orcamento VALUES " +
                "(null, @valor);";

                comando.Parameters.AddWithValue("@valor", orcamento.Valor);
                comando.Parameters.AddWithValue("@idPaciente", orcamento.Paciente.Id);
                comando.Parameters.AddWithValue("@idFuncionario", orcamento.Funcionario.Id);

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

        public List<Orcamento> List()
        {
            try
            {
                var lista = new List<Orcamento>();
                var comando = _conn.Query();

                comando.CommandText = "SELECT * FROM Orcamento";

                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    var orcamento = new Orcamento();

                    orcamento.Id = reader.GetInt32("id_orca");
                    orcamento.Valor = DAOHelper.GetDouble(reader, "valor_orca");
                    orcamento.PacienteOrcamento = DAOHelper.GetString(reader, "paciente_orca");
                    orcamento.FuncionarioOrcamento = DAOHelper.GetString(reader, "funcionario_orca");
                    orcamento.Descricao = DAOHelper.GetString(reader, "descricao_orca");
                    orcamento.Paciente = new Paciente
                    {
                        Id = DAOHelper.GetInt(reader, "id_pac_fk"),
                    };

                    orcamento.Funcionario = new Funcionario
                    {
                        Id = DAOHelper.GetInt(reader, "id_func_fk"),
                    };




                    lista.Add(orcamento);
                }
                reader.Close();
                return lista;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Delete(Orcamento t)
        {
            try
            {
                var comando = _conn.Query();
                comando.CommandText = "delete from Orcamento where id_orca = @id";

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
