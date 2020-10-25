using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelControl : MonoBehaviour
{
    [SerializeField]
    ReadText textReader = null;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnNewsPathEnterd(string path)
    {
        textReader.filePathNews = path;
    }
    public void OnReportsPathEnterd(string path)
    {
        textReader.filePathNews = path;
    }
    public void TurnNumberEntered(string turn)
    {
        textReader.turnNumber = Int32.Parse(turn);
    }
    public void ConvertNews()
    {
        textReader.ReadNewsFromText();
        textReader.ConvertNewsToJson();
    }
    public void ConvertReports()
    {
        textReader.ReadReportFromText();
        textReader.ConvertReportsToJson();
    }
    public void Close()
    {
#if UNITY_EDITOR
        // Application.Quit() does not work in the editor so
        // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }
}
