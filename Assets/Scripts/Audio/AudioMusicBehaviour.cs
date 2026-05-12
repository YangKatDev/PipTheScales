using UnityEngine;

public class AudioMusicBehaviour : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
