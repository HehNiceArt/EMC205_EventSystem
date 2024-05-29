using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

//edits stuff
[CustomEditor(typeof(GameManager)), CanEditMultipleObjects]
public class GameManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        GameManager gameManager = (GameManager)target;
        if (GUILayout.Button("Feeding Frenzy"))
        {
            gameManager.DamagePowerUp_FeedingFrenzy();
        }
        if(GUILayout.Button("Well Fed"))
        {
            gameManager.DamagePowerUp_WellFed();
        }

        if(GUILayout.Button("Reset Damage"))
        {
            gameManager.DamageReset();
        }
        GUILayout.Space(15);
        if(GUILayout.Button("Add EXp"))
        {
            gameManager.AddExp(gameManager.expToAdd);
        }
        if(GUILayout.Button("Reset EXP"))
        {
            gameManager.ResetExp();
        }
    }
}
