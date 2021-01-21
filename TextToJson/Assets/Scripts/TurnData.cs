using System.Collections.Generic;
using System;

[Serializable]
public class TurnData
{
    public string turnNumber = "0";
    public List<SaveData> saveDatas = new List<SaveData>();

    public bool HasEmptyValue()
    {
        for (int i = 0; i < saveDatas.Count; i++)
        {
            if (saveDatas[i].dataValue == "")
            {
                return true;
            }
        }
        return false;
    }
}
