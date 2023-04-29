using Sea_battle.Other;

namespace Sea_battle.Field_
{
    public class Field
    {
        public Cell[,] cells { get; private set; }
        public List<Vector2> shipsCoordinates { get; private set; } = new();
        public List<Vector2> markedCellsCoordinates { get; private set; } = new();

        public ConsoleColor BackgroundColor = ConsoleColor.Blue;

        public static int startXPos = 3;
        public static int startYPos = 1;

        public int size = 10;
        public Field(int size)
        {
            this.size = size;
            cells = new Cell[this.size, this.size];
            InitField();
        }

        private void InitField()
        {
            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    cells[x, y] = new Cell(CellValueType.Empty);
                }
            }
        }

        public void AddShip(Vector2 coords)
        {
            cells[coords.x, coords.y].Value = CellValueType.HasShip;
            cells[coords.x, coords.y].Color = ConsoleColor.Red;
            shipsCoordinates.Add(coords);
        }

        public void MarkCell(Vector2 coords, CellValueType hitType)
        {
            cells[coords.x, coords.y].Value = hitType;
            markedCellsCoordinates.Add(coords);
        }

        public bool DoesCellHaveShip(Vector2 coords) => cells[coords.x, coords.y].Value == CellValueType.HasShip;

        public bool HadMarkedCell(Vector2 pos) => markedCellsCoordinates.ContainsVector(pos);
    }
}