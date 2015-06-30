using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DynamicProgramming
{
	public class Product
	{
		public int Weight { get; set; }
		public int Price { get; set; }

		public Product (int weight, int price)
		{
			this.Weight = weight;
			this.Price = price;
		}
	}

	public class KnapSack2
	{
		public KnapSack2 (int capacity, List<Product> products)
		{
			int result = Solve (capacity, products);
			Console.WriteLine (result);
		}

		public int Solve(int capacity, List<Product> candidates)
		{
			if (candidates.Min(a => a.Weight) > capacity) {
				return 0;
			}

			List<int> results = new List<int> ();

			foreach (var item in candidates) {
				if (item.Weight <= capacity) {
					var tmp = new List<Product> ();
					tmp = candidates.ToList ();
					tmp.Remove (item);
					results.Add (Solve (capacity - item.Weight, tmp) + item.Price);
				}
			}
			return results.Max ();
		}
	}
}

