using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
    public class JogosController : ControllerBase
    {
        private IJogoRepository _jogoRepository { get; set; }

        public JogosController()
        {
            _jogoRepository = new JogoRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_jogoRepository.Listar());
        }

        [HttpPost]
        [Authorize(Roles = "1")]
        public IActionResult Post(JogoDomain novoJogo)
        {
            if (novoJogo.NomeJogo == null)
            {
                return BadRequest("O nome do Jogo é obrigatório");
            }

            _jogoRepository.Cadastrar(novoJogo);
            return Created("http://localhost:5000/api/Jogos", novoJogo);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "1")]
        public IActionResult Put(int id, JogoDomain jogoAtualizado)
        {
            JogoDomain jogoBuscado = _jogoRepository.BuscarPorId(id);

            if (jogoBuscado != null)
            {
                try
                {
                    _jogoRepository.Atualizar(id, jogoAtualizado);

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
                        mensagem = "Jogo não encontrado",
                        erro = true
                    }
                );
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "1")]
        public IActionResult Delete(int id)
        {
            JogoDomain jogoBuscado = _jogoRepository.BuscarPorId(id);

            if (jogoBuscado != null)
            {
                _jogoRepository.Deletar(id);

                return Ok($"O Jogo {id} foi deletado com sucesso!");
            }
            return NotFound("Nenhum Jogo foi encontrado");
        }
    }
}