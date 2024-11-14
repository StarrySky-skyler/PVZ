// ********************************************************************************
// @author: Starry Sky
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2024/10/20 14:10
// @version: 1.0
// @description:
// ********************************************************************************

using System;
using UnityEngine;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;

        public int CurrentSunNum
        {
            get => _currentSunNum;
            private set
            {
                _currentSunNum = value;
                CurrentSunNumChanged?.Invoke();
            }
        }
        public event Action CurrentSunNumChanged;
        
        private int _currentSunNum; // 当前太阳数量

        private void Awake()
        {
            instance = this;
            Application.targetFrameRate = 200;
            CurrentSunNum = 50;
        }

        private void Start()
        {
            
        }

        /// <summary>
        /// 改变太阳数量
        /// </summary>
        /// <param name="num"></param>
        public void ChangeSunNum(int num)
        {
            CurrentSunNum = Mathf.Clamp(CurrentSunNum + num, 0, 9999);
            // TODO：阳光 UI 更新，卡片变灰处理
        }
    }
}
