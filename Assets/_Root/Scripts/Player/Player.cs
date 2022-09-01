using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MonstersRevival.Configs;

namespace MonstersRevival.Player
{
    public class Player : ICharacterConfig
    {
        public float health {get;set;}

        public float maxHealth { get; set; }

        public float minHealth { get; set; }

        public float speed { get; set; }
        public int force { get; set;}
        public float jumpForce { get;set;}
        public float movingTresh { get; set; }

        public float jumpTresh { get; set; }

        public Player(ICharacterConfig config)
        {
            this.health = config.health;
            this.maxHealth = config.maxHealth;
            this.minHealth = config.minHealth;
            this.speed = config.speed;
            this.force = config.force;
            this.jumpForce = config.jumpForce;
            this.movingTresh = config.movingTresh;
            this.jumpTresh = config.jumpTresh;

        }
    }
}
