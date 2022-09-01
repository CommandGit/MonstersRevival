using Abstractions.Map;
using Abstractions.Room;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Room
{
    internal sealed class RoomInstantiator : IRoomInstantiator
    {
        private void InstantialeFloor(Tilemap tileMap, IRoomModel roomModel, IRoomTileSet roomTileSet, Vector2Int offset)
        {
            for (int x = 0; x < roomModel.Width; x++)
            {
                for (int y = 0; y < roomModel.Height; y++)
                {
                    FloorType floorType = roomModel.FloorMap[x, y];
                    if (floorType != FloorType.None)
                    {
                        Vector3Int position = new Vector3Int(x + offset.x, y + offset.y);
                        Tile tile = roomTileSet.GetTile(floorType);
                        tileMap.SetTile(position, tile);
                    }
                }
            }
        }

        private void InstantialeWalls(Tilemap tileMap, IRoomModel roomModel, IRoomTileSet roomTileSet, Vector2Int offset)
        {
            for (int x = 0; x < roomModel.Width; x++)
            {
                for (int y = 0; y < roomModel.Height; y++)
                {
                    WallType wallType = roomModel.WallMap[x, y];
                    if (wallType != WallType.None)
                    {
                        Vector3Int position = new Vector3Int(x + offset.x, y + offset.y);
                        Tile tile = roomTileSet.GetTile(wallType);
                        tileMap.SetTile(position, tile);
                    }
                }
            }
        }

        private void InstantialeDoors(Tilemap tileMap, IRoomModel roomModel, IRoomTileSet roomTileSet, Vector2Int offset)
        {
            if (roomModel.IsWayUp)
            {
                Vector3Int position = new Vector3Int(roomModel.UpDoorPosition + offset.x, roomModel.Height - 1 + offset.y);
                Tile tile = roomTileSet.GetTile(DoorType.Up);
                tileMap.SetTile(position, tile);
            }
            if (roomModel.IsWayDown)
            {
                Vector3Int position = new Vector3Int(roomModel.DownDoorPosition + offset.x, 0 + offset.y);
                Tile tile = roomTileSet.GetTile(DoorType.Down);
                tileMap.SetTile(position, tile);
            }
            if (roomModel.IsWayLeft)
            {
                Vector3Int position = new Vector3Int(0 + offset.x, roomModel.LeftDoorPosition + offset.y);
                Tile tile = roomTileSet.GetTile(DoorType.Left);
                tileMap.SetTile(position, tile);
            }
            if (roomModel.IsWayRight)
            {
                Vector3Int position = new Vector3Int(roomModel.Width - 1 + offset.x, roomModel.RightDoorPosition + offset.y);
                Tile tile = roomTileSet.GetTile(DoorType.Right);
                tileMap.SetTile(position, tile);
            }
        }

        public void Instantiate(IMapView mapView, IRoomModel roomModel, IRoomTileSet roomTileSet, Vector2Int offset)
        {
            InstantialeFloor(mapView.FloorTileMap, roomModel, roomTileSet, offset);
            InstantialeWalls(mapView.WallsTileMap, roomModel, roomTileSet, offset);
            InstantialeDoors(mapView.DoorsTileMap, roomModel, roomTileSet, offset);
        }
    }
}

