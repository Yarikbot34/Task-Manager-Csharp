namespace TaskManager;

public class Target
{
    private int id { get; }
    private string name { get; set; }
    private string description { get; set; }
    private DateTime createDate { get; set; }
    private DateTime endDate { get; set; }

    public Target(int id, string name, string description, DateTime endDate)
    {
        this.id = id;
        this.name = name;
        this.description = description;
        this.endDate = endDate;
        createDate = DateTime.Now;
    }
}