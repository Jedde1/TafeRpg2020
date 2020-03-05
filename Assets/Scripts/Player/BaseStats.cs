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
            public float maxValue;
            public float curValue;
            public float regenValue;
            public Image displayImage;
        }
        #endregion
        #region Variables
        [Header("Character Data")]
        public new string name;
        public LifeForceStatus[] characterResources = new LifeForceStatus[3];
        public StatBlock[] characterStats = new StatBlock[6];
        [Header("Character Level Info")]
        public int level = 0;
        public float currentExp, neededExp, maxExp;
        public Transform checkPoint;

        [Header("Death")]
        public Image damageImage;
        public Image deathImage;
        public Text deathText;
        public AudioClip deathClip;
        public AudioSource playersAudio;

        public float flashSpeed;
        public Color flashColour = new Color(1, 0, 0, 0.2f);
        public static bool isDead;
        public bool damaged;
        public bool canHeal;
        public float healTimer;
        #endregion

        private void Update()
        {
#if UNITY_EDITOR
            if (Input.GetKeyDown(KeyCode.Backspace))
            {
                DamagePlayer(25);
            }
#endif
            #region Health, Stam, Man
            for (int i = 0; i < characterResources.Length; i++)
            {
                characterResources[i].displayImage.fillAmount = Mathf.Clamp01(characterResources[i].curValue / characterResources[i].maxValue);
            }
            #endregion
            #region Damage Flash
            if (damaged && !isDead)
            {
                damageImage.color = flashColour;
                damaged = false;
            }
            else if (damageImage.color.a > 0)
            {
                damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
            }
            #endregion
            if (!canHeal)
            {
                healTimer += Time.deltaTime;
                if (healTimer >= 5)
                {
                    canHeal = true;
                }
            }
        }

        private void LateUpdate()
        {
            if (characterResources[0].curValue <= 0 && !isDead)
            {
                //Death Function
                Death();
            }
            //Healing
            if (canHeal && characterResources[0].curValue < characterResources[0].maxValue && characterResources[0].curValue > 0)
            {
                HealOverTime();
            }
        }
        #region Death & Respawn
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
            characterResources[0].curValue = characterResources[0].maxValue;
            //Load Positon

            //Revive
            deathImage.GetComponent<Animator>().SetTrigger("Respawn");
        }
        #endregion

        public void DamagePlayer(float damage)
        {
            //Aplies damage to player from world
            damaged = true;
            characterResources[0].curValue -= damage;
            //Unable to heal
            canHeal = false;
            //Reset heal Timer
            healTimer = 0;
        }
        public void HealOverTime()
        {
            characterResources[0].curValue += Time.deltaTime * (characterResources[0].regenValue/*Maybe * by Con*/);
        }
    }
}

