using System;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class NewsList
{
    public List<News> news = new List<News>();
}
[Serializable]
public class News
{
    [SerializeField]
    string conditionVariable = "";
    [SerializeField]
    bool isEnabled = false;
    [SerializeField]
    bool isUserNotified = false;
    [SerializeField]
    int turnNo = 0;
    [SerializeField]
    string newsName = "";
    [SerializeField]
    string newsDescription = "";
    [SerializeField]
    string newsDate = "";
    [SerializeField]
    string newsSource = "";
    [SerializeField]
    bool itemRead = false;

    public News()
    {
    }

    public News(string conditionVariable, string newsName, string newsDescription, string newsSource, int turnNo = 0, string newsDate = "", bool itemRead = false, bool isEnabled = false, bool isUserNotified = false)
    {
        this.conditionVariable = conditionVariable;
        this.isEnabled = isEnabled;
        this.isUserNotified = isUserNotified;
        this.turnNo = turnNo;
        this.newsName = newsName;
        this.newsDescription = newsDescription;
        this.newsDate = newsDate;
        this.newsSource = newsSource;
        this.itemRead = itemRead;
    }
}
