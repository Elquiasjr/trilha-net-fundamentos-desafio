using System.Text.RegularExpressions;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string novaPlaca = Console.ReadLine().ToUpper();
            if(ValidarPlaca(novaPlaca)){
                veiculos.Add(novaPlaca);
                Console.WriteLine($"O veículo de placa: {novaPlaca} foi adicionado com sucesso!");
            }else{
                Console.WriteLine($"O veículo de placa: {novaPlaca} tem formato inválido!");
            }

        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");

            string placa = string.Empty;
            placa = Console.ReadLine();
            if(ValidarPlaca(placa)){
                // Verifica se o veículo existe
                if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
                {
                    Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                    int horas = 0;
                    decimal valorTotal = 0; 

                    horas = int.Parse(Console.ReadLine());
                    valorTotal = (horas * precoPorHora) + precoInicial;

                    veiculos.Remove(placa);
                    Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
                }
                else
                {
                    Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
                }
            }else{
                Console.WriteLine("A formatação da placa está incorreta!");
            }
            
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                veiculos.ForEach(x => Console.WriteLine(x));
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }

        private bool ValidarPlaca(string placa)
        {
            string pattern = @"[A-Z]{3}[0-9][A-Z][0-9]{2}";
            return Regex.Match(placa, pattern).Success;
        }
    }
}
