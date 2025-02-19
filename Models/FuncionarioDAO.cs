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
    internal class FuncionarioDAO
    {
        private static Conexao _conn = new Conexao();

        public void Insert(Funcionario funcionario)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "INSERT INTO Funcionario VALUES " +
                "(null, @nome);";

                comando.Parameters.AddWithValue("@nome", funcionario.Nome);



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

        public List<Funcionario> List()
        {
            try
            {
                var lista = new List<Funcionario>();
                var comando = _conn.Query();

                comando.CommandText = "SELECT * FROM Funcionario";

                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    var funcionario = new Funcionario();

                    funcionario.Id = reader.GetInt32("id_func");
                    funcionario.Nome = DAOHelper.GetString(reader, "nome_func");
                    funcionario.Cpf = DAOHelper.GetString(reader, "cpf_func");
                    funcionario.Status = DAOHelper.GetString(reader, "status_func");
                    funcionario.Rg = DAOHelper.GetString(reader, "rg_func");
                    funcionario.Expedidor = DAOHelper.GetString(reader, "expedidor_func");
                    funcionario.EstadoCivil = DAOHelper.GetString(reader, "estadoCivil_func");
                    funcionario.Genero = DAOHelper.GetString(reader, "genero_func");
                    funcionario.Cargo = DAOHelper.GetString(reader, "cargo_func");
                    funcionario.Email = DAOHelper.GetString(reader, "email_func");
                    funcionario.Telefone = DAOHelper.GetString(reader, "telefone_func");
                    funcionario.DataNascimento = DAOHelper.GetDateTime(reader, "dataDeNascimento_func");
                    funcionario.Cep = DAOHelper.GetString(reader, "cep_func");
                    funcionario.Cidade = DAOHelper.GetString(reader, "cidade_func");
                    funcionario.Bairro = DAOHelper.GetString(reader, "bairro_func");
                    funcionario.Rua = DAOHelper.GetString(reader, "rua_func");
                    funcionario.Numero = DAOHelper.GetInt(reader, "numero_func");
                    funcionario.DataAdmissao = DAOHelper.GetDateTime(reader, "dataDeAdmissao_func");
                    funcionario.Ctps = DAOHelper.GetString(reader, "ctps_func");
                    funcionario.Senha = DAOHelper.GetString(reader, "senha_func");


                    lista.Add(funcionario);
                }
                reader.Close();
                return lista;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Delete(Funcionario t)
        {
            try
            {
                var comando = _conn.Query();
                comando.CommandText = "delete from Funcionario where id_func = @id";

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