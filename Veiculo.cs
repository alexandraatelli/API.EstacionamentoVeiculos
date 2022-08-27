using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsGaragem
{
    internal class Veiculo
    {
        //Atributos da Classe:
        string placa; // 7 caracteres
        string tipo;
        string dataEntrada;
        string horaEntrada;
        string dataSaida;
        string horaSaida;
        int tempoPermanencia; // calculo em minutos
        double valorCobrado;

        /// <summary>
        /// construtor é utilizado para leitura do arquivo de veículos que 
        /// constam na garagem.
        /// </summary>
        /// <param name="placa">identificação do veículo</param>
        /// <param name="dataEntrada">Data de entrada do veículo</param>
        /// <param name="horaEntrada">Hora de entrada do veículo</param>
        public Veiculo(string placa, string tipo, string dataEntrada, string horaEntrada)
        {
            this.Placa = placa;
            this.tipo = tipo;
            this.DataEntrada = dataEntrada;
            this.HoraEntrada = horaEntrada;
        }

        //Este construtor tem o comportamento do primeiro construtor anterior, mais o que
        //for adicionado neste. Por isso o uso do this (que diz respeito a própria classe,
        //ao próprio objeto). Primeiro executa construtor anterior e após o adicionados
        //neste. Chamada em cascata.
        public Veiculo(string placa, string tipo, string dataEntrada, string horaEntrada,
            string dataSaida, string horaSaida) : this(placa, tipo, dataEntrada, horaEntrada)
        {
           //this.Placa = placa;
           // this.tipo = tipo;
           // this.DataEntrada = dataEntrada;
           // this.HoraEntrada = horaEntrada;
            this.DataSaida = dataSaida;
            this.HoraSaida = horaSaida;
        }

        /// <summary>
        /// construtor utilizado para leitura do arquivo de saída com veículos
        /// que passaram pela garagem: Histórico de veículos.
        /// </summary>
        public Veiculo(string placa, string tipo, string dataEntrada, string horaEntrada,
            string dataSaida, string horaSaida, int tempoPermanencia,
            double valorCobrado) : this(placa, tipo, dataEntrada, horaEntrada)
        {
            this.DataSaida = dataSaida;
            this.HoraSaida = horaSaida;
            this.TempoPermanencia = tempoPermanencia;
            this.ValorCobrado = valorCobrado;
        }

        // Visibilidade
        public string Placa { get => placa; set => placa = value; }
        public string Tipo { get => tipo; set => tipo = value; }
        public string DataEntrada { get => dataEntrada; set => dataEntrada = value; }
        public string HoraEntrada { get => horaEntrada; set => horaEntrada = value; }
        public string DataSaida { get => dataSaida; set => dataSaida = value; }
        public string HoraSaida { get => horaSaida; set => horaSaida = value; }
        public int TempoPermanencia { get => tempoPermanencia; set => tempoPermanencia = value; }
        public double ValorCobrado { get => valorCobrado; set => valorCobrado = value; }

        /// <summary>
        /// Método que gera a data e hora para entrada ou saída de veículo
        /// </summary>
        /// <param name="tipo">entrada para gerar a data e hora de entrada; saída para gerar data e hora de saída</param>
        public void GerarDataHora(string tipo)
        {
            DateTime dateTime = DateTime.Now;
            string[] vetorDados = dateTime.ToString().Split(' ');
            switch (tipo)
            {
                case "entrada":
                    this.DataEntrada = vetorDados[0];
                    this.HoraEntrada = vetorDados[1];
                    break;
                case "saida":
                    this.DataSaida = vetorDados[0];
                    this.HoraSaida = vetorDados[1];
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Método que calcula o tempo de permanência (em minutos) e calcula o 
        /// valor de cobrança.
        /// </summary>
        /// <param name="valorHora">valor de referência da hora para minutos</param>
        public void RealizarCobranca(double valorHora)
            {
                string[] vetorDados = HoraEntrada.Split(':');
                int hora = int.Parse(vetorDados[0]);
                int minutos = int.Parse(vetorDados[1]);
                int entrada = hora * 60 + minutos;

                vetorDados = HoraSaida.Split(':');
                hora = int.Parse(vetorDados[0]);
                minutos = int.Parse(vetorDados[1]);
                int saida = hora * 60 + minutos;

                this.TempoPermanencia = saida - entrada;
                double resultado = (double)this.TempoPermanencia / 60;
                double qtdHorasNaGaragem = Math.Ceiling(resultado);

                this.ValorCobrado = (int)qtdHorasNaGaragem * valorHora;
        }

        /// <summary>
        /// Método que verifica se há vagas disponíveis em garagem, tendo em 
        /// vista o limite máximo suportado.
        /// </summary>
        public static bool TemLugar(List<Veiculo> lista, int tamanhoGaragem)
        {
            return lista.Count < tamanhoGaragem;
        }

        /// <summary>
        /// Método que procura um veículo na lista a partir de sua placa
        /// </summary>
        /// <returns>posição do veículo em lista, senão -27</returns>
        public static int Localizado(string placa, List<Veiculo> lista)
        {
            foreach (Veiculo i in lista)
            {
                if (i.Placa.Equals(placa))
                {
                    return lista.IndexOf(i);
                }
            }
            return -27; 
        }
    }
}
