using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HelpBehaviour : MonoBehaviour
{
    [Header ("UI Settings")]
    public GameObject helpPanel;
    public GameObject controlText, helpText, tutorialText;
    public GameObject helpCanvas;

    [Header ("Coroutine Settings")]
    public float displayTimer = 4f;
    private Coroutine hideCoroutine;

    void Awake()
    {
        helpPanel.SetActive(false);
    }

    // Sets the tutorial text panel active
    public void Help()
    {
        if (helpPanel.activeSelf)
        {
            if (hideCoroutine != null) StopCoroutine(hideCoroutine);
            helpPanel.SetActive(false);
        }
        else
        {
            helpPanel.SetActive(true);

            if (hideCoroutine != null) StopCoroutine(hideCoroutine);
            hideCoroutine = StartCoroutine(HidePanel());
        }
    }

    private IEnumerator HidePanel()
    {
        if (helpText == null && tutorialText == null)
        {
            yield return new WaitForSeconds(displayTimer);
            controlText.SetActive(false);
            helpPanel.SetActive(false);
            helpCanvas.SetActive(false);
        }

        if (controlText == null && tutorialText == null)
        {
            yield return new WaitForSeconds(displayTimer);
            helpText.SetActive(false);
            helpPanel.SetActive(false);
            helpCanvas.SetActive(false);
        }

        yield return new WaitForSeconds(displayTimer);
        controlText.SetActive(false);
        helpText.SetActive(true);

        yield return new WaitForSeconds(displayTimer);
        helpText.SetActive(false);
        tutorialText.SetActive(true);

        yield return new WaitForSeconds(displayTimer);
        tutorialText.SetActive(false);
        helpPanel.SetActive(false);
        helpCanvas.SetActive(false);
    }
}
