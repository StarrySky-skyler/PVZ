// ********************************************************************************
// @author: Starry Sky
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2024/11/13 20:11
// @version: 1.0
// @description:
// ********************************************************************************

using UnityEngine;

namespace Zombies
{
    public class ZombieHead : MonoBehaviour
    {
        public void HeadAniOver()
        {
            gameObject.SetActive(false);
        }
    }
}
