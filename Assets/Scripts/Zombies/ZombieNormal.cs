// ********************************************************************************
// @author: Starry Sky
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2024/11/05 16:11
// @version: 1.0
// @description:
// ********************************************************************************

using System;
using Plants;
using Plants.PeaShooter;
using Plants.WallNut;
using UnityEngine;

namespace Zombies
{
    public class ZombieNormal : MonoBehaviour
    {
        public Vector3 direction = new(-1, 0, 0); // 僵尸移动方向

        public float maxHealth = 100; // 僵尸最大生命值
        public float speed; // 僵尸移动速度
        public float damage; // 僵尸伤害
        public float damageInterval; // 僵尸伤害间隔
        public float lostHeadHealth; // 僵尸丢失头部时的生命值

        private Animator _animator; // 动画控制器
        private bool _isWalking; // 是否正在行走 
        private float _damageTimer; // 伤害计时器
        private float _currentHealth; // 当前生命值
        private bool _isDead; // 是否死亡
        private bool _lostHead; // 是否丢失头部
        private GameObject _head; // 僵尸头部

        private void Start()
        {
            _isWalking = true;
            _animator = GetComponent<Animator>();
            _currentHealth = maxHealth;
            _isDead = false;
            _lostHead = false;
            _head = transform.Find("Head").gameObject;
        }

        private void Update()
        {
            if (_isDead) return;
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
            if (_isDead) return;
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
            if (_isDead) return;
            if (other.CompareTag("Plant"))
            {
                _damageTimer += Time.deltaTime;
                if (_damageTimer >= damageInterval)
                {
                    _damageTimer = 0;
                    var plant = other.GetComponent<Plant>();
                    // TODO: 坚果受伤逻辑
                    var newHealth = plant.ChangeHealth(damage);
                    // 如果植物生命值为0，则僵尸回到行走状态
                    if (newHealth <= 0)
                    {
                        _isWalking = true;
                        _animator.SetBool("Walk", _isWalking);
                    }
                }
            }
        }

        // 当前僵尸碰撞器退出
        private void OnTriggerExit2D(Collider2D other)
        {
            if (_isDead) return;
            if (other.CompareTag("Plant"))
            {
                // 僵尸离开植物 / 植物被消灭
                _isWalking = true;
                _animator.SetBool("Walk", _isWalking);
            }
        }

        /// <summary>
        /// 改变僵尸生命值
        /// </summary>
        /// <param name="damages"></param>
        public void ChangeHealth(float damages)
        {
            _currentHealth = Mathf.Clamp(_currentHealth + damages, 0, maxHealth);
            //Debug.Log("僵尸受到伤害，当前生命值：" + _currentHealth);
            // 血量低于 lostHeadHealth 时，僵尸丢失头部
            if (_currentHealth < lostHeadHealth && !_lostHead)
            {
                _lostHead = true;
                _head.SetActive(true);
                _animator.SetBool("LostHead", true);
            }

            if (_currentHealth <= 0)
            {
                _animator.SetTrigger("Die");
                _isDead = true;
            }
        }

        public void DieAniOver()
        {
            _animator.enabled = false;
            Destroy(gameObject);
        }
    }
}
