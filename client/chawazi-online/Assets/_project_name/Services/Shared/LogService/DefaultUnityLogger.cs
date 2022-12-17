using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DefaultUnityLogger : ILogger
{
    private readonly ILogger unityDefaultDebugger;
    
    public DefaultUnityLogger()
    {
        unityDefaultDebugger = Debug.unityLogger;
    }

    public ILogHandler logHandler { get => unityDefaultDebugger.logHandler; set => unityDefaultDebugger.logHandler = value; }
    public bool logEnabled { get => unityDefaultDebugger.logEnabled; set => unityDefaultDebugger.logEnabled = value; }
    public LogType filterLogType { get => unityDefaultDebugger.filterLogType; set => unityDefaultDebugger.filterLogType = value; }

    public bool IsLogTypeAllowed(LogType logType)
    {
        return unityDefaultDebugger.IsLogTypeAllowed(logType);
    }

    public void Log(LogType logType, object message)
    {
        unityDefaultDebugger.Log(logType, message);
    }

    public void Log(LogType logType, object message, UnityEngine.Object context)
    {
        unityDefaultDebugger.Log(logType, message, context);
    }

    public void Log(LogType logType, string tag, object message)
    {
        unityDefaultDebugger.Log(logType, tag, message);
    }

    public void Log(LogType logType, string tag, object message, UnityEngine.Object context)
    {
        unityDefaultDebugger.Log(logType, tag, message, context);
    }

    public void Log(object message)
    {
        unityDefaultDebugger.Log(message);
    }

    public void Log(string tag, object message)
    {
        unityDefaultDebugger.Log(tag, message);
    }

    public void Log(string tag, object message, UnityEngine.Object context)
    {
        unityDefaultDebugger.Log(tag, message, context);
    }

    public void LogError(string tag, object message)
    {
        unityDefaultDebugger.LogError(tag, message);
    }

    public void LogError(string tag, object message, UnityEngine.Object context)
    {
        unityDefaultDebugger.LogError(tag, message, context);
    }

    public void LogException(Exception exception)
    {
        unityDefaultDebugger.LogException(exception);
    }

    public void LogException(Exception exception, UnityEngine.Object context)
    {
        unityDefaultDebugger.LogException(exception, context);
    }

    public void LogFormat(LogType logType, string format, params object[] args)
    {
        unityDefaultDebugger.LogFormat(logType, format, args);
    }

    public void LogFormat(LogType logType, UnityEngine.Object context, string format, params object[] args)
    {
        unityDefaultDebugger.LogFormat(logType, context, format, args);
    }

    public void LogWarning(string tag, object message)
    {
        unityDefaultDebugger.LogWarning(tag, message);
    }

    public void LogWarning(string tag, object message, UnityEngine.Object context)
    {
        unityDefaultDebugger.LogWarning(tag, message, context);
    }
}
