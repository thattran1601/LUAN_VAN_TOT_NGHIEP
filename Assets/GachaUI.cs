using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GachaUI : MonoBehaviour
{
    public static GachaUI instance;
    public GameObject PanelGacha;
    public GameObject PanelReward;
    public GameObject PanelShop;
    public GameObject PanelLuuY;
    public Image RewardIcon;
    public TextMeshProUGUI TextRewardName;
    public TextMeshProUGUI TextAmount;
    private GachaReward GachaCurrrent;
    public AnimtionGacha[] animator;
    public ChestData[] Chests;
    public int indexGacha;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        if (PanelReward != null)
            PanelReward.SetActive(false);
    }

    public void RollChest(int index)
    {
        indexGacha=index;
        if (index < 0 || index >= Chests.Length)
        {
            Debug.LogWarning("Sai index rương");
            return;
        }

        ChestData chest = Chests[index];

        if (chest.priceGold > 0)
        {
            if (CoinManger.Instance.Coin < chest.priceGold)
            {
                Debug.Log("Không đủ vàng");
                return;
            }

            CoinManger.Instance.RemoveCoin(chest.priceGold) ;
            CoinManger.Instance.UpdateUICoin();
            GachaCurrrent = GachaManager.Instance.RollOne(chest);
            
            animator[index].OpenAnimator();
            
        }

        
    }

    public void ShowReward()
    {
        if (GachaCurrrent == null)
            return;

        PanelReward.SetActive(true);

        RewardIcon.sprite = GachaCurrrent.Icon;
        TextRewardName.text = GachaCurrrent.Name;
        TextAmount.text = "x" + GachaCurrrent.amount;
    }

    public void OpenGacha()
    {
        PanelShop.SetActive(true);
        PanelGacha.SetActive(true);
        PanelLuuY.SetActive(true);
    }

    public void CloseGacha()
    {
        PanelShop.SetActive(false);
    }

    public void CloseReward()
    {
        PanelReward.SetActive(false);
        animator[indexGacha].CloseAnimator();
    }
}