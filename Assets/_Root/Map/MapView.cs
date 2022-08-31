using Abstractions.Map;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Map
{
    internal sealed class MapView : MonoBehaviour, IMapView
    {
        [SerializeField] private Tilemap _wallsTileMap;
        [SerializeField] private Tilemap _floorTileMap;
        [SerializeField] private Tilemap _doorsTileMap;

        public Tilemap WallsTileMap { get; }
        public Tilemap FloorTileMap { get; }
        public Tilemap DoorsTileMap { get; }
    }
}
