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
        new ProjectDetails("The Journey", "My first console app in NodeJS", "TheJourney", "images/logos/Artboard1.svg", "JS", "1 Week");
        new ProjectDetails("First basic website", "First web project I ever made", "TheJourney", "404", "HTML, CSS", "1 Week");
        new ProjectDetails("ColorTD", "Small tower defense game", "ColorTD", "", "C#, UnityEngine, ", "6 Weeks");
        new ProjectDetails("Hollow Knight Slice", "A copy of a small part of the game", "HollowKnightSlice", "404", "C#, UnityEngine", "4 Weeks");
        new ProjectDetails("Siepie and Takkie", "An international collaboration project between Sweden and the Netherlands", "SiepieAndTakkieOriginal", "404", "C#, UnityEngine", "3 Weeks");
        new ProjectDetails("Siepie and Takkie Dialog system", "Finishing the dialog system for the orgiginal", "SiepieAndTakkieDialogSystem", "images/projects/SiepieAndTakkieDialogDummy.png", "C#, UnityEngine", "6 Weeks");
        new ProjectDetails("Portfolio", "My personal portfolio website", "Portfolio", "404", "C#, ASP.NET Core, Blazor WASM, HTML, CSS", "2 Weeks");
      }
      return AllProjects;
    }
  }
}
