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
}