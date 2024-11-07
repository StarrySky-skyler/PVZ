// ********************************************************************************
// @author: Starry Sky
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2024/10/20 14:10
// @version: 1.0
// @description:
// ********************************************************************************

using UnityEngine;

namespace Plants.PeaShooter
{
    public class PeaBullet : MonoBehaviour
    {
        public Vector3 direction;               // 子弹朝向
        public float speed;                     // 子弹速度

        private void Update()
        {
            transform.position += speed * Time.deltaTime * direction;
        }
    }
}
