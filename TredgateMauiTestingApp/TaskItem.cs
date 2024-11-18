namespace TredgateMauiTestingApp;

public class TaskItem
{
    public string Name { get; set; } = string.Empty;
    public DateTime Deadline { get; set; } = DateTime.Today;
    public string Priority { get; set; } = "Støední"; // Výchozí priorita
}