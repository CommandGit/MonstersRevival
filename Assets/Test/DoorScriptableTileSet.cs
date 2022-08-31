using UnityEngine;
using UnityEngine.Tilemaps;

namespace Room
{
    [CreateAssetMenu(fileName = nameof(DoorScriptableTileSet), menuName = "ScriptableObjects/" + nameof(DoorScriptableTileSet))]
    internal sealed class DoorScriptableTileSet : ScriptableObject, IDoorScriptableTileSet
    {
        [SerializeField] private Tile _up;
        [SerializeField] private Tile _down;
        [SerializeField] private Tile _left;
        [SerializeField] private Tile _right;

        public Tile Up => _up;
        public Tile Down => _down;
        public Tile Left => _left;
        public Tile Right => _right;
    }
}
