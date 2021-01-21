using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using System.IO;
using System;
public class SaveDataForGoogleForm
{
    public string version = "404-Unknown";
    public string turnNumber = "404-Unknown";
    public string playerName = "404-Unknown";
    public string budget = "404-Unknown";
    public string publicOpinion = "404-Unknown";
    public string bludishOpinion = "404-Unknown";
    public string economy = "404-Unknown";
    public string sollist = "404-Unknown";
    public string capitalist = "404-Unknown";
    public string malenyevist = "404-Unknown";
    public string democratic = "404-Unknown";
}
public class SuzSavesReader : MonoBehaviour
{
    [SerializeField]
    string path = "";
    [SerializeField]
    string saveName = "";
    // Start is called before the first frame update
    [SerializeField]
    GameData gameData;
    const string BASE_URL = "https://docs.google.com/forms/u/0/d/e/1FAIpQLSc4vRIS5sAyJ6nRYK8wbwqGG9wIMBb50QbTkRPNhNTLQEv_bw/formResponse";

    IEnumerator Post(SaveDataForGoogleForm dataForm)
    {
        WWWForm form = new WWWForm();
        // 1903643271 - Version
        form.AddField("entry.1903643271", dataForm.version);
        // entry.429997597 - name
        form.AddField("entry.429997597", dataForm.playerName);
        // entry.1293977492 - Turn
        form.AddField("entry.1293977492", dataForm.turnNumber);
        // entry.491749872 - Budget
        form.AddField("entry.491749872", dataForm.budget);
        // entry.1536548266 - Public 
        form.AddField("entry.1536548266", dataForm.publicOpinion);
        // entry.1260444725 - bludish
        form.AddField("entry.1260444725", dataForm.bludishOpinion);
        // entry.682927316 - Economy
        form.AddField("entry.682927316", dataForm.economy);
        // entry.69745305 - Sollist
        form.AddField("entry.69745305", dataForm.sollist);
        // entry.1355065117 - capitalist
        form.AddField("entry.1355065117", dataForm.capitalist);
        // entry.1951205263 - malenyevist
        form.AddField("entry.1951205263", dataForm.malenyevist);
        // entry.573333853 - democratic
        form.AddField("entry.573333853", dataForm.democratic);
        byte[] rawData = form.data;
        WWW www = new WWW(BASE_URL, rawData);
        yield return www;
    }
    [Button]
    public void SaveAndUpload()
    {
        SaveAllFilesInPath();
        UploadDataToGoogleSheets();
    }
    [Button]
    public void UploadDataToGoogleSheets()
    {
        for (int i = 0; i < gameData.turnDataList.Count; i++)
        {
            if (gameData.turnDataList[i].HasEmptyValue())
            {
                Debug.Log(("Turn has empty value").Bolden().Colorize(Color.red));
                continue;
            }
            var newSaveData = new SaveDataForGoogleForm();
            newSaveData.turnNumber = gameData.turnDataList[i].turnNumber;
            newSaveData.playerName = saveName;
            newSaveData.version = gameData.version;
            newSaveData.publicOpinion = gameData.turnDataList[i].saveDatas[0].dataValue;
            newSaveData.bludishOpinion = gameData.turnDataList[i].saveDatas[1].dataValue;
            newSaveData.budget = gameData.turnDataList[i].saveDatas[2].dataValue;
            newSaveData.economy = gameData.turnDataList[i].saveDatas[3].dataValue;
            newSaveData.sollist = gameData.turnDataList[i].saveDatas[4].dataValue;
            newSaveData.capitalist = gameData.turnDataList[i].saveDatas[5].dataValue;
            newSaveData.democratic = gameData.turnDataList[i].saveDatas[6].dataValue;
            newSaveData.malenyevist = gameData.turnDataList[i].saveDatas[7].dataValue;
            Debug.Log(("Turn saved: " + newSaveData.turnNumber).Bolden().Colorize(Color.green));
            StartCoroutine(Post(newSaveData));
        }
    }

    [Button]
    public void SaveAllFilesInPath()
    {
        gameData.Clear();
        List<string> suzeSaves = new List<string>();
        GetAllSuzeFilesInDirectory(path, ref suzeSaves);
        Debug.Log("Found " + suzeSaves.Count + " suze saves");
        for (int i = 0; i < suzeSaves.Count; i++)
        {
            StreamReader sr = new StreamReader(suzeSaves[i]);
            string save = sr.ReadToEnd();
            string turnValue = GetValue(save, "\"turnNo\": ");
            gameData.version = GetValue(save, "\"currentSuzerainVersion\": ");
            for (int turnIndex = 0; turnIndex < gameData.turnDataList.Count; turnIndex++)
            {
                var turnToAssess = gameData.turnDataList[turnIndex];
                if (turnToAssess.turnNumber.Equals(turnValue.Trim()))
                {
                    Debug.Log(("Reading Turn " + turnToAssess.turnNumber).Bolden().Colorize(Color.green));
                    for (int dataIndex = 0; dataIndex < turnToAssess.saveDatas.Count; dataIndex++)
                    {
                        turnToAssess.saveDatas[dataIndex].dataValue = GetValue(save, turnToAssess.saveDatas[dataIndex].key);
                    }
                }
            }
            sr.Close();
        }
        string jsonSaved = JsonUtility.ToJson(gameData);
        File.WriteAllText(Application.dataPath + "/StreamingAssets/" + saveName + ".json", jsonSaved);
    }

    private string GetValue(string save, string valueName)
    {
        var startValue = save.IndexOf(valueName);
        if (startValue == -1)
        {
            return "";
        }
        string value = "";
        for (int i = startValue + valueName.Length; i < save.Length; i++)
        {

            if (save[i] != ',')
            {
                value += save[i];
            }
            else
            {
                break;
            }
        }

        return value;
    }

    public void GetAllSuzeFilesInDirectory(string folderPath, ref List<string> suzeSaves, bool readEndFolder = true)
    {
        var files = Directory.GetFiles(folderPath, "SaveGame.suze");
        var folderName = folderPath.ToLower();

        bool shouldSkip = false;
        if (readEndFolder)
        {
            shouldSkip = files.Length <= 0 || folderName.Contains("end") == false || folderName.Contains("demo") == true;
        }
        else
        {
            shouldSkip = files.Length <= 0 || (folderName.Contains("start") == false && folderName.Contains("begin") == false) || folderName.Contains("demo") == true;
        }

        if (shouldSkip)
        {
            Debug.Log("Skip " + folderPath);
        }
        else
        {
            Debug.Log("Add files in folder " + folderPath);
            suzeSaves.AddRange(files);
        }
        var folders = Directory.GetDirectories(folderPath);
        for (int i = 0; i < folders.Length; i++)
        {
            var nestedFolderName = folders[i];
            nestedFolderName = nestedFolderName.ToLower();
            if (nestedFolderName.Contains("turn 11"))
            {
                this.GetAllSuzeFilesInDirectory(folders[i], ref suzeSaves, false);
            }
            else
            {
                this.GetAllSuzeFilesInDirectory(folders[i], ref suzeSaves, readEndFolder);
            }
        }

        if (folders.Length <= 0)
        {
            Debug.Log("Found no folder in " + folderPath);
        }
        return;
    }
}
