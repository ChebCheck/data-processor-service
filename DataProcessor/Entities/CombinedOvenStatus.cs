﻿namespace DataProcessor.Entities;

public class CombinedOvenStatus : BaseCombinedStatus
{
    public bool UseTemperatureControl { get; set; }
    public bool OvenOn { get; set; }
    public float Temperature_Actual { get; set; }
    public float Temperature_Room { get; set; }
    public float MaximumTemperatureLimit { get; set; }
    public int Valve_Position { get; set; }
    public int Valve_Rotations { get; set; }
    public bool Buzzer { get; set; }

    public CombinedOvenStatus() : base() { }

    public CombinedOvenStatus(
        string moduleState,
        bool isBusy,
        bool isReady,
        bool isError,
        bool keyLock,
        bool useTemperatureControl,
        bool ovenOn,
        float temperature_Actual,
        float temperature_Room,
        float maximumTemperatureLimit,
        int valve_Position,
        int valve_Rotations,
        bool buzzer) : base(moduleState, isBusy, isReady, isError, keyLock)
    {
        UseTemperatureControl = useTemperatureControl;
        OvenOn = ovenOn;
        Temperature_Actual = temperature_Actual;
        Temperature_Room = temperature_Room;
        MaximumTemperatureLimit = maximumTemperatureLimit;
        Valve_Position = valve_Position;
        Valve_Rotations = valve_Rotations;
        Buzzer = buzzer;
    }

    public CombinedOvenStatus(
        BaseCombinedStatus baseStatus,
        bool useTemperatureControl,
        bool ovenOn,
        float temperature_Actual,
        float temperature_Room,
        float maximumTemperatureLimit,
        int valve_Position,
        int valve_Rotations,
        bool buzzer) : base(baseStatus)
    {
        UseTemperatureControl = useTemperatureControl;
        OvenOn = ovenOn;
        Temperature_Actual = temperature_Actual;
        Temperature_Room = temperature_Room;
        MaximumTemperatureLimit = maximumTemperatureLimit;
        Valve_Position = valve_Position;
        Valve_Rotations = valve_Rotations;
        Buzzer = buzzer;
    }
}
