using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class DamageSystem
{
    int damage_AK47 = 20;
    int damage_DEagle = 15;
    int damage_RLauncher = 100;
    int damage_M4A1 = 20;

    #region getter setter
    //this just get set
    public int Damage_AK47
    {
        get { return damage_AK47; } set { damage_AK47 = value; }
    }

    public int Damage_DEagle
    {
        get { return damage_DEagle; } set { damage_DEagle = value; }
    }

    public int Damage_RLauncher
    {
        get { return damage_RLauncher; } set { damage_RLauncher = value;}
    }

    public int Damage_M4A1
    {
        get { return damage_M4A1;} set { damage_M4A1 = value;}
    }
    #endregion
    public class PowerUp
    {
        //base damage powerups
        //feedingFrenzy increases damage by 20 pts
        float feedingFrenzy = 20;
        public float FeedingFrenzy
        {
            get { return feedingFrenzy; } set { feedingFrenzy = value; }
        }

        //percentage damage powerups
        //wellFed increases damage by 30%a
        float wellFed = 30;
        public float WellFed
        {
            get { return wellFed; }
            set { wellFed = value; }
        }
    }
    
}
