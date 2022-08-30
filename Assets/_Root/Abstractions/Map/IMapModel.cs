using Abstractions.Room;
using UnityEngine;

namespace Abstractions.Map
{
    internal interface IMapModel
    {
        public IMapModelSettings MapModelSettings { get; }
        public int Width { get; }
        public int Height { get; }
        public IRoomModel[,] RoomModels { get; }

        public void SetRoomModel(Vector2Int position, IRoomModel roomModel);

        public IRoomModel GetRoomModel(Vector2Int position);
    }
}

