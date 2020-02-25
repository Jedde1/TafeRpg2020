using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace stats
{
    public class BaseStats : MonoBehaviour
    {
        #region Structs
        [System.Serializable]
        public struct StatBlock
        {
            public string name;
            public int value;
        }

        [System.Serializable]
        public struct LifeForceStatus
        {
            public string name;
            public float curValue;
            public float maxValue;
            public float regenValue;
            public Image displayImage;
        }
        #endregion
        #region Variables
        [Header("Character Data")]
        public new string name;
        public LifeForceStatus[] characterStatus = new LifeForceStatus[3];
        public StatBlock[] characterStats = new StatBlock[6];
        [Header("Character Level Info")]
        public int level = 0;
        public float currentExp, neededExp, maxExp;
        #endregion

        private void Update()
        {
            for (int i = 0; i < characterStatus.Length; i++)
            {
                characterStatus[i].displayImage.fillAmount = Mathf.Clamp01(characterStatus[i].curValue / characterStatus[i].maxValue);
            }            
        }
    }
}

