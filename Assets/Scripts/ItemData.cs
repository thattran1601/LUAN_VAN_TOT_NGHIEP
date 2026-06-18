    using UnityEngine;

    [CreateAssetMenu(fileName = "New Item", menuName = "Game/Item")]
    public class ItemData : ScriptableObject
    {
        public int Id;
        public string Name;
        public Sprite Item;
        public string Description;
        public int Price;
        public ItemType ItemType;
        public TreasureType TreasureType;
        public bool Used = false;
    
}
