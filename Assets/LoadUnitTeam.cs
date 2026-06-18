using System.Collections.Generic;
using System.Linq;
using Unity.Jobs;
using UnityEngine;

public class LoadUnitTeam : MonoBehaviour
{
    public List<UnitData> listUnit=new List<UnitData>();

    void Start()
    {
        LoadUnit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadUnit()
    {
        listUnit.Clear();
        for(int i=0;i<4;i++)
        {
            int ID=SaveGameManager.instance.LoadTeamSlot(i);

            if (ID == -1)
                continue;
            UnitData unit = listUnit.FirstOrDefault(x => x.Id == ID);
            if(unit!=null)
            {
                listUnit.Add(unit);
            }
        }    
    }    
}
