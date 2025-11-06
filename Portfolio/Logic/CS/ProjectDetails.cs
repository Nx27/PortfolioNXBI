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
    public readonly string Time;
    public readonly string LinkToProject;
    public readonly Dictionary<FilterOptions, string[]> Tags;

    public enum FilterOptions
    { 
      Languages,
      Software,
      Frameworks
    }


    public ProjectDetails(string name, string description, string url, string imageUrl,  string time, string linkToProject, Dictionary<FilterOptions, string[]> tags)
    {
      Name = name;
      Description = description;
      Url = url;
      ImageUrl = imageUrl;
      Time = time;
      LinkToProject = linkToProject;
      Tags = tags;
      AllProjects.Add(this);
    }

    public static List<ProjectDetails> GetAllProjects()
    {
      if (AllProjects.Count == 0)
      {
        new ProjectDetails("The Journey", "My first console app in NodeJS", "Projects/TheJourney", "images/projects/Nathan.png", "1 Week", "https://github.com/Nx27-ma/BO-textbased-application/", new Dictionary<FilterOptions, string[]>() { { FilterOptions.Languages, ["JavaScript"] }, { FilterOptions.Frameworks, ["NodeJS"] }, {FilterOptions.Software, ["Paint.net"] } });
        new ProjectDetails("First basic website", "First web project I ever made", "https://37214.hosts2.ma-cloud.nl/Module2.1/Skill/LandingPage", "images/projects/dizzy.png", "1 Week", "404", new Dictionary<FilterOptions, string[]>() { { FilterOptions.Languages, ["HTML, CSS"] } });
        new ProjectDetails("ColorTD", "Small tower defense game", "Projects/ColorTD", "images/projects/ColorTD.png", "6 Weeks", "https://github.com/Nx27-ma/colorTD", new Dictionary<FilterOptions, string[]>() { { FilterOptions.Languages, ["C#"] } });
        new ProjectDetails("Hollow Knight Slice", "A copy of a small part of the game", "Projects/HollowKnightSlice", "images/projects/HK.jpg", "4 Weeks", "https://github.com/Entropire/HungryNight", new Dictionary<FilterOptions, string[]>() { { FilterOptions.Languages, ["C#"] } });
        new ProjectDetails("Siepie and Takkie", " A project with Swedes and the Dutch", "Projects/SiepieAndTakkieOriginal", "images/projects/SiepieTakkiePoster.png", "3 Weeks", "https://github.com/Nx27-ma/siepie", new Dictionary<FilterOptions, string[]>() { { FilterOptions.Languages, ["C#"] } });
        new ProjectDetails("Entropy Jam", "A game jam I hosted", "Projects/EntropyJam", "images/projects/EntropyJam.jpg", "3 day", "", new Dictionary<FilterOptions, string[]>() { { FilterOptions.Languages, [] } });
        new ProjectDetails("Siepie and Takkie Dialog system", "Finishing the dialog system", "Projects/SiepieAndTakkieDialogSystem", "images/projects/SiepieTakkiePoster.png", "6 Weeks", "https://github.com/Entropy-Entertainment/Siepie", new Dictionary<FilterOptions, string[]>() { { FilterOptions.Languages, ["C#, USS"] }, { } });
        new ProjectDetails("Portfolio", "My personal portfolio website", "Projects/Portfolio", "images/projects/BlazorIcon.png", "Forever I suppose", "https://github.com/Nx27/PortfolioNXBI", new Dictionary<FilterOptions, string[]>() { { FilterOptions.Languages, ["C#, Razor, HTML, CSS"] } });
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
