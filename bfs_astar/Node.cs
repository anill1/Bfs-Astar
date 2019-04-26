using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bfs_astar
{
    class Node
    {
        public int heuristic_val;
        public List<Node> children = new List<Node>();
        public Node parent;
        public int[] puzzle = new int[9];
        public int[] goalState =
           {
                0,1,2,
                3,4,5,
                6,7,8
            };
        public int x = 0;

        public Node(int[] p, int heuristic)
        {
            SetPuzzle(p);
            this.heuristic_val = heuristic;

        }



        public void SetPuzzle(int[] p)
        {
            for (int i = 0; i < puzzle.Length; i++)
                this.puzzle[i] = p[i];
        }


        public void heuristic(List<Node> openList)
        {
            Node temp;
            int[] arr = new int[9];
            List<Node> list = new List<Node>();
            int cnt = 0;
            // Node max = openList[0];


            for (int i = 0; i < 9; i++)
                goalState[i] = i;


            for (int j = 0; j < openList.Count; j++)
            {

                for (int i = 0; i < 9; i++)
                {
                    if (goalState[i] == openList[j].puzzle[i])
                        cnt++;
                }
                openList[j].heuristic_val = cnt;
                cnt = 0;

            }



            //Console.Write(openList.Count +  " ");
            // Console.ReadLine();
            if (openList.Count > 1)
            {
                // Console.Write(openList.Count);
                for (int i = 0; i < openList.Count - 1; i++)
                {
                    // int i = 0;
                    //Console.Write(openList[i + 1].heuristic_val + " ");

                    if (openList[i + 1].heuristic_val > openList[i].heuristic_val)
                    {
                        //temp = openList[i];
                        //openList[i] = openList[i + 1];
                        //openList[i + 1] = temp;

                        temp = openList[0];
                        openList[0] = openList[i + 1];
                        openList[i + 1] = temp;

                        //max = openList[i+1];
                    }



                    // Console.Write(openList.Count + " ");
                    //Console.Write(openList[3].heuristic_val + " ");

                }
            }
            //for (int j = 0; j < openList.Count; j++)

        }

        public void ExpandMove()
        {
            for (int i = 0; i < puzzle.Length; i++)
            {
                if (puzzle[i] == 0)
                {
                    x = i;
                }
            }

            MoveToRight(puzzle, x);
            MoveToLeft(puzzle, x);
            MoveToUp(puzzle, x);
            MoveToDown(puzzle, x);

        }

        public bool GoalTest()
        {
            bool isGoal = true;

            int m = puzzle[0];

            for (int i = 0; i < puzzle.Length; i++)
            {
                if (m > puzzle[i])
                    isGoal = false;
                m = puzzle[i];
            }
            return isGoal;

        }





        public void MoveToRight(int[] p, int i)
        {

            if (i % 3 < 2)
            {
                int[] pc = new int[9];
                CopyPuzzle(pc, p);

                int temp = pc[i + 1];
                pc[i + 1] = pc[i];
                pc[i] = temp;

                Node child = new Node(pc, 0);
                children.Add(child);
                child.parent = this;
            }
        }

        public void MoveToLeft(int[] p, int i)
        {
            if (i % 3 > 0)
            {
                int[] pc = new int[9];
                CopyPuzzle(pc, p);

                int temp = pc[i - 1];
                pc[i - 1] = pc[i];
                pc[i] = temp;

                Node child = new Node(pc, 0);
                children.Add(child);
                child.parent = this;
            }
        }

        public void MoveToUp(int[] p, int i)
        {
            if (i - 3 >= 0)
            {
                int[] pc = new int[9];
                CopyPuzzle(pc, p);

                int temp = pc[i - 3];
                pc[i - 3] = pc[i];
                pc[i] = temp;

                Node child = new Node(pc, 0);
                children.Add(child);
                child.parent = this;
            }
        }

        public void MoveToDown(int[] p, int i)
        {
            if (i + 3 < puzzle.Length)
            {
                int[] pc = new int[9];
                CopyPuzzle(pc, p);

                int temp = pc[i + 3];
                pc[i + 3] = pc[i];
                pc[i] = temp;

                Node child = new Node(pc, 0);
                children.Add(child);
                child.parent = this;
            }
        }

        public void printPuzzle()
        {
            Console.WriteLine();
            int m = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(puzzle[m] + " ");
                    m++;
                }
                Console.WriteLine();
            }
        }


        public bool IsSamePuzzle(int[] p)
        {
            bool samePuzzle = true;
            for (int i = 0; i < p.Length; i++)
            {
                if (puzzle[i] != p[i])
                {
                    samePuzzle = false;
                }
            }
            return samePuzzle;
        }

        public void CopyPuzzle(int[] a, int[] b)
        {
            for (int i = 0; i < b.Length; i++)
                a[i] = b[i];
        }





    }
}
