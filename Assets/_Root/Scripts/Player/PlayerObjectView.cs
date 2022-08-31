using MonstersRevival.Configs;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MonstersRevival.Player
{
    public class PlayerObjectView : MonoBehaviour
    {
        public Transform _transform;
        public SpriteRenderer _spriteRenderer;
        public Collider2D _collider;
        public Rigidbody2D _rb;
        public Action<PlayerObjectView> OnPlayerObjectContact { get; set; }
        [SerializeField] CharacterObjectConfig _config;
        private void OnTriggerEnter2D(Collider2D collision)
        {
            PlayerObjectView playerObject = collision.gameObject.GetComponent<PlayerObjectView>();
            OnPlayerObjectContact?.Invoke(playerObject);
        }
    }
}
