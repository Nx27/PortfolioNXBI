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
   "{\r\n" +
   "  \"navigati" +
   "onFallback\": {\r\n" +
   "    \"rewrite" +
   "\": \"/index.html\"" +
   "\r\n" +
   "    }\r\n" +
   "}"
      },
      {
        "loadingScreenInterface",
        "public interface ILoadable\n{\n    public bool IsInitialized { get; }\n    public event Action CompletedInit;\n}\n"
},
      {
        "loadingScreenSceneLoad",
        "yield return SceneManager.LoadSceneAsync(_sceneName, LoadSceneMode.Single);"
      }
      ,
      {
        "loadingScreenYieldAll",
        "List<ILoadable> subscribableObjects = new();\n        int finished = 0;\n        int totalLoadables = 0;\n        foreach (GameObject gameObject in UnityEngine.Object.FindObjectsByType<GameObject>(FindObjectsSortMode.None))\n            if (gameObject.TryGetComponent<ILoadable>(out var subscribableObject))\n                if (!subscribableObject.IsInitialized)\n                {\n                    totalLoadables++;\n                    Coroutine _c = CoroutineRunner.Run(aggregate(subscribableObject));\n                    if (subscribableObject.IsInitialized)\n                    {\n                        finished++;\n                        CoroutineRunner.Stop(_c);\n                    }\n\n                    subscribableObjects.Add(subscribableObject);\n                }\n\n        Debug.Log($\"Total loadables: {totalLoadables}\");\n        Debug.Log(\"Got items\");\n\n        IEnumerator aggregate(ILoadable loadable)\n        {\n            bool done = false;\n\n            void completionChecker()\n            {\n                done = true;\n            }\n\n            loadable.CompletedInit += completionChecker;\n\n            if (loadable.IsInitialized)\n            {\n                Debug.Log(\"Broke aggregation early\");\n                loadable.CompletedInit -= completionChecker;\n                finished++;\n                yield break;\n            }\n\n            yield return new WaitUntil(() => done);\n\n            loadable.CompletedInit -= completionChecker;\n\n            finished++;\n            Debug.Log(\"Finished aggregation\");\n        }\n        Debug.Log($\"Waiting: {finished}/{totalLoadables}\");\n        yield return new WaitUntil(() => finished == totalLoadables);"
      },
      {
        "loadingScreenEvent",
        "FinishedLoading?.Invoke(subscribableObjects);;"
      },
      {
        "SetupChunkPool",
        "public IEnumerator SetupChunkPool(Biome biome = Biome.AllBiomes)\n{\n    if (_chunks != null)\n    {\n        yield break;\n    }\n\n    GameObject[] _resourceChunks;\n    _chunks = new();\n    foreach (Biome singleBiome in BiomeExtension.AllBiomes)\n    {\n        GameObject _biomeSortObject = new(singleBiome.ToString());\n        _biomeSortObject.transform.SetParent(ChunkContainer.transform);\n        if (biome.HasFlag(singleBiome))\n        {\n            _chunks.Add(singleBiome, new());\n            _resourceChunks = Resources.LoadAll<GameObject>($\"{ResourcesPath}/{singleBiome}\");\n            for (int i = 0; i < _resourceChunks.Length; i++)\n            {\n                IChunkData _chunkComponent;\n                if (!_resourceChunks[i].TryGetComponent(out _chunkComponent))\n                {\n                    Debug.LogWarning($\"Expected component {_chunkComponent} on preloaded chunk \'{_resourceChunks[i].name}\' but it was missing.\");\n                    continue;\n                }\n\n                yield return StartCoroutine(setReferences(_chunkComponent, _biomeSortObject.transform));\n            }\n        }\n    }\n\n    _resourceChunks = Resources.LoadAll<GameObject>($\"{ResourcesPath}/{TransitionalChunkPath}\");\n\n    foreach (Biome transitionBiome in _resourceChunks.Select(b => b.GetComponent<IChunkData>().Biomes).Distinct())\n    {\n        _chunks.Add(transitionBiome, new());\n    }\n\n    foreach (GameObject resourceChunk in _resourceChunks)\n    {\n        IChunkData _component = resourceChunk.GetComponent<IChunkData>();\n        yield return StartCoroutine(setReferences(_component, ChunkContainer.transform));\n    }\n\n    if (_chunks == null || _chunks.Count == 0)\n        throw new System.Exception(\"ChunkPool used the Resource folder but found nothing\");\n    CompletedInit?.Invoke();\n    IsInitialized = true;\n}"
      },
      {
        "CodeColliderTrimmer",
        "public class OutOfBoundsColliderRemoval : EditorWindow\n{\n    [SerializeField] EditorSaves editorSaves;\n    GameObject prefabToEdit, playerPrefab;\n    private Vector3 Start, End;\n    private static OutOfBoundsColliderRemoval instance;\n    private bool runOnce = true;\n\n    [MenuItem(\"Window/Custom Tools/Chunk Collider Trimmer\")]\n    public static void ShowWindow()\n    {\n        instance = GetWindow<OutOfBoundsColliderRemoval>(\"Collider Trimmer\");\n        instance.LoadData();\n    }\n\n    public static OutOfBoundsColliderRemoval Instance => instance ?? (instance = GetWindow<OutOfBoundsColliderRemoval>());\n    private void OnGUI()\n    {\n        var _startField = new Vector3Field(\"Start\") { value = Start };\n        var _endField = new Vector3Field(\"End\") { value = End };\n        ObjectField _playerPrefabField = new ObjectField(\"Player Prefab\")\n        {\n            objectType = typeof(GameObject),\n            value = playerPrefab,\n            label = \"Player Prefab\"\n        };\n        _playerPrefabField.RegisterValueChangedCallback(evt =>\n        {\n            playerPrefab = (GameObject)evt.newValue;\n            Start = playerPrefab.GetComponent<PlayerLocomotion>().StartPoint;\n            End = playerPrefab.GetComponent<PlayerLocomotion>().EndPoint;\n\n        });\n\n\n        _startField.RegisterValueChangedCallback(evt =>\n        {\n            Start = evt.newValue;\n        });\n\n        _endField.RegisterValueChangedCallback(evt =>\n        {\n            End = evt.newValue;\n        });\n\n        Button button = new Button(() =>\n                {\n                    if (playerPrefab == null && Start == Vector3.zero || End == Vector3.zero)\n                    {\n                        Debug.LogError(\"One or more required fields are missing.\" +\n                        \" Please assign player or trimming coordinates before trying to delete colliders colliders.\");\n                        return;\n                    }\n                    DeleteObjectsInRange();\n                })\n        {\n            text = \"Delete Colliders\"\n        };\n\n        if (runOnce)\n        {\n            rootVisualElement.Add(_playerPrefabField);\n            rootVisualElement.Add(_startField);\n            rootVisualElement.Add(_endField);\n            rootVisualElement.Add(button);\n            runOnce = false;\n        }\n    }\n    private void DeleteObjectsInRange()\n    {\n        AssetDatabase.StartAssetEditing();\n        Vector3 _center = (Start + End) * 0.5f;\n        var _allPrefabs = getAllPrefabs();\n        foreach (string path in _allPrefabs)\n        {\n            GameObject prefab = PrefabUtility.LoadPrefabContents(path);\n            Vector3 _halfExtents = new Vector3(\n                Mathf.Abs(Start.x - End.x),\n                Mathf.Abs(Start.y - End.y),\n                Mathf.Abs(9999)\n                ) * 0.5f;\n            Collider[] colliders = prefab.GetComponentsInChildren<Collider>(true);\n            Bounds _bounds = new Bounds(_center, _halfExtents * 2);\n            List<Collider> collidersToDelete = new List<Collider>(colliders);\n            foreach (Collider collider in colliders)\n            {\n                if (_bounds.Intersects(collider.bounds))\n                {\n                    collidersToDelete.Remove(collider);\n                }\n            }\n            foreach (Collider collider in collidersToDelete)\n            {\n                Undo.DestroyObjectImmediate(collider);\n\n            }\n            PrefabUtility.SaveAsPrefabAsset(prefab, path);\n            PrefabUtility.UnloadPrefabContents(prefab);\n        }\n        AssetDatabase.StopAssetEditing();\n    }\n\n    private List<string> getAllPrefabs()\n    {\n        string[] guids = AssetDatabase.FindAssets(\"t:Prefab\");\n        GameObject[] prefabs = new GameObject[guids.Length];\n        List<string> chunks = new List<string>();\n        for (int i = 0; i < guids.Length; i++)\n        {\n            string path = AssetDatabase.GUIDToAssetPath(guids[i]);\n            prefabs[i] = AssetDatabase.LoadAssetAtPath<GameObject>(path);\n            if (prefabs[i].TryGetComponent<ChunkLogic.ChunkData>(out ChunkLogic.ChunkData chunkData))\n            {\n                chunks.Add(path);\n            }\n        }\n        return chunks;\n    }\n\n    void OnDestroy()\n    {\n        SaveData();\n    }\n\n    private void SaveData()\n    {\n        editorSaves.playerLocoGUID = AssetDatabase.GetAssetPath(playerPrefab);\n    }\n\n    private void LoadData()\n    {\n        if (editorSaves != null)\n        {\n            playerPrefab = AssetDatabase.LoadAssetAtPath<GameObject>(editorSaves.playerLocoGUID);\n            Start = playerPrefab.GetComponent<PlayerLocomotion>().StartPoint;\n            End = playerPrefab.GetComponent<PlayerLocomotion>().EndPoint;\n        }\n    }\n}"
      }

    };
  }
}

