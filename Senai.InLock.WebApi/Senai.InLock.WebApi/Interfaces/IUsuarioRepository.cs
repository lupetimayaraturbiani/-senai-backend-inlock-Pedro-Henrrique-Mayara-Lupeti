using Senai.InLock.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Interfaces
{
    interface IUsuarioRepository
    {
        /// <summary>
        /// Lista todos os Usuarios do sistema
        /// </summary>
        /// <returns>Retorna uma lista de usuarios</returns>
        List<UsuarioDomain> Listar();

        /// <summary>
        /// Cadastra um novo Usuario no sistema
        /// </summary>
        /// <param name="novoUsuario">Objeto novoUsuario que será cadastrado</param>
        void Cadastrar(UsuarioDomain novoUsuario);

        /// <summary>
        /// Atualiza os usuarios do sistema
        /// </summary>
        /// <param name="id">ID do usuario que será atualizado</param>
        /// <param name="UsuarioAtualizado">objeto UsuarioAtualizado que será atualizado</param>
        void Atualizar(int id, UsuarioDomain UsuarioAtualizado);

        /// <summary>
        /// Deleta um Usuario existente
        /// </summary>
        /// <param name="id">ID do usuario que será deletado</param>
        void Deletar(int id);

        /// <summary>
        /// Busca um usuário pelo seu ID
        /// </summary>
        /// <param name="id">ID do usuário que será buscado</param>
        /// <returns>Retorna um usuário buscado</returns>
        UsuarioDomain BuscarPorId(int id);

        UsuarioDomain BuscarPorEmailSenha(string email, string senha);
    }
}
