using UnityEngine;

namespace Abstractions.Room
{
    internal interface IRoomModel
    {
        public int Id { get; }
        public bool IsWayUp { get; }
        public bool IsWayDown { get; }
        public bool IsWayLeft { get; }
        public bool IsWayRight { get; }
        public int UpDoorPosition { get; }
        public int DownDoorPosition { get; }
        public int LeftDoorPosition { get; }
        public int RightDoorPosition { get; }
        public int Width { get; }
        public int Height { get; }
        public WallType[,] WallMap { get; }
        public FloorType[,] FloorMap { get; }
        public void CreateDoorWayUp(int doorPosition);
        public void CreateDoorWayDown(int doorPosition);
        public void CreateDoorWayLeft(int doorPosition);
        public void CreateDoorWayRight(int doorPosition);
        public bool IsDoorUp(int position);
        public bool IsDoorDown(int position);
        public bool IsDoorLeft(int position);
        public bool IsDoorRight(int position);
        public bool IsWall(Vector2Int position);
    }
}

