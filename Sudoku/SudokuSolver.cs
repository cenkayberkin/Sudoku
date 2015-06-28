using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
	
namespace Sudoku
{
	public class SudokuSolver
	{
		public int[,] sTable;
		public SudokuSolver (int [,]table)
		{
			this.sTable = table;

			Solve (this.sTable);

		}

		public bool Solve(int[,] table)
		{
			if (FindNextEmptyCell(table) == null) {
				this.sTable = table;
				return true;
			}

			Tuple<int,int> t = FindNextEmptyCell (table);
			int row = t.Item1;
			int col = t.Item2;
			var candidates = FindCandidates (row, col, table);
			foreach (var item in candidates) {
				table [row, col] = item;
				if (Solve(table)) {
					return true;
				}
				table [row, col] = 0;
			}
			return false;
		}

		public Tuple<int,int> FindNextEmptyCell(int[,] table)
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

		public List<int> FindCandidates(int row,int col,int[,] table)
		{
			List<int> result = new List<int> ();
			for (int i = 1; i < 10; i++) {
				if (IsValid(row,col,i,table)) {
					result.Add (i);
				}
			}
			return result;
		}

		public void Print()
		{
			string tmp = "";
			for (int row = 0; row < 9; row++) {
				
				for (int col = 0; col < 9; col++) {
					tmp += this.sTable [row, col] + " ";	
				}
				Console.WriteLine (tmp);
				tmp = "";
			}
		}

		public bool IsValid(int row,int col, int value,int[,] table)
		{
			if (IsValidByRow (row, value,table) && IsValidByCol (col, value,table) && IsValidBySquare (row, col, value,table)) {
				return true;
			} else {
				return false;
			}
		}

		public bool IsValidByRow(int row, int value,int[,] table)
		{
			for (int i = 0; i < 9; i++) {
				if (table[row,i] == value) {
					return false;
				}
			}
			return true;
		}

		public bool IsValidByCol(int col, int value, int[,] table)
		{
			for (int i = 0; i < 9; i++) {
				if (table[i,col] == value) {
					return false;
				}
			}
			return true;
		}

		public bool IsValidBySquare(int row, int col, int value, int[,] table)
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

