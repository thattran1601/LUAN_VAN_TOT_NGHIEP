using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MapItemUI : MonoBehaviour
{
    public Image Background;

    public Image[] EnemyImage;
    public Image[] EnemyVien;

    public Image Boss;
    public Button ButtonStart;

    public MapData currentMap;
    public TextMeshProUGUI NameMap;

    public GameObject PanelLock;
    public Image[] iconReward;

    public int MapId;

    public void setup(MapData data)
    {
        if (data == null)
        {
            Debug.LogError("MapData bị null");
            return;
        }

        currentMap = data;
        MapId = data.IdMap;

        LoadLockState(data);
        LoadBasicInfo(data);
        LoadRewardIcon(data);
        LoadEnemyIcon(data);
        SetupButton();
    }

    private void LoadLockState(MapData data)
    {
        int mapCurrent = 1;

        if (SaveGameManager.instance != null)
        {
            mapCurrent = SaveGameManager.instance.GetUnlockMap();
        }

        if (PanelLock != null)
        {
            PanelLock.SetActive(data.IdMap > mapCurrent);
        }
    }

    private void LoadBasicInfo(MapData data)
    {
        if (NameMap != null)
            NameMap.text = data.NameMap;

        if (Background != null)
            Background.sprite = data.Background;

        if (Boss != null)
            Boss.sprite = data.IconBoss;
    }

    private void LoadRewardIcon(MapData data)
    {
        if (iconReward == null)
            return;

        for (int i = 0; i < iconReward.Length; i++)
        {
            if (iconReward[i] == null)
                continue;

            bool hasReward =
                data.Items != null &&
                i < data.Items.Length &&
                data.Items[i] != null &&
                data.Items[i].item != null &&
                data.Items[i].item.Item != null;

            if (hasReward)
            {
                iconReward[i].sprite = data.Items[i].item.Item;
                iconReward[i].gameObject.SetActive(true);
            }
            else
            {
                iconReward[i].gameObject.SetActive(false);
            }
        }
    }

    private void LoadEnemyIcon(MapData data)
    {
        if (EnemyImage == null)
            return;

        for (int i = 0; i < EnemyImage.Length; i++)
        {
            if (EnemyImage[i] == null)
                continue;

            bool hasEnemyIcon =
                data.IconEnemy != null &&
                i < data.IconEnemy.Length &&
                data.IconEnemy[i] != null;

            if (hasEnemyIcon)
            {
                EnemyImage[i].sprite = data.IconEnemy[i];
                EnemyImage[i].gameObject.SetActive(true);

                if (EnemyVien != null && i < EnemyVien.Length && EnemyVien[i] != null)
                    EnemyVien[i].gameObject.SetActive(true);
            }
            else
            {
                EnemyImage[i].gameObject.SetActive(false);

                if (EnemyVien != null && i < EnemyVien.Length && EnemyVien[i] != null)
                    EnemyVien[i].gameObject.SetActive(false);
            }
        }
    }

    private void SetupButton()
    {
        if (ButtonStart == null)
            return;

        ButtonStart.onClick.RemoveAllListeners();
        ButtonStart.onClick.AddListener(Onclickbutton);
    }

    public void Onclickbutton()
    {
        if (currentMap == null)
        {
            Debug.LogError("currentMap bị null");
            return;
        }

        if (MapSelect.instance == null)
        {
            Debug.LogError("MapSelect.instance bị null");
            return;
        }

        MapSelect.instance.mapselect(currentMap.IdMap);
    }
}