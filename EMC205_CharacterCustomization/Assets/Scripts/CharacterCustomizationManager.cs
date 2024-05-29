using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(KiraGameManager)), CanEditMultipleObjects]
public class CharacterCustomizationManager : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        KiraGameManager gameManager = (KiraGameManager)target;

        GUILayout.Space(15);
        if (GUILayout.Button("RESET HIDDEN GAMEOBJECTS"))
        {
            gameManager.ResetHidden();
        }
        
        if (GUILayout.Button("HIDE GAMEOBJECTS"))
        {
            gameManager.HideExcessPart();
        }
    }

}
