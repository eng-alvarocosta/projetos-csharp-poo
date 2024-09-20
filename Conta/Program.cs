
namespace Banco
{
    class Program
    {
        public static void Main(string[] args)
        {

            //List<char> char_numeros_interos = new() { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'};
            //string frase = "Foi123 Voce!";

            //foreach (char caracter in char_numeros_interos)
            //{
            //    if (frase.Contains(caracter))
            //    {
            //        Console.WriteLine(caracter);
            //    }
            //}

            
            string? aux;
            Conta? usuario = null;
            ValidacaoDados validacaoDados = new ValidacaoDados();

            int numero_conta = 555222;
            string titular_conta = "Alvaro Costa";
            double valor_inicial_conta = 200.00;
            double valor_para_deposito = 0;
            double valor_para_saque = 0;

            

            if (validacaoDados.Valida())
            {
                Console.Write("Entre o número da conta (6 dígitos): ");
                aux = Console.ReadLine();
                numero_conta = validacaoDados.ValidaConta(aux);
            }

            if (validacaoDados.Valida())
            {
                Console.Write("Entre o titular da conta: ");
                aux = Console.ReadLine();
                titular_conta = validacaoDados.ValidaTitular(aux);
            }

            if (validacaoDados.Valida())
            {
                Console.Write("Haverá depósito inicial na conta (s/n)? ");
                aux = Console.ReadLine();
                if (validacaoDados.ValidaDepositoInicial(aux) && aux == "s")
                {
                    Console.Write("Entre com o valor de depósito inicial: ");
                    aux = Console.ReadLine();

                    valor_inicial_conta = validacaoDados.ValidaValorSaqueDeposito(aux);
                }
            }

            
            if (validacaoDados.Valida())
            {
                usuario = new Conta(numero_conta, titular_conta, valor_inicial_conta);
                Console.WriteLine("Conta criada com sucesso.");
            }
            else
            {
                Console.WriteLine("Dados invalidos.");
            }

            

            if (validacaoDados.Valida())
            {
                Console.WriteLine(usuario);

                Console.Write("Entre com um valor para depósito: ");
                aux = Console.ReadLine();

                valor_para_deposito = validacaoDados.ValidaValorSaqueDeposito(aux);
                usuario.Deposito(valor_para_deposito);

                Console.Write("Entre com um valor para saque: ");
                aux = Console.ReadLine();

                valor_para_saque = validacaoDados.ValidaValorSaqueDeposito(aux);
                usuario.Saque(valor_para_saque);
            }

            
        }
    }
}