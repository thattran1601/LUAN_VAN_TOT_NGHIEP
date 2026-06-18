using System.Linq;
using System.Collections.Generic;

public static class TeamLoader
{
    public static void LoadTeamToGameData(UnitData[] allUnit)
    {
        GameData.UnitData.Clear();
        for (int i = 0;i<4;i++)
        {
            int id=SaveGameManager.instance.LoadTeamSlot(i);
            if(id!=-1)
            {
               UnitData unit=allUnit.FirstOrDefault(x => x.Id==id);
                if(unit!=null)
                {
                    GameData.UnitData.Add(unit);
                }
            }    
        }    
    }
}