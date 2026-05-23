using UnityEngine;

public class GamePlayUnitUi : MonoBehaviour
{
    public GamePlayUnitSlots[] slot;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUISlot();
    }
    public void UpdateUISlot()
    {
        for(int i=0;i<slot.Length;i++)
        {
            if(i<GameData.UnitData.Count)
            {
                slot[i].gameObject.SetActive(true);
                slot[i].setup(GameData.UnitData[i]);
            }
            else
            {
                slot[i].gameObject.SetActive(false);
            }
        }    
    }    
}
