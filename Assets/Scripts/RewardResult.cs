
[System.Serializable]
public class RewardResult
{
   public ItemData item;
   public int amount;
    public RewardResult(ItemData item,int amount)
    {
        this.item=item;
        this.amount=amount;
    }
}
