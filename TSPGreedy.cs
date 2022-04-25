using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrimsLib.tsp
{

	public class TSPGreedy
	{

		// Function to find the minimum
		// cost path for all the paths
		// greedy
		// algorithm
		static void findMinRoute(int[,] tsp)
		{
			int sum = 0;
			int counter = 0;
			int j = 0, i = 0;
			int min = int.MaxValue;

			List<int> visitedRouteList = new List<int>();

			// Starting from the 0th indexed
			// city i.e., the first city
			visitedRouteList.Add(0);
			int[] route = new int[tsp.Length];

			// Traverse the adjacency
			// matrix tsp[,]
			while (i < tsp.GetLength(0) &&
				j < tsp.GetLength(1))
			{

				// Corner of the Matrix
				if (counter >= tsp.GetLength(0) - 1)
				{
					break;
				}

				// If this path is unvisited then
				// and if the cost is less then
				// update the cost
				if (j != i &&
					!(visitedRouteList.Contains(j)))
				{
					if (tsp[i, j] < min)
					{
						min = tsp[i, j];
						route[counter] = j + 1;
					}
				}
				j++;

				// Check all paths from the
				// ith indexed city
				if (j == tsp.GetLength(0))
				{
					sum += min;
					min = int.MaxValue;
					visitedRouteList.Add(route[counter] - 1);

					j = 0;
					i = route[counter] - 1;
					counter++;
				}
			}

			// Update the ending city in array
			// from city which was last visited
			i = route[counter - 1] - 1;

			for (j = 0; j < tsp.GetLength(0); j++)
			{
				if ((i != j) && tsp[i, j] < min)
				{
					min = tsp[i, j];
					route[counter] = j + 1;
				}
			}
			sum += min;

			// Started from the node where
			// we finished as well.
			Console.Write("Minimum Cost is : ");
			Console.WriteLine(sum);
			int ret = sum;
		}

		// Driver Code
		public static void Test()
		{

			// Input Matrix
			int[,] tsp = { { 0, 10, 15, 20, 33 },
						   { 10, 0, 35, 25, 36 },
						   { 15, 35, 0, 30, 37 },
						   { 20, 25, 30, 0, 38 },
						   { 33, 36, 37, 38, 0 }
			};

			// Function call
			findMinRoute(tsp);
		}
		public static void TestDouble()
		{

			// Input Matrix
			double[,] tsp = { { -1, 10.5, 15.5, 20.5, 33.5 },
						   { 10.5, -1, 35.5, 25.5, 36.5 },
						   { 15.5, 35.5, -1, 30.5, 37.5 },
						   { 20.5, 25.5, 30.5, -1, 38.5 },
						   { 33.5, 36.5, 37.5, 38.5, -1 }
							};

			// Function call
			findDoubleMinRoute(tsp);
		}

		static void findDoubleMinRoute(double[,] tsp)
		{
			double sum = 0;
			int counter = 0;
			int j = 0, i = 0;
			double min = double.MaxValue;

			List<double> visitedRouteList = new List<double>();

			// Starting from the 0th indexed
			// city i.e., the first city
			visitedRouteList.Add(0);
			int[] route = new int[tsp.Length];

			// Traverse the adjacency
			// matrix tsp[,]
			while (i < tsp.GetLength(0) &&
				j < tsp.GetLength(1))
			{

				// Corner of the Matrix
				if (counter >= tsp.GetLength(0) - 1)
				{
					break;
				}

				// If this path is unvisited then
				// and if the cost is less then
				// update the cost
				if (j != i &&
					!(visitedRouteList.Contains(j)))
				{
					if (tsp[i, j] < min)
					{
						min = tsp[i, j];
						route[counter] = j + 1;
					}
				}
				j++;

				// Check all paths from the
				// ith indexed city
				if (j == tsp.GetLength(0))
				{
					sum += min;
					min = int.MaxValue;
					visitedRouteList.Add(route[counter] - 1);

					j = 0;
					i = route[counter] - 1;
					counter++;
				}
			}

			// Update the ending city in array
			// from city which was last visited
			i = route[counter - 1] - 1;

			for (j = 0; j < tsp.GetLength(0); j++)
			{
				if ((i != j) && tsp[i, j] < min)
				{
					min = tsp[i, j];
					route[counter] = j + 1;
				}
			}
			sum += min;

			// Started from the node where
			// we finished as well.
			Console.Write("Minimum Cost is : ");
			Console.WriteLine(sum);
			double ret = sum;
		}
	}
	// This code is contributed by Amit Katiyar
}
