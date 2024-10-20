// ********************************************************************************
// @author: Starry Sky
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2024/10/20 15:10
// @version: 1.0
// @description:
// ********************************************************************************

using System;
using UnityEngine;

namespace Sunflower
{
    public class Sun : MonoBehaviour
    {
        public float duration;          // 太阳销毁时间

        private void OnEnable()
        {
            Destroy(gameObject, duration);
        }
    }
}
