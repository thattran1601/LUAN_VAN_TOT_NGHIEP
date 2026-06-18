using System;
public static class CastleStatCalculator
    {
      public static int GetHp(CastleData data, int level)
        {
            return data.hp + data.HpPerLevel * (level-1);
        }
    }

