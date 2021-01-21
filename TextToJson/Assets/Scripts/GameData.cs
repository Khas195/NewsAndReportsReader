using System.Collections.Generic;
using System;

[Serializable]
public class GameData
{
    public string version = "";
    public List<TurnData> turnDataList = new List<TurnData>();
    public void Clear()
    {
        version = "";
        for (int i = 0; i < turnDataList.Count; i++)
        {
            for (int j = 0; j < turnDataList[i].saveDatas.Count; j++)
            {
                turnDataList[i].saveDatas[j].dataValue = "";
            }
        }
    }
}
