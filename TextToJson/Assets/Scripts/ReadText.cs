using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using System.IO;
public class ReadText : MonoBehaviour
{
    public string filePathNews = "";
    public string filePathReports = "";
    public string saveDestinationNews = "";
    public string saveDestinationReports = "";
    [SerializeField]
    NewsList newsList = new NewsList();
    [SerializeField]
    ReportList reportList = new ReportList();
    public int turnNumber = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }
    [Button]
    public void ConvertNewsToJson()
    {
        string newsData = JsonUtility.ToJson(newsList);
        File.WriteAllText(saveDestinationNews + "/news.json", newsData);
    }
    [Button]
    public void ConvertReportsToJson()
    {
        string reportData = JsonUtility.ToJson(reportList);
        File.WriteAllText(saveDestinationReports + "/reports.json", reportData);
    }
    [Button]
    public void ReadNewsFromText()
    {
        newsList.news.Clear();
        StreamReader sr = new StreamReader(filePathNews);
        Debug.Log("Reading file");
        int totalTitle = 0;
        while (sr.EndOfStream != true)
        {
            var line = sr.ReadLine();
            line += " ";
            var loweredLine = line.ToLower();
            if (loweredLine.Contains("title:"))
            {
                var title = line.Replace("Title:", "").Trim();

                var variable = sr.ReadLine();
                variable = variable.Replace("Variable:", "").Trim();

                var newspaper = sr.ReadLine();
                newspaper = newspaper.Replace("Newspaper:", "").Trim();

                var condition = sr.ReadLine();
                var content = "";
                var nextLine = sr.ReadLine();
                while (nextLine.Contains("END") == false)
                {
                    if (nextLine.Length > 0)
                    {
                        content += nextLine + "\n\n";
                    }
                    nextLine = sr.ReadLine();
                }
                var news = new News(variable, title, content.Trim(), newspaper, turnNumber);
                this.newsList.news.Add(news);
                totalTitle += 1;
            }
        }
        Debug.Log("Finished reading file and found " + totalTitle + " news");
        sr.Close();
    }
    [Button]
    public void ReadReportFromText()
    {
        reportList.reports.Clear();
        StreamReader sr = new StreamReader(filePathReports);
        Debug.Log("Reading file");
        int totalTitle = 0;
        while (sr.EndOfStream != true)
        {
            var line = sr.ReadLine();
            line += " ";
            var loweredLine = line.ToLower();
            if (loweredLine.Contains("title:"))
            {
                var title = line.Replace("Title:", "").Trim();

                var variable = sr.ReadLine();
                variable = variable.Replace("Variable:", "").Trim();

                var place = sr.ReadLine();
                place = place.Replace("City/Country:", "").Trim();

                var condition = sr.ReadLine();
                var content = "";
                var nextLine = sr.ReadLine();
                while (nextLine.Contains("END") == false)
                {
                    if (nextLine.Length > 0)
                    {
                        content += nextLine + "\n\n";
                    }
                    nextLine = sr.ReadLine();
                }
                var report = new Report(variable, place, title, content.Trim(), turnNumber);
                this.reportList.reports.Add(report);
                totalTitle += 1;
            }
        }
        Debug.Log("Finished reading file and found " + totalTitle + " reports");
        sr.Close();
    }
}
