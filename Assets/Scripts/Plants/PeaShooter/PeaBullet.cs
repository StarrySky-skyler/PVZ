// ********************************************************************************
// @author: Starry Sky
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2024/10/20 14:10
// @version: 1.0
// @description:
// ********************************************************************************

using System;
using UnityEngine;
using Zombies;

namespace Plants.PeaShooter
{
    public class PeaBullet : MonoBehaviour
    {
        public Vector3 direction;       // 子弹朝向
        public float speed;     // 子弹速度
        public float damage = 15f;        // 子弹伤害

        private void Update()
        {
            transform.position += speed * Time.deltaTime * direction;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            // 如果子弹碰到墙，销毁子弹
            if (other.CompareTag("Wall"))
            {
                Destroy(gameObject);
            }
            else if (other.CompareTag("Zombie"))
            {
                other.GetComponent<ZombieNormal>().ChangeHealth(-damage);
                Destroy(gameObject);
            }
        }
    }
}
