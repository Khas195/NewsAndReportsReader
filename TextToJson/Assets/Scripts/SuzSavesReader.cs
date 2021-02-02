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
    public string voteCount_Independents = "404-Unknown";
    public string voteCount_NFP = "404-Unknown";
    public string voteCount_PFJP_RictersWing = "404-Unknown";
    public string voteCount_PFJP_Undecided = "404-Unknown";
    public string voteCount_USP_AlbinsWing = "404-Unknown";
    public string voteCount_USP_GloriasWing = "404-Unknown";
    public string voteCount_USP_Undecided = "404-Unknown";
    public string endingVote_Bludish = "404-Unknown";
    public string endingVote_Centrists = "404-Unknown";
    public string endingVote_Conservatives = "404-Unknown";
    public string endingVote_Liberals = "404-Unknown";
    public string endingVote_Nationalists = "404-Unknown";
    public string endingVote_Socialists = "404-Unknown";
    public string ending_Election_Votes = "404-Unknown";
    public string court_Vote = "404-Unknown";
    public string assembly_vote = "404-Unknown";
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
        // Independent Vote
        form.AddField("entry.1454203095", dataForm.voteCount_Independents);
        // NFP Vote
        form.AddField("entry.762042860", dataForm.voteCount_NFP);

        // PFJP Ricter Wing 
        form.AddField("entry.421097645", dataForm.voteCount_PFJP_RictersWing);

        // PFJP Undecided 
        form.AddField("entry.1769630878", dataForm.voteCount_PFJP_Undecided);

        // USP Victoria 
        form.AddField("entry.896766524", dataForm.voteCount_USP_GloriasWing);

        // USP Albin 
        form.AddField("entry.1543224069", dataForm.voteCount_USP_AlbinsWing);
        // USP Undecided 
        form.AddField("entry.1192201159", dataForm.voteCount_USP_Undecided);
        // Ending Bludish Vote 
        form.AddField("entry.2085699813", dataForm.endingVote_Bludish);
        // Ending Centris 
        form.AddField("entry.559308892", dataForm.endingVote_Centrists);
        // Ending Conservatives 
        form.AddField("entry.765241053", dataForm.endingVote_Conservatives);

        // Ending Liberals 
        form.AddField("entry.1791755143", dataForm.endingVote_Liberals);
        // Ending Nationalist 
        form.AddField("entry.1861751280", dataForm.endingVote_Nationalists);
        // Ending Socialist 
        form.AddField("entry.1744765744", dataForm.endingVote_Socialists);
        // Ending Election Ending 
        form.AddField("entry.2071787596", dataForm.ending_Election_Votes);
        //  Assembly Vote
        form.AddField("entry.2016252887", dataForm.assembly_vote);
        //  Court Vote
        form.AddField("entry.685662422", dataForm.court_Vote);
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

            if (gameData.turnDataList[i].saveDatas.Count >= 22)
            {
                newSaveData.voteCount_Independents = gameData.turnDataList[i].saveDatas[8].dataValue;
                newSaveData.voteCount_NFP = gameData.turnDataList[i].saveDatas[9].dataValue;
                newSaveData.voteCount_PFJP_RictersWing = gameData.turnDataList[i].saveDatas[10].dataValue;
                newSaveData.voteCount_PFJP_Undecided = gameData.turnDataList[i].saveDatas[11].dataValue;
                newSaveData.voteCount_USP_AlbinsWing = gameData.turnDataList[i].saveDatas[12].dataValue;
                newSaveData.voteCount_USP_GloriasWing = gameData.turnDataList[i].saveDatas[13].dataValue;
                newSaveData.voteCount_USP_Undecided = gameData.turnDataList[i].saveDatas[14].dataValue;
                newSaveData.endingVote_Bludish = gameData.turnDataList[i].saveDatas[15].dataValue;
                newSaveData.endingVote_Centrists = gameData.turnDataList[i].saveDatas[16].dataValue;
                newSaveData.endingVote_Conservatives = gameData.turnDataList[i].saveDatas[17].dataValue;
                newSaveData.endingVote_Liberals = gameData.turnDataList[i].saveDatas[18].dataValue;
                newSaveData.endingVote_Nationalists = gameData.turnDataList[i].saveDatas[19].dataValue;
                newSaveData.endingVote_Socialists = gameData.turnDataList[i].saveDatas[20].dataValue;
                newSaveData.ending_Election_Votes = gameData.turnDataList[i].saveDatas[21].dataValue;
                newSaveData.court_Vote = gameData.turnDataList[i].saveDatas[22].dataValue;
                newSaveData.assembly_vote = gameData.turnDataList[i].saveDatas[23].dataValue;
            }

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

    public void GetAllSuzeFilesInDirectory(string folderPath, ref List<string> suzeSaves, string saveToRead = "SaveGame.suze")
    {
        var files = Directory.GetFiles(folderPath, saveToRead);
        var folderName = folderPath.ToLower();

        bool shouldSkip = false;
        shouldSkip = files.Length <= 0;

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

                this.GetAllSuzeFilesInDirectory(folders[i], ref suzeSaves, "SaveGame_LastPlaythrough.suze");
            }
            this.GetAllSuzeFilesInDirectory(folders[i], ref suzeSaves);
        }

        if (folders.Length <= 0)
        {
            Debug.Log("Found no folder in " + folderPath);
        }
        return;
    }
}
