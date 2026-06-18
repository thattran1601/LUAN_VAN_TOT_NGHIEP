using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UnitItemUI : MonoBehaviour
{

    public Image Icon;
    public TextMeshProUGUI TextLevel;
    public Button button;
    public UnitData unitData;

    public void Setup(UnitData data)
    {
        unitData = data;

        Icon.sprite = data.icon;
        UnitRuntimeData runtime = UnitOwnedManager.Instance.GetRuntime(data.Id);
        Debug.Log(runtime);
        TextLevel.text = "LV:" + runtime.Level;
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(OnlickDetail);
        RefreshUI();
    }
    public void OnlickDetail()
    {
        Debug.Log("da click");
        DetailUnitUI.Intance.OpenPanel(unitData);
    }
    public void RefreshUI()
    {
        if (unitData == null)
        {
            Debug.LogError("UnitItemUI: unitData đang null");
            return;
        }

        if (TextLevel == null)
        {
            Debug.LogError("UnitItemUI: Chưa gán TextLevel trong Inspector");
            return;
        }

        if (UnitOwnedManager.Instance == null)
        {
            Debug.LogError("UnitOwnedManager.Instance đang null. Hãy chạy từ Scene Main hoặc thêm UnitOwnedManager vào scene này.");
            TextLevel.text = "LV:1";
            return;
        }

        UnitRuntimeData runtime =
            UnitOwnedManager.Instance.GetRuntime(unitData.Id);

        if (runtime != null)
            TextLevel.text = "LV:" + runtime.Level;
        else
            TextLevel.text = "LV:1";
    }
}
