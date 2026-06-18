using UnityEngine;

public class ShowBoss : MonoBehaviour
{
    public BossData[] bossDatas;
    public GameObject bossPrefab;
    public Transform content;
    void Start()
    {
        showDanhsach();
        var firstlist = content.GetChild(0).GetComponent<EncyclopediaItem>();
        EncyclopediaManager.Instance.SelectItem(firstlist);
        EncyclopediaManager.Instance.showBoss(bossDatas[0]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void showDanhsach()
    {
        for(int i=0;i<bossDatas.Length;i++)
        {
            GameObject ojb = Instantiate(bossPrefab,content);
            ojb.GetComponent<EncyclopediaItem>().setupboss(bossDatas[i]);
        }    
    }    
}
