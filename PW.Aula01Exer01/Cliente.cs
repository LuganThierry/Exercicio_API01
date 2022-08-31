namespace PW.Aula01Exer01
{
    public class Cliente
    {
        public string Nome { get; set; }

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

        public int CalcularIdade(DateTime nascimento)
        {
            int idade = DateTime.Now.Year - nascimento.Year;
            if (DateTime.Now.DayOfYear > nascimento.DayOfYear)
                idade--;
            return idade;
        }
    }
}
