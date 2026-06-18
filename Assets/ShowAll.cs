using UnityEngine;

public class ShowAll : MonoBehaviour
{
    public EnemyData[] enemyDatas;
    public BossData[] bossDatas;
    public GameObject PrelafUI;
    public Transform content;


    void Start()
    {
        ShowALL();
        var first=content.GetChild(0).GetComponent<EncyclopediaItem>();
        EncyclopediaManager.Instance.SelectItem(first);
        EncyclopediaManager.Instance.showBossAll(bossDatas[0]);
    }

    // Update is called once per frame
    void Update()
    {
     
    }
    public void ShowALL()
    {
        for (int i = 0; i < bossDatas.Length; i++)
        {
            GameObject ojb = Instantiate(PrelafUI, content);
            ojb.GetComponent<EncyclopediaItem>().setupbossAll(bossDatas[i]);
        }
        for (int i=0;i<enemyDatas.Length;i++)
        {
            GameObject ojb = Instantiate(PrelafUI,content);
            ojb.GetComponent<EncyclopediaItem>().setupAll(enemyDatas[i]);
        } 
         
    }    
}
