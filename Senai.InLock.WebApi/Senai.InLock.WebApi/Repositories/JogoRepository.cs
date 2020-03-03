using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Repositories
{
    public class JogoRepository : IJogoRepository
    {

        private string stringConexao = "Data Source=DEV22\\SQLEXPRESS; initial catalog=InLock_Games_Tarde; user Id=sa; pwd=sa@132";

        public List<JogoDomain> Listar()
        {
            List<JogoDomain> jogos = new List<JogoDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT Jogos.IdJogo, Jogos.NomeJogo, Jogos.Descricao, Jogos.DataLancamento,  Jogos.Valor , E.IdEstudio, E.NomeEstudio  FROM Jogos " +
                                        "INNER JOIN Estudios E ON Jogos.IdEstudio = E.IdEstudio";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        JogoDomain jogo = new JogoDomain
                        {
                            IdJogo = Convert.ToInt32(rdr["IdJogo"])
                            ,
                            NomeJogo = rdr["NomeJogo"].ToString()
                            ,
                            Descricao = rdr["Descricao"].ToString()
                            ,
                            DataLancamento = Convert.ToDateTime(rdr["DataLancamento"])
                            ,
                            Valor = Convert.ToSingle(rdr["Valor"])
                            ,
                            Estudio = new EstudioDomain
                            {
                                IdEstudio = Convert.ToInt32(rdr["IdEstudio"])
                                ,
                                NomeEstudio = rdr["NomeEstudio"].ToString()
                            }
                        };

                        jogos.Add(jogo);
                    }
                }
            }
            return jogos;
        }

        public void Cadastrar(JogoDomain novoJogo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO Jogos(NomeJogo, Descricao, DataLancamento, Valor, IdEstudio)" +
                                     "VALUES (@NomeJogo, @Descricao, @DataLancamento, @Valor, @IdEstudio)";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@NomeJogo", novoJogo.NomeJogo);
                    cmd.Parameters.AddWithValue("@Descricao", novoJogo.Descricao);
                    cmd.Parameters.AddWithValue("@DataLancamento", novoJogo.DataLancamento);
                    cmd.Parameters.AddWithValue("@Valor", novoJogo.Valor);
                    cmd.Parameters.AddWithValue("@IdEstudio", novoJogo.IdEstudio);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Atualizar(int id, JogoDomain JogoAtualizado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdate = "UPDATE Jogos SET NomeJogo = @NomeJogo WHERE IdJogo = @ID";

                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@NomeJogo", JogoAtualizado.NomeJogo);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM Jogos WHERE IdJogo = @ID";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public JogoDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT IdJogo, NomeJogo FROM Jogos" +
                                        " WHERE IdJogo = @ID";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        JogoDomain Jogo = new JogoDomain
                        {
                            IdJogo = Convert.ToInt32(rdr["IdJogo"])
                            ,
                            NomeJogo = rdr["NomeJogo"].ToString()
                        };

                        return Jogo;
                    }


                    return null;
                }
            }
        }
    }
}
