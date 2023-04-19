namespace Sea_battle
{
    public enum ShipType
    {
        TorpedoBoat = 1,
        Destroyer = 2,
        Cruiser = 3,
        Battleship = 4
    }
    public class Ship
    {
        public int size { get; private set; }

        public Ship(int size)
        {
            this.size = size;
        }
    }
}
