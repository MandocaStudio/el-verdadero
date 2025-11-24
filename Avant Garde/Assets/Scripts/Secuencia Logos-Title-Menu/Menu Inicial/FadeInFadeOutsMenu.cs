using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuTransitionManager : MonoBehaviour
{
    [System.Serializable]
    public class CanvasGroupData
    {
        public string menuName;            
        public CanvasGroup canvasGroup;   
        public float fadeDuration = 0.5f;  
    }

    public CanvasGroupData[] menus;  
    public void FadeInMenu(int menuIndex)
    {
        if (menuIndex < menus.Length)
            StartCoroutine(FadeCanvasGroup(menus[menuIndex].canvasGroup, 0f, 1f, menus[menuIndex].fadeDuration));
    }

     public void FadeOutMenu(int menuIndex)
    {
        if (menuIndex < menus.Length)
            StartCoroutine(FadeCanvasGroup(menus[menuIndex].canvasGroup, 1f, 0f, menus[menuIndex].fadeDuration));
    }

     private IEnumerator FadeCanvasGroup(CanvasGroup cg, float startAlpha, float endAlpha, float duration)
    {
        float elapsedTime = 0f;

        if (endAlpha > startAlpha)
            cg.gameObject.SetActive(true);

        cg.alpha = startAlpha;

        while (elapsedTime < duration)
        {
            cg.alpha = Mathf.Lerp(startAlpha, endAlpha, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        cg.alpha = endAlpha;

        if (endAlpha == 0f)
        {
            cg.interactable = false;
            cg.blocksRaycasts = false;
            cg.gameObject.SetActive(false);
        }
        else
        {
            cg.interactable = true;
            cg.blocksRaycasts = true;
        }
    }
}
