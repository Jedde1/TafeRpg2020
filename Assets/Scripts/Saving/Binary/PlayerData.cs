[System.Serializable]
public class PlayerData
{
    //Same variables that are already existing in game but named here so we know which ines we are saving
    public string playerName;
    public int level;
    public string checkPoint;
    public float[] resourceMaxValues = new float[3];
    public float[] resourceCurValues = new float[3];
    public float pX, pY, pZ;
    public float rX, rY, rZ, rW;
    public float currentExp, neededExp, maxExp;

    public PlayerData(stats.BaseStats player)
    {
        playerName = player.name;
        level = player.level;
        checkPoint = player.checkPoint.name;
        for (int i = 0; i < resourceMaxValues.Length; i++)
        {
            resourceCurValues[i] = player.characterResources[i].curValue;
            resourceMaxValues[i] = player.characterResources[i].curValue;         
        }
        //Position
        pX = player.transform.position.x;
        pY = player.transform.position.y;
        pZ = player.transform.position.z;
        //Rotation
        rX = player.transform.rotation.x;
        rY = player.transform.rotation.y;
        rZ = player.transform.rotation.z;
        rW = player.transform.rotation.w;
    }
}
