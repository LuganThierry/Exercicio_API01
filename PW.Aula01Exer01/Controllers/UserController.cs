using Microsoft.AspNetCore.Mvc;
using PW.Aula01Exer01.Repository;

namespace PW.Aula01Exer01.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        public static List<Cliente> Clientes = new List<Cliente>()
        {
            new Cliente("João", "11111111111", Convert.ToDateTime("1991/01/01")),
            new Cliente("Maria", "22222222222", Convert.ToDateTime("1992/02/02")),
            new Cliente("Pedro", "3333333333", Convert.ToDateTime("1993/03/03")),
            new Cliente("Clara", "4444444444", Convert.ToDateTime("1994/04/04")),
            new Cliente("José", "55555555555", Convert.ToDateTime("1995/05/05")),
            new Cliente("Ieda", "66666666666", Convert.ToDateTime("1996/06/06")),
        };

        private readonly IConfiguration _configuration;

        public UserController(IConfiguration configuration)
        {
            Clientes = new List<Cliente>();
            _configuration = configuration;
        }

        [HttpPost("Criar/{nome}")]
        public IActionResult Criar(Cliente novocliente)
        {
            
            Clientes.Add(novocliente);
            return Ok (novocliente);
        }

        [HttpGet("Selecionar/{nome}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<Cliente>> Selecionar()
        {
            var clienteRespository = new ClienteRepository(_configuration);

            var clientes = clienteRespository.GetClientes();

            if (clientes == null)
                return NotFound();
            return Ok(clientes);
            
        }


        [HttpGet("SelecionarporCPF/{CPF}")]
        public IActionResult SelecionarporCPF(string _Cpf)
        {
            var selecionarUsuario = Clientes.Find(x => x.Cpf == _Cpf);

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
