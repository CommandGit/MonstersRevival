using Abstractions.Room;

namespace Abstractions.Map
{
    internal interface IMapModelSettings
    {
        public int RoomsCount { get; }
        public IRoomModelSettings RoomModelSettings { get; }
    }
}

