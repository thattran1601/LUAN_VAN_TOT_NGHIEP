using UnityEngine;

public class BossManger : MonoBehaviour
{
    public static BossManger instance;
    public Transform SpawnPosition;
    public GameObject PrelafBoss;
    public int spawn=1;
    public bool IsBoss;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void spawnBoss()
    {
        if (GameManager.instance.IsWin)
            return;
        if (UISetting.intance.isSetting == true)
            return;
        IsBoss = true;
        StartCoroutine(CameraShake.instance.camerashake(0.5f, 0.15f));
        Instantiate(PrelafBoss, SpawnPosition.position, Quaternion.identity);
       
    }
    public void BossDie()
    {
        IsBoss= false;
    }    
}
