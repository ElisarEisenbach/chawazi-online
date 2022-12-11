using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;


public class DefaultUnityLogger : ILogger
{
    private ILogger unityDefaultDebuger = Debug.unityLogger;

    [Inject]
    public DefaultUnityLogger()
    {

    }

    public ILogHandler logHandler { get => unityDefaultDebuger.logHandler; set => unityDefaultDebuger.logHandler = value; }
    public bool logEnabled { get => unityDefaultDebuger.logEnabled; set => unityDefaultDebuger.logEnabled = value; }
    public LogType filterLogType { get => unityDefaultDebuger.filterLogType; set => unityDefaultDebuger.filterLogType = value; }

    public bool IsLogTypeAllowed(LogType logType)
    {
        return unityDefaultDebuger.IsLogTypeAllowed(logType);
    }

    public void Log(LogType logType, object message)
    {
        unityDefaultDebuger.Log(logType, message);
    }

    public void Log(LogType logType, object message, UnityEngine.Object context)
    {
        unityDefaultDebuger.Log(logType, message, context);
    }

    public void Log(LogType logType, string tag, object message)
    {
        unityDefaultDebuger.Log(logType, tag, message);
    }

    public void Log(LogType logType, string tag, object message, UnityEngine.Object context)
    {
        unityDefaultDebuger.Log(logType, tag, message, context);
    }

    public void Log(object message)
    {
        unityDefaultDebuger.Log(message);
    }

    public void Log(string tag, object message)
    {
        unityDefaultDebuger.Log(tag, message);
    }

    public void Log(string tag, object message, UnityEngine.Object context)
    {
        unityDefaultDebuger.Log(tag, message, context);
    }

    public void LogError(string tag, object message)
    {
        unityDefaultDebuger.LogError(tag, message);
    }

    public void LogError(string tag, object message, UnityEngine.Object context)
    {
        unityDefaultDebuger.LogError(tag, message, context);
    }

    public void LogException(Exception exception)
    {
        unityDefaultDebuger.LogException(exception);
    }

    public void LogException(Exception exception, UnityEngine.Object context)
    {
        unityDefaultDebuger.LogException(exception, context);
    }

    public void LogFormat(LogType logType, string format, params object[] args)
    {
        unityDefaultDebuger.LogFormat(logType, format, args);
    }

    public void LogFormat(LogType logType, UnityEngine.Object context, string format, params object[] args)
    {
        unityDefaultDebuger.LogFormat(logType, context, format, args);
    }

    public void LogWarning(string tag, object message)
    {
        unityDefaultDebuger.LogWarning(tag, message);
    }

    public void LogWarning(string tag, object message, UnityEngine.Object context)
    {
        unityDefaultDebuger.LogWarning(tag, message, context);
    }
}
