namespace TaskManager;

public class Target
{
    public static List<Target> targets = new List<Target>();
    
    private int id { get; }
    private string name { get; set; }
    private string description { get; set; }
    private DateTime createDate { get; set; }
    private DateTime endDate { get; set; }
    public bool inFocus = false;
    public bool сomplete = false;

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
    
    public Target(string name, string description,DateTime createDate, DateTime endDate)
    {
        id = targets.Count;
        this.name = name;
        this.description = description;
        this.endDate = endDate;
        this.createDate = createDate;
        targets.Add(this);
    }
    

    override public string ToString()
    {
        if (inFocus)
        {
            return $"▓ {id} \t| {name} | {endDate} \n▓ \t| {description}\n";
        }
        return $"░ {id} \t| {name} | {endDate} \n░ \t| {description}\n";
    }

    private static string FormatData()
    {
        string data = "";
        foreach (Target target in targets)
        {
            data += target.name + "|" + target.description + "|" + 
                    target.createDate + "|" + target.endDate + "\n";
        }
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
            string[] data = File.ReadAllText(path).Split('\n');
            foreach (string line in data)
            {
                try
                {
                    string[] lineData = line.Split('|');
                    Target tar = new Target(lineData[0], lineData[1], DateTime.Parse(lineData[2]),
                        DateTime.Parse(lineData[3]));
                } catch (IndexOutOfRangeException) {break;}
            }
        }
    }
}