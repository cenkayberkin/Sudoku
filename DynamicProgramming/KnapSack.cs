using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DynamicProgramming
{
	public class KnapSack
	{
		List<int> candidates;
		Dictionary<int,int> priceIndex;

		public KnapSack (int capacity, int[] cands,int[] prices)
		{
			this.candidates = new List<int> (cands);
			this.priceIndex = new  Dictionary<int,int> ();

			for (int i = 0; i < cands.Count(); i++) {
				priceIndex[cands[i]] = prices[i];
			}

			int result = Solve (capacity,candidates);
			Console.WriteLine (result);
		}

		public int Solve(int capacity, List<int> candidates)
		{
			if (this.SetMin(candidates) > capacity) {
				return 0;
			}

			List<int> results = new List<int> ();

			Dictionary<int,List<int>> newSet = new Dictionary<int, List<int>> ();
			foreach (var item in candidates) {
				if (item <= capacity) {
					var tmp = new List<int> ();
					tmp = candidates.ToList ();
					tmp.Remove (item);
					results.Add (Solve (capacity - item, tmp) + priceIndex[item]);
				}
			}

//			foreach (var item in candidates) {
//				if (item <= capacity ) {
//					newSet.Add (item, BuildList (candidates, item));
//				}
//			}
//
//			foreach (var key in newSet.Keys) {
//				results.Add (Solve (capacity - key, newSet [key]) + weightsIndex[key]);
//			}


			return results.Max ();
			
		}

		public List<int> BuildList(List<int> cand, int item)
		{
			List<int> result = new List<int> ();
			foreach (var i in cand) {
				if (i != item) {
					result.Add (i);
				}
			}
			return result;
		}

		public int SetMin(List<int> set)
		{
			int min = int.MaxValue;
			foreach (var item in set) {
				if (item < min) {
					min = item;
				}
			}
			return min;
		}
	}
}

