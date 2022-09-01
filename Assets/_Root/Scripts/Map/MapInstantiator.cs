using Abstraction.Map;
using Abstractions.Map;
using Abstractions.Room;
using UnityEngine;

namespace Map
{
    internal sealed class MapInstantiator : IMapInstantiator
    {
        private IRoomInstantiator _roomInstantiator;
        public MapInstantiator(IRoomInstantiator roomInstantiator)
        {
            _roomInstantiator = roomInstantiator;
        }

        public void Instantiate(IMapView mapView, IMapModel mapModel, IRoomTileSet roomTileSet, IRoomTileSet startRoomTileSet, IRoomTileSet bossRoomTileSet)
        {
            for (int x = 0; x < mapModel.Width; x++)
            {
                for (int y = 0; y < mapModel.Height; y++)
                {
                    IRoomModel roomModel = mapModel.RoomModels[x, y];
                    if (roomModel != null)
                    {
                        Vector2Int offset = new Vector2Int(x * mapModel.MapModelSettings.RoomModelSettings.Width, y * mapModel.MapModelSettings.RoomModelSettings.Height);
                        if (roomModel.Id == 0)
                        {
                            _roomInstantiator.Instantiate(mapView, roomModel, startRoomTileSet, offset);
                        }
                        else if (roomModel.Id == mapModel.MapModelSettings.RoomsCount - 1)
                        {
                            _roomInstantiator.Instantiate(mapView, roomModel, bossRoomTileSet, offset);
                        }
                        else
                        {
                            _roomInstantiator.Instantiate(mapView, roomModel, roomTileSet, offset);
                        }
                        
                    }
                }
            }
        }
    }
}
