using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class ExpHandler
{
    //public class often used in referencing
    //public struct often used in values
    int currentLevel;
    float currentExperience;
    float maxExperience;

    public int CurrentLevel
    {
        get { return currentLevel; }
        private set { currentLevel = value; }
    }

    //public int CurrentLevel { get { private set; } }
    public float MaxExperience
    {
        get { return maxExperience; }
        private set { maxExperience = value; }
    }

    public float CurrentExperience
    {
        get { return currentExperience; }
        //                                stops overfow when value excee the max experience
        private set { currentExperience = Mathf.Clamp(value, 0f, maxExperience); }
    }
    
    public float ExpToAdd
    {
        get; private set;
    }
    public void GainExperience(float experienceToAdd)
    {
        currentExperience += experienceToAdd;
        if(currentExperience >= maxExperience )
        {
            LevelUp();
        }
    }

    public void LevelUp()
    {
        currentLevel++;
        currentExperience = 0f;
        //Increases the max experience by 50% (1.5)
        maxExperience *= 1.5f;
        //skillPoints++; || statPoints++;
    }
}
