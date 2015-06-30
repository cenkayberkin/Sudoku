using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DynamicProgramming
{
	class MainClass
	{
		public static void Main (string[] args)
		{
//			int[] c = new int[5]{1,2,3,7,11};
//			int result = CoinChange.Solve (53,c);
//			Console.WriteLine (result);


			List<Product> products = new List<Product> ()
			{
				new Product(2,3),
				new Product(3,4),
				new Product(4,5),
				new Product(5,6)
			};
		
//			KnapSack ks = new KnapSack(5, cands ,weights);

			KnapSack2 ks = new KnapSack2(9, products);

			Console.WriteLine ("");
		}

	}
}
