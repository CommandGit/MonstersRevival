using Abstractions.Map;
using Abstractions.Room;
using Map;
using Room;
using UnityEngine;

namespace Starter
{
    internal sealed class Game
    {
        public void Start()
        {
            TestInitMapModel();
        }

        private void TestInitMapModel()
        {
            IMapModelFactory mapModelFactory = new MapModelFactory();
            IRoomModelFactory roomModelfactory = new RoomModelFactory();
            IRoomModelSettings roomModelSettings = new RoomModelSettings(20, 15);
            IMapModelSettings mapModelSettings = new MapModelSettings(20, roomModelSettings);
            IMapModel mapModel = mapModelFactory.Generate(mapModelSettings, roomModelfactory);
        }

        public void Update(float deltaTime)
        {
            Debug.Log("TestUpdate");
        }
    }
}
