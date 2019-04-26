using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bfs_astar
{
    class Search
    {
        public int[] goalState =
           {
                0,1,2,
                3,4,5,
                6,7,8
            };

        public Search()
        {

        }

        public int costFunction(int[] start, int[] goal, int level)
        {
            int gx = 0;
            return gx;
        }

        public List<Node> AstarSearch(Node root)
        {
            List<Node> PathToSolution = new List<Node>();
            List<Node> OpenList = new List<Node>();
            List<Node> ClosedList = new List<Node>();

            OpenList.Add(root);
            bool goalFound = false;



            return PathToSolution;

        }

        public List<Node> searchAlgorithm(Node root)
        {
            List<Node> PathToSolution = new List<Node>();
            List<Node> OpenList = new List<Node>();
            List<Node> ClosedList = new List<Node>();


            OpenList.Add(root);
            bool goalFound = false;
            while (OpenList.Count > 0 && !goalFound)
            {
                int x = 0;
                x++;
                //Node node = new Node(puzzle,0);
                if (Program.currentAlgorithm == "astar")
                    root.heuristic(OpenList);

                Node currentNode = OpenList[0];
                if (OpenList.Count == 0)
                    Console.WriteLine("no solution");



                ClosedList.Add(currentNode);
                Program.closedListCounter++;
                OpenList.RemoveAt(0);

                currentNode.ExpandMove();

                for (int i = 0; i < currentNode.children.Count; i++)
                {
                    Node currentChild = currentNode.children[i];
                    if (currentChild.GoalTest())
                    {
                        Console.WriteLine("Goal found.");
                        goalFound = true;
                        PathTrace(PathToSolution, currentChild);
                    }

                    if (!Contains(OpenList, currentChild) && !Contains(ClosedList, currentChild))
                        OpenList.Add(currentChild);
                    Program.openListCounter++;

                }

            }


            return PathToSolution;
        }



        public void PathTrace(List<Node> path, Node n)
        {
            Console.WriteLine("tracing path..");
            Node current = n;
            path.Add(current);

            while (current.parent != null)
            {
                current = current.parent;
                path.Add(current);
                Program.solutionCost++;

            }

        }


        public static bool Contains(List<Node> list, Node c)
        {
            bool contains = false;

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].IsSamePuzzle(c.puzzle))
                    contains = true;

            }
            return contains;
        }

        public void sortOpenList(List<Node> openList)
        {
            openList.Sort();
        }
    }
}
