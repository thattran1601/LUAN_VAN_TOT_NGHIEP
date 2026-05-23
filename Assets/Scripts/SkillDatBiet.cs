using System.Data;
using UnityEngine;

public class SkillDatBiet : MonoBehaviour
{
    public static SkillDatBiet Instance;
    public GameObject prelafLinhDacBiet;
    public Transform SpawnPosition;
    private void Awake()
    {
        Instance= this;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void buttonSkill()
    {
        
        Instantiate(prelafLinhDacBiet, SpawnPosition.position, Quaternion.identity);

    }
}
