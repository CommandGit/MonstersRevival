using Abstractions.Room;

namespace Room
{

    internal sealed class RoomTileSetCreator : IRoomTileSetCreator
    {
        public IRoomTileSet Create(IFloorScriptableTileSet floorTiles, IWallScriptableTileSet wallTiles, IDoorScriptableTileSet doorTiles)
        {
            IRoomTileSet roomTileSet = new RoomTileSet();

            roomTileSet.SetTile(FloorType.Full, floorTiles.Full);

            roomTileSet.SetTile(DoorType.Up, doorTiles.Up);
            roomTileSet.SetTile(DoorType.Down, doorTiles.Down);
            roomTileSet.SetTile(DoorType.Left, doorTiles.Left);
            roomTileSet.SetTile(DoorType.Right, doorTiles.Right);

            roomTileSet.SetTile(WallType.Full, wallTiles.Full);
            roomTileSet.SetTile(WallType.UpWall, wallTiles.UpWall);
            roomTileSet.SetTile(WallType.DownWall, wallTiles.DownWall);
            roomTileSet.SetTile(WallType.LeftWall, wallTiles.LeftWall);
            roomTileSet.SetTile(WallType.RightWall, wallTiles.RightWall);
            roomTileSet.SetTile(WallType.UpLeftOutCorner, wallTiles.UpLeftOutCorner);
            roomTileSet.SetTile(WallType.UpRightOutCorner, wallTiles.UpRightOutCorner);
            roomTileSet.SetTile(WallType.DownLeftOutCorner, wallTiles.DownLeftOutCorner);
            roomTileSet.SetTile(WallType.DownRightOutCorner, wallTiles.DownRightOutCorner);
            roomTileSet.SetTile(WallType.UpLeftInCorner, wallTiles.UpLeftInCorner);
            roomTileSet.SetTile(WallType.UpRightInCorner, wallTiles.UpRightInCorner);
            roomTileSet.SetTile(WallType.DownLeftInCorner, wallTiles.DownLeftInCorner);
            roomTileSet.SetTile(WallType.DownRightInCorner, wallTiles.DownRightInCorner);

            return roomTileSet;
        }
    }
}
