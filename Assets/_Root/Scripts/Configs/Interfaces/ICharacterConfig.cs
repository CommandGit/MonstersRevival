using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MonstersRevival.Configs
{
    public interface ICharacterConfig 
    {
        public float health { get; }
        public float maxHealth { get; }
        public float minHealth { get; }
        public float speed { get; }
        public int force { get; }
        public float jumpForce { get; }
        public float movingTresh { get; }
        public float jumpTresh { get; }
    }
}
