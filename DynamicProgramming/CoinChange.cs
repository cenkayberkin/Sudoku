using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DynamicProgramming
{
	public class CoinChange
	{
		public static Dictionary<int,int> dic = new Dictionary<int, int>();

		public static int Solve(int amount,int[] coins)
		{
			if (amount == 0) {
				return 0;
			}

			List<int> candidates = new List<int> ();
			foreach (var coin in coins) {
				if (coin <= amount) {
					if (dic.ContainsKey (amount - coin)) {
						candidates.Add (dic [amount - coin]);
					} else {
						dic [amount - coin] = Solve (amount - coin, coins);
						candidates.Add (Solve (amount - coin, coins));
					}

				}
			}

			return candidates.Min() + 1;
		}
	}


}

