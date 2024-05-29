using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityManager : MonoBehaviour
{
    public static AbilityManager Instance { get; private set; }
    public List<ParticleSystem> attackFX = new();
    public List<ParticleSystem> skillFX = new();
    public List<ParticleSystem> ultimateFX = new();
    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
}
