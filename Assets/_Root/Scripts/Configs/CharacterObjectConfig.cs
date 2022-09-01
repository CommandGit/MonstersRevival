using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MonstersRevival.Configs
{
    [CreateAssetMenu(fileName = "CharacterObjectCfg", menuName = "Configs/ Character Cfg", order = 1)]
    public class CharacterObjectConfig : ScriptableObject, ICharacterConfig
    {
        [SerializeField, Range(0, 20f)]
        private float _health;

        [SerializeField, Range(0,20f)]
        private float _maxHealth;
        private int _minHealth = 0;
        [SerializeField, Range(0, 20f)]
        private float _speed;
        [SerializeField, Range(0, 10)]
        private int _force;
        [SerializeField, Range(0, 100f)]
        private float _jumpForce;

        private float _movingTresh = 0.1f;
        private float _jumpTresh = 1f;
        public float health { get => _health; }

        public float maxHealth {get => _maxHealth; }

        public float minHealth {get => _minHealth; }

        public float speed {get => _speed; }

        public int force {get => _force; }

        public float jumpForce {get => _jumpForce; }

        public float movingTresh { get => _movingTresh; }
        public float jumpTresh { get => _jumpTresh; }
    }
}
