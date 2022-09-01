using UnityEngine.Tilemaps;

namespace Abstractions.Map
{
    internal interface IMapView
    {
        public Tilemap WallsTileMap { get; }
        public Tilemap FloorTileMap { get; }
        public Tilemap DoorsTileMap { get; }
    }
}

