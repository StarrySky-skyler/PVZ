// ********************************************************************************
// @author: Starry Sky
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2024/10/20 14:10
// @version: 1.0
// @description:
// ********************************************************************************

using UnityEngine;
using UnityEngine.Serialization;

namespace Plants.PeaShooter
{
    public class PeaShooter : MonoBehaviour
    {
        public float maxHealth = 100f;     // 生命值
        public float shootInterval;        // 射击间隔
        public GameObject bulletPre;        // 子弹预制体

        private float _timer;
        private Transform _bulletSpawnPos;
        private float _currentHealth;       // 当前生命值

        private void Start()
        {
            _bulletSpawnPos = transform.Find("BulletPos").GetComponent<Transform>();
            _currentHealth = maxHealth;
        }

        private void Update()
        {
            // 如果生命值为0，则销毁该植物
            _timer += Time.deltaTime;
            if (_timer >= shootInterval)
            {
                _timer = 0;
                Instantiate(bulletPre, _bulletSpawnPos.position, Quaternion.identity);
            }
        }

        /// <summary>
        /// 改变生命值
        /// </summary>
        /// <param name="damage">伤害</param>
        /// <returns></returns>
        public float ChangeHealth(float damage)
        {
            _currentHealth = Mathf.Clamp(_currentHealth - damage, 0, maxHealth);
            if (_currentHealth <= 0)
            {
                Destroy(gameObject);
            }
            return _currentHealth;
        }
    }
}