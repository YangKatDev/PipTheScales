using UnityEngine;

public class UIButtonBehaviour : MonoBehaviour
{
    // UI menus on the title screen
    public GameObject titleMenu;
    public GameObject creditsMenu;

    // Function to show the credits in the main title screen
    public void ShowCredits()
    {
        titleMenu.SetActive(false);
        creditsMenu.SetActive(true);
    }

    // Function to go back to the main title screen
    public void ShowTitleMenu()
    {
        titleMenu.SetActive(true);
        creditsMenu.SetActive(false);
    }
}
