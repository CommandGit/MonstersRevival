using Abstractions.Map;
using Abstractions.Room;
using Extension;
using System.Collections.Generic;
using UnityEngine;

namespace Map
{

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

