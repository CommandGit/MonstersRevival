using UnityEngine;

namespace Starter
{
    internal sealed class Starter : MonoBehaviour
    {
        private Game _game;

        void Start()
        {
            _game = new Game();
            _game.Start();
        }

        void Update()
        {
            _game.Update(Time.deltaTime);
        }
    }
}
