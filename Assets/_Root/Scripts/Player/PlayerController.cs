using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MonstersRevival.Configs;
using MonstersRevival.Utils;
using MonstersRevival.View;
using Unity.VisualScripting;

namespace MonstersRevival.Player
{
    public class PlayerController 
    {
        private Vector3 _leftScale = new Vector3(-1, 1, 1);
        private Vector3 _rightScale = new Vector3(1, 1, 1);
        private float _xVelosity;
        private bool _doJump;
        private float _xAxisInput;

        private CharacterObjectConfig _playerObjectConfig;
        private LevelObjectView _view;
        private ContactPooler _contactPooler;


        public PlayerController(CharacterObjectConfig playerObjectConfig, LevelObjectView view)
        {
            _playerObjectConfig = playerObjectConfig;
            _contactPooler = new ContactPooler(_view._collider);
            _view = view;
        }

        public void Update()
        {
            _contactPooler.Update();
            _doJump = Input.GetAxis("Vertical") > 0;
            _xAxisInput = Input.GetAxis("Horizontal");
            bool Move = Mathf.Abs(_xAxisInput) > _playerObjectConfig.movingTresh;

            if (Move)
            {
                MoveTowards();
            }
            if (_contactPooler.IsGrounded)
            {

                if (_doJump && _view._rb.velocity.y <= _playerObjectConfig.jumpTresh)
                {
                        _view._rb.AddForce(Vector2.up * _playerObjectConfig.jumpForce, ForceMode2D.Impulse);
                }
            }
        }
        private void MoveTowards()
        {
            _xVelosity = Time.fixedDeltaTime * _playerObjectConfig.speed * (_xAxisInput < 0 ? -1 : 1);
            _view._rb.velocity = _view._rb.velocity.Change(x: _xVelosity);
            _view._transform.localScale = (_xAxisInput < 0 ? _leftScale : _rightScale);
        }
    }
}

