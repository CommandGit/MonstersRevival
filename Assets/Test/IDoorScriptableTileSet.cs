using UnityEngine.Tilemaps;

namespace Room
{
    internal interface IDoorScriptableTileSet
    {
        Tile Down { get; }
        Tile Left { get; }
        Tile Right { get; }
        Tile Up { get; }
    }
}