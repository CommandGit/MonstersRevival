using Abstraction.Map;
using Abstraction.Room;
using Abstractions.Map;
using Abstractions.Room;
using Map;
using Room;
using Settings;
using UnityEngine;

namespace Starter
{
    internal sealed class Game
    {
        private IMapModel _mapModel;

        public void Start()
        {
            InitMapModel();
            InstantiateMap();
        }

        private void InitMapModel()
        {
            IMapModelFactory mapModelFactory = new MapModelFactory();
            IRoomModelFactory roomModelfactory = new RoomModelFactory();
            IRoomModelSettings roomModelSettings = new RoomModelSettings(20, 15);
            IMapModelSettings mapModelSettings = new MapModelSettings(20, roomModelSettings);
            _mapModel = mapModelFactory.Generate(mapModelSettings, roomModelfactory);
        }

        private void InstantiateMap()
        {
            IMapView mapView = GameObject.FindObjectOfType<MapView>();
            IRoomInstantiator roomInstantiator = new RoomInstantiator();
            IMapInstantiator mapInstantiator = new MapInstantiator(roomInstantiator);
            IRoomTileSetCreator roomTileSetCreator = new RoomTileSetCreator();
            IFloorScriptableTileSet floorTiles = Resources.Load<FloorScriptableTileSet>(ResourcePathes.ScriptableObjects.FLOOR_TILE_SET);
            IFloorScriptableTileSet startFoorTiles = Resources.Load<FloorScriptableTileSet>(ResourcePathes.ScriptableObjects.START_FLOOR_TILE_SET);
            IFloorScriptableTileSet bossFoorTiles = Resources.Load<FloorScriptableTileSet>(ResourcePathes.ScriptableObjects.BOSS_FLOOR_TILE_SET);
            IWallScriptableTileSet wallTiles = Resources.Load<WallScriptableTileSet>(ResourcePathes.ScriptableObjects.WALL_TILE_SET);
            IDoorScriptableTileSet doorTiles = Resources.Load<DoorScriptableTileSet>(ResourcePathes.ScriptableObjects.DOOR_TILE_SET);
            IRoomTileSet roomTileSet = roomTileSetCreator.Create(floorTiles, wallTiles, doorTiles);
            IRoomTileSet startRoomTileSet = roomTileSetCreator.Create(startFoorTiles, wallTiles, doorTiles);
            IRoomTileSet bossRoomTileSet = roomTileSetCreator.Create(bossFoorTiles, wallTiles, doorTiles);
            mapInstantiator.Instantiate(mapView, _mapModel, roomTileSet, startRoomTileSet, bossRoomTileSet);
        }

        public void Update(float deltaTime)
        {
            Debug.Log("TestUpdate");
        }
    }
}
