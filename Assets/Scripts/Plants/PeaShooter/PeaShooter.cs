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
        [FormerlySerializedAs("interval")]
        public float shootInterval;
        public GameObject bulletPre;

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
    }
}