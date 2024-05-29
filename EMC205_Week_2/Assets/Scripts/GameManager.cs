using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum eEqquippedWeapon
{
    AK47,
    DesertEagle,
    RocketLauncher,
    M4A1
}
public class GameManager : MonoBehaviour
{
    [Header("PlayerStats")]
    public float basePlayerDamage;
    public float finalPlayerDamage;
    [Header("Eqquipped Weapon")]
    public eEqquippedWeapon eWeapon;
    [Header("Experience")]
    public float playerLevel;
    public float currentXP;
    public float expToAdd;
    public float maxXP;

    //updates value without playing the game
    private void OnValidate()
    {
        DamageSystem damageSystem = new DamageSystem(); 
        switch (eWeapon)
        {
            case eEqquippedWeapon.AK47:
                finalPlayerDamage = basePlayerDamage + damageSystem.Damage_AK47;
               // print("AK47: " + basePlayerDamage + " + " + damageSystem.Damage_AK47 + " = " + finalPlayerDamage );
                break;
            case eEqquippedWeapon.DesertEagle:
                finalPlayerDamage = basePlayerDamage + damageSystem.Damage_DEagle;
                break;
            case eEqquippedWeapon.M4A1:
                finalPlayerDamage = basePlayerDamage + damageSystem.Damage_M4A1;
                break;
            case eEqquippedWeapon.RocketLauncher:
                finalPlayerDamage = basePlayerDamage + damageSystem.Damage_RLauncher;
                break;
            default:
                break;
        }
    }

    public void DamagePowerUp_FeedingFrenzy()
    {
        DamageSystem.PowerUp powerUp = new();
        finalPlayerDamage += powerUp.FeedingFrenzy;
        Debug.Log("PowerUp Feeding Frenzy: " + powerUp.FeedingFrenzy + " Final Damage: "+ finalPlayerDamage);
    }

    public void DamagePowerUp_WellFed()
    {
        DamageSystem.PowerUp powerUp = new();
        finalPlayerDamage += finalPlayerDamage * (powerUp.WellFed / 100);
        Debug.Log(powerUp.WellFed + " " + finalPlayerDamage);
    }
    public void DamageReset()
    {
        DamageSystem  damageSystem = new DamageSystem();
        switch (eWeapon)
        {
            case eEqquippedWeapon.AK47:
                finalPlayerDamage = basePlayerDamage + damageSystem.Damage_AK47;
                break;
            case eEqquippedWeapon.DesertEagle:
                finalPlayerDamage = basePlayerDamage + damageSystem.Damage_DEagle;
                break;
            case eEqquippedWeapon.RocketLauncher:
                finalPlayerDamage = basePlayerDamage + damageSystem.Damage_RLauncher;
                break;
            case eEqquippedWeapon.M4A1:
                finalPlayerDamage = basePlayerDamage + damageSystem.Damage_M4A1;
                break;
        }
        Debug.Log("Reset damage");
    }

    public void ExpSytem()
    {
        ExpHandler expHandler = new ExpHandler();
        maxXP = expHandler.MaxExperience;
        currentXP = expHandler.CurrentExperience;
        playerLevel = expHandler.CurrentLevel;
        expToAdd = expHandler.ExpToAdd;
    }
    public void AddExp(float experienceToAdd)
    {
        currentXP += experienceToAdd;
        if(currentXP >= maxXP )
        {
            LevelUp();
        }
    }
    public void LevelUp()
    {
        playerLevel++;
        currentXP = 0;
        maxXP *= 1.5f;
    }
    public void ResetExp()
    {
        playerLevel = 0;
        currentXP = 0;
        expToAdd = 0;
        maxXP = 0;
    }
}
