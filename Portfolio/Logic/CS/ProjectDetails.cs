namespace Portfolio.Logic.CS
{
  //I'm aware that this isn't as pretty as a database but it works for me
  public record ProjectDetails
  {
    private static List<ProjectDetails> AllProjects = new();
    public readonly string Name;
    public readonly string Description;
    public readonly string Url;
    public readonly string ImageUrl;
    public readonly string[] SoftwareStack;
    public readonly string Time;
    public readonly string LinkToProject;
    public ProjectDetails(string name, string description, string url, string imageUrl, string[] softwareStack, string time, string linkToProject)
    {
      Name = name;
      Description = description;
      Url = url;
      ImageUrl = imageUrl;
      SoftwareStack = softwareStack; 
      Time = time;
      LinkToProject = linkToProject;
      AllProjects.Add(this);
    }

    public static List<ProjectDetails> GetAllProjects()
    {
      if (AllProjects.Count == 0)
      {
        new ProjectDetails("The Journey", "My first console app in NodeJS", "TheJourney", "images/logos/Artboard1.svg", new string[] { "JS" }, "1 Week", "404");
        new ProjectDetails("First basic website", "First web project I ever made", "TheJourney", "404", new string[]  { "HTML, CSS" }, "1 Week", "404");
        new ProjectDetails("ColorTD", "Small tower defense game", "ColorTD", "", new string[] { "C#, UnityEngine, " }, "6 Weeks", "404");
        new ProjectDetails("Hollow Knight Slice", "A copy of a small part of the game", "HollowKnightSlice", "404", new string[] { "C#, UnityEngine" }, "4 Weeks", "404");
        new ProjectDetails("Siepie and Takkie", " A project with Swedes and the Dutch", "SiepieAndTakkieOriginal", "404", new string[] { "C#, UnityEngine" }, "3 Weeks", "404");
        new ProjectDetails("Siepie and Takkie Dialog system", "Finishing the dialog system", "Projects/SiepieAndTakkieDialogSystem", "images/projects/SiepieAndTakkieDialogDummy.png", new string[] { "C#", "Unity", "Jira" }, "6 Weeks", "https://github.com/Entropy-Entertainment/Siepie");
        new ProjectDetails("Portfolio", "My personal portfolio website", "Projects/Portfolio", "images/projects/BlazorIcon.png", new string[] { "C#", "Blazor", "CSS" }, "2 Weeks", "404");
      }
      return AllProjects;
    }
    public static List<ProjectDetails> GetByNames(params string[] names)
    {
      GetAllProjects();

      var set = new HashSet<string>(names ?? Array.Empty<string>(), StringComparer.OrdinalIgnoreCase);
      return AllProjects.Where(p => set.Contains(p.Name)).ToList();
    }
  }
}
