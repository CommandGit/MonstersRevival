using UnityEngine;
using UnityEngine.Tilemaps;

namespace Room
{
    [CreateAssetMenu(fileName = nameof(FloorScriptableTileSet), menuName = "ScriptableObjects/" + nameof(FloorScriptableTileSet))]
    internal sealed class FloorScriptableTileSet : ScriptableObject, IFloorScriptableTileSet
    {
        [SerializeField] private Tile _full;

        public Tile Full => _full;
    }
}
