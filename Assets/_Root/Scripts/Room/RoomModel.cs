using Abstractions.Room;
using UnityEngine;

namespace Room
{
    internal sealed class RoomModel : IRoomModel
    {
        private int _id;
        private bool _isWayUp;
        private bool _isWayDown;
        private bool _isWayLeft;
        private bool _isWayRight;
        public int _upDoorPosition;
        public int _downDoorPosition;
        public int _leftDoorPosition;
        public int _rightDoorPosition;
        public int _width;
        public int _height;
        public WallType[,] _wallMap;
        public FloorType[,] _floorMap;

        public int Id => _id;

        public bool IsWayUp => _isWayUp;

        public bool IsWayDown => _isWayDown;

        public bool IsWayLeft => _isWayLeft;

        public bool IsWayRight => _isWayRight;

        public int UpDoorPosition => _upDoorPosition;

        public int DownDoorPosition => _downDoorPosition;

        public int LeftDoorPosition => _leftDoorPosition;

        public int RightDoorPosition => _rightDoorPosition;
        public int Width => _width;
        public int Height => _height;
        public WallType[,] WallMap => _wallMap;
        public FloorType[,] FloorMap => _floorMap;

        public RoomModel(int id, IRoomModelSettings roomModelSettings)
        {
            _id = id;
            _isWayUp = false;
            _isWayDown = false;
            _isWayLeft = false;
            _isWayRight = false;
            _upDoorPosition = 0;
            _downDoorPosition = 0;
            _leftDoorPosition = 0;
            _rightDoorPosition = 0;
            _width = roomModelSettings.Width;
            _height = roomModelSettings.Height;
        }

        public void CreateDoorWayUp(int doorPosition)
        {
            _isWayUp = true;
            _upDoorPosition = doorPosition;
        }

        public void CreateDoorWayDown(int doorPosition)
        {
            _isWayDown = true;
            _downDoorPosition = doorPosition;
        }

        public void CreateDoorWayLeft(int doorPosition)
        {
            _isWayLeft = true;
            _leftDoorPosition = doorPosition;
        }

        public void CreateDoorWayRight(int doorPosition)
        {
            _isWayRight = true;
            _rightDoorPosition = doorPosition;
        }

        public bool IsDoorUp(int position)
        {
            return (IsWayUp && UpDoorPosition == position);
        }
        public bool IsDoorDown(int position)
        {
            return (IsWayDown && DownDoorPosition == position);
        }
        public bool IsDoorLeft(int position)
        {
            return (IsWayLeft && LeftDoorPosition == position);
        }
        public bool IsDoorRight(int position)
        {
            return (IsWayRight && RightDoorPosition == position);
        }
        public bool IsWall(Vector2Int position)
        {
            if (position.x < 0 || position.x > _width - 1 || position.x < 0 || position.y > _height - 1) return true;
            return WallMap[position.x, position.y] != WallType.None;
        }
    }
}

