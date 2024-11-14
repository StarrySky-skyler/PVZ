// ********************************************************************************
// @author: Starry Sky
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2024/10/20 15:10
// @version: 1.0
// @description:
// ********************************************************************************

using System;
using UnityEngine;
using DG.Tweening;
using Managers;

namespace Plants.Sunflower
{
    public class Sun : MonoBehaviour
    {
        public float duration;          // 太阳销毁时间

        private Vector3 _startScale;
        private Vector3 _targetScale;
        private float _timer;
        private bool _createdAnimation = false;
        
        private void Update()
        {
            _timer += Time.deltaTime;
            if (_timer >= duration && !_createdAnimation)
            {
                // 创建销毁动画
                Sequence sequence = DOTween.Sequence();
                sequence.Append(transform.DOScale(_startScale, 0.3f));
                sequence.AppendCallback(() => Destroy(gameObject));
                _createdAnimation = true;
            }
        }

        private void OnEnable()
        {
            // 阳关产出的缩放动画
            _startScale = new Vector3(0.5F, 0.5F, 0.5F);
            _targetScale = Vector3.one;
            transform.localScale = _startScale;
            transform.DOScale(_targetScale, 0.3F);
            //Destroy(gameObject, duration);
        }

        private void OnMouseDown()
        {
            // 点击后，增加阳光数量
            GameManager.instance.ChangeSunNum(25);
            // TODO：飞到太阳 UI 上，然后销毁
            Destroy(gameObject);
        }
    }
}
