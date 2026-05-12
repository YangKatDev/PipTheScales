using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelBehaviour : MonoBehaviour
{
    // Function to send the player to the next level
    public void NextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        int nextSceneIndex = currentSceneIndex + 1;

        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
    }
}
