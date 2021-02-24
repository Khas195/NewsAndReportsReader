using System.Collections.Generic;
using System;
using NaughtyAttributes;

[Serializable]
public class GameData
{
    [ReadOnly]
    public string version = "";
    [ReadOnly]
    public string turnNumber = "0";
    public string saveName = "";
    public List<SaveData> saveDatas = new List<SaveData>();


    public void Clear()
    {
        version = "";
        for (int i = 0; i < saveDatas.Count; i++)
        {
            saveDatas[i].dataValue = "";
        }
    }
    public bool HasEmptyValue()
    {
        for (int i = 0; i < saveDatas.Count; i++)
        {
            if (saveDatas[i].dataValue != "")
            {
                return false;
            }
        }
        return true;
    }
}
