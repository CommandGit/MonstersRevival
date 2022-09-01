using Abstractions.Map;
using Abstractions.Room;

namespace Abstraction.Map
{
    internal interface IMapInstantiator
    {
        void Instantiate(IMapView mapView, IMapModel mapModel, IRoomTileSet roomTileSet, IRoomTileSet startRoomTileSet, IRoomTileSet bossRoomTileSet);
    }
}