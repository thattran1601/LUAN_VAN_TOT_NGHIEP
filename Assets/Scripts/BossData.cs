using UnityEngine;

[CreateAssetMenu(fileName = "BossData", menuName = "Game Data/Boss")]
public class BossData : ScriptableObject
{
    public string BossName;
    public int hp;
    public int damage;
    public string speed;
    public Sprite icon;
    public string skill;
    public string Counter;
    public string Giamthuong;
}