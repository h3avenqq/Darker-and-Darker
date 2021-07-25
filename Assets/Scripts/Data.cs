using System;
using BreakInfinity;

[Serializable]
public class Data
{
        public BigDouble money;
        public BigDouble dph;
        public BigDouble dps;
        public BigDouble gems;
        public int stage;
        public int stageMax;
        public int kills;
        public int killsMax;
        public int isBoss;
        public string username;
        public int heroLevel1;
        public int heroLevel2;
        public int heroLevel3;
        public int playerLevel;
        public int OfflineProgressCheck;

        public Data()
        {
                money = 1000.0;
                dph = 1.0;
                dps = 0.0;
                gems = 0.0;
                stage = 1;
                stageMax = 5;
                kills = 0;
                killsMax = 10;
                isBoss = 1;
                username = "<Username>";
                heroLevel1 = 0;
                heroLevel2 = 0;
                heroLevel3 = 0;
                playerLevel = 0;
                OfflineProgressCheck = 1;
        }
}




