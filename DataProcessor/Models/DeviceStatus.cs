namespace DataProcessor.Models;

public class DeviceStatus
{
    public string ModuleCategoryID { get; set; }
    public int IndexWithinRole { get; set; }
    public BaseCombinedStatus RapidControlStatus { get; set; }

    public DeviceStatus() { }

    public DeviceStatus(string moduleCategoryID, int indexWithinRole, BaseCombinedStatus rapidControlStatus)
    {
        ModuleCategoryID = moduleCategoryID;
        IndexWithinRole = indexWithinRole;
        RapidControlStatus = rapidControlStatus;
    }
}
