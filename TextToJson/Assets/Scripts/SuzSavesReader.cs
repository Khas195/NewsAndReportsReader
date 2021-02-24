using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using System.IO;
using System;
using UnityEngine.UI;

public class SuzSavesReader : MonoBehaviour
{
    [SerializeField]
    Text filePathUI;
    [SerializeField]
    Text resultText;

    string path = "";
    // Start is called before the first frame update
    [SerializeField]
    GameData gameData;
    const string BASE_URL = "https://docs.google.com/forms/u/0/d/e/1FAIpQLSc4vRIS5sAyJ6nRYK8wbwqGG9wIMBb50QbTkRPNhNTLQEv_bw/formResponse";
    IEnumerator Post()
    {
        WWWForm form = new WWWForm();
        form.AddField("entry.429997597", gameData.saveName);
        form.AddField("entry.1903643271", gameData.version);
        form.AddField("entry.1293977492", gameData.turnNumber);
        for (int i = 0; i < gameData.saveDatas.Count; i++)
        {
            var googleFormField = "entry." + gameData.saveDatas[i].googleFormID;
            var valueKey = gameData.saveDatas[i].dataValue;

            form.AddField(googleFormField, valueKey);
        }
        // PFJP destroyed
        //form.AddField("entry.544782278", dataForm.pfjp_destroyed);
        byte[] rawData = form.data;
        WWW www = new WWW(BASE_URL, rawData);
        yield return www;
    }

    [Button]
    public void SaveAndUpload()
    {
        resultText.text = "";
        if (path == "")
        {
            resultText.text = "Antonnn, you forgot to enter the file path!.\n".Bolden().Colorize(Color.red);
            return;
        }
        SaveAllFilesInPath();
        UploadDataToGoogleSheets();
        resultText.text += "We did it Anton, the operation was a success\n".Bolden().Colorize(Color.green);
    }



    [Button]
    public void UploadDataToGoogleSheets()
    {
        StartCoroutine(Post());
    }

    [Button]
    public void SaveAllFilesInPath()
    {
        if (path == "")
        {
            resultText.text = "Antonnn, you forgot to enter the file path!.\n".Bolden().Colorize(Color.red);
            return;
        }

        gameData.Clear();
        List<string> suzeSaves = new List<string>();
        GetAllSuzeFilesInDirectory(path, ref suzeSaves);
        Debug.Log("Found " + suzeSaves.Count + " suze saves");


        for (int i = 0; i < suzeSaves.Count; i++)
        {
            var pos = suzeSaves[i].LastIndexOf("\\") + 1;

            gameData.saveName = suzeSaves[i].Substring(pos, suzeSaves[i].Length - pos - 5);
            StreamReader sr = new StreamReader(suzeSaves[i]);
            string save = sr.ReadToEnd();
            string turnValue = GetValue(save, "\"turnNo\": ");

            gameData.version = GetValue(save, "\"currentSuzerainVersion\": ");


            Debug.Log(("Reading Saves " + suzeSaves[i]).Bolden().Colorize(Color.green));
            for (int turnIndex = 0; turnIndex < gameData.saveDatas.Count; turnIndex++)
            {
                var turnToAssess = gameData.saveDatas[turnIndex];
                string saveKey = "[\\\"" + turnToAssess.key + "\\\"]=";
                turnToAssess.dataValue = GetValue(save, saveKey);
            }
            sr.Close();
            string jsonSaved = JsonUtility.ToJson(gameData);
            File.WriteAllText(Application.dataPath + "/StreamingAssets/" + gameData.saveName + ".json", jsonSaved);

        }

        resultText.text += "Got all the datas Anton. Let's roll!!\n".Bolden().Colorize(Color.green);
    }

    private string GetValue(string save, string valueName)
    {
        Debug.Log("Finding value: " + valueName);
        var startValue = save.IndexOf(valueName);
        if (startValue == -1)
        {
            Debug.Log("Value not found: " + valueName);
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

    public void GetAllSuzeFilesInDirectory(string folderPath, ref List<string> suzeSaves, string saveToRead = "*.suze")
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
            this.GetAllSuzeFilesInDirectory(folders[i], ref suzeSaves, saveToRead);
        }

        if (folders.Length <= 0)
        {
            Debug.Log("Found no folder in " + folderPath);
        }
        return;
    }
    public void OnPathChanged(string newPath)
    {
        this.path = newPath;
    }
}
