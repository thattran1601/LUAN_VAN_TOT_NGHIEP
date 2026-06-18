
using UnityEngine;

public class UnitUpgradeManager : MonoBehaviour
{
    public static UnitUpgradeManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public bool CanUpgrade(UnitData data, UnitRuntimeData runtime)
    {
        if (data == null || runtime == null) return false;

        if (runtime.Level >= data.LevelMax)
        {
            Debug.Log("Đã đạt cấp tối đa");
            return false;
        }

        int cost = data.Gold(runtime.Level);

        if (!CoinManger.Instance.HasCoin(cost))
        {
            Debug.Log("Không đủ vàng");
            return false;
        }

        MaterialCost[] materials = data.GetMaterialsCost(runtime.Level);

        if (materials != null)
        {
            foreach (MaterialCost material in materials)
            {
                if (material == null || material.item == null) continue;

                if (!InventoryManager.Instance.HasItem(material.item, material.amount))
                {
                    Debug.Log("Thiếu nguyên liệu: " + material.item.Name);
                    return false;
                }
            }
        }

        return true;
    }
    public bool Upgrade(UnitData data, UnitRuntimeData runtime)
    {
        if (!CanUpgrade(data, runtime)) return false;

        int cost = data.Gold(runtime.Level);

        MaterialCost[] materials = data.GetMaterialsCost(runtime.Level);

        if (materials != null)
        {
            foreach (MaterialCost material in materials)
            {
                if (material == null || material.item == null) continue;

                InventoryManager.Instance.RemoveItem(material.item, material.amount);
            }
        }

        CoinManger.Instance.RemoveCoin(cost);

        runtime.Level++;
        SaveGameManager.instance.SaveUnitLevel(runtime.UnitId,runtime.Level);
        DetailUnitUI.Intance.UnlockRelic(data);
        Debug.Log("Nâng cấp thành công: " + data.Name + " Lv." + runtime.Level);

        return true;
    }
    public void CLoseUpgrade()
    {
        SceneTransition.Instance.LoadSceneManager("Lobby");
    }    
}