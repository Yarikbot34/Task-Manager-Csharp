namespace TaskManager;

public class Target
{
    public static List<Target> targets = new List<Target>();
    
    private int id { get; }
    private string name { get; set; }
    private string description { get; set; }
    private DateTime createDate { get; set; }
    private DateTime endDate { get; set; }

    public Target(string name, string description, DateTime endDate)
    {
        id = targets.Count;
        this.name = name;
        this.description = description;
        this.endDate = endDate;
        createDate = DateTime.Now;
        targets.Add(this);
    }

    override public string ToString()
    {
        return $"{id} \t| {name} | {createDate}-{endDate} \n \t| {description}\n";
    }
}