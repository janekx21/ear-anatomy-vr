using UnityEngine;
using TMPro; 
using UnityEngine.UI; 

public class AutoScrollText : MonoBehaviour
{
    [Header("Settings")]
    public float scrollSpeed = 20f;
    public float startPause = 1.5f;     
    public float endPause = 2.0f;       

    private RectTransform textRectTransform;
    private RectTransform parentRectTransform;
    private float textHeight;
    private float parentHeight;
    private bool shouldScroll = false;
    private bool downwards = true;
    private Vector2 startPosition;

    void Start()
    {
        textRectTransform = GetComponent<RectTransform>();
        parentRectTransform = transform.parent.GetComponent<RectTransform>();

        // Ensure pivots are set to Top-Left or Top-Center for easy math
        // (This assumes Pivot Y is 1)
        startPosition = textRectTransform.anchoredPosition;

        ResetAndCheck();
    }

    void Update()
    {
        if (!shouldScroll)
        {
            return;
        }


        float maxScrollY = textHeight - parentHeight;

        if (downwards)
        {
            if (textRectTransform.anchoredPosition.y < maxScrollY)
            {
                textRectTransform.anchoredPosition += Vector2.up * scrollSpeed * Time.deltaTime;
            }
            else
            {
                StartCoroutine(WaitAndSwitchDirection(false)); // reached bottom
            }
        }
        else
        {
            if (textRectTransform.anchoredPosition.y > 0)
            {
                textRectTransform.anchoredPosition -= Vector2.up * scrollSpeed * Time.deltaTime;
            }
            else
            {
                StartCoroutine(WaitAndSwitchDirection(true)); // reached top
            }
        }


    }

    private System.Collections.IEnumerator WaitAndSwitchDirection(bool state)
    {
        shouldScroll = false; 
        yield return new WaitForSeconds(state ? startPause : endPause);

        downwards = state;

        shouldScroll = true;
    }

    public void ResetAndCheck()
    {
        Canvas.ForceUpdateCanvases();

        textHeight = textRectTransform.rect.height;
        parentHeight = parentRectTransform.rect.height;

        
        textRectTransform.anchoredPosition = startPosition; // reset Position


        if (textHeight > parentHeight) // only scroll if the text is taller than the container
        {
            StartCoroutine(WaitAndSwitchDirection(true));
        }
        else
        {
            shouldScroll = false;
        }
    }
}