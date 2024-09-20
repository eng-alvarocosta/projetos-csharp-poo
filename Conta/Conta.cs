namespace Banco
{
    internal class Conta
    {
        public int NumeroConta { get; private set; }
        public string? Titular { get; private set; }
        public double Saldo { get; private set; }

        public Conta(int numeroConta, string? titular)
        {
            NumeroConta = numeroConta;
            Titular = titular;
        }

        public Conta(int numeroConta, string? titular, double saldo) : this(numeroConta, titular)
        {
            Saldo = saldo;
        }

        public bool Deposito(double deposito)
        {
            if (deposito > 0)
            {
                Saldo += deposito;
            }

            this.ImprimirConsoleAtualizar();

        }

        public void Saque(double saque)
        {

            double valor_disponivel = Saldo - saque;

            if (valor_disponivel >= 0)
            {
                Saldo -= saque;
            }

            this.ImprimirConsoleAtualizar();
        }

        public void ImprimirConsoleAtualizar()
        {
            Console.WriteLine("Dados da conta atualizados.");
            Console.WriteLine(this);
        }

        public override string? ToString()
        {
            return $"Conta {NumeroConta}, Titular: {Titular}, Saldo: {Saldo}";
        }
    }
}
