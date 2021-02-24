using System;
using NaughtyAttributes;

[Serializable]
public class SaveData
{
    public string key;
    [ReadOnly]
    public string dataValue;
    public string googleFormID = "";
}
