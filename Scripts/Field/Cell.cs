namespace Sea_battle.Field_
{
    public enum CellValueType
    {
        Empty,
        HasShip,
        HitWithSuccess,
        HitWithFailure
    }
    public struct Cell
    {
        public CellValueType Value;
        public ConsoleColor Color = ConsoleColor.Blue;

        public Cell(CellValueType type)
        {
            Value = type;
        }
    }
}
