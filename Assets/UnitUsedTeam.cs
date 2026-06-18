using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UnitUsedTeam : MonoBehaviour
{
    public GamePlayUnitUIWinLost[] unitTeams;
    public Image[] Images;
    private void Update()
    {
        Show();
    }
    public void Show()
    {
        for(int i=0;i<unitTeams.Length;i++)
        {
            if(i<GameData.UnitData.Count)
            {
                Images[i].gameObject.SetActive(true);
                unitTeams[i].gameObject.SetActive(true);
                unitTeams[i].setup(GameData.UnitData[i]);
            }
            else
            {
                Images[i].gameObject.SetActive(false);
                unitTeams[i].gameObject.SetActive(false);
              
            }
        }    
    }    
}
