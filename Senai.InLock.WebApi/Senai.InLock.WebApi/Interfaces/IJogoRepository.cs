using Senai.InLock.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Interfaces
{
    interface IJogoRepository
    {
        List<JogoDomain> Listar();

        void Cadastrar(JogoDomain novoJogo);

        void Atualizar(int id, JogoDomain JogoAtualizado);

        void Deletar(int id);

        JogoDomain BuscarPorId(int id);
    }
}
