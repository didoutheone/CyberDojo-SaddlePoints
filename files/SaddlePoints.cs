using System;
using System.Collections.Generic;
using System.Linq;

namespace MySaddlePoints
{
    public class Matrix
    {
        private const int ARRAY_SIZE = 5;
        private int[,] _array = new int[ARRAY_SIZE, ARRAY_SIZE];

        public void SetPoint(int row, int column, int value)
        {
            if (row >= ARRAY_SIZE || column >= ARRAY_SIZE) throw new CellOutOfArrayException(row, column);

            _array[row, column] = value;
        }

        // Saddle point :
        // value >= any in its row
        // value <= any in its column
        public List<Cell> GetSaddlePoints()
        {
            List<Cell> maxOfRows = GetCellsWithMaxValueOfEachRow();
            Debug(_array, maxOfRows, "Maxs of each row :");

            List<Cell> minOfColumns = GetCellsWithMinValueOfEachColumn();
            Debug(_array, minOfColumns, "Mins of each column :");

            List<Cell> result = maxOfRows.Intersect(minOfColumns).ToList();
            Debug(_array, result, "Saddle points :");

            return result;
        }

        private List<Cell> GetCellsWithMaxValueOfEachRow()
        {
            List<Cell> result = new List<Cell>();
            for (int i = 0; i < ARRAY_SIZE; i++)
            {
                List<Cell> row = GetRow(i);
                IEnumerable<Cell> cellsWithMaxValuesForThisRow = (from cell in row
                                                                  group cell by cell.Value into grpByValue
                                                                  orderby grpByValue.Key descending
                                                                  select grpByValue).First();

                result.AddRange(cellsWithMaxValuesForThisRow);
            }

            return result;
        }

        private List<Cell> GetCellsWithMinValueOfEachColumn()
        {
            List<Cell> result = new List<Cell>();
            for (int i = 0; i < ARRAY_SIZE; i++)
            {
                List<Cell> column = GetColumn(i);
                IEnumerable<Cell> cellsWithMinValuesForThisColumn = (from cell in column
                                                                     group cell by cell.Value into grpByValue
                                                                     orderby grpByValue.Key ascending
                                                                     select grpByValue).First();

                result.AddRange(cellsWithMinValuesForThisColumn);
            }

            return result;
        }

        private List<Cell> GetRow(int rowIndex)
        {
            List<Cell> row = new List<Cell>();

            for (int i = 0; i < ARRAY_SIZE; i++)
            {
                row.Add(new Cell(rowIndex, i, _array[rowIndex, i]));
            }

            return row;
        }

        private List<Cell> GetColumn(int columnIndex)
        {
            List<Cell> column = new List<Cell>();

            for (int i = 0; i < ARRAY_SIZE; i++)
            {
                column.Add(new Cell(i, columnIndex, _array[i, columnIndex]));
            }

            return column;
        }

        private void Debug(int[,] workArray, List<Cell> saddlePoints, string info)
        {
            Console.WriteLine(info);
            // Debug
            for (int i = 0; i < ARRAY_SIZE; i++)
            {
                for (int j = 0; j < ARRAY_SIZE; j++)
                {
                    if (saddlePoints.Contains(new Cell(i, j, _array[i, j])))
                    {
                        Console.Write("[" + workArray[i, j] + "]");
                    }
                    else
                    {
                        Console.Write(" " + workArray[i, j] + " ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}