// ********************************************************************************
// @author: Starry Sky
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2024/10/20 16:10
// @version: 1.0
// @description:
// ********************************************************************************

using System;
using UnityEngine;
using UnityEngine.UI;

namespace Card
{
    public class Card : MonoBehaviour
    {
        // 卡片种植cd
        public float cardCd;

        // 消耗太阳数量
        public int sunCost;

        private GameObject _darkBg;
        private Image _progressBar;

        private float _timer;
        private bool _cardReady;

        public bool CardReady
        {
            get => _cardReady;
            private set
            {
                _cardReady = value;
                if (_cardReady)
                {
                    CardOnReady?.Invoke();
                }
            }
        }

        private event Action CardOnReady;

        private void Start()
        {
            _darkBg = transform.Find("Dark").gameObject;
            _progressBar = transform.Find("Progress").GetComponent<Image>();
            // 卡片准备完成事件注册
            CardOnReady += UpdateDarkBg;
        }

        private void Update()
        {
            _timer += Time.deltaTime;
            UpdateProgressBar();
        }

        private void UpdateProgressBar()
        {
            var per = Mathf.Clamp(_timer / cardCd, 0, 1);
            _progressBar.fillAmount = 1 - per;
            _cardReady = _progressBar.fillAmount == 0;
        }

        private void UpdateDarkBg()
        {
            // TODO:增加判断条件当前阳光数大于需要阳光数
            if (_cardReady)
            {
                _darkBg.SetActive(false);
            }
            else
            {
                _darkBg.SetActive(true);
            }
        }
    }
}
