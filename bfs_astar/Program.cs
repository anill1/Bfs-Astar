using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace bfs_astar
{
    class Program
    {
        public static int openListCounter = 0;
        public static int closedListCounter = 0;
        public static int solutionCost = 0;
        public static string currentAlgorithm;
        static readonly string file = @"C: \Users\bfsastar\input.txt";

        static void Main(string[] args)
        {
            if (File.Exists(file))
            {
                string input = File.ReadAllText(file);

                int[] puzzle = Array.ConvertAll(input.Split(','), int.Parse);


                Console.Write("Enter an algorithm ( bfs or astar ) : ");

                string currentAlgorithm = Console.ReadLine();


                Node root = new Node(puzzle, 0);
                Search search = new Search();
                List<Node> solution = search.searchAlgorithm(root);
                if (solution.Count > 0)
                {
                    solution.Reverse();
                    for (int i = 0; i < solution.Count; i++)
                        solution[i].printPuzzle();
                }
                else
                {
                    Console.WriteLine("no path to solution");
                }
                Console.Write("Çözüm Maliyeti: " + Program.solutionCost + "\n");
                Console.Write("Fronteir’e Giren Düğüm Sayısı : " + Program.openListCounter + "\n");
                Console.Write("Fronteir’den Çıkan (Expanded) Düğüm Sayısı : " + Program.closedListCounter);


            }

            else
            {
                Console.WriteLine("File not exist!");

            }
            Console.ReadLine();


        }
    }
}
