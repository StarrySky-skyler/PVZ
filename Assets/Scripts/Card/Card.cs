// ********************************************************************************
// @author: Starry Sky
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2024/10/20 16:10
// @version: 1.0
// @description:
// ********************************************************************************

using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Card
{
    public class Card : MonoBehaviour
    {
        public GameObject objectPrefab; // 卡片对应的物体预制件

        // 卡片种植cd
        public float cardCd;

        // 消耗太阳数量
        public int sunCost;
        
        public bool CardReady
        {
            get => _cardReady;
            private set
            {
                _cardReady = value;
                if (_cardReady)
                {
                    CardOnReady?.Invoke();
                    _timer = 0;
                }
            }
        }

        public event Action CardOnReady;

        private GameObject _darkBg;
        private Image _progressBar;
        private GameObject _currentGameObject; // 记录当前卡片对应的物体
        private Image _cardImage;

        private float _timer;
        private bool _cardReady;

        private void Start()
        {
            // 卡片准备完成事件注册
            CardOnReady += UpdateDarkBg;
            _darkBg = transform.Find("Dark").gameObject;
            _progressBar = transform.Find("Progress").GetComponent<Image>();
            _cardImage = GetComponent<Image>();
        }

        private void Update()
        {
            if (!CardReady)
            {
                _timer += Time.deltaTime;
                UpdateProgressBar();
            }
        }

        private void UpdateProgressBar()
        {
            var per = Mathf.Clamp(_timer / cardCd, 0, 1);
            _progressBar.fillAmount = 1 - per;
            CardReady = _progressBar.fillAmount == 0;
        }

        private void UpdateDarkBg()
        {
            // TODO:增加判断条件当前阳光数大于需要阳光数
            if (CardReady)
            {
                _darkBg.SetActive(false);
            }
            else
            {
                _darkBg.SetActive(true);
            }
        }

        // 拖拽开始（鼠标点击的一瞬间）
        public void OnBeginDrag(BaseEventData baseEventData)
        {
            if (!CardReady) return;
            PointerEventData pointerEventData = baseEventData as PointerEventData;
            _cardImage.color = new Color32(255, 255, 255, 135);
            _currentGameObject = Instantiate(objectPrefab);
            _currentGameObject.GetComponent<Animator>().enabled = false;
            _currentGameObject.GetComponent<SpriteRenderer>().sortingOrder = 99;
            _currentGameObject.transform.position = TranslateScreenToWorld(pointerEventData.position);
        }

        // 拖拽中（鼠标点击后一直拖动）
        public void OnDrag(BaseEventData baseEventData)
        {
            if (!CardReady || _currentGameObject == null) return;
            PointerEventData pointerEventData = baseEventData as PointerEventData;
            _currentGameObject.transform.position = TranslateScreenToWorld(pointerEventData.position);
        }

        // 拖拽结束（鼠标松开）
        public void OnEndDrag(BaseEventData baseEventData)
        {
            if (!CardReady || _currentGameObject == null) return;
            _cardImage.color = new Color32(255, 255, 255, 255);
            _currentGameObject.GetComponent<Animator>().enabled = true;
            // 拿到当前鼠标位置的碰撞体
            PointerEventData pointerEventData = baseEventData as PointerEventData;
            Collider2D[] colliders = Physics2D.OverlapPointAll(TranslateScreenToWorld(pointerEventData.position));
            // 遍历碰撞体
            foreach (var collider1 in colliders)
            {
                // 如果为可种植的格子且格子上没有种植植物
                if (collider1.CompareTag("Land") && collider1.transform.childCount == 0)
                {
                    // 设置当前卡片对应的物体的父物体为当前碰撞体
                    _currentGameObject.transform.parent = collider1.transform;
                    _currentGameObject.transform.localPosition = Vector3.zero;
                    _currentGameObject.GetComponent<SpriteRenderer>().sortingOrder = 1;
                    // 重置当前卡片对应的物体，防止重复种植
                    _currentGameObject = null;
                    break;
                }
            }
            
            // 如果没有符合条件的格子，销毁当前卡片对应的物体
            if (_currentGameObject!= null)
            {
                Destroy(_currentGameObject);
                _currentGameObject = null;
            }
        }

        /// <summary>
        /// 将屏幕坐标转换为世界坐标
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public static Vector3 TranslateScreenToWorld(Vector3 position)
        {
            Vector3 cameraTranslatePosition = Camera.main.ScreenToWorldPoint(position);
            return new Vector3(cameraTranslatePosition.x, cameraTranslatePosition.y, 0);
        }
    }
}
