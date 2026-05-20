using System.Text.Json;
using System.Text.Json.Serialization;

namespace TaskManager;

public class Target
{
    public static List<Target> targets = new List<Target>();
    [JsonIgnore]
    private int id { get; }
    [JsonInclude]
    private string name { get; set; }
    [JsonInclude]
    private string description { get; set; }
    [JsonInclude]
    private DateTime createDate { get; set; }
    [JsonInclude]
    private DateTime endDate { get; set; }
    [JsonIgnore]
    public bool inFocus = false;
    [JsonInclude]
    public bool complete = false;

    public void setName(string name)
    {
        if (name.Length != 0)
        {
            this.name = name;
        }
    }
    public void setDesc(string description)
    {
        this.description = description;
    }
    public void setTargetDate(DateTime targetDate)
    {
        this.endDate = targetDate;
    }

    public Target(string name, string description, DateTime endDate)
    {
        id = targets.Count;
        this.name = name;
        this.description = description;
        this.endDate = endDate;
        createDate = DateTime.Now;
        targets.Add(this);
    }
    
    [JsonConstructor]
    public Target(string name, string description,DateTime createDate, DateTime endDate, bool complete)
    {
        id = targets.Count;
        this.name = name;
        this.description = description;
        this.endDate = endDate;
        this.createDate = createDate;
        this.complete = complete;
        targets.Add(this);
    }


    override public string ToString()
    {
        string stat = this.complete ? "Comp" : "NComp";
        if (inFocus)
        {
            return $"▓ {id} \t| {name} | {endDate} \n▓ {stat}\t| {description}\n";
        }

        return $"░ {id} \t| {name} | {endDate} \n░ {stat}\t| {description}\n";
    }





    private static string FormatData()
    {
        string data = JsonSerializer.Serialize<List<Target>>(Target.targets);
        return data;
    }

    
    public static void SaveToFile()
    {
        string userFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        string path = Path.Combine(userFolder, "AppData\\Local\\data.targ");
        File.WriteAllText(path, FormatData());
    }

    public static void LoadFromFile()
    {
        string userFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        string path = Path.Combine(userFolder, "AppData\\Local\\data.targ");
        if (File.Exists(path))
        {
            string data = File.ReadAllText(path);
            Target.targets = JsonSerializer.Deserialize<List<Target>>(data);
        }
    }
}