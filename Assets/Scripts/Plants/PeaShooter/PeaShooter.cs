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
    public class PeaShooter : Plant
    {
        public float shootInterval;        // 射击间隔
        public GameObject bulletPre;        // 子弹预制体

        private float _timer;
        private Transform _bulletSpawnPos;

        private void Start()
        {
            _bulletSpawnPos = transform.Find("BulletPos").GetComponent<Transform>();
        }

        private void Update()
        {
            if (!_isPlanted) return;
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