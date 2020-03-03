using Senai.InLock.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Interfaces
{
    interface IEstudioRepository
    {
        List<EstudioDomain> Listar();

        void Cadastrar(EstudioDomain novoEstudio);

        void Atualizar(int id, EstudioDomain EstudioAtualizado);

        void Deletar(int id);

        EstudioDomain BuscarPorId(int id);
    }
}
