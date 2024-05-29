using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using Unity.VisualScripting;

public class KiraCharacterCustomization : MonoBehaviour
{
    [Header("KIRA MODEL")]
    public KiraHairTypeDatas kiraHairTypes;
    public KiraClotheTypeDatas kiraClotheTypes;
    public KiraPantTypeDatas kiraPantTypes;
    public GameObject kiraPrefab;

    #region Kira
    [System.Serializable]
    public class KiraHairTypeDatas
    {
        public GameObject[] hairParts;
        public Button nextBTN;
        public Button prevBTN;
        public int currentIndex;
        public KiraGameManager gameManager;
        public void HairIncrement()
        {
            currentIndex = currentIndex + 1;
            if (currentIndex > hairParts.Length - 1) 
            { 
                currentIndex = 0; 
                gameManager.SetHairToggle(currentIndex, true);
            }
        }
        public void HairDecrement()
        {
            //gameManager.SetHairToggle(currentIndex, false);
            currentIndex = currentIndex - 1;
            //gameManager.SetHairToggle(currentIndex, true);
            if (currentIndex < 0)
            {
                currentIndex = hairParts.Length - 1;
                gameManager.SetHairToggle(currentIndex, true);
            }
        }
    }

    [System.Serializable]
    public class KiraClotheTypeDatas
    {
        public GameObject[] clothesParts;
        public Button nextBTN;
        public Button prevBTN;
        public int currentIndex;
        public KiraGameManager gameManager;
       
        public void ClotheIncrement()
        {
            currentIndex = currentIndex + 1;
            if (currentIndex >= clothesParts.Length) 
            { 
                currentIndex = 0;
                gameManager.SetClotheToggle(currentIndex, true);
            }
        }
        public void ClotheDecrement()
        {
            currentIndex = currentIndex - 1;
            if (currentIndex < 0) 
            { 
                currentIndex = clothesParts.Length - 1;
                gameManager.SetClotheToggle(currentIndex, true);
            }
        }
    }

    [System.Serializable]
   public class KiraPantTypeDatas
   {
           
        public GameObject[] pantParts;
        public Button nextBTN;
        public Button prevBTN;
        public int currentIndex;

        public KiraGameManager gameManager;
        
        public void PantIncrement()
        {
            currentIndex = currentIndex + 1;
            if (currentIndex >= pantParts.Length) 
            {
                currentIndex = 0;
                gameManager.SetPantToggle(currentIndex, true);
            }
        }
        public void PantDecrement()
        {
            currentIndex = currentIndex - 1;
            if (currentIndex < 0)
            { 
                currentIndex = pantParts.Length  - 1;
                gameManager.SetPantToggle(currentIndex, true);
            }
        }
    }
    #endregion

}







