// ********************************************************************************
// @author: Starry Sky
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2024/10/20 14:10
// @version: 1.0
// @description:
// ********************************************************************************

using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

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
                CurrentSunNumChanged?.Invoke(_currentSunNum);
            }
        }
        public event Action<int> CurrentSunNumChanged;
        public GameObject zombieBornParent;     // 僵尸出生点父对象
        public GameObject zombiePrefab;      // 僵尸预制体
        public float zombieSpawnInterval;       // 僵尸生成间隔时间
        
        private int _currentSunNum; // 当前太阳数量
        private int _zOrderIndex = 0;       // 僵尸z轴排序（解决僵尸重叠问题）

        private void Awake()
        {
            instance = this;
            Application.targetFrameRate = 200;
            CurrentSunNum = 150;
        }

        private void Start()
        {
            StartDelaySpawnZombie();
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

        public void StartDelaySpawnZombie()
        {
            StartCoroutine(DelaySpawnZombie());
        }

        /// <summary>
        /// 协程延迟生成僵尸
        /// </summary>
        /// <returns></returns>
        private IEnumerator DelaySpawnZombie()
        {
            // 等待生成间隔时间
            yield return new WaitForSeconds(zombieSpawnInterval);
            var index = Random.Range(0, 5);
            var zombieLine = zombieBornParent.transform.Find("Born" + index.ToString());
            var zombie = Instantiate(zombiePrefab, zombieLine);
            zombie.transform.localPosition = Vector3.zero;
            zombie.GetComponent<SpriteRenderer>().sortingOrder = _zOrderIndex++;
            // 递归调用自身，循环生成僵尸
            StartCoroutine(DelaySpawnZombie());
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
