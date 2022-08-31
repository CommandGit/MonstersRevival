using Abstractions.Room;
using System.Collections.Generic;
using UnityEngine.Tilemaps;

namespace Room
{
    internal sealed class RoomTileSet : IRoomTileSet
    {
        private Dictionary<WallType, Tile> _wallTiles;
        private Dictionary<DoorType, Tile> _doorTiles;
        private Dictionary<FloorType, Tile> _floorTiles;

        public RoomTileSet()
        {
            _wallTiles = new Dictionary<WallType, Tile>();
            _doorTiles = new Dictionary<DoorType, Tile>();
            _floorTiles = new Dictionary<FloorType, Tile>();
        }

        public Tile GetTile(WallType wallType)
        {
            if (_wallTiles.TryGetValue(wallType, out Tile value))
            {
                return value;
            }
            else
            {
                return null;
            }
        }

        public Tile GetTile(FloorType floorType)
        {
            if (_floorTiles.TryGetValue(floorType, out Tile value))
            {
                return value;
            }
            else
            {
                return null;
            }
        }

        public Tile GetTile(DoorType doorType)
        {
            if (_doorTiles.TryGetValue(doorType, out Tile value))
            {
                return value;
            }
            else
            {
                return null;
            }
        }

        public void SetTile(WallType wallType, Tile tile)
        {
            if (_wallTiles.ContainsKey(wallType))
            {
                _wallTiles[wallType] = tile;
            }
            else
            {
                _wallTiles.Add(wallType, tile);
            }
        }

        public void SetTile(FloorType floorType, Tile tile)
        {
            if (_floorTiles.ContainsKey(floorType))
            {
                _floorTiles[floorType] = tile;
            }
            else
            {
                _floorTiles.Add(floorType, tile);
            }
        }

        public void SetTile(DoorType doorType, Tile tile)
        {
            if (_doorTiles.ContainsKey(doorType))
            {
                _doorTiles[doorType] = tile;
            }
            else
            {
                _doorTiles.Add(doorType, tile);
            }
        }
    }
}
