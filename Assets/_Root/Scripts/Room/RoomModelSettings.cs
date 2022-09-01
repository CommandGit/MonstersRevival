using Abstractions.Room;

namespace Room
{
    internal sealed class RoomModelSettings : IRoomModelSettings
    {
        private int _width;
        private int _height;

        public int Width => _width;

        public int Height => _height;

        public RoomModelSettings(int width, int height)
        {
            _width = width;
            _height = height;
        }
    }
}

