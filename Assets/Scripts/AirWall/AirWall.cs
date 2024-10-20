// ********************************************************************************
// @author: Starry Sky
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2024/10/20 15:10
// @version: 1.0
// @description:
// ********************************************************************************

using System;
using UnityEngine;

namespace AirWall
{
    public class AirWall : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Bullet"))
            {
                Destroy(other.gameObject);
            }
        }

        private void OnCollisionStay2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Bullet"))
            {
                Destroy(other.gameObject);
            }
        }
    }
}
