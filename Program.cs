using System;

namespace fith
{
    class Program
    {
        class Table
        {
            int[,] map = new int[3, 3];
            string answer = "";

            public Table()
            {
                Random rand = new Random();
                int n = 0;

                while (n < 9)
                {
                    int x = rand.Next(map.Length / 3);
                    int y = rand.Next(map.Length / 3);

                    if (map[x, y] == 0) map[x, y] = n++;
                }

                for (int i = 1; i < map.Length / 2 + 1; i++)
                    answer += i.ToString();

                answer += '0';
            }

            public void Show()
            {
                for (int i = 0; i < map.Length / 3; i++)
                {
                    for (int j = 0; j < map.Length / 3; j++)
                        if (map[i, j] != 0) Console.Write(map[i, j] + " ");
                        else Console.Write("  ");

                    Console.WriteLine();
                }
            }
            public bool Move(ConsoleKeyInfo key) 
            {
                for (int i = 0; i < map.Length / 3; i++)
                    for (int j = 0; j < map.Length / 3; j++)
                        if (map[i, j] == 0)
                            switch (key.Key.ToString())
                            {
                                case "LeftArrow": TryMove(i, j + 1, i, j); return Check();
                                case "UpArrow": TryMove(i + 1, j, i, j); ; return Check();
                                case "RightArrow": TryMove(i, j - 1, i, j); ; return Check();
                                case "DownArrow": TryMove(i - 1, j, i, j); ; return Check();
                            }

                return Check();
            }

            private void TryMove(int x1, int y1, int x2, int y2)
            {
                try
                {
                    map[x2, y2] = map[x1, y1];
                    map[x1, y1] = 0;
                }
                catch { }
            }

            private bool Check()
            {
                string str = "";

                foreach (int a in map) str += a.ToString();

                return str == "123456780";
            }
        }

        static void Main(string[] args)
        {
            Table table = new Table();

            while (true)
            {
                table.Show();

                if (table.Move(Console.ReadKey(true)))
                {
                    Console.WriteLine("Over");
                    break;
                }

                Console.Clear();
            }
        }
    }
}
