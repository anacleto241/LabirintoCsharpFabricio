using System;
using System.Collections.Generic;

namespace LabirintoCSharp
{
    internal class Program
    {
        private const int limit = 15;

        static void mostrarLabirinto(char[,] array, int l, int c)
        {
            for (int i = 0; i < l; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < c; j++)
                {
                    Console.Write($" {array[i, j]} ");
                }
            }
            Console.WriteLine();
        }


        static void criaLabirinto(char[,] meuLab)
        {
            Random random = new Random();
            for (int i = 0; i < limit; i++)
            {
                for (int j = 0; j < limit; j++)
                {
                    meuLab[i, j] = random.Next(4) == 1 ? '|' : '.';
                }
            }


            for (int i = 0; i < limit; i++)
            {
                meuLab[0, i] = '*';
                meuLab[limit - 1, i] = '*';
                meuLab[i, 0] = '*';
                meuLab[i, limit - 1] = '*';
            }


            int x = random.Next(limit);
            int y = random.Next(limit);
            meuLab[x, y] = 'Q';
        }

    static void buscarQueijo(char[,] meuLab, int i, int j)
{
    Stack<(int, int)> minhaPilha = new Stack<(int, int)>();

        while (meuLab[i, j] != 'Q') {
                {
                    if (meuLab[i, j] == 'Q')
                    {
                        Console.WriteLine("Queijo encontrado!");
                        return;
                    }
                    meuLab[i, j] = 'v';

                    if (j + 1 < limit && meuLab[i, j + 1] == '.')
                    {
                        minhaPilha.Push((i, j)); // empilhar posição atual
                        j++; // mover para a direita
                    }
                    else if (i + 1 < limit && meuLab[i + 1, j] == '.')
                    {
                        minhaPilha.Push((i, j)); // empilhar posição atual
                        i++; // mover para baixo
                    }

                    else if (j - 1 >= 0 && meuLab[i, j - 1] == '.')
                    {
                        minhaPilha.Push((i, j)); // empilhar posição atual
                        j--; // mover para a esquerda
                    }
                    else if (i - 1 >= 0 && meuLab[i - 1, j] == '.')
                    {
                        minhaPilha.Push((i, j)); // empilhar posição atual
                        i--; // mover para cima
                    }else
                    {
                        if (minhaPilha.Count > 0)
                        {
                            (i, j) = minhaPilha.Pop(); // desempilhar posição anterior
                        }
                        else
                        {
                            Console.WriteLine("Não foi possível encontrar o queijo!");
                            return; // sair da função se a pilha estiver vazia
                        }
                    }
                }

        System.Threading.Thread.Sleep(200);
        Console.Clear();
        mostrarLabirinto(meuLab, limit, limit);

    }
}







        static void Main(string[] args)
        {
            char[,] labirinto = new char[limit, limit];
            criaLabirinto(labirinto);
            mostrarLabirinto(labirinto, limit, limit);
            buscarQueijo(labirinto, 1, 1);
            Console.ReadKey();
        }
    }
}