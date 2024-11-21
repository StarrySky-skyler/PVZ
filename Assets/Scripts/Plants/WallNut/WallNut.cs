// ********************************************************************************
// @author: Starry Sky
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2024/11/19 16:11
// @version: 1.0
// @description:
// ********************************************************************************

using System;
using UnityEngine;

namespace Plants.WallNut
{
    public class WallNut : Plant
    {
        public float crackedHealth;         // 被吃掉一块的生命值
        public float crackedWuwuwuHealth;           // 呜呜呜时的生命值
        
        private Animator _animator;
        private bool _isCracked;            // 是否被吃掉一块
        private bool _isCrackedWuwuwu;      // 是否呜呜呜呜

        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {
            if (!_isPlanted) return;
        }

        public override float ChangeHealth(float damage)
        {
            var newHealth = base.ChangeHealth(damage);
            _isCracked = newHealth <= crackedHealth;
            _isCrackedWuwuwu = newHealth <= crackedWuwuwuHealth;
            _animator.SetBool("IsCrack", _isCracked);
            _animator.SetBool("IsCrackWuwuwu", _isCrackedWuwuwu);
            return newHealth;
        }
    }
}
