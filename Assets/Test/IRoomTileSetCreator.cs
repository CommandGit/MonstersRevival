using Abstractions.Room;

namespace Room
{
    internal interface IRoomTileSetCreator
    {
        IRoomTileSet Create(IFloorScriptableTileSet floorTiles, IWallScriptableTileSet wallTiles, IDoorScriptableTileSet doorTiles);
    }
}