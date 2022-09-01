using Abstractions.Room;

namespace Abstractions.Map
{
    internal interface IMapModelFactory
    {
        public IMapModel Generate(IMapModelSettings mapModelSettings, IRoomModelFactory roomModelFactory);
    }
}

