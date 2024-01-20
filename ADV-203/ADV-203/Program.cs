using System.Drawing;
using System.IO.MemoryMappedFiles;

namespace ADV_203
{
    internal class Program
    {
        //Input: [,] of 0 and 1
        //0: water
        //1: land
        //count the number if islands

        /*
        1 1 0 1   3
        0 1 0 1
        0 0 1 1
        1 0 0 0

        0 1 0 0   3
        0 0 0 1
        0 0 0 1
        1 0 0 0

        0 0 0 1   2
        0 0 0 1
        0 1 1 1
        1 0 0 0

        1 0 0 0   2
        0 0 0 0
        0 0 0 0
        0 0 0 1

        0 0 0 0   1
        0 1 1 0
        0 0 0 0
        0 0 0 0

        3
        4
        2
        2
        2
        */
        static void Main(string[] args)
        {
            int[,] case1 =
            {
                { 1, 1, 0, 1 },
                { 0, 1, 0, 1 },
                { 0, 0, 1, 1 },
                { 1, 0, 0, 0 }
            };

            int[,] case2 =
            {
                { 0, 1, 0, 0 },
                { 0, 0, 0, 1 },
                { 0, 0, 0, 1 },
                { 1, 0, 0, 0 }
            };

            int[,] case3 =
            {
                { 0, 0, 0, 1 },
                { 0, 0, 0, 1 },
                { 0, 1, 1, 1 },
                { 1, 0, 0, 0 }
            };

            int[,] case4 =
            {
                { 1, 0, 0, 0 },
                { 0, 0, 0, 0 },
                { 0, 0, 0, 0 },
                { 0, 0, 0, 1 }
            };

            int[,] case5 =
            {
                { 0, 0, 0, 0 },
                { 0, 1, 1, 0 },
                { 0, 0, 0, 0 },
                { 0, 0, 0, 0 }
            };

            var one = CountIslands2(case1);
            var two = CountIslands2(case2);
            var three = CountIslands2(case3);
            var four = CountIslands2(case4);
            var five = CountIslands2(case5);
            Console.WriteLine(one.Item1);
            Console.WriteLine(two.Item1);
            Console.WriteLine(three.Item1);
            Console.WriteLine(four.Item1);
            Console.WriteLine(five.Item1);
            ;
        }

        static int CountIslands(int[,] map)
        {
            int islandCount = 0;
            for (int y = 0; y < map.GetLength(1); y++)
            {
                for (int x = 0; x < map.GetLength(0); x++)
                {
                    if (map[x, y] == 1 && GetNumConnections(map, new Point(x, y)) <= 1 && GetNumWater(map, new Point(x, y)) >= 2) islandCount++;
                }
            }

            return islandCount;
        }

        static int GetNumConnections(int[,] map, Point point)
        {
            int numConnections = 0;

            if(point.X - 1 >= 0 && map[point.X - 1, point.Y] == 1) numConnections++;
            
            if (point.X + 1 < map.GetLength(0) && map[point.X + 1, point.Y] == 1) numConnections++;

            if (point.Y - 1 >= 0 && map[point.X, point.Y - 1] == 1) numConnections++;

            if (point.Y + 1 < map.GetLength(1) && map[point.X, point.Y + 1] == 1) numConnections++;

            return numConnections;
        }

        static int GetNumWater(int[,] map, Point point)
        {
            int numConnections = 0;

            if (point.X - 1 >= 0 && map[point.X - 1, point.Y] == 0) numConnections++;

            if (point.X + 1 < map.GetLength(0) && map[point.X + 1, point.Y] == 0) numConnections++;

            if (point.Y - 1 >= 0 && map[point.X, point.Y - 1] == 0) numConnections++;

            if (point.Y + 1 < map.GetLength(1) && map[point.X, point.Y + 1] == 0) numConnections++;

            return numConnections;
        }

        static (int, List<Point>) CountIslands2(int[,] map)
        {
            int CurrentIsland = 2;
            for (int x = 0; x < map.GetLength(0); x++)
            {
                for (int y = 0; y < map.GetLength(1); y++)
                {
                    if (map[x, y] != 0)
                    {
                        int set = GetSet(map, new Point(x, y));
                        if (set == 1)
                        {
                            map[x, y] = CurrentIsland;
                            CurrentIsland++;
                        }
                        else
                        {
                            map[x, y] = set;
                            int oldSet = 0;
                            if (y - 1 >= 0 && map[x, y - 1] != 0) oldSet = map[x, y - 1];
                            if (oldSet != 0)
                            {
                                for (int x2 = 0; x2 < map.GetLength(0); x2++)
                                {
                                    for (int y2 = 0; y2 < map.GetLength(1); y2++)
                                    {
                                        if (map[x2, y2] == oldSet)
                                        {
                                            map[x2, y2] = set;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            CurrentIsland = 0;
            Dictionary<int, int> sets = new Dictionary<int, int>();
            for (int x = 0; x < map.GetLength(0); x++)
            {
                for (int y = 0; y < map.GetLength(1); y++)
                {
                    if (map[x, y] != 0)
                    {
                        if (sets.ContainsKey(map[x, y]))
                        {
                            sets[map[x, y]]++;
                        }
                        else
                        {
                            sets.Add(map[x, y], 1);
                        }
                    }
                }
            }
            //Find largest island
            int largestSet = 0;
            foreach (var set in sets)
            {
                if (largestSet == 0 || set.Value > sets[largestSet]) largestSet = set.Key;
            }

            //find locations of that set
            List<Point> points = new List<Point>();
            for (int x = 0; x < map.GetLength(0); x++)
            {
                for (int y = 0; y < map.GetLength(1); y++)
                {
                    if (map[x, y] == largestSet)
                    {
                        points.Add(new Point(x, y));
                    }
                }
            }

            return (sets.Count, points);
        }

        static int GetSet(int[,] map, Point point)
        {
            if (point.X - 1 >= 0 && map[point.X - 1, point.Y] != 0) return map[point.X - 1, point.Y];

            if (point.Y - 1 >= 0 && map[point.X, point.Y - 1] != 0) return map[point.X, point.Y - 1];

            if (point.X + 1 < map.GetLength(0) && map[point.X + 1, point.Y] != 0) return map[point.X + 1, point.Y];

            if (point.Y + 1 < map.GetLength(1) && map[point.X, point.Y + 1] != 0) return map[point.X, point.Y + 1];

            return map[point.X, point.Y];
        }
    }
}