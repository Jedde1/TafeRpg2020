using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartEx : MonoBehaviour
{
    //Current Health
    public int curHealth;
    //Max Health
    public int maxHealth;
    //Health per sector
    public int healthPerSector;
    //Heart slots - image
    public List<Image> heartSlot = new List<Image>();
    //sprite groupsing
    public Sprite[] heartSprites = new Sprite[5];
    //Spawn Location
    public Transform heartContainer;
    //prefab
    public GameObject slotPrefab;
    void Start()
    {
        //Add new Sprite to heart slots...Prefab
        for (int i = 0; i < 3; i++)
        {
            Image listObject = Instantiate(slotPrefab, heartContainer).GetComponent<Image>();

            heartSlot.Add(listObject);
        }
        HealthPerSector();
    }
    void HealthPerSector()
    {
        healthPerSector = maxHealth / (heartSlot.Count * 4);
    }
    void UpdateHearts()
    {
        //reference variable starting at 0 for slot checks
        int i = 0;
        //foreach image slot in heartSlots
        foreach (var image in heartSlot)
        {
            //if current health is greater or equal to full for this slot
            //if curHealth is greater or equal to the quater of heart + the set healthPerSector
            if (curHealth >= healthPerSector * 4 + healthPerSector * 4 * i)
            {
                //set slot to 4/4(Full) health
                heartSlot[i].sprite = heartSprites[0];     
            }
            //else if current health is greater or equal to 3/4 for this slot
            else if (curHealth >= healthPerSector * 3 + healthPerSector * 4 * i)
            {
                //Set slot to 3/4 for this slot
                heartSlot[i].sprite = heartSprites[1];
            }
            else if (curHealth >= healthPerSector * 2 + healthPerSector * 4 * i)
            {
                //Set slot to 2/4 for this slot
                heartSlot[i].sprite = heartSprites[2];
            }
            else if (curHealth >= healthPerSector * 1 + healthPerSector * 4 * i)
            {
                //Set slot to 1/4 for this slot
                heartSlot[i].sprite = heartSprites[3];
            }
            //else we are empty so set slot sprite to 0/4
            else
            {
                heartSlot[i].sprite = heartSprites[4];
            }
            //Move to the next slot after checking
            i++;
        }
    }

    void Update()
    {
        UpdateHearts();
    }
}
