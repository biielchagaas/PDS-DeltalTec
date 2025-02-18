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
    internal class ConsultaDAO
    {
        private static Conexao _conn = new Conexao();

        public void Insert(Consulta consulta)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "INSERT INTO Consulta VALUES " +
                "(null, @data);";

                comando.Parameters.AddWithValue("@data", consulta.Data);



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

        public List<Consulta> List()
        {
            try
            {
                var lista = new List<Consulta>();
                var comando = _conn.Query();

                comando.CommandText = "SELECT * FROM Consulta";

                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    var consulta = new Consulta();

                    consulta.Id = reader.GetInt32("id_cons");
                    consulta.Data = DAOHelper.GetDateTime(reader, "data_cons");
                    consulta.Hora = DAOHelper.GetTimeSpan(reader, "hora_cons");
                    consulta.Valor = DAOHelper.GetDouble(reader, "valor_cons");
                    consulta.Descricao = DAOHelper.GetString(reader, "descricao_cons");
                    consulta.PacienteConsulta = DAOHelper.GetString(reader, "paciente_cons");
                    consulta.FuncionarioConsulta = DAOHelper.GetString(reader, "funcionario_cons");
                    consulta.Paciente = new Paciente
                    {
                        Id = DAOHelper.GetInt(reader, "id_pac_fk"),
                    };

                    consulta.Funcionario = new Funcionario
                    {
                        Id = DAOHelper.GetInt(reader, "id_func_fk"),
                    };
                    consulta.Anamnese = new Anamnese
                    {
                        Id = DAOHelper.GetInt(reader, "id_anam_fk"),
                    };

                    lista.Add(consulta);
                }
                reader.Close();
                return lista;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Delete(Consulta t)
        {
            try
            {
                var comando = _conn.Query();
                comando.CommandText = "delete from Consulta where id_cons = @id";

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