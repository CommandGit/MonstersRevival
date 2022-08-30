namespace Abstractions.Room
{
    internal interface IRoomModelFactory
    {
        public IRoomModel GetNew(int id, IRoomModelSettings roomModelSettings);
        public void GenerateWalls(IRoomModel roomModel);
        public void GenerateFloor(IRoomModel roomModel);
    }
}

