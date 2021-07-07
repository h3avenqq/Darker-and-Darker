using System;
using BreakInfinity;

[Serializable]
public class Data
{
        public BigDouble money;//yes
        public BigDouble dph;//yes
        public BigDouble dps;
        public BigDouble gems;
        public int stage;//yes
        public int stageMax;//yes
        public int kills;//yes
        public int killsMax;//yes
        public int isBoss;//yes
        public string username;
        public int heroLevel;
        public int playerLevel;
        public int OfflineProgressCheck;

        public Data()
        {
                money = 0.0;//yes
                dph = 1.0;//yes
                dps = 0.0;
                gems = 0.0;
                stage = 1;//yes
                stageMax = 5;//yes
                kills = 0;//yes
                killsMax = 10;//yes
                isBoss = 1;//yes
                username = "<Username>";
                heroLevel = 0;
                playerLevel = 0;
                OfflineProgressCheck = 1;
        }
}




