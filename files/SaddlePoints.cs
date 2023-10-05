using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

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
            return (from row in Rows                                    // for each row
                        select
                        (
                             from cell in row                           // - look the cells of that row
                             group cell by cell.Value into grpByValue   // - group them by value
                             orderby grpByValue.Key descending          // - order the groups by value descending (so the first group has the greatest value)
                             select grpByValue                          // - select the groups
                        ).First()                                       // - keep only the top one group
                    ).SelectMany(cellList => cellList).ToList();        // finally : flatten the List of List
        }

        private List<Cell> GetCellsWithMinValueOfEachColumn()
        {
            return (from column in Columns                              // for each column
                    select
                        (
                             from cell in column                        // - look the cells of that column
                             group cell by cell.Value into grpByValue   // - group them by value
                             orderby grpByValue.Key ascending           // - order the groups by value ascending (so the first group has the lowest value)
                             select grpByValue                          // - select the groups
                        ).First()                                       // - keep only the top one group
                    ).SelectMany(cellList => cellList).ToList();        // finally : flatten the List of List
        }

        private IEnumerable<List<Cell>> Rows
        {
            get
            {
                return (
                            from rowIndex in Enumerable.Range(0, ARRAY_SIZE)
                            select 
                            (
                                from columnIndex in Enumerable.Range(0, ARRAY_SIZE)
                                select new Cell(rowIndex, columnIndex, _array[rowIndex, columnIndex])
                            ).ToList<Cell>()
                       ).AsEnumerable<List<Cell>>();
            }
        }

        private IEnumerable<List<Cell>> Columns
        {
            get
            {
                return (
                            from columnIndex in Enumerable.Range(0, ARRAY_SIZE)
                            select
                            (
                                from rowIndex in Enumerable.Range(0, ARRAY_SIZE)
                                select new Cell(rowIndex, columnIndex, _array[rowIndex, columnIndex])
                            ).ToList<Cell>()
                       ).AsEnumerable<List<Cell>>();
            }
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