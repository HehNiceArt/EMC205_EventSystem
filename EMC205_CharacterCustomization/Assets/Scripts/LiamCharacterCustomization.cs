using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using Unity.VisualScripting;

public class LiamCharacterCustomization : MonoBehaviour
{
    [Header("LIAM MODEL")]
    public LiamHairTypeDatas liamHairTypes;
    public LiamClotheTypeDatas liamClotheTypes;
    public LiamPantTypeDatas liamPantTypes;
    public GameObject liamPrefab;

    #region Liam
    [System.Serializable]
    public class LiamHairTypeDatas 
    {
        public GameObject[] hairParts;
        public Button nextBTN;
        public Button prevBTN;
        public int currentIndex;

        public LiamGameManager gameManager;
        public void HairIncrement()
        {
            currentIndex = currentIndex + 1;
            if (currentIndex > hairParts.Length - 1) 
            {
                currentIndex = 0; 
                gameManager.SetLiamHairToggle(currentIndex, true);
            }
        }
        public void HairDecrement()
        {
            //IDk why but for some reason this is the only one that's bugged af
            //it works on the Kira model but not Liam's model
            gameManager.SetLiamHairToggle(currentIndex, false);
            currentIndex = currentIndex - 1;
            gameManager.SetLiamHairToggle(currentIndex, true);
            if (currentIndex == -1)
            {
                currentIndex = hairParts.Length - 1;
                gameManager.SetLiamHairToggle(currentIndex, true) ;
               
            }
        }
    }
    [System.Serializable]
    public class LiamClotheTypeDatas
    {
        public GameObject[] clotheParts;
        public Button nextBTN;
        public Button prevBTN;
        public int currentIndex;

        public LiamGameManager gameManager;
        public void ClotheIncrement()
        {
            currentIndex = currentIndex + 1;
            if(currentIndex >= clotheParts.Length) { currentIndex = 0; }
        }
        public void ClotheDecrement()
        {
            currentIndex = currentIndex - 1;
            if(currentIndex <= -1) 
            { 
                currentIndex = clotheParts.Length - 1;
                //I forgot the logic on why I wrote this when I was writing it but it works
                //Got it now - when the currentIndex reaches -1, it will loop back to 
                //the max length of the gameobject array - 1 so it's only [0,1,2]
                //Instead of having an extra number i.e. [0,1,2,3]
                //So the solution was to run SetClotheToggle again
                gameManager.SetClotheToggle(currentIndex, true);
            }
        }
    }
    [System.Serializable]
    public class LiamPantTypeDatas
    {
        public GameObject[] pantParts;
        public Button nextBTN;
        public Button prevBTN;
        public int currentIndex;

        public LiamGameManager gameManager;
        public void PantIncrement()
        {
            currentIndex = currentIndex + 1;
            if (currentIndex >= pantParts.Length) { currentIndex = 0; }
        }
        public void PantDecrement()
        {
            currentIndex = currentIndex - 1;
            if (currentIndex < 0) 
            { 
                currentIndex = pantParts.Length - 1;
                gameManager.SetPantToggle(currentIndex, true);
            }
        }
    }
    #endregion
}







