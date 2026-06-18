using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShowItemVictory : MonoBehaviour
{
    public Image[] images;
    public Image[] Viens;
    public TextMeshProUGUI TextCoin;
    public TextMeshProUGUI[] texts;

    public void ShowItem(List<RewardResult> rewards,MapData mapData)
    {
        int randomCoin = Random.Range(mapData.CoinMin,mapData.CoinMax);
        Debug.Log(randomCoin);
        TextCoin.text=randomCoin.ToString();
        Debug.Log("ShowItem Count = " + rewards.Count);
        for (int i = 0; i < images.Length; i++)
        {
            if ( rewards!=null &&i < rewards.Count)
            {
                Viens[i].gameObject.SetActive(true);
                images[i].gameObject.SetActive(true);
                texts[i].gameObject.SetActive(true);

                images[i].sprite = rewards[i].item.Item;
                texts[i].text = rewards[i].amount.ToString();
        }
            else
        {
            Viens[i].gameObject.SetActive(false);
            images[i].gameObject.SetActive(false);
            texts[i].gameObject.SetActive(false);
        }
    }
    }

}
