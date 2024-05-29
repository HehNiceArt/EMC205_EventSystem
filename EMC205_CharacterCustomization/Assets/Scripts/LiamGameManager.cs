using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LiamGameManager : MonoBehaviour
{
    public LiamCharacterCustomization liamcustom;
    public GameObject liamPrefab;
    public Button switchSex;

    int loadScene = 1;
    private void Start()
    {
        HideExcessPart();
        Button changeSex = switchSex;
        changeSex.onClick.AddListener(LoadPreviousScene);
        Initialize();
    }
    private void LoadPreviousScene()
    {
        StartCoroutine(GoPreviousScene());
    }
    IEnumerator GoPreviousScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(loadScene - 1);
        while (!asyncLoad.isDone) { yield return null; }
    }
    private void Initialize()
    {
        #region Liam
        if (liamPrefab.activeInHierarchy)
        {
            Button liamHairNextBTN = liamcustom.liamHairTypes.nextBTN;
            liamHairNextBTN.onClick.AddListener(NextHair);
            liamHairNextBTN.onClick.AddListener(liamcustom.liamHairTypes.HairIncrement);

            Button liamHairPreviousBTN = liamcustom.liamHairTypes.prevBTN;
            liamHairPreviousBTN.onClick.AddListener(PreviousHair);
            liamHairPreviousBTN.onClick.AddListener(liamcustom.liamHairTypes.HairDecrement);

            Button liamClotheNextBTN = liamcustom.liamClotheTypes.nextBTN;
            liamClotheNextBTN.onClick.AddListener(NextClothe);
            liamClotheNextBTN.onClick.AddListener(liamcustom.liamClotheTypes.ClotheIncrement);

            Button liamClothePreviousBTN = liamcustom.liamClotheTypes.prevBTN;
            liamClothePreviousBTN.onClick.AddListener(PreviousClothe);
            liamClothePreviousBTN.onClick.AddListener(liamcustom.liamClotheTypes.ClotheDecrement);

            Button liamPantNextBTN = liamcustom.liamPantTypes.nextBTN;
            liamPantNextBTN.onClick.AddListener(NextPant);
            liamPantNextBTN.onClick.AddListener(liamcustom.liamPantTypes.PantIncrement);

            Button liamPantPreviousBTN = liamcustom.liamPantTypes.prevBTN;
            liamPantPreviousBTN.onClick.AddListener(PreviousPant);
            liamPantPreviousBTN.onClick.AddListener(liamcustom.liamPantTypes.PantDecrement);
        }
        #endregion
        
    }
    #region For Inspector Only
    //Resets the visibility of the children models
    public void ResetHidden()
    {
        foreach(Transform child in liamPrefab.transform) { child.gameObject.SetActive(true); }
    }

    public void HideExcessPart()
    {
        #region Liam
        int liamHairPartsLength = liamcustom.liamHairTypes.hairParts.Length;
        int liamClothePartsLength = liamcustom.liamClotheTypes.clotheParts.Length;
        int liamPantPartsLength = liamcustom.liamPantTypes.pantParts.Length;
        GameObject[] liamHairParts = liamcustom.liamHairTypes.hairParts;
        GameObject[] liamClotheParts = liamcustom.liamClotheTypes.clotheParts;
        GameObject[] liamPantParts = liamcustom.liamPantTypes.pantParts;
        for(int i = 0; i < liamHairPartsLength; i++) { liamHairParts[i].SetActive(false); }
        for(int i = 0;i < liamClothePartsLength; i++) { liamClotheParts[i].SetActive(false); }
        for(int i = 0; i < liamPantPartsLength; i++) { liamPantParts[i].SetActive(false); }
        #endregion
    }
    #endregion

    #region Customization Functions
    public void NextHair()
    {
        int liamIndex = liamcustom.liamHairTypes.currentIndex;
        //Deactivates current visible hair
        SetLiamHairToggle(liamIndex, false);
        //move to next index
        liamIndex++;
        //Activates next hair
        SetLiamHairToggle(liamIndex, true);
    }
    public void PreviousHair()
    {
        int liamIndex = liamcustom.liamHairTypes.currentIndex;
        SetLiamHairToggle(liamIndex, false);
        liamIndex--;
        SetLiamHairToggle(liamIndex, true);
    }
    public void NextClothe()
    {
        int liamIndex = liamcustom.liamClotheTypes.currentIndex;
        SetClotheToggle(liamIndex, false);
        //SetClotheToggle(index, false);
        liamIndex++;
        SetClotheToggle(liamIndex, true);
    }
    public void PreviousClothe()
    {
        int liamIndex = liamcustom.liamClotheTypes.currentIndex;
        SetClotheToggle(liamIndex, false);
        //SetClotheToggle(index);
        liamIndex--;
        SetClotheToggle(liamIndex, true);
    }
    public void NextPant()
    {
        int liamIndex = liamcustom.liamPantTypes.currentIndex;
        SetPantToggle(liamIndex, false);
        liamIndex++ ;   
        SetPantToggle(liamIndex, true);
    }
    public void PreviousPant()
    {
        int liamIndex = liamcustom.liamPantTypes.currentIndex;
        SetPantToggle(liamIndex, false);
        liamIndex-- ;
        SetPantToggle(liamIndex, true);

    }
    #endregion

    /// <summary>
    /// Determines whether it actives or deactivates the current model 
    /// </summary>
    #region Toggles
    public void SetLiamHairToggle(int liamIndex, bool isActive)
    {
        int liamHairLength = liamcustom.liamHairTypes.hairParts.Length;
        GameObject[] liamHairParts = liamcustom.liamHairTypes.hairParts;

        if (liamIndex >= 0 && liamIndex < liamHairLength)
        {
            for (int i = 0; i <= liamHairLength; i++)
                liamHairParts[liamIndex].SetActive(isActive);
        }
        if (!isActive && (liamIndex == liamHairLength)) { liamHairParts[0].SetActive(true); }
    }
    public void SetClotheToggle(int liamIndex, bool isActive)
    {
        int liamClotheLength = liamcustom.liamClotheTypes.clotheParts.Length;
        GameObject[] liamClotheParts = liamcustom.liamClotheTypes.clotheParts;

        if (liamIndex >= 0 && liamIndex < liamClotheLength)
        {
            for (int i = 0; i < liamClotheLength; i++)
                liamClotheParts[liamIndex].SetActive(isActive);
            if (!isActive && (liamIndex == liamClotheLength)) { liamClotheParts[0].SetActive(true); }
        }
    }
/// <summary>
/// Teehee
/// Idk anymore why I have this summary
/// </summary>
    public void SetPantToggle(int liamIndex, bool isActive)
    {
        int liamPantLength = liamcustom.liamPantTypes.pantParts.Length;
        GameObject[] liamPantParts = liamcustom.liamPantTypes.pantParts;
        //Debug.Log("wtf god save me why won't this shit decrement mtfkr");
        if(liamIndex >= 0 && liamIndex < liamPantLength)
        {
            for (int i = 0; i < liamPantLength; i++)
                liamPantParts[liamIndex].SetActive(isActive);
        }
        if(!isActive && (liamIndex == liamPantLength)) { liamPantParts[0].SetActive(true); }
    }
    #endregion

}
