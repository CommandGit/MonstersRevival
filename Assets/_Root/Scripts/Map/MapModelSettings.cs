using Abstractions.Map;
using Abstractions.Room;

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
}

