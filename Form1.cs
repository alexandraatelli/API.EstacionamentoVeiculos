using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsGaragem
{
    public partial class FormGaragem : Form
    {
        // Listas de objetos do tipo veículo.
        List<Veiculo> listaEntradaGaragem = new List<Veiculo>();
        List<Veiculo> listaHistorico = new List<Veiculo>();
        Veiculo veiculo;
        //Veiculo veiculos;
        int posicaoVeiculo = -27;
        int tamanhoDaGaragem;
        double valorDaHora;
        string nomeEstabelecimento;
        string[] tipoVeiculo;
        int limiteVeiculosHistorico;
        public FormGaragem()
        {
            InitializeComponent();
            Persistencia.ConfiguracoesGaragem(ref tamanhoDaGaragem, ref valorDaHora, ref nomeEstabelecimento, ref tipoVeiculo, ref limiteVeiculosHistorico);
            //ref - Passagem por referencia
            Persistencia.LerArquivoEntrada(listaEntradaGaragem);
            this.popularlistaVeiculosEntrada(listaEntradaGaragem);
            Persistencia.LerArquivoSaida(listaHistorico, limiteVeiculosHistorico);
            this.popularlistaHistorico(listaHistorico);
            //Armazena as parametrizações para o funcionamento da garagem. Inclui os tipos
            //de veículos aceitos.
        }

        private void popularlistaVeiculosEntrada(List<Veiculo> lista)
        {
            Tb_ListaEntrada.Text = "";
            int contador = 0;
            foreach (Veiculo i in lista)
            {
                contador++;
                Tb_ListaEntrada.AppendText(contador + " ; " + i.Placa + " ; " + i.Tipo + 
                ";" + i.DataEntrada + " ; " + i.HoraEntrada + Environment.NewLine);
            }
        }

        private void popularlistaHistorico(List<Veiculo> lista)
        {
           
            Tb_ListaHistorico.Text = "";
            int contador = 0;
            //Popula a lista de histórico de forma que mantem as últimas saídas dos
            //veículos no topo de exibição.
            foreach (Veiculo i in lista)
            {
                contador++;
                Tb_ListaHistorico.AppendText(contador + " ; " + 
                    i.Placa + " ; " +
                    i.Tipo + ";" +
                    i.DataEntrada + " ; " +
                    i.HoraEntrada + " ; " +
                    i.DataSaida + " ; " +
                    i.HoraSaida + " ; " +
                    i.TempoPermanencia + " ; " +
                    i.ValorCobrado + Environment.NewLine);
            }
        }

        //Limpa o formulário e espera 1 segundo (conforto de usabilidade) até a
        //apresentação do Tiquete de Entrada.
        private void LimparFormulario()
        {
            Tb_Placas.Text = "";
            Cb_TipoVeiculo.Text = "";
            Thread.Sleep(1000);
        }

        private void Tb_Cadastrar_Click(object sender, EventArgs e)
        {
            //Verifica a disponibilidade de vagas na garagem
            if (Veiculo.TemLugar(listaEntradaGaragem, tamanhoDaGaragem))
            {
                // Se vaga, então, instancia objeto veículo com os parâmetros do cadastro
                veiculo = new Veiculo(Tb_Placas.Text.ToUpper(), Cb_TipoVeiculo.Text, 
                DateTime.Now.ToString("dd/MM/yyyy"), DateTime.Now.ToString("HH:mm"));

                //validação da quantidade de caracteres.
                if (Tb_Placas.Text.Length != 7)
                {
                    MessageBox.Show("Placa inválida! (deve conter 7 dígitos)");
                }
                else if (Veiculo.Localizado(veiculo.Placa, listaEntradaGaragem) != -27)
                {
                    MessageBox.Show("Veículo consta no pátio da garagem!");
                }
                else if ((Cb_TipoVeiculo.Text.Length == 0))
                {
                    MessageBox.Show("Tipo do veículo não informado.");
                }
                else
                {
                    //Se atendida todas as condições (placa não consta no pátio, escolhido
                    //o tipo de veículo, comprimento da placa, e se, vaga no pátio, então:
                    //adiciona o novo veículo na lista de entrada.
                    listaEntradaGaragem.Add(veiculo);
                    //Persiste a lista de veículo completa na garagem.
                    Persistencia.GravarNoArquivoEntrada(listaEntradaGaragem);
                    //Recarrega e exibe a lista de veículos no pátio.
                    this.popularlistaVeiculosEntrada(listaEntradaGaragem);
                    LimparFormulario();

                    //Gerar tiquet de controle de entrada:
                    MessageBox.Show($"Tiquet Entrada:\n" +
                        $"Placa: {veiculo.Placa}\n" +
                        $"Tipo: {veiculo.Tipo}\n" +
                        $"Data de Entrada: {veiculo.DataEntrada}\n" +
                        $"Hora de Entrada: {veiculo.HoraEntrada}");
                }
            }
            else
            {
                MessageBox.Show("Garagem com todas as vagas ocupadas!");
            }
        }

        private void FormGaragem_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Iniciando programa!");
                
                //Altera de nome de exibição da empresa de acordo com o parametrizado -
                //Arquivo de configurações da garagem.
                Lbl_NomeEstabelecimento.Text = nomeEstabelecimento;

            //Popula a comboBox do tipo de veículo, conforme o arquivo de parametrização -
            //Arquivo de configurações da garagem. 
            foreach (var i in tipoVeiculo)
            {
                Cb_TipoVeiculo.Items.Add(i);
            }
         }

        private void Bt_Saida_Click(object sender, EventArgs e)
        {
            if (Tb_Placas.Text.Length != 7)
            {
                MessageBox.Show("Placa inválida! Informe placa com 7 dígitos.");
            }
            else
            {
                //Armazena a posição/indice no vetor que contem um objeto com a placa
                //informada. A listaEntradaGaragem é o vetor.
                posicaoVeiculo = Veiculo.Localizado(Tb_Placas.Text.ToUpper(), listaEntradaGaragem);
  
                if (posicaoVeiculo != -27)
                {
                    //Cria novo objeto para saída com base na posição do vetor, que contem
                    //o objeto da placa informada em tela, previamente localizado na 
                    //posicaoVeiculo.
                    veiculo = new Veiculo(
                        listaEntradaGaragem[posicaoVeiculo].Placa,
                        listaEntradaGaragem[posicaoVeiculo].Tipo,
                        listaEntradaGaragem[posicaoVeiculo].DataEntrada,
                        listaEntradaGaragem[posicaoVeiculo].HoraEntrada,
                        DateTime.Now.ToString("dd/MM/yyyy"),
                        DateTime.Now.ToString("HH:mm"));

                    veiculo.RealizarCobranca(valorDaHora);

                    //Remove o veículo localizado da lista de entrada
                    listaEntradaGaragem.RemoveAt(Veiculo.Localizado(veiculo.Placa, listaEntradaGaragem));
                    //Persiste a lista completa atualizada da lista de entrada
                    Persistencia.GravarNoArquivoEntrada(listaEntradaGaragem);
                    //Adiciona o veículo que saiu da lista de entrada para a lista de
                    //histórico na primeira posição(para não desaparecer caso seja atingida
                    //o tamanho de persistencia) - saída.
                    listaHistorico.Insert(0,veiculo);
                    
                    //Retira o último item da lista para quantidade de veiculos serem
                    //gravadas corretamente na lista de histórico, obecendo o limite de
                    //veiculos estipulado no arquivo.
                    if (listaHistorico.Count >= limiteVeiculosHistorico + 1)
                    {
                        listaHistorico.RemoveAt(limiteVeiculosHistorico);
                    }

                    //Persiste a lista completa atualizada da lista histórico - saída
                    Persistencia.GravarNoArquivoSaida(listaHistorico);

                    //Refaz a lista de histórico e da lista de entrada
                    Persistencia.LerArquivoSaida(listaHistorico, limiteVeiculosHistorico);
                    this.popularlistaHistorico(listaHistorico);
                    this.popularlistaVeiculosEntrada(listaEntradaGaragem);

                    LimparFormulario();

                    //Gera tiquet de saída:
                    MessageBox.Show($"Tiquete Saída:\n" +
                    $"Placa: {veiculo.Placa}\n" +
                    $"Tipo: {veiculo.Tipo}\n" +
                    $"Data de Entrada: {veiculo.DataEntrada}\n" +
                    $"Hora de Entrada: {veiculo.HoraEntrada}\n" +
                    $"Data de Saída: {veiculo.DataSaida}\n" +
                    $"Hora de Saída: {veiculo.HoraSaida}\n" +
                    $"Tempo de Permanência em Minutos: {veiculo.TempoPermanencia}\n" +
                    $"Valor a Pagar: {veiculo.ValorCobrado.ToString("C")}\n");
                }
                else
                {
                    MessageBox.Show("Veículo no pátio da garagem!");
                    LimparFormulario();
                }
            }
        }

        private void FormGaragem_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Deseja realmente fechar o programa?", "Confirmação",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                DialogResult.No)
            {
                e.Cancel = true; // esse e. veio do Evento - uma variável
                                 // que carrega algumas propriedades 
                                 // oriundas do método que chamou este
                                 // evento.
            }
        }
    }
}