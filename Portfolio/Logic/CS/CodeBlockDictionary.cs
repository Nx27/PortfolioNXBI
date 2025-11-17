using Microsoft.AspNetCore.Components.Routing;
using Portfolio.Components;
using Portfolio.Logic.CS;
using Portfolio.Pages;
using System;
using static System.Net.Mime.MediaTypeNames;

namespace Portfolio.Logic.CS
{
  public record CodeBlockDictionary
  {
    public static readonly Dictionary<string, string> CodeBlocks = new()
    {
      {
        "UnitTest",
        """
        public class Deserializer_HandlesJson
        {
          string jsonResourceAPIpath = "DialogData";
        
          [TestCase(typeof(DialogData))]
          public void Deserializer_GivesTypeBackBasedOnClassGeneric(Type type)
          {
            //Arrange
            SceneManager.LoadScene("GeneralTestScene", LoadSceneMode.Single);
            Type expectedType = type;
            Type actualType;
            Deserializer<DialogData> deserializer = new(jsonResourceAPIpath, SceneManager.GetActiveScene().name);
            deserializer.ResourcesAPILoader();
            var jsonTextFile = deserializer.GetCurrentlyAssignedJson();
        
            //Act
            actualType = deserializer.GetDeserializedObject().GetType();
        
            //Assert
            Assert.AreEqual(expectedType, actualType);
          }
        
          [TestCase(typeof(DialogData))]
          public void Deserializer_CanGiveObjectBackFromValidJson(Type type)
          {
            //Arrange
            SceneManager.LoadScene("GeneralTestScene", LoadSceneMode.Single);
            Deserializer<DialogData> deserializer = new(jsonResourceAPIpath, SceneManager.GetActiveScene().name);
        
            deserializer.ResourcesAPILoader();
            var jsonTextFile = deserializer.GetCurrentlyAssignedJson();
            //Act
            var deserializedObject = deserializer.GetDeserializedObject();
            //Assert
            Assert.IsNotNull(deserializedObject);
            Debug.Print(deserializedObject.ToString());
          }
        }
        
        """
      },
      {
        "PortfolioGrid",
        """
        @using System.Threading.Tasks
        @inject IJSRuntime JS

        <div class="ProjectsTimeline">
        <div class="Middle">
        <h1 style="white-space: nowrap; text-align:center; margin-top: var(--GeneralMargin);">My whole programming career so far</h1>
        <span />
        </div>

        @for (int j = projectDetails.Count - 1; j >= 0; j--)
        {
        var i = j;
        Console.Write(projectDetails.Count);
        Console.Write(i);
        <div class="leftright1">
        @if ((i + 1) % 2 == 1)
        {
        <div class="TimeInfo">
          <p>@projectDetails[i].Time</p>
        </div>
        <span />
        }
        else
        {
        <NavLink href="@projectDetails[i].Url">
          <div class="ProjectDetails" style="background-image: url(@projectDetails[i].ImageUrl)">
            <div class="ProjectDescription">
              <ButtonStickyNote Text="@projectDetails[i].Name" />
              <ButtonStickyNote Text="@projectDetails[i].Description" />
            </div>
          </div>
        </NavLink>
        <span />
        }
        </div>

        <div class="Middle"><span /></div>

        <div class="leftright0">
        @if ((i + 1) % 2 == 1)
        {
        <NavLink href="@projectDetails[i].Url">
          <div class="ProjectDetails" style="background-image: url(@projectDetails[i].ImageUrl)">
            <div class="ProjectDescription">
              <ButtonStickyNote Text="@projectDetails[i].Name" />
              <ButtonStickyNote Text="@projectDetails[i].Description" />
            </div>
          </div>
        </NavLink>
        <span />
        }
        else
        {
        <div class="TimeInfo">
          <p>@projectDetails[i].Time</p>
        </div>
        <span />
        }
        </div>
        }

        <h1 class="Middle" style="white-space: nowrap; text-align:center; margin-top: var(--GeneralMargin);">Start of my career</h1>
        </div>
        """

  },
      {
        "InstantDontDestroyOnLoad",
        """
        void Start()
        {
          DontDestroyOnLoad(this.gameObject);
          SetDeserializer(new Deserializer<DialogData>(DialogFilePath, SceneManager.GetActiveScene().name));
          SceneManager.activeSceneChanged += LoadNewSceneDialog;
        }
        """
      },
      {
        "DialogData",
        """
          [Serializable]
          public class DialogData
          {
            public DialogLine[] Lines;
            [Serializable]
              public class DialogLine : IDialogLine
              {
                public string Speaker { get; set; }
                public int UID { get; set; }
                public int SequenceID { get; set; }
                public string Dialog { get; set; }
              }
          }
        """
      },
      {
        "UIDSequenceManagerQuery",
        """
        void Start()
        {
          speakerLeftImage = UI.rootVisualElement.Q<Image>("Person1");
          speakerRightImage = UI.rootVisualElement.Q<Image>("Person2");
          currentSpeaker = UI.rootVisualElement.Q<Label>("CurrentlySpeaking");
          dialogTextDisplay = UI.rootVisualElement.Q<Label>("Text");
          speakerLeft = UI.rootVisualElement.Q<Label>("SpeakerLeft");
          speakerRight = UI.rootVisualElement.Q<Label>("SpeakerRight");
          UI.rootVisualElement.style.display = DisplayStyle.None;
        }
        """
      },
      {
        "JsonExampleDialogData",
        "Example Json file:\n" +
       "{\r\n" +
   "  \"Lines\": [\r\n" +
   "    {\r\n" +
   "      \"Speaker\": " +
   "\"NPC\",\r\n" +
   "      \"UID\": 0,\r" +
   "\n" +
   "      \"SequenceID\"" +
   ": 0,\r\n" +
   "      \"Dialog\": \"" +
   "Is een boterham met " +
   "kaas en worst een ra" +
   "uwe tosti?\"\r\n" +
   "    },\r\n" +
   "    {\r\n" +
   "      \"Speaker\": " +
   "\"PLAYER\",\r\n" +
   "      \"UID\": 0,\r" +
   "\n" +
   "      \"SequenceID\"" +
   ": 1,\r\n" +
   "      \"Dialog\": \"" +
   "Hoe bedoel je?\"\r\n" +
   "    },\r\n" +
   "    {\r\n" +
   "      \"Speaker\": " +
   "\"NPC\",\r\n" +
   "      \"UID\": 0,\r" +
   "\n" +
   "      \"SequenceID\"" +
   ": 2,\r\n" +
   "      \"Dialog\": \"" +
   "Nou, een tosti is ee" +
   "n getoaste boterham " +
   "met ham en gesmolte " +
   "kaas, maar wat nou a" +
   "ls ik een boterham m" +
   "aak zonder hem in ee" +
   "n tosti ijzer te sto" +
   "ppen? Hoe zou ik dat" +
   " dan noemen?\"\r\n" +
   "    }\n" +
   "  ]\n" +
   "}\n"
      },
      {
        "UID",
        """
        public int UID { get; set; }
        """
      },
      {
        "SequenceID",
        """
        public int SequenceID { get; set; }
        """
      },
      {
        "Speaker",
        """
        public int Speaker { get; set; }
        """
      },
      {
        "staticwebconfig",
        "        \"\"\"\r\n" +
   "        {\r\n" +
   "          \"navigati" +
   "onFallback\": {\r\n" +
   "          \"rewrite" +
   "\": \"/index.html\"" +
   "\r\n" +
   "          }\r\n" +
   "        }\r\n\r\n" +
   "        \"\"\""
      }
    };
  }
}

