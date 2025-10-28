namespace Portfolio.Logic.CS
{
  public record CodeBlockDictionary
  {
    public static readonly Dictionary<string, string> CodeBlocks = new()
    {
      {
        "DialogDeserializer",
       @"public class DialogDeserializer : Deserializer<DialogData>
{
  public string DialogFilePath { get => dialogFilePath; private set => dialogFilePath = value; }
  string dialogFilePath = ""DialogData/"";

  public DialogDeserializer(string resourcesApiPath) : base(resourcesApiPath)
  {
    SceneManager.activeSceneChanged += LoadNewSceneDialog;
    Debug.Log($""DialogDeserializer initialized with path: {resourcesApiPath}"");
  }

  void LoadNewSceneDialog(Scene current, Scene next)
  {
    Debug.Log($""Scene changed from {current.name} to {next.name}"");
    dialogFilePath = resourcesApiPath = dialogFilePath + next.name;

    ResourcesAPILoader();
    if(jsonTextFile != null)
    {
      GetDeserializedObject();
    }
  }
}"
      },
      {
        "AnotherBlock",
        """
        public int Add(int a, int b)
        {
            return a + b;
        }
        """
      }
    };
  }
}
