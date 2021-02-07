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
    public string budget = "-";
    public string publicOpinion = "-";
    public string bludishOpinion = "-";
    public string economy = "-";
    public string sollist = "-";
    public string capitalist = "-";
    public string malenyevist = "-";
    public string democratic = "-";
    public string voteCount_Independents = "-";
    public string voteCount_NFP = "-";
    public string voteCount_PFJP_RictersWing = "-";
    public string voteCount_PFJP_Undecided = "-";
    public string voteCount_USP_AlbinsWing = "-";
    public string voteCount_USP_GloriasWing = "-";
    public string voteCount_USP_Undecided = "-";
    public string endingVote_Bludish = "-";
    public string endingVote_Centrists = "-";
    public string endingVote_Conservatives = "-";
    public string endingVote_Liberals = "-";
    public string endingVote_Nationalists = "-";
    public string endingVote_Socialists = "-";
    public string ending_Election_Votes = "-";
    public string court_Vote = "-";
    public string assembly_vote = "-";
    public string pfjp_destroyed = "false";
    public string nfp_destroyed = "false";
}
public class WarDataForGoogleForm
{
    public string version = "404-Unknown";
    public string turnNumber = "404-Unknown";
    public string playerName = "404-Unknown";

    public string phase1_victory = "-";
    public string phase2_victory = "-";
    public string callAllies = "-";
    public string agnoliaAllied = "-";
    public string phase1_agnolia_attackDome = "-";
    public string phase1_agnolia_assistPincer = "-";
    public string wehlenAllied = "-";
    public string phase1_wehlen_flank = "-";
    public string phase1_wehlen_reinforce = "-";
    public string valgslandAllied = "-";
    public string phase1_valgsland_assistFrontline = "-";
    public string phase1_valgsland_invadeNorthRumburg = "-";
    public string lespiaAllied = "-";
    public string phase1_pincer = "-";
    public string phase1_digDown = "-";
    public string phase1_assaultTzarsbough = "-";
    public string phase2_takeThornbourgh = "-";
    public string phase2_attackDome = "-";
    public string phase2_lespia_attackDome = "-";
    public string phase2_lespia_defendTzarsbourgh = "-";
    public string phase2_wehlen_attackDome = "-";
    public string phase2_wehlen_defendTzarsbourgh = "-";
    public string phase2_valgsland_defendTzarsbourgh = "-";
    public string phase2_valgsland_attackDome = "-";
    public string reservist = "-";
    public string gendarmerie = "-";
    public string modernizedOrExpand = "-";
    public string upgradedSector = "-";
    public string increasedTrade = "-";
    public string increasedProduction = "-";
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
    [SerializeField]
    GameData warData;
    const string BASE_URL = "https://docs.google.com/forms/u/0/d/e/1FAIpQLSc4vRIS5sAyJ6nRYK8wbwqGG9wIMBb50QbTkRPNhNTLQEv_bw/formResponse";
    const string WAR_BASE_URL = "https://docs.google.com/forms/u/1/d/e/1FAIpQLSejn3qUlZM6TI8UDYpGp9xpOuYLZQRzyJakQPmF-aidaR45hg/formResponse";
    IEnumerator Post(SaveDataForGoogleForm dataForm)
    {
        WWWForm form = new WWWForm();
        // PFJP destroyed
        form.AddField("entry.544782278", dataForm.pfjp_destroyed);
        // NFP Destroyed
        form.AddField("entry.27990144", dataForm.nfp_destroyed);
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

    IEnumerator PostWarData(WarDataForGoogleForm dataForm)
    {
        WWWForm form = new WWWForm();

        form.AddField("entry.97260512", dataForm.version);
        form.AddField("entry.1321076154", dataForm.turnNumber);
        form.AddField("entry.1536165304", dataForm.playerName);

        form.AddField("entry.201016141", dataForm.phase1_victory);
        form.AddField("entry.1967443541", dataForm.phase2_victory);
        form.AddField("entry.687962811", dataForm.callAllies);
        form.AddField("entry.2096606340", dataForm.agnoliaAllied);
        form.AddField("entry.205649511", dataForm.phase1_agnolia_attackDome);
        form.AddField("entry.638530477", dataForm.phase1_agnolia_assistPincer);
        form.AddField("entry.2069249335", dataForm.wehlenAllied);
        form.AddField("entry.1301319540", dataForm.phase1_wehlen_flank);
        form.AddField("entry.148304627", dataForm.phase1_wehlen_reinforce);
        form.AddField("entry.14202420", dataForm.valgslandAllied);
        form.AddField("entry.1862378098", dataForm.phase1_valgsland_assistFrontline);
        form.AddField("entry.291895241", dataForm.phase1_valgsland_invadeNorthRumburg);
        form.AddField("entry.57400942", dataForm.lespiaAllied);
        form.AddField("entry.431787777", dataForm.phase1_pincer);
        form.AddField("entry.584819947", dataForm.phase1_digDown);
        form.AddField("entry.1808536316", dataForm.phase1_assaultTzarsbough);
        form.AddField("entry.820946429", dataForm.phase2_takeThornbourgh);
        form.AddField("entry.438950876", dataForm.phase2_attackDome);
        form.AddField("entry.80390878", dataForm.phase2_lespia_attackDome);
        form.AddField("entry.715699231", dataForm.phase2_lespia_defendTzarsbourgh);
        form.AddField("entry.1526346403", dataForm.phase2_wehlen_attackDome);
        form.AddField("entry.1165311304", dataForm.phase2_wehlen_defendTzarsbourgh);
        form.AddField("entry.295281731", dataForm.phase2_valgsland_defendTzarsbourgh);
        form.AddField("entry.1510650497", dataForm.phase2_attackDome);
        form.AddField("entry.1714219605", dataForm.reservist);
        form.AddField("entry.469351929", dataForm.gendarmerie);
        form.AddField("entry.177844826", dataForm.modernizedOrExpand);
        form.AddField("entry.1781836786", dataForm.upgradedSector);
        form.AddField("entry.1652237913", dataForm.increasedTrade);
        form.AddField("entry.328543177", dataForm.increasedProduction);
        byte[] rawData = form.data;
        WWW www = new WWW(WAR_BASE_URL, rawData);
        yield return www;
    }
    [Button]
    public void SaveAndUpload()
    {
        SaveAllFilesInPath();
        UploadDataToGoogleSheets();
        UploadWarDataToGoogleSheets();
    }

    [Button]
    private void UploadWarDataToGoogleSheets()
    {
        for (int i = 0; i < warData.turnDataList.Count; i++)
        {
            if (warData.turnDataList[i].HasEmptyValue())
            {
                Debug.Log(("Turn has empty value").Bolden().Colorize(Color.red));
                continue;
            }
            var newSaveData = new WarDataForGoogleForm();
            newSaveData.turnNumber = warData.turnDataList[i].turnNumber;
            newSaveData.playerName = saveName;
            newSaveData.version = warData.version;
            newSaveData.phase1_victory = warData.turnDataList[i].saveDatas[0].dataValue;
            newSaveData.phase2_victory = warData.turnDataList[i].saveDatas[1].dataValue;
            newSaveData.callAllies = warData.turnDataList[i].saveDatas[2].dataValue;
            newSaveData.agnoliaAllied = warData.turnDataList[i].saveDatas[3].dataValue;
            newSaveData.phase1_agnolia_attackDome = warData.turnDataList[i].saveDatas[4].dataValue;
            newSaveData.phase1_agnolia_assistPincer = warData.turnDataList[i].saveDatas[5].dataValue;
            newSaveData.wehlenAllied = warData.turnDataList[i].saveDatas[6].dataValue;
            newSaveData.phase1_wehlen_flank = warData.turnDataList[i].saveDatas[7].dataValue;
            newSaveData.phase1_wehlen_reinforce = warData.turnDataList[i].saveDatas[8].dataValue;
            newSaveData.valgslandAllied = warData.turnDataList[i].saveDatas[9].dataValue;
            newSaveData.phase1_valgsland_assistFrontline = warData.turnDataList[i].saveDatas[10].dataValue;
            newSaveData.phase1_valgsland_invadeNorthRumburg = warData.turnDataList[i].saveDatas[11].dataValue;
            newSaveData.lespiaAllied = warData.turnDataList[i].saveDatas[12].dataValue;
            newSaveData.phase1_pincer = warData.turnDataList[i].saveDatas[13].dataValue;
            newSaveData.phase1_digDown = warData.turnDataList[i].saveDatas[14].dataValue;
            newSaveData.phase1_assaultTzarsbough = warData.turnDataList[i].saveDatas[15].dataValue;
            newSaveData.phase2_takeThornbourgh = warData.turnDataList[i].saveDatas[16].dataValue;
            newSaveData.phase2_attackDome = warData.turnDataList[i].saveDatas[17].dataValue;
            newSaveData.phase2_lespia_attackDome = warData.turnDataList[i].saveDatas[18].dataValue;
            newSaveData.phase2_lespia_defendTzarsbourgh = warData.turnDataList[i].saveDatas[19].dataValue;
            newSaveData.phase2_wehlen_attackDome = warData.turnDataList[i].saveDatas[20].dataValue;
            newSaveData.phase2_wehlen_defendTzarsbourgh = warData.turnDataList[i].saveDatas[21].dataValue;
            newSaveData.phase2_valgsland_defendTzarsbourgh = warData.turnDataList[i].saveDatas[22].dataValue;
            newSaveData.phase2_valgsland_attackDome = warData.turnDataList[i].saveDatas[23].dataValue;
            newSaveData.reservist = warData.turnDataList[i].saveDatas[24].dataValue;
            newSaveData.gendarmerie = warData.turnDataList[i].saveDatas[25].dataValue;

            var expandedArmy = warData.turnDataList[i].saveDatas[26].dataValue;
            var expandedNavy = warData.turnDataList[i].saveDatas[27].dataValue;
            var expandedAirforce = warData.turnDataList[i].saveDatas[28].dataValue;
            var modernArmy = warData.turnDataList[i].saveDatas[29].dataValue;
            var modernNavy = warData.turnDataList[i].saveDatas[30].dataValue;
            var modernAirforce = warData.turnDataList[i].saveDatas[31].dataValue;


            if (expandedArmy.Equals("true") || expandedNavy.Equals("true") || expandedAirforce.Equals("true"))
            {
                newSaveData.modernizedOrExpand = "Expand";
            }
            else if (modernArmy.Equals("true") || modernNavy.Equals("true") || modernAirforce.Equals("true"))
            {

                newSaveData.modernizedOrExpand = "Modernised";
            }
            else
            {
                newSaveData.modernizedOrExpand = "NONE";
            }

            if (newSaveData.modernizedOrExpand == "Expand" || newSaveData.modernizedOrExpand == "Modernised")
            {

                if (expandedArmy.Equals("true") || modernArmy.Equals("true"))
                {
                    newSaveData.upgradedSector = "Army";
                }
                else if (expandedNavy.Equals("true") || modernNavy.Equals("true"))
                {

                    newSaveData.upgradedSector = "Navy";
                }
                else
                {
                    newSaveData.upgradedSector = "Airforce";
                }
            }

            newSaveData.increasedTrade = warData.turnDataList[i].saveDatas[32].dataValue;
            newSaveData.increasedProduction = warData.turnDataList[i].saveDatas[33].dataValue;
            Debug.Log(("Turn saved for WAR: " + newSaveData.turnNumber).Bolden().Colorize(Color.green));
            StartCoroutine(PostWarData(newSaveData));
        }
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
                newSaveData.pfjp_destroyed = gameData.turnDataList[i].saveDatas[24].dataValue;
                newSaveData.nfp_destroyed = gameData.turnDataList[i].saveDatas[25].dataValue;
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
            warData.version = GetValue(save, "\"currentSuzerainVersion\": ");


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

            if (turnValue.Equals("10") || turnValue.Equals("12"))
            {
                for (int turnIndex = 0; turnIndex < warData.turnDataList.Count; turnIndex++)
                {
                    var turnToAssess = warData.turnDataList[turnIndex];
                    if (turnToAssess.turnNumber.Equals(turnValue.Trim()))
                    {
                        Debug.Log(("Reading Turn for War data: " + turnToAssess.turnNumber).Bolden().Colorize(Color.green));
                        for (int dataIndex = 0; dataIndex < turnToAssess.saveDatas.Count; dataIndex++)
                        {
                            if (turnToAssess.saveDatas[dataIndex].key.Equals("Military_LargeReservistPool"))
                            {
                                Debug.Log("Here");
                            }
                            string saveKey = "[\\\"" + turnToAssess.saveDatas[dataIndex].key + "\\\"]=";

                            turnToAssess.saveDatas[dataIndex].dataValue = GetValue(save, saveKey);
                        }
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
