using Abstraction.Map;
using Abstraction.Room;
using Extension;
using System.Collections.Generic;
using UnityEngine;

namespace Abstraction.Basics
{

}

namespace Abstraction.Room
{
    internal interface IRoomModelSettings
    {
        public int Width { get; }
        public int Height { get; }
    }

    internal enum WallType
    { 
        None,
        Full,
        UpWall,
        DownWall,
        LeftWall,
        RightWall,
        UpLeftOutCorner,
        UpRightOutCorner,
        DownLeftOutCorner,
        DownRightOutCorner,
        UpLeftInCorner,
        UpRightInCorner,
        DownLeftInCorner,
        DownRightInCorner
    }

    internal enum FloorType
    {
        None,
        Full
    }

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

    internal interface IRoomModelFactory
    {
        public IRoomModel GetNew(int id, IRoomModelSettings roomModelSettings);
        public void GenerateWalls(IRoomModel roomModel);
        public void GenerateFloor(IRoomModel roomModel);
    }
}

namespace Abstraction.Map
{
    internal interface IMapModelSettings
    {
        public int RoomsCount { get; }
        public IRoomModelSettings RoomModelSettings { get; }
    }

    internal interface IMapModel
    {
        public IMapModelSettings MapModelSettings { get; }
        public int Width { get; }
        public int Height { get; }
        public IRoomModel[,] RoomModels { get; }

        public void SetRoomModel(Vector2Int position, IRoomModel roomModel);

        public IRoomModel GetRoomModel(Vector2Int position);
    }

    internal interface IMapModelFactory
    {
        public IMapModel Generate(IMapModelSettings mapModelSettings, IRoomModelFactory roomModelFactory);
    }
}

namespace Room
{
    internal sealed class RoomModelSettings : IRoomModelSettings
    {
        private int _width;
        private int _height;

        public int Width => _width;

        public int Height => _height;

        public RoomModelSettings(int width, int height)
        {
            _width = width;
            _height = height;
        }
    }

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

namespace Map
{
    internal sealed class MapModelSettings : IMapModelSettings
    {
        private int _roomsCount;
        private IRoomModelSettings _roomModelSettings;

        public int RoomsCount => _roomsCount;

        public IRoomModelSettings RoomModelSettings => _roomModelSettings;

        public MapModelSettings(int roomsCount, IRoomModelSettings roomModelSettings)
        {
            _roomsCount = roomsCount;
            _roomModelSettings = roomModelSettings;
        }
    }

    internal sealed class MapModel : IMapModel
    {
        private const int DOUBLE_SIZE = 2;
        private IMapModelSettings _mapModelSettings;
        private int _width;
        private int _height;
        private IRoomModel[,] _roomModels;

        public IMapModelSettings MapModelSettings => _mapModelSettings;
        public int Width => _width;

        public int Height => _height;

        public IRoomModel[,] RoomModels => _roomModels;

        public MapModel(IMapModelSettings mapModelSettings)
        {
            _mapModelSettings = mapModelSettings;
            _width = mapModelSettings.RoomsCount * DOUBLE_SIZE;
            _height = mapModelSettings.RoomsCount * DOUBLE_SIZE;
            _roomModels = new IRoomModel[_width, _height];
        }

        public void SetRoomModel(Vector2Int position, IRoomModel roomModel)
        {
            _roomModels[position.x, position.y] = roomModel;
        }

        public IRoomModel GetRoomModel(Vector2Int position)
        {
            return _roomModels[position.x, position.y];
        }

    }

    internal sealed class MapModelFactory : IMapModelFactory
    {
        private void AddNoRoomNextPoint(List<Vector2Int> nextPoints, IMapModel mapModel, Vector2Int position)
        {
            IRoomModel roomModel = mapModel.GetRoomModel(position);
            if (roomModel == null)
            {
                nextPoints.Add(new Vector2Int(position.x, position.y));
            }
        }
        private void AddRoomNextPoint(List<Vector2Int> nextPoints, IMapModel mapModel, Vector2Int position)
        {
            IRoomModel roomModel = mapModel.GetRoomModel(position);
            if (roomModel != null)
            {
                nextPoints.Add(new Vector2Int(position.x, position.y));
            }
        }

