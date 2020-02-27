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

        [Header("Death")]
        public Image damageImage;
        public Image deathImage;
        public Text deathText;
        public AudioClip deathClip;
        public AudioSource playersAudio;

        public float flashSpeed;
        public Color flashColour = new Color(1,0,0,0.2f);
        public static bool isDead;
#if UNITY_EDITOR
        //REMOVE LATER
        public bool damaged;
#endif
#endregion

        private void Update()
        {
#if UNITY_EDITOR
            if (Input.GetKeyDown(KeyCode.Backspace))
            {
                damaged = true;
                characterStatus[0].curValue -= 25;
            }
#endif
            for (int i = 0; i < characterStatus.Length; i++)
            {
                characterStatus[i].displayImage.fillAmount = Mathf.Clamp01(characterStatus[i].curValue / characterStatus[i].maxValue);
            }            
        }

        private void LateUpdate()
        {
            if(characterStatus[0].curValue <= 0 && !isDead)
            {
                //Death Function
                Death();

            }
        }
        void Death()
        {
            //Set the death flag to dead and clear existing Text if text isnt blank
            isDead = true;
            deathText.text = "";
            //Set the Audio to play our Death Clip
            playersAudio.clip = deathClip;
            playersAudio.Play();
            //Trigger the animation
            deathImage.GetComponent<Animator>().SetTrigger("isDead");
            //2-Death Text
            Invoke("DeathText", 2f);
            //6-Revive Text
            Invoke("ReviveText", 6f);
            //9-Respawn Function
            Invoke("Revive", 9f);
        }
        void DeathText()
        {
            deathText.text = "YOU DIED";
        }
        void ReviveText()
        {
            deathText.text = "HAHA GET GOOD";
        }
        void Revive()
        {
            //Reset Everything
            deathText.text = "";
            isDead = false;
            characterStatus[0].curValue = characterStatus[0].maxValue;
            //Load Positon

            //Revive
            deathImage.GetComponent<Animator>().SetTrigger("Respawn");
        }
    }
}

