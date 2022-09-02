using System.ComponentModel.DataAnnotations;

namespace PW.Aula01Exer01
{
    public class Cliente
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        [StringLength(11, ErrorMessage = "CPF deve ter 11 dígitos")]
        public string Cpf { get; set; }

        public DateTime DataNasc { get; set; }

        public int Idade { get; set; }

        public Cliente(string _nome, string _cpf, DateTime _datanasc)
        {
            this.Nome = _nome;
            this.Cpf = _cpf;
            this.DataNasc = _datanasc;
            this.Idade = CalcularIdade(DataNasc);
        }

        public Cliente(int _id, string _nome, string _cpf, DateTime _datanasc)
        {
            this.Id = _id;
            this.Nome = _nome;
            this.Cpf = _cpf;
            this.DataNasc = _datanasc;
            this.Idade = CalcularIdade(DataNasc);
        }

        public int CalcularIdade(DateTime nascimento)
        {
            int idade = DateTime.Now.Year - nascimento.Year;
            if (DateTime.Now.DayOfYear > nascimento.DayOfYear)
                idade--;
            return idade;
        }
    }
}
