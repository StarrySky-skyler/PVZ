// ********************************************************************************
// @author: Starry Sky
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2024/11/05 16:11
// @version: 1.0
// @description:
// ********************************************************************************

using System;
using UnityEngine;

namespace Zombies
{
    public class ZombieNormal : MonoBehaviour
    {
        [HideInInspector]
        public Vector3 direction = new Vector3(-1, 0, 0);    // 僵尸移动方向
        
        public float speed;      // 僵尸移动速度
        public float damage;        // 僵尸伤害
        public float damageInterval;    // 僵尸伤害间隔

        private Animator _animator;     // 动画控制器
        private bool _isWalking;        // 是否正在行走
        private float _damageTimer;     // 伤害计时器

        private void Start()
        {
            _isWalking = true;
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {
            Move();
        }

        /// <summary>
        /// 移动
        /// </summary>
        private void Move()
        {
            if (_isWalking)
            {
                // 移动
                transform.position += speed * Time.deltaTime * direction;
                
            }
        }

        // 当前僵尸进入碰撞器
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Plant"))
            {
                // 更改为攻击状态
                _isWalking = false;
                _animator.SetBool("Walk", _isWalking);
            }
        }

        // 当前僵尸碰撞器中
        private void OnTriggerStay2D(Collider2D other)
        {
            if (other.CompareTag("Plant"))
            {
                _damageTimer += Time.deltaTime;
                if (_damageTimer >= damageInterval)
                {
                    // TODO: 对植物造成伤害
                }
            }
        }

        // 当前僵尸碰撞器退出
        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Plant"))
            {
                // 僵尸离开植物 / 植物被消灭
                _isWalking = true;
                _animator.SetBool("Walk", _isWalking);
            }
        }
    }
}
