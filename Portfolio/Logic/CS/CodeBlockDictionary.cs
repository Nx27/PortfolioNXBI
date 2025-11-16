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
        public class PlayerInteractor_OnInteract_Range : InputTestFixture
        {
          GameObject stubPlayer;
          GameObject stubNpc;
          PlayerInteractor playerInteractor;
          Action<GameObject, GameObject> interactionHandler;
          bool playerInteractFired = false;

          [UnitySetUp]
          public IEnumerator TestSetup()
          {
            yield return SceneManager.LoadSceneAsync("GeneralTestScene", LoadSceneMode.Single);

            yield return null;
          }

          void setupInScene()
          {
            // Create dummy NPC to interact with
            stubNpc = new GameObject("StubNpc");
            stubNpc.AddComponent<NpcInteract>();

            // In the test scene, there is a Player object already
            stubPlayer = GameObject.Find("Player");
            Assert.IsNotNull(stubPlayer, "Player GameObject not found in GeneralTestScene");

            if (!stubPlayer.TryGetComponent<PlayerInteractor>(out playerInteractor))
              playerInteractor = stubPlayer.AddComponent<PlayerInteractor>();
            // Set interaction distance || make sure its not zero
            playerInteractor.InteractDistance = 2.0f;
            // Refresh IInteractableObjects list
            playerInteractor.InteractableObjects = IInteractable.GetAllInteractableItems();

            // Subscribe to PlayerInteract event to see that when it fires 
            interactionHandler = (player, interactedObject) => playerInteractFired = true;
            PlayerInteractor.PlayerInteract += interactionHandler;

            // Set locations outside of interaction range
            stubPlayer.transform.position = Vector3.zero;
            stubNpc.transform.position = new Vector2(playerInteractor.InteractDistance, 0) + Vector2.right;
          }

          [UnityTest]
          public IEnumerator PlayerInteractor_Range_Mono()
          {
            // Arrange
            setupInScene();
            var movePositionAmount = new Vector3(2, 0);

            // Act & Assert
            Assert.IsNotNull(stubPlayer, "Player object not found in scene!");
            Assert.IsNotNull(stubNpc, "NPC object not found in scene!");
            Assert.IsNotNull(playerInteractor.InteractableObjects, "No interactables in scene for test");

            Assert.GreaterOrEqual(Vector3.Distance(stubPlayer.transform.position, stubNpc.transform.position), playerInteractor.InteractDistance);
            Debug.Log($"{playerInteractor.gameObject} shouldn't find anything here ignore the debug log");
            playerInteractor.OnInteract();
            Assert.IsFalse(playerInteractFired, "Npc is in range before moving - how did that happen?");

            stubPlayer.transform.position += movePositionAmount;
            Assert.LessOrEqual(Vector3.Distance(stubPlayer.transform.position, stubNpc.transform.position), playerInteractor.InteractDistance, "Player not in range after moving in test");
            playerInteractor.OnInteract();
            Assert.IsTrue(playerInteractFired, "PlayerInteract event did not fire when in range");

            yield return null;
          }

          [TearDown]
          public void Teardown()
          {
            UnityEngine.Object.Destroy(stubNpc);
            PlayerInteractor.PlayerInteract -= interactionHandler;
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
      }
    };
  }
}

