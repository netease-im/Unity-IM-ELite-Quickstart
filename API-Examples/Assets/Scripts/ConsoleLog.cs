using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

/*
 * 本文件用于将控制台日志打印到UI上
 */
public class ConsoleLog : MonoBehaviour
{
    public Text logText;

    void OnEnable()
    {
        Application.logMessageReceived += LogCallback;
        Application.logMessageReceivedThreaded += LogCallbackThread;
    }

    private void OnDisable()
    {
        Application.logMessageReceived -= LogCallback;
        Application.logMessageReceivedThreaded -= LogCallbackThread;
    }

    public void LogCallback(string logString, string stackTrace, LogType type)
    {
        AddLog(logString, stackTrace, type);
    }

    private void AddLog(string logString, string stackTrace, LogType type)
    {
        string cur = logText.text;
        StringBuilder sb = new StringBuilder();
        sb.Append(cur);
        sb.AppendLine(logString);
        logText.text = sb.ToString();
    }

    public void LogCallbackThread(string logString, string stackTrace, LogType type)
    {
        // to mainthread
        Loom.QueueOnMainThread(() =>{
            AddLog(logString, stackTrace, type);
        });
    }
}