        private void AddNoRoomNextPoints(List<Vector2Int> nextPoints, IMapModel mapModel, Vector2Int position)
        {
            AddNoRoomNextPoint(nextPoints, mapModel, new Vector2Int(position.x - 1, position.y));
            AddNoRoomNextPoint(nextPoints, mapModel, new Vector2Int(position.x + 1, position.y));
            AddNoRoomNextPoint(nextPoints, mapModel, new Vector2Int(position.x, position.y - 1));
            AddNoRoomNextPoint(nextPoints, mapModel, new Vector2Int(position.x, position.y + 1));
        }
        private void AddRoomNextPoints(List<Vector2Int> nextPoints, IMapModel mapModel, Vector2Int position)
        {
            AddRoomNextPoint(nextPoints, mapModel, new Vector2Int(position.x - 1, position.y));
            AddRoomNextPoint(nextPoints, mapModel, new Vector2Int(position.x + 1, position.y));
            AddRoomNextPoint(nextPoints, mapModel, new Vector2Int(position.x, position.y - 1));
            AddRoomNextPoint(nextPoints, mapModel, new Vector2Int(position.x, position.y + 1));
        }

        private void ConnectRooms(IMapModel mapModel, Vector2Int firstRoomPosition, Vector2Int secondRoomPosition)
        {
            IRoomModel firstRoomModel = mapModel.GetRoomModel(firstRoomPosition);
            IRoomModel secondRoomModel = mapModel.GetRoomModel(secondRoomPosition);
            int minWidth = Mathf.Min(firstRoomModel.Width, secondRoomModel.Width);
            int minHeight = Mathf.Min(firstRoomModel.Height, secondRoomModel.Height);
            if (firstRoomPosition.x < secondRoomPosition.x)
            {
                int heightDoorPosition = Random.Range(1, minHeight - 1);
                firstRoomModel.CreateDoorWayRight(heightDoorPosition);
                secondRoomModel.CreateDoorWayLeft(heightDoorPosition);
            }
            if (firstRoomPosition.x > secondRoomPosition.x)
            {
                int heightDoorPosition = Random.Range(1, minHeight - 1);
                firstRoomModel.CreateDoorWayLeft(heightDoorPosition);
                secondRoomModel.CreateDoorWayRight(heightDoorPosition);
            }
            if (firstRoomPosition.y < secondRoomPosition.y)
            {
                int widthDoorPosition = Random.Range(1, minWidth - 1);
                firstRoomModel.CreateDoorWayUp(widthDoorPosition);
                secondRoomModel.CreateDoorWayDown(widthDoorPosition);
            }
            if (firstRoomPosition.y > secondRoomPosition.y)
            {
                int widthDoorPosition = Random.Range(1, minWidth - 1);
                firstRoomModel.CreateDoorWayDown(widthDoorPosition);
                secondRoomModel.CreateDoorWayUp(widthDoorPosition);
            }
        }

        private void ConnectRoom(IMapModel mapModel, List<Vector2Int> connectPoints, Vector2Int position)
        {
            connectPoints.Clear();
            AddRoomNextPoints(connectPoints, mapModel, position);
            Vector2Int connectPosition = connectPoints.GetRandom();
            ConnectRooms(mapModel, position, connectPosition);
        }

        public IMapModel Generate(IMapModelSettings mapModelSettings, IRoomModelFactory roomModelFactory)
        {
            IMapModel mapModel = new MapModel(mapModelSettings);

            Vector2Int startPosition = new Vector2Int(mapModelSettings.RoomsCount, mapModelSettings.RoomsCount);
            int currentRoomId = 0;
            List<Vector2Int> nextPoints = new List<Vector2Int>();
            List<Vector2Int> connectPoints = new List<Vector2Int>();

            IRoomModel roomModel = roomModelFactory.GetNew(currentRoomId, mapModelSettings.RoomModelSettings);
            mapModel.SetRoomModel(startPosition, roomModel);
            currentRoomId++;
            AddNoRoomNextPoints(nextPoints, mapModel, startPosition);

            while (currentRoomId < mapModelSettings.RoomsCount)
            {
                Vector2Int nextPosition = nextPoints.GetRandomAndRemove();
                roomModel = roomModelFactory.GetNew(currentRoomId, mapModelSettings.RoomModelSettings);
                mapModel.SetRoomModel(nextPosition, roomModel);
                currentRoomId++;
                AddNoRoomNextPoints(nextPoints, mapModel, nextPosition);
                ConnectRoom(mapModel, connectPoints, nextPosition);
            }

            for (int x = 0; x < mapModel.Width - 1; x++)
            {
                for (int y = 0; y < mapModel.Height - 1; y++)
                {
                    IRoomModel currentRoomModel = mapModel.RoomModels[x, y];
                    if (currentRoomModel == null) continue;
                    roomModelFactory.GenerateWalls(currentRoomModel);
                    roomModelFactory.GenerateFloor(currentRoomModel);
                }
            }

            return mapModel;
        }
    }
}

