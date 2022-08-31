using UnityEngine;
using UnityEngine.Tilemaps;

namespace Room
{
    [CreateAssetMenu(fileName = nameof(WallScriptableTileSet), menuName = "ScriptableObjects/" + nameof(WallScriptableTileSet))]
    internal sealed class WallScriptableTileSet : ScriptableObject, IWallScriptableTileSet
    {
        [SerializeField] private Tile _full;
        [SerializeField] private Tile _upWall;
        [SerializeField] private Tile _downWall;
        [SerializeField] private Tile _leftWall;
        [SerializeField] private Tile _rightWall;
        [SerializeField] private Tile _upLeftOutCorner;
        [SerializeField] private Tile _upRightOutCorner;
        [SerializeField] private Tile _downLeftOutCorner;
        [SerializeField] private Tile _downRightOutCorner;
        [SerializeField] private Tile _upLeftInCorner;
        [SerializeField] private Tile _upRightInCorner;
        [SerializeField] private Tile _downLeftInCorner;
        [SerializeField] private Tile _downRightInCorner;

        public Tile Full => _full;
        public Tile UpWall => _upWall;
        public Tile DownWall => _downWall;
        public Tile LeftWall => _leftWall;
        public Tile RightWall => _rightWall;
        public Tile UpLeftOutCorner => _upLeftOutCorner;
        public Tile UpRightOutCorner => _upRightOutCorner;
        public Tile DownLeftOutCorner => _downLeftOutCorner;
        public Tile DownRightOutCorner => _downRightOutCorner;
        public Tile UpLeftInCorner => _upLeftInCorner;
        public Tile UpRightInCorner => _upRightInCorner;
        public Tile DownLeftInCorner => _downLeftInCorner;
        public Tile DownRightInCorner => _downRightInCorner;
    }
}
