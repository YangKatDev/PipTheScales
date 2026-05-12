using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetLevelBehaviour : MonoBehaviour
{
    
    public void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
