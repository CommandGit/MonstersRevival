using Abstractions.Room;

namespace Abstraction.Room
{
    internal interface IRoomTileSetCreator
    {
        IRoomTileSet Create(IFloorScriptableTileSet floorTiles, IWallScriptableTileSet wallTiles, IDoorScriptableTileSet doorTiles);
    }
}