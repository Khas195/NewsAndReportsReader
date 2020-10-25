using System;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class ReportList
{
    public List<Report> reports = new List<Report>();
}
[Serializable]
public class Report
{
    [SerializeField]
    string conditionVariable = "";
    [SerializeField]
    string cityName = "";
    [SerializeField]
    string reportName = "";
    [SerializeField]
    string reportText = "";
    [SerializeField]
    int turnNo = 1;
    [SerializeField]
    bool isEnabled = false;
    [SerializeField]
    bool isUserNotified = false;
    [SerializeField]
    bool isReportDone = false;

    public Report(string conditionVariable, string cityName, string reportName, string reportText, int turnNo = 0, bool isEnabled = false, bool isUserNotified = false, bool isReportDone = false)
    {
        this.conditionVariable = conditionVariable;
        this.cityName = cityName;
        this.reportName = reportName;
        this.reportText = reportText;
        this.turnNo = turnNo;
        this.isEnabled = isEnabled;
        this.isUserNotified = isUserNotified;
        this.isReportDone = isReportDone;
    }
}
