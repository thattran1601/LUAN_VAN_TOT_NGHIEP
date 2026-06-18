using UnityEngine;

[CreateAssetMenu(fileName = "ChestData", menuName = "Gacha/Chest Data")]
public class ChestData : ScriptableObject
{
    public string chestName;
    public Sprite chestIcon;

    public int priceGold;
    public int priceGem;

    public GachaReward[] rewards;
}