using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Game Data/Enemy")]
public class EnemyData : ScriptableObject
{
    public string enemyName;
    public int hp;
    public int damage;
    public string speed;
    public Sprite icon;
    public string GiamThuong;
    public string skill;
    public string Counter;
}