using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName ="NewUnit",menuName ="Game/Unit Data")]
public class UnitData : ScriptableObject
{
    public GameObject prelaf;
    public Sprite icon;
    public string Name;
    public int Id;
    public int cost;
    public int Cooldown;
    public int Hp;
    public int dame;
}
