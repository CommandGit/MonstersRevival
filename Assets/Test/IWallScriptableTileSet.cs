using UnityEngine.Tilemaps;

namespace Room
{
    internal interface IWallScriptableTileSet
    {
        Tile DownLeftInCorner { get; }
        Tile DownLeftOutCorner { get; }
        Tile DownRightInCorner { get; }
        Tile DownRightOutCorner { get; }
        Tile DownWall { get; }
        Tile Full { get; }
        Tile LeftWall { get; }
        Tile RightWall { get; }
        Tile UpLeftInCorner { get; }
        Tile UpLeftOutCorner { get; }
        Tile UpRightInCorner { get; }
        Tile UpRightOutCorner { get; }
        Tile UpWall { get; }
    }
}