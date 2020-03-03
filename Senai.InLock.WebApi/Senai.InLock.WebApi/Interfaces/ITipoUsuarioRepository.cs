using Senai.InLock.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Interfaces
{
    interface ITipoUsuarioRepository
    {
        /// <summary>
        /// Lista os Tipos de Usuarios do Sistema
        /// </summary>
        /// <returns>Retorna uma lista de Tipos de Usuarios</returns>
        List<TipoUsuarioDomain> Listar();
    }
}
