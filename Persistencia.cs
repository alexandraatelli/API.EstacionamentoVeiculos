using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsGaragem
{
    internal class Persistencia
    {
        /// <summary>
        /// Método que a partir da lista persiste os dados no arquivo dos veículos 
        /// que estão no pátio da garagem - veiculosEntrada
        /// </summary>
        /// <param name="lista">Lista veículos</param>
        public static void GravarNoArquivoEntrada(List<Veiculo> lista)
        {
            //Abrir um fluxo de escrita (descarrega aos poucos)
            StreamWriter escritor = new StreamWriter("veiculoEntrada.dat");

            foreach (Veiculo i in lista) //Escreveu cada objeto dentro do arquivo.
            {
                escritor.WriteLine(i.Placa + ";" + i.Tipo + ";" + i.DataEntrada + ";" + i.HoraEntrada);
                escritor.Flush(); //Descarga : efetiva a escrita no arquivo.
            }
            escritor.Close();
        }

        /// <summary>
        /// Método que a partir da lista persiste os dados no arquivo dos veículos 
        /// que que já saíram da garagem.: Histórico Veículos.
        /// </summary>
        /// <param name="lista">Lista veículos</param>
        public static void GravarNoArquivoSaida(List<Veiculo> lista)
        {
            StreamWriter escritor = new StreamWriter("veiculoSaida.dat");

            foreach (Veiculo i in lista)
            {
                escritor.WriteLine(i.Placa + ";" + i.Tipo + ";" + i.DataEntrada + ";" + 
                i.HoraEntrada + ";" + i.DataSaida + ";" + i.HoraSaida + ";" + 
                i.TempoPermanencia + ";" + i.ValorCobrado);
                escritor.Flush();
            }
            escritor.Close();
        }

        /// <summary>
        /// Método que lê o contéudo do arquivo de entrada e popula o vetor para exibição.
        /// Arquivo base: Lista Entrada Garagem.
        /// </summary>
        /// <param name="lista">Lista veículos</param>
        public static void LerArquivoEntrada(List<Veiculo> lista)
        {
            StreamReader leitor = new StreamReader("veiculoEntrada.dat");
            string linha;
            string[] vetorDados;

            do
            {
                linha = leitor.ReadLine();
                if (linha != null && linha != "")
                {
                    vetorDados = linha.Split(';');
                    lista.Add(new Veiculo(vetorDados[0], vetorDados[1], vetorDados[2], vetorDados[3]));
                }
            } while (!leitor.EndOfStream);
            leitor.Close();
        }

        /// <summary>
        /// Método que lê o contéudo do arquivo de saída e popula o vetor para exibição.
        /// Arquivo base: Histórico de Veículos.
        /// </summary>
        /// <param name="lista">lista veículos</param>
        public static void LerArquivoSaida(List<Veiculo> lista, int limiteVeiculosHistorico)
        {
            StreamReader leitor = new StreamReader("veiculoSaida.dat");
            string linha;
            string[] vetorDados;
            int contador = 1;
            ///<summary>
            ///Ler o arquivo e popular a lista para exibição em tela.
            ///</summary>
            lista.Clear();
            do
            {
                linha = leitor.ReadLine();
                if (linha != null && linha != "")
                {
                    vetorDados = linha.Split(';');
                   
                    lista.Add(new Veiculo(vetorDados[0], vetorDados[1], vetorDados[2], 
                    vetorDados[3], vetorDados[4], vetorDados[5], int.Parse(vetorDados[6]),
                    double.Parse(vetorDados[7])));
                    contador++;
                }
            } while (!leitor.EndOfStream && contador <= limiteVeiculosHistorico);
            
            leitor.Close();
        }

        //Armazena as parametrizações para o funcionamento da garagem. Inclui os tipos de veículos aceitos.
        public static void ConfiguracoesGaragem(ref int tamanhoDaGaragem, 
            ref double valorDaHora, ref string nomeEstabelecimento, 
            ref string[] tipoVeiculo, ref int limiteVeiculosHistorico) 
            //ref - Passagem por referencia.
        {
            StreamReader leitor = new StreamReader("dadosGaragem.dat");
            string linha;
            string[] vetorDados;
            do
            {
                linha = leitor.ReadLine();

                /* gera vetor com parâmetros do sistema,sepapando-os por vírgula. Ou seja,
                para cada ponto e vírgula gera um conteúdo diferente. */
                vetorDados = linha.Split(';');
                tamanhoDaGaragem = int.Parse(vetorDados[0]);
                valorDaHora = double.Parse(vetorDados[1]);

                // Representa o nome do estabelecimento constante no arquivo de configuração.
                nomeEstabelecimento = vetorDados[2];

                /* Gerou novo vetor a partir de um elemento do vetor de configurações -
                * vetorDados - linha 101. - que representa a lista dos tipos de veículos
                * aceitos, com possibilidade de aumentá-la ou diminui-la.*/
                tipoVeiculo = vetorDados[3].Split(','); 
                limiteVeiculosHistorico = int.Parse(vetorDados[4]);
            } while (!leitor.EndOfStream);
            leitor.Close();
        }
     }
}
