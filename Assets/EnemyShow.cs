using UnityEngine;

public class EnemyShow : MonoBehaviour
{
    public EnemyData[] enemyDatas;
    public Transform content;
    public GameObject PrelafUI;
    void Start()
    {
        showEnemy();
        var firtchil = content.GetChild(0).GetComponent<EncyclopediaItem>();
        EncyclopediaManager.Instance.SelectItem(firtchil);
        EncyclopediaManager.Instance.show(enemyDatas[0]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void showEnemy()
    {
        for(int i=0;i<enemyDatas.Length;i++)
        {
            GameObject ojb = Instantiate(PrelafUI, content);
            ojb.GetComponent<EncyclopediaItem>().setup(enemyDatas[i]);
        }
       
    }
}
