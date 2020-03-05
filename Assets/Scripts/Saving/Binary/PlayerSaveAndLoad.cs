using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSaveAndLoad : MonoBehaviour
{
    public stats.BaseStats playerStats;

    private void Awake()
    {
        if (!PlayerPrefs.HasKey("Loaded"))
        {
            FirstLoad();
            PlayerPrefs.SetInt("Loaded", 0);
            Save();
        }
        else
        {
            Load();
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F5))
        {
            Save();
        }
    }
    void FirstLoad()
    {
        for (int i = 0; i < playerStats.characterResources.Length; i++)
        {
            playerStats.characterResources[i].maxValue = 100;
            playerStats.characterResources[i].curValue = 100;
            playerStats.transform.position = new Vector3(160,1,160);
            playerStats.transform.rotation = new Quaternion(0,0,0,0);
            Debug.Log("REMEBER CHECKPOINT");
        }
    }
    public void Save()
    {
        PlayerBinary.SavePlayerData(playerStats);
    }
    public void Load()
    {
        PlayerData data = PlayerBinary.LoadPlayerData(playerStats);
        playerStats.name = data.playerName;
        playerStats.checkPoint = GameObject.Find(data.checkPoint).GetComponent<Transform>();
        playerStats.level = data.level;
        for (int i = 0; i < playerStats.characterResources.Length; i++)
        {
            playerStats.characterResources[i].curValue = data.resourceCurValues[i];
            playerStats.characterResources[i].maxValue = data.resourceMaxValues[i];
        }
        playerStats.transform.position = new Vector3(data.pX, data.pY, data.pZ);
        playerStats.transform.rotation = new Quaternion(data.rX, data.rY, data.rZ, data.rW);

        playerStats.currentExp = data.currentExp;
        playerStats.maxExp = data.maxExp;
        playerStats.neededExp = data.neededExp;
    }
    
}
