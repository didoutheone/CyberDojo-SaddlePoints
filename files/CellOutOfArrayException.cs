using System.Runtime.Serialization;

namespace MySaddlePoints
{
    [Serializable]
    internal class CellOutOfArrayException : Exception
    {
        public int Row { get; private set; }
        public int Column { get; private set; }

        public CellOutOfArrayException(int row, int column) : base($"Array does not contain a cell in row {row} and column {column}")
        {
            this.Row = row;
            this.Column = column;
        }
    }
}