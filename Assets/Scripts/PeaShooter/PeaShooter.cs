// ********************************************************************************
// @author: Starry Sky
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2024/10/20 14:10
// @version: 1.0
// @description:
// ********************************************************************************

using System;
using UnityEngine;

namespace PeaShooter
{
    public class PeaShooter : MonoBehaviour
    {
        public float interval;
        public GameObject bulletPre;

        private float _timer;
        private Transform _bulletSpawnPos;

        private void Start()
        {
            _bulletSpawnPos = transform.Find("BulletPos").GetComponent<Transform>();
        }

        private void Update()
        {
            _timer += Time.deltaTime;
            if (_timer >= interval)
            {
                _timer = 0;
                Instantiate(bulletPre, _bulletSpawnPos.position, Quaternion.identity);
            }
        }
    }
}