using Abstractions.Room;
using UnityEngine;

namespace Room
{
    internal sealed class RoomModelFactory : IRoomModelFactory
    {
        public IRoomModel GetNew(int id, IRoomModelSettings roomModelSettings)
        {
            RoomModel roomModel = new RoomModel(id, roomModelSettings);
            return roomModel;
        }

        public void GenerateWalls(IRoomModel roomModel)
        {
            for (int x = 0; x < roomModel.Width; x++)
            {
                if (roomModel.IsDoorDown(x))
                {
                    roomModel.WallMap[x, 0] = WallType.None;
                }
                else
                {
                    roomModel.WallMap[x, 0] = WallType.Full;
                }

                if (roomModel.IsDoorUp(x))
                {
                    roomModel.WallMap[x, roomModel.Height - 1] = WallType.None;
                }
                else
                {
                    roomModel.WallMap[x, roomModel.Height - 1] = WallType.Full;
                }
            }
            for (int y = 0; y < roomModel.Height; y++)
            {
                if (roomModel.IsDoorLeft(y))
                {
                    roomModel.WallMap[0, y] = WallType.None;
                }
                else
                {
                    roomModel.WallMap[0, y] = WallType.Full;
                }

                if (roomModel.IsDoorRight(y))
                {
                    roomModel.WallMap[roomModel.Width - 1, y] = WallType.None;
                }
                else
                {
                    roomModel.WallMap[roomModel.Width - 1, y] = WallType.Full;
                }
            }
            for (int x = 0; x < roomModel.Width; x++)
            {
                for (int y = 0; y < roomModel.Height; y++)
                {
                    if (!roomModel.IsWall(new Vector2Int(x, y))) continue;
                    bool upWall = roomModel.IsWall(new Vector2Int(x, y + 1));
                    bool downWall = roomModel.IsWall(new Vector2Int(x, y - 1));
                    bool leftWall = roomModel.IsWall(new Vector2Int(x - 1, y));
                    bool rightWall = roomModel.IsWall(new Vector2Int(x + 1, y));
                    if (upWall && downWall && leftWall && rightWall) roomModel.WallMap[x, y] = WallType.Full;
                    if (upWall && downWall && leftWall && !rightWall) roomModel.WallMap[x, y] = WallType.RightWall;
                    if (upWall && downWall && !leftWall && rightWall) roomModel.WallMap[x, y] = WallType.LeftWall;
                    if (upWall && downWall && !leftWall && !rightWall) roomModel.WallMap[x, y] = WallType.Full;
                    if (upWall && !downWall && leftWall && rightWall) roomModel.WallMap[x, y] = WallType.DownWall;
                    if (upWall && !downWall && leftWall && !rightWall) roomModel.WallMap[x, y] = WallType.UpLeftInCorner;
                    if (upWall && !downWall && !leftWall && rightWall) roomModel.WallMap[x, y] = WallType.UpRightInCorner;
                    if (upWall && !downWall && !leftWall && !rightWall) roomModel.WallMap[x, y] = WallType.Full;
                    if (!upWall && downWall && leftWall && rightWall) roomModel.WallMap[x, y] = WallType.DownWall;
                    if (!upWall && downWall && leftWall && !rightWall) roomModel.WallMap[x, y] = WallType.DownLeftInCorner;
                    if (!upWall && downWall && !leftWall && rightWall) roomModel.WallMap[x, y] = WallType.DownRightInCorner;
                    if (!upWall && downWall && !leftWall && !rightWall) roomModel.WallMap[x, y] = WallType.Full;
                    if (!upWall && !downWall && leftWall && rightWall) roomModel.WallMap[x, y] = WallType.Full;
                    if (!upWall && !downWall && leftWall && !rightWall) roomModel.WallMap[x, y] = WallType.Full;
                    if (!upWall && !downWall && !leftWall && rightWall) roomModel.WallMap[x, y] = WallType.Full;
                    if (!upWall && !downWall && !leftWall && !rightWall) roomModel.WallMap[x, y] = WallType.Full;
                }
            }
            if (roomModel.WallMap[0, 0] == WallType.Full) roomModel.WallMap[0, 0] = WallType.DownLeftOutCorner;
            if (roomModel.WallMap[roomModel.Width - 1, 0] == WallType.Full) roomModel.WallMap[0, 0] = WallType.DownRightOutCorner;
            if (roomModel.WallMap[0, roomModel.Height - 1] == WallType.Full) roomModel.WallMap[0, 0] = WallType.UpLeftOutCorner;
            if (roomModel.WallMap[roomModel.Width - 1, roomModel.Height - 1] == WallType.Full) roomModel.WallMap[0, 0] = WallType.UpRightOutCorner;
        }

        public void GenerateFloor(IRoomModel roomModel)
        {
            for (int x = 0; x < roomModel.Width; x++)
            {
                for (int y = 0; y < roomModel.Height; y++)
                {
                    if (roomModel.IsWall(new Vector2Int(x, y)))
                    {
                        roomModel.FloorMap[x, y] = FloorType.None;
                    }
                    else
                    {
                        roomModel.FloorMap[x, y] = FloorType.Full;
                    }
                }
            }
        }
    }
}

