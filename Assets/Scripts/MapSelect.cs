using UnityEngine;
using UnityEngine.SceneManagement;

public class MapSelect : MonoBehaviour
{
    public static MapSelect instance;

    public GameObject Wated;
    public GameObject Panel;
    public GameObject MapItem;
    public Transform content;
    public MapData[] mapdata;
    public UnitData[] unitDatas;
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        if (Panel != null)
            Panel.SetActive(false);

        if (Wated != null)
            Wated.SetActive(false);

        if (content == null)
        {
            Debug.LogError("Chưa kéo Content vào");
            return;
        }

        if (MapItem == null)
        {
            Debug.LogError("Chưa kéo MapItemPrefab vào");
            return;
        }

        if (mapdata == null || mapdata.Length == 0)
        {
            Debug.LogError("Chưa kéo MapData vào mảng mapdata");
            return;
        }

        CreateMapItems();
    }

    private void CreateMapItems()
    {
        foreach (MapData map in mapdata)
        {
            if (map == null)
                continue;

            GameObject obj = Instantiate(MapItem, content);
            MapItemUI itemUI = obj.GetComponent<MapItemUI>();

            if (itemUI != null)
            {
                itemUI.setup(map);
            }
            else
            {
                Debug.LogError("MapItem prefab chưa có script MapItemUI");
            }
        }
    }

    public void mapselect(int mapId)
    {
        PlayClickSound();

        if (SaveGameManager.instance == null)
        {
            Debug.LogError("SaveGameManager chưa tồn tại trong scene đầu tiên");
            return;
        }

        int mapUnlocked = SaveGameManager.instance.GetUnlockMap();
        TeamLoader.LoadTeamToGameData(unitDatas);

        if (mapId <= mapUnlocked)
        {
            if (GameData.UnitData == null || GameData.UnitData.Count == 0)
            {
                if (Panel != null)
                    Panel.SetActive(true);

                return;
            }

            GameData.MapInt = mapId;
            LoadSceneSafe("GamePlay");
        }
        else
        {
            if (Wated != null)
                Wated.SetActive(true);
        }
    }

    public void OK()
    {
        PlayClickSound();

        if (Wated != null)
            Wated.SetActive(false);
    }

    public void ButtonOK()
    {
        PlayClickSound();

        if (Panel != null)
            Panel.SetActive(false);
    }

    private void PlayClickSound()
    {
        if (AudioManager.instance != null)
        {
            AudioManager.instance.PlaySFX(AudioManager.instance.ButtonClick);
        }
    }

    private void LoadSceneSafe(string sceneName)
    {
        if (SceneTransition.Instance != null)
        {
            SceneTransition.Instance.LoadSceneManager(sceneName);
        }
        else
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}