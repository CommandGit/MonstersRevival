using UnityEngine.Tilemaps;

namespace Abstractions.Room
{
    internal interface IRoomTileSet
    {
        public Tile GetTile(WallType wallType);
        public Tile GetTile(FloorType floorType);
        public Tile GetTile(DoorType doorType);

        public void SetTile(WallType wallType, Tile tile);
        public void SetTile(FloorType floorType, Tile tile);
        public void SetTile(DoorType doorType, Tile tile);

    }
}

