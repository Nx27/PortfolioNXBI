namespace Portfolio.Logic.CS
{
  public class ProjectDetails
  {
    private static List<ProjectDetails> AllProjects = new();
    public readonly string Name;
    public readonly string Description;
    public readonly string Url;
    public readonly string ImageUrl;
    public readonly string ProgrammingLanguage;
    public readonly string Time;
    public ProjectDetails(string name, string description, string url, string imageUrl, string programmingLanguage, string time)
    {
      Name = name;
      Description = description;
      Url = url;
      ImageUrl = imageUrl;
      ProgrammingLanguage = programmingLanguage; 
      Time = time;
      AllProjects.Add(this);
    }

    public static List<ProjectDetails> GetAllProjects()
    {
      if (AllProjects.Count == 0)
      {
        new ProjectDetails("404", "404", "404", "404", "404", "404");
      }
      return AllProjects;
    }
  }
}
