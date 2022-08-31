using Microsoft.AspNetCore.Mvc;

namespace PW.Aula01Exer01.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        public static List<Cliente> Clientes = new List<Cliente>()
        {
            new Cliente("João", "111111", Convert.ToDateTime("1991/01/01")),
            new Cliente("Maria", "222222", Convert.ToDateTime("1992/02/02")),
            new Cliente("Pedro", "333333", Convert.ToDateTime("1993/03/03")),
            new Cliente("Clara", "444444", Convert.ToDateTime("1994/04/04")),
            new Cliente("José", "555555", Convert.ToDateTime("1995/05/05")),
            new Cliente("Ieda", "666666", Convert.ToDateTime("1996/06/06")),
        };

        [HttpPost("Criar/{nome}")]
        public IActionResult Criar(Cliente novocliente)
        {
            
            Clientes.Add(novocliente);
            return Ok (novocliente);
        }

        [HttpGet("Selecionar/{nome}")]
        public IActionResult Selecionar(string _nome)
        {
            var selecionarUsuario = Clientes.Find(x => x.Nome == _nome);

            if (selecionarUsuario == null)
                return NotFound();
            return Ok(selecionarUsuario);
            
        }

        [HttpPut("Atualizar/{nome}")]
        public IActionResult Atualizar(string _nome, Cliente clienteAtual)
        {
            var atualizarUsuario = Clientes.Find(x => x.Nome == _nome);
            if (atualizarUsuario == null)
                return NotFound();
            var indice = Clientes.IndexOf(atualizarUsuario);
            Clientes[indice] = clienteAtual;
            return Ok(atualizarUsuario);
        }

        [HttpDelete("Deletar/{nome}")]
        public IActionResult Deletar(string _nome)
        {
            var deletarUsuario = Clientes.Find(x => x.Nome == _nome);
            if (deletarUsuario == null)
                return NotFound();
            Clientes.Remove(deletarUsuario);
            return Ok(deletarUsuario);
        }

    }
}
