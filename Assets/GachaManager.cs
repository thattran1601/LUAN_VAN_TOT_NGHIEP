using UnityEngine;

public class GachaManager : MonoBehaviour
{
    public static GachaManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public GachaReward RollOne(ChestData chest)
    {
        if (chest == null)
            return null;

        if (chest.rewards == null || chest.rewards.Length == 0)
            return null;

        GachaReward reward = GetRandomReward(chest);
        GiveReward(reward);

        return reward;
    }

    private GachaReward GetRandomReward(ChestData chest)
    {
        float totalRate = 0;

        foreach (GachaReward reward in chest.rewards)
            totalRate += reward.rate;

        float random = Random.Range(0, totalRate);
        float current = 0;

        foreach (GachaReward reward in chest.rewards)
        {
            current += reward.rate;

            if (random <= current)
                return reward;
        }

        return chest.rewards[0];
    }

    private void GiveReward(GachaReward reward)
    {
        if (reward == null)
            return;

        if (reward.item != null)
        {
            InventoryManager.Instance.AddItem(reward.item, reward.amount);
            Debug.Log("Đã thêm item: " + reward.item.Name + " x" + reward.amount);
        }

        if (reward.unit != null)
        {
            SaveGameManager.instance.LoadUnit(reward.unit.Id);
            SaveGameManager.instance.SaveUnit(reward.unit.Id,true);
            Debug.Log("Đã mở tướng: " + reward.unit.Name);
        }
    }
}