// ********************************************************************************
// @author: Starry Sky
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2024/10/20 15:10
// @version: 1.0
// @description:
// ********************************************************************************

using UnityEngine;
using Random = UnityEngine.Random;

namespace Plants.Sunflower
{
    public class Sunflower : Plant
    {
        public float readyTime;                 // 太阳生产准备时间
        public GameObject sunPre;               // 太阳预制体
        
        private Animator _animator;             // 动画控制器
        private float _timer;                   // 计时器

        private void Start()
        {
            _animator = GetComponent<Animator>();
            _timer = 0;
        }

        private void Update()
        {
            if (!_isPlanted) return;
            _timer += Time.deltaTime;
            if (_timer >= readyTime)
            {
                _animator.SetBool("Ready", true);
            }
        }

        public void BornSunOver()
        {
            BornSun();
            _timer = 0;
            _animator.SetBool("Ready", false);
        }

        private void BornSun()
        {
            GameObject sunNew = Instantiate(sunPre, transform.position, Quaternion.identity);
            var randomTag = Random.Range(1, 3);
            float randomX;
            float randomY;
            switch (randomTag)
            {
                // 左侧
                case 1:
                    randomX = Random.Range(transform.position.x - 30, transform.position.x - 20);
                    break;
                // 右侧
                case 2:
                    randomX = Random.Range(transform.position.x + 20, transform.position.x + 30);
                    break;
                default:
                    randomX = 0;
                    break;
            }

            randomY = Random.Range(transform.position.y - 20, transform.position.y + 20);
            sunNew.transform.position = new Vector2(randomX, randomY);
        }
    }
}
