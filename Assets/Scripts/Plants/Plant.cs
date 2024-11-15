// ********************************************************************************
// @author: Starry Sky
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2024/11/15 18:11
// @version: 1.0
// @description:
// ********************************************************************************

using System;
using UnityEngine;

namespace Plants
{
    public class Plant : MonoBehaviour
    {
        public float maxHealth = 100f;     // 生命值;
        
        protected float CurrentHealth;       // 当前生命值

        private void Start()
        {
            CurrentHealth = maxHealth;
        }

        /// <summary>
        /// 改变生命值
        /// </summary>
        /// <param name="damage">伤害</param>
        /// <returns></returns>
        public float ChangeHealth(float damage)
        {
            CurrentHealth = Mathf.Clamp(CurrentHealth - damage, 0, maxHealth);
            if (CurrentHealth <= 0)
            {
                Destroy(gameObject);
            }
            return CurrentHealth;
        }
    }
}
