namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }
        private DateTime DataEntrada = DateTime.Now;
        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            if (Suite.Capacidade >= hospedes.Count)
            {
                Hospedes = hospedes;
            }
            else
            {
                throw new Exception("Capacidade da suíte é menor que o número de hóspedes.");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            if (Hospedes != null)
            {
                return Hospedes.Count;
            }
            return 0;
        }

        public decimal CalcularValorDiaria()
        {
            // Cálculo: DiasReservados X Suite.ValorDiaria
            decimal valor = DiasReservados * Suite.ValorDiaria;
            // Se a quantidade de dias for maior ou igual a 10, aplicar 10% de desconto
            if (DiasReservados >= 10)
            {
                valor *= 0.9m; // Aplicando 10% de desconto
            }

            return valor;
        }

        public DateTime GetDataEntrada()
        {
            return DataEntrada;
        }
        public DateTime GetDataSaida()
        {
            return DataEntrada.AddDays(DiasReservados);
        }
        public void ListarHospedes()
        {
            if (Hospedes != null && Hospedes.Count > 0)
            {
                foreach (var hospede in Hospedes)
                {
                    Console.WriteLine($"Hóspede: {hospede.NomeCompleto}");
                }
            }
            else
            {
                Console.WriteLine("Nenhum hóspede cadastrado.");
            }
        }

    }
}