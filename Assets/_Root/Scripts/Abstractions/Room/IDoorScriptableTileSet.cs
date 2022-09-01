using UnityEngine.Tilemaps;

namespace Abstraction.Room
{
    internal interface IDoorScriptableTileSet
    {
        Tile Down { get; }
        Tile Left { get; }
        Tile Right { get; }
        Tile Up { get; }
    }
}