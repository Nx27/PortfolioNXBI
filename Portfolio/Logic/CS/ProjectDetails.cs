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
        //new ProjectDetails("The Journey", "My first console app in NodeJS", "TheJourney", "images/logos/Artboard1.svg", "JS", "1 Week", "404");
        //new ProjectDetails("First basic website", "First web project I ever made", "TheJourney", "404", "HTML, CSS", "1 Week", "404");
        //new ProjectDetails("ColorTD", "Small tower defense game", "ColorTD", "", "C#, UnityEngine, ", "6 Weeks", "404");
        //new ProjectDetails("Hollow Knight Slice", "A copy of a small part of the game", "HollowKnightSlice", "404", "C#, UnityEngine", "4 Weeks", "404");
        //new ProjectDetails("Siepie and Takkie", "An international collaboration project between Sweden and the Netherlands", "SiepieAndTakkieOriginal", "404", "C#, UnityEngine", "3 Weeks", "404");
        new ProjectDetails("Siepie and Takkie Dialog system", "Finishing the dialog system for the orgiginal", "Projects/SiepieAndTakkieDialogSystem", "images/projects/SiepieAndTakkieDialogDummy.png", new string[] { "C#", "Unity", "Jira" }, "6 Weeks", "https://github.com/Entropy-Entertainment/Siepie");
        new ProjectDetails("Portfolio", "My personal portfolio website", "Projects/Portfolio", "404", new string[] { "C#", "Blazor", "CSS" }, "2 Weeks", "404");
      }
      return AllProjects;
    }
  }
}
