namespace Netherlands
{
  public class Nora : GameDeveloper
  {
    public short Age = 19;
    public List<IHobbies> Hobbies = new() { "Gaming", "Archery", "Drawing", new LearningLanguages("Dutch", "English", "Swedish") };
  }
}


public class GameDeveloper : AllRoundSoftwareDeveloper
{
  public void GameDevPreferences()
  {
    Console.WriteLine("I love making games, especially 2D platformers!");
    Console.WriteLine("My favorite game engine to work with is Unity, " +
      "mainly because of its versatility and large community");
  }
}


public class AllRoundSoftwareDeveloper()
{
  protected virtual string MainLanguage => "C#";
  internal string LanguagesList => "C#, Css, Blazor";
  protected string[] SomeExperience => new string[] { "JavaScript", "Cpp" };

  protected void CodePreferences()
  {
    Console.WriteLine("I prefer coding in " + MainLanguage);
    Console.WriteLine($"Although Frontend web development is fun too, I maily use {LanguagesList[2]} (WebAssembly ASP.NET)"));
  }

  public static void WorkMethods()
  {
    Console.WriteLine("I like Agile it keeps the planning clean, " +
      "I mainly use Trello for small less serious projects and Jira for the more serious projects");
    Console.WriteLine("I try to stay up to date with what the market wants from me, " +
      "Through social media most of the time or just by chatting with colleagues");
  }
}

public class LearningLanguages() : IHobbies
{
  private string[] languages;
  public LearningLanguages(params string[] languages)
  {
    foreach (var language in languages)
    {
      this.languages.Append(language);
    }
  }

  public string ActivelyLearning()
  {
    return "Swedish";
  }
  public string[] ListSkills()
  {
    return new string[] { "Dutch", "English" };
  }
}

public class Drawing()
{
  private static Drawing instance = null;
  public static Drawing Instance
  {
    get
    {
      if (instance == null)
      {
        instance = new Drawing();
      }
      return instance;
    }
  }
}




public interface IHobbies
{
  public string[] ListSkills();
}
