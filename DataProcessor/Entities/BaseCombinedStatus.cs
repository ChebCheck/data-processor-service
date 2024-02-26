﻿namespace DataProcessor.Entities;

public class BaseCombinedStatus
{
    public string ModuleState { get; set; }
    public bool IsBusy { get; set; }
    public bool IsReady { get; set; }
    public bool IsError { get; set; }
    public bool KeyLock { get; set; }

    public BaseCombinedStatus() { }

    public BaseCombinedStatus(string moduleState, bool isBusy, bool isReady, bool isError, bool keyLock)
    {
        ModuleState = moduleState;
        IsBusy = isBusy;
        IsReady = isReady;
        IsError = isError;
        KeyLock = keyLock;
    }

    public BaseCombinedStatus(BaseCombinedStatus status)
    {
        ModuleState = status.ModuleState;
        IsBusy = status.IsBusy;
        IsReady = status.IsReady;
        IsError = status.IsError;
        KeyLock = status.KeyLock;
    }
}