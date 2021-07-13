using System;
using tabuleiro;
using xadrez;

namespace xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                PartidaXadrez partida = new PartidaXadrez();

                while(! partida.terminada)
                {
                    try
                    {

                        Console.Clear();
                        Tela.ImprimirPartida(partida);

                        
                        Console.WriteLine();
                        Console.Write("Origem: ");
                        Posicao origem = Tela.lerPosicaoXadrez().toPosicao();
                        partida.ValidarPosicaoOrigem(origem);
                    
                        bool[,] posicoesPossiveis = partida.Tab.peca(origem).movimentosPossiveis();
                    
                        Console.Clear();
                        Tela.imprimirTabuleiro(partida.Tab, posicoesPossiveis);

                        Console.WriteLine();
                        Console.Write("Destino: ");
                        Posicao destino = Tela.lerPosicaoXadrez().toPosicao();
                        partida.ValidarPosicaoDestino(origem, destino);

                        partida.RealizaJogada(origem, destino);
                    }
                    catch (TabuleiroExeption e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }

                }

            }
            catch(TabuleiroExeption e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
