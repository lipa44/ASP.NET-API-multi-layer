namespace ReportsWebApi.DataTransferObjects;

public record WorkTeamDto
{
    public string Name { get; init; }
    public string TeamLeadData { get; init; }
}