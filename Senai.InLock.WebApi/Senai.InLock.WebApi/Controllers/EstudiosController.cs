using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Interfaces;
using Senai.InLock.WebApi.Repositories;

namespace Senai.InLock.WebApi.Controllers
{
    [Route("api/[controller]")]

    [Produces("application/json")]

    [ApiController]
    public class EstudiosController : ControllerBase
    {
        private IEstudioRepository _estudioRepository { get; set; }

        public EstudiosController()
        {
            _estudioRepository = new EstudioRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_estudioRepository.Listar());
        }

        [HttpPost]
        public IActionResult Post(EstudioDomain novoEstudio)
        {
            if(novoEstudio.NomeEstudio == null)
            {
                return BadRequest("O nome do Estúdio é obrigatório");
            }

            _estudioRepository.Cadastrar(novoEstudio);
            return Created("http://localhost:5000/api/Estudios", novoEstudio);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, EstudioDomain estudioAtualizado)
        {
            EstudioDomain estudioBuscado = _estudioRepository.BuscarPorId(id);

            if(estudioBuscado != null)
            {
                try
                {
                    _estudioRepository.Atualizar(id, estudioAtualizado);

                    return NoContent();
                }
                catch (Exception erro)
                {
                    return BadRequest(erro);
                }
            }
            return NotFound
                (
                    new
                    {
                        mensagem = "Estudio não encontrado",
                        erro = true
                    }
                );
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            EstudioDomain estudioBuscado = _estudioRepository.BuscarPorId(id);

            if(estudioBuscado != null)
            {
                _estudioRepository.Deletar(id);

                return Ok($"O Estúdio {id} foi deletado com sucesso!");
            }
            return NotFound("Nenhum Estúdio foi encontrado");
        }
    }
}