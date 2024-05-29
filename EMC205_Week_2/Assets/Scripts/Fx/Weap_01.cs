using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weap_01 : WeaponAbilities
{
    private ParticleSystem attack, skill, ultimate;
    public override void Attack()
    {
        attack = AbilityManager.Instance.attackFX[0];
    }

    public override void Skill()
    {
        skill = AbilityManager.Instance.skillFX[0];
    }

    public override void Ultimate()
    {
        ultimate = AbilityManager.Instance.ultimateFX[0];
        Instantiate(ultimate);
        ultimate.Play();
    }
}
