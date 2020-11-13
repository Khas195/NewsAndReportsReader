using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using System.IO;
using System;
public class SuzSavesReader : MonoBehaviour
{
    [SerializeField]
    string path = "";
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    [Button]
    public void GetAllFilesInPath()
    {
        List<string> suzeSaves = new List<string>();
        GetAllSuzeFilesInDirectory(path, ref suzeSaves);
        Debug.Log("Found " + suzeSaves.Count + " suze saves");
        for (int i = 0; i < suzeSaves.Count; i++)
        {
            StreamReader sr = new StreamReader(suzeSaves[i]);
            string save = sr.ReadToEnd();
            string turnValue = GetValue(save, "\"turnNo\": ");
            string econmyValue = GetValue(save, "[\\\"SuzVar.Economy\\\"]=");
            string budgetValue = GetValue(save, "[\\\"SuzVar.GovernmentBudget\\\"]=");
            string malenyevistValue = GetValue(save, "[\\\"SuzVar.Malenyevist\\\"]=");
            string capitalistValue = GetValue(save, "[\\\"SuzVar.Capitalist\\\"]=");
            string democraticValue = GetValue(save, "[\\\"SuzVar.Democratic\\\"]=");
            string sollistValue = GetValue(save, "[\\\"SuzVar.Sollist\\\"]=");
            string publicOpinion = GetValue(save, "[\\\"SuzVar.Public_Opinion\\\"]=");
            string bludishOpinion = GetValue(save, "[\\\"SuzVar.Bludish_Opinion\\\"]=");



            Debug.Log(("==============================").Colorize(Color.green).Bolden());
            Debug.Log(("Turn No: " + turnValue).Colorize(Color.green).Bolden() + " in " + suzeSaves[i]);
            Debug.Log((("Economy").Colorize(Color.green).Bolden()));
            Debug.Log(("Budget: " + budgetValue).Bolden());
            Debug.Log(("Economy: " + econmyValue).Bolden());
            Debug.Log(("Opinion").Colorize(Color.green).Bolden());
            Debug.Log(("Public Opinion: " + publicOpinion).Bolden());
            Debug.Log(("Bludish Opinion: " + bludishOpinion).Bolden());
            Debug.Log(("Political Leanings").Colorize(Color.green).Bolden());
            Debug.Log(("Democratic: " + democraticValue).Bolden());
            Debug.Log(("Malenyevist: " + malenyevistValue).Bolden());
            Debug.Log(("Sollist: " + sollistValue).Bolden());
            Debug.Log(("Capitalist: " + capitalistValue).Bolden());

            sr.Close();
        }
    }

    private string GetValue(string save, string valueName)
    {
        var startValue = save.IndexOf(valueName);
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

    public void GetAllSuzeFilesInDirectory(string folderPath, ref List<string> suzeSaves)
    {
        var files = Directory.GetFiles(folderPath, "SaveGame.suze");
        var folderName = folderPath.ToLower();

        if (files.Length <= 0 || folderName.Contains("end") == false || folderName.Contains("demo") == true)
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
            this.GetAllSuzeFilesInDirectory(folders[i], ref suzeSaves);
        }

        if (folders.Length <= 0)
        {
            Debug.Log("Found no folder in " + folderPath);
        }
        return;
    }
}
