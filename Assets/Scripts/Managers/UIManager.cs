// ********************************************************************************
// @author: Starry Sky
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2024/11/13 21:11
// @version: 1.0
// @description:
// ********************************************************************************

using System;
using UnityEngine;
using UnityEngine.UI;

namespace Managers
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager instance;
        
        public Text sunNumText;     // 阳光数量文本

        private void Awake()
        {
            instance = this;
            GameManager.instance.CurrentSunNumChanged += UpdateSunNumText;
        }

        private void Start()
        {
            UpdateSunNumText();
        }

        private void UpdateSunNumText()
        {
            sunNumText.text = GameManager.instance.CurrentSunNum.ToString();
        }
    }
}
