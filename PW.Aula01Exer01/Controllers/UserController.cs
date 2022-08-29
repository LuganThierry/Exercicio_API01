using Microsoft.AspNetCore.Mvc;

namespace PW.Aula01Exer01.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        [HttpPost("Criar/{nome}")]
        public IActionResult Criar(string _cpf, string _nome, int _idade)
        {
            var novoUsuario = new Cliente();
            novoUsuario.Cpf = _cpf;
            novoUsuario.Nome = _nome;
            novoUsuario.Idade = _idade;

            return Ok (novoUsuario);
        }

        [HttpGet("Selecionar/{nome}")]
        public IActionResult Selecionar(string _nome)
        {
            var selecionarUsuario = new Cliente();

            if (selecionarUsuario.Nome == _nome)
                return Ok (selecionarUsuario);
            
        }

        [HttpPut("Atualizar/{nome}")]
        public IActionResult Atualizar()
        {

        }

        [HttpDelete("Deletar/{nome}")]
        public IActionResult Deletar()
        {

        }

    }
}
