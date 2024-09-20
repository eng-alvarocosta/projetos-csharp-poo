using System.Runtime.Intrinsics.X86;
using static System.Net.Mime.MediaTypeNames;

namespace Banco
{
    internal class ValidacaoDados
    {
        public bool conta_validated;
        public bool titular_validated;
        public bool deposito_s_n_validated;
        public bool valor_validated;

        public ValidacaoDados() {
            conta_validated = true;
            titular_validated = true;
            deposito_s_n_validated = true;
            valor_validated = true;
        }

        public int ValidaConta(string conta)
        {
            int numero_conta = 0;

            if (!String.IsNullOrWhiteSpace(conta) && conta.Length == 6)
            {
                conta_validated = int.TryParse(conta, out numero_conta);
                return numero_conta;
            }
            else
            {
                conta_validated = false;
                return numero_conta;
            }
            
        }

        public string ValidaTitular(string titular)
        {
            if (!String.IsNullOrWhiteSpace(titular) && titular.Length > 2 && titular.Length < 30)
            {
                List<char> char_numeros_interos = new() { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

                foreach (char caracter in char_numeros_interos)
                {
                    if (titular.Contains(caracter))
                    {
                        titular_validated = false;
                        return "unknown";
                    }
                }

                titular_validated = true;
                return titular;
            }
            else
            {
                titular_validated = false;
                return "unknown";
            }
        }

        public bool ValidaDepositoInicial(string control)
        {
            switch (control)
            {
                case "s":
                    deposito_s_n_validated = true;
                    return true;
                case "n":
                    deposito_s_n_validated = true;
                    return true;
                default:
                    deposito_s_n_validated = false;
                    return false;
            }
        }

        public double ValidaValorSaqueDeposito(string valor)
        {
            double valor_saque_deposito = 0;

            if (!String.IsNullOrWhiteSpace(valor))
            {
                valor_validated = double.TryParse(valor, out valor_saque_deposito);
                
                if (valor_saque_deposito < 0)
                {
                    valor_validated = false;
                    return 0;
                }
                else
                {
                    valor_validated = true;
                    return valor_saque_deposito;
                }
            }
            else
            {
                valor_validated = false;
                return valor_saque_deposito;
            }


        }

        public bool Valida()
        {
            return (conta_validated &&  titular_validated && deposito_s_n_validated && valor_validated);
        }
    }
}
