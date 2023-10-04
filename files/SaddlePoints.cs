using System;
using System.Collections.Generic;
using System.Linq;

namespace MySaddlePoints
{
    public class Cell
    {
        public int Row { get; private set; }

        public int Column { get; private set; }

        public int Value { get; private set; }

        public Cell(int row, int column, int value)
        {
            Row = row;
            Column = column;
            Value = value;
        }

        override public bool Equals(object obj)
        {
            return Equals(obj as Cell);
        }

        public bool Equals(Cell other)
        {
            if (other == null) return false;
            return Row == other.Row && Column == other.Column && Value == other.Value;
        }

        public override int GetHashCode()
        {
            return Row.GetHashCode() ^ Column.GetHashCode() ^ Value.GetHashCode();
        }
    }

    public class Matrix
    {
        private int[,] _array;

        public Matrix()
        {
            _array = GetZeroArray();
        }

        public void SetPoint(int row, int column, int value)
        {
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
            for (int i = 0; i < 5; i++)
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
            for (int i = 0; i < 5; i++)
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

        private int[,] GetZeroArray()
        {
            return new int[,]
            {
            {0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0}
            };
        }

        private List<Cell> GetRow(int i)
        {
            return new List<Cell> {
                new Cell(i, 0, _array[i, 0]),
                new Cell(i, 1, _array[i, 1]),
                new Cell(i, 2, _array[i, 2]),
                new Cell(i, 3, _array[i, 3]),
                new Cell(i, 4, _array[i, 4])
            };
        }

        private List<Cell> GetColumn(int j)
        {
            return new List<Cell> {
                new Cell(0, j, _array[0, j]),
                new Cell(1, j, _array[1, j]),
                new Cell(2, j, _array[2, j]),
                new Cell(3, j, _array[3, j]),
                new Cell(4, j, _array[4, j])
            };
        }

        private void Debug(int[,] workArray, List<Cell> saddlePoints, string info)
        {
            Console.WriteLine(info);
            // Debug
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
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