using UnityEngine;

public class SkillKhien : SkillBase
{
    public GameObject Khien;
    public Transform Khientarget;

    private void Start()
    {
    }
    public override void Cast(Vector3 position)
    {
        Instantiate(Khien, Khientarget.position, Quaternion.identity);
        Heals_Thanh[] heals = FindObjectsOfType<Heals_Thanh>();
        foreach(Heals_Thanh heal in heals)
        {
           StartCoroutine( heal.Giamdame());
        }
    }
}