using System;

namespace Sudoku
{
	class MainClass
	{
		public static void Main (string[] args)
		{
//			int[,] input = new int[9,9] {
//				{0,0,1,2,0,3,4,0,0},
//				{0,7,0,0,1,0,0,0,0},
//				{5,0,0,9,0,6,0,0,0},
//				{0,0,0,0,0,0,0,0,0},
//				{6,0,0,0,0,0,0,0,0},
//				{0,0,0,0,0,0,0,0,0},
//				{0,0,0,0,0,0,0,0,0},
//				{9,0,0,0,0,0,0,0,0},
//				{0,0,0,0,0,0,0,0,0}
//			};

			int[,] input = new int[9, 9] {
				{ 1, 1, 1, 2, 1, 3, 4, 1, 1 },
				{ 1, 1, 1, 2, 1, 3, 4, 1, 1 },
				{ 1, 1, 1, 2, 1, 3, 4, 1, 1 },
				{ 1, 1, 1, 2, 1, 3, 4, 1, 1 },
				{ 1, 1, 1, 2, 1, 3, 4, 1, 1 },
				{ 1, 1, 1, 2, 1, 3, 4, 0, 1 },
				{ 1, 1, 1, 2, 1, 3, 4, 1, 1 },
				{ 1, 1, 1, 2, 1, 3, 4, 1, 1 },
				{ 1, 1, 1, 2, 1, 3, 4, 1, 1 }
			};

			SudokuSolver ss = new SudokuSolver (input);
//			ss.Print (input);

			Console.WriteLine (string.Join(" " , ss.FindCandidates(1,3)));
			if (ss.FindNextEmptyCell () == null) {
				Console.WriteLine ("Sudoku finished");
			} else {
				Console.WriteLine (ss.FindNextEmptyCell ());
			}

			Console.WriteLine ("Hello World!");
		}
	}
}
