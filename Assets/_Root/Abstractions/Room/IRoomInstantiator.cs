using Abstractions.Map;
using UnityEngine;

namespace Abstractions.Room
{
    internal interface IRoomInstantiator
    {
        public void Instantiate(IMapView mapView, IRoomModel roomModel, IRoomTileSet roomTileSet, Vector2Int offset);
    }
}

