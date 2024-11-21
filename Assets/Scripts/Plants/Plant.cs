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
        protected bool _isPlanted;        // 是否种植
        protected BoxCollider2D _collider;

        private void Awake()
        {
            CurrentHealth = maxHealth;
            _collider = GetComponent<BoxCollider2D>();
            _collider.enabled = false;
        }

        /// <summary>
        /// 改变生命值
        /// </summary>
        /// <param name="damage">伤害</param>
        /// <returns></returns>
        public virtual float ChangeHealth(float damage)
        {
            CurrentHealth = Mathf.Clamp(CurrentHealth - damage, 0, maxHealth);
            if (CurrentHealth <= 0)
            {
                Destroy(gameObject);
            }
            return CurrentHealth;
        }

        /// <summary>
        /// 设置种植状态
        /// </summary>
        /// <returns></returns>
        public void SetPlanted()
        {
            _isPlanted = true;
            _collider.enabled = true;
        }
    }
}
