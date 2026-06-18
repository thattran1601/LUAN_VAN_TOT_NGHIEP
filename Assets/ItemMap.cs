using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class ItemMap : MonoBehaviour
{
    public static ItemMap Instance;
    public MapData[] mapDatas;
    int count = 0;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public List<RewardResult> AddItemWin(MapData mapdata)
    {
      
        int AmountCoin=Random.Range(mapdata.CoinMin, mapdata.CoinMax);
        CoinManger.Instance.AddCoin(AmountCoin);
        List<RewardResult> results = new List<RewardResult>();
        foreach(RewardData reward in mapdata.Items)
        {
            int Amount = Random.Range(reward.minAmount, reward.maxAmount+1);
            if(Amount>0)
            {
                SaveGameManager.instance.AddItem(reward.item.Id, Amount);
                results.Add(new RewardResult(reward.item, Amount));

            }
        }
        return results;
    }    
}
