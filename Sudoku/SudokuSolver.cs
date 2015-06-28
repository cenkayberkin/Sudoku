using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Sudoku
{
	public class SudokuSolver
	{
		public int[,] table;
		public SudokuSolver (int [,]table)
		{
			this.table = table;
		}

		public Tuple<int,int> FindNextEmptyCell()
		{	
			for (int row = 0; row < 9; row++) {
				for (int col = 0; col < 9; col++) {
					if (table[row,col] == 0) {
						return new Tuple<int,int> (row, col);
					}
				}
			}
			return null;
		}

		public List<int> FindCandidates(int row,int col)
		{
			List<int> result = new List<int> ();
			for (int i = 0; i < 9; i++) {
				if (IsValid(row,col,i)) {
					result.Add (i);
				}
			}
			return result;
		}

		public void Print(int[,] result)
		{
			string tmp = "";
			for (int row = 0; row < 9; row++) {
				
				for (int col = 0; col < 9; col++) {
					tmp += result [row, col] + " ";	
				}
				Console.WriteLine (tmp);
				tmp = "";
			}
		}

		public bool IsValid(int row,int col, int value)
		{
			if (IsValidByRow (row, value) && IsValidByCol (col, value) && IsValidBySquare (row, col, value)) {
				return true;
			} else {
				return false;
			}
		}

		public bool IsValidByRow(int row, int value)
		{
			for (int i = 0; i < 9; i++) {
				if (table[row,i] == value) {
					return false;
				}
			}
			return true;
		}

		public bool IsValidByCol(int col, int value)
		{
			for (int i = 0; i < 9; i++) {
				if (table[i,col] == value) {
					return false;
				}
			}
			return true;
		}

		public bool IsValidBySquare(int row, int col, int value)
		{
			int sectionCol = col / 3;
			int startCol = sectionCol * 3;
			int endCol = (sectionCol * 3) + 3;

			int sectionRow = row / 3;
			int startRow = sectionRow * 3;
			int endRow = (sectionRow * 3) + 3;

			for (int i = startRow; i < endRow; i++) {
				for (int z = startCol; z < endCol; z++) {
					if (table[i,z] == value) {
						return false;
					}
				}
			}

			return true;
		}

	}
}

