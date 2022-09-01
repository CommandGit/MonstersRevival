using Abstractions.Map;
using Abstractions.Room;
using UnityEngine;

namespace Map
{
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
}

