using System.Text.Json;

namespace DataProcessor.Models;

public class InstrumentStatus
{
    public string PackageID { get; set; }
    public List<DeviceStatus> DeviceStatuses { get; set; } = new List<DeviceStatus>();

    public InstrumentStatus() { }

    public InstrumentStatus(string packageID, List<DeviceStatus> deviceStatuses)
    {
        PackageID = packageID;
        DeviceStatuses = deviceStatuses;
    }
}
