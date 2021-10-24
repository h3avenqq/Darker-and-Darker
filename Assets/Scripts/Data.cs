using System;
using BreakInfinity;

[Serializable]
public class Data
{
        public BigDouble money;
        public BigDouble dph;
        public BigDouble dps;
        public BigDouble gems;
        public BigDouble diamonds;
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
        //Multiplier
        public double MoneyMultiply;
        public double MoneyMultiplyChance;
        public bool MoneyMultiplyCondition;
        public int MoneyMultiplyTimer;
        public double MoneyForKillMultiply;
        public double MoneyPerSecMultiply;
        //Crits
        public double CriticalDamage;
        public double CriticalChance;
        public double CriticalDamageHero;
        public double CriticalChanceHero;
        public bool DoubleAttack;
        public int DoubleAttackTime;
        public bool DoubleAttackHero;
        public int DoubleAttackTimeHero;

        public Data()
        {
                money = 1001.0;
                dph = 1.0;
                dps = 0.0;
                gems = 100.0;
                diamonds = 0.0;
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
                CriticalDamage = 1.5;
                CriticalChance = 0;
                CriticalDamageHero = 1.5;
                CriticalChanceHero = 0;
                DoubleAttack = false;
                DoubleAttackTime = 7;
                DoubleAttackHero = false;
                DoubleAttackTimeHero = 7;
                MoneyPerSecMultiply = 1;
                MoneyForKillMultiply = 1;
                MoneyMultiply = 1;
                MoneyMultiplyCondition = false;
                MoneyMultiplyTimer = 5;
                MoneyMultiplyChance = 20;
        }
}




