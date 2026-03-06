using UnityEngine;
using UnityEngine.InputSystem;

public class InputActionManagerBehaviour : MonoBehaviour
{
    public static InputActionAsset actions;
    public static InputActionManagerBehaviour manager;

    //private void OnEnable() => actions.Enable();
    //private void OnDisable() => actions.Disable();

    void Awake()
    {
        if (manager == null)
        {
            manager = this;
            DontDestroyOnLoad(this.gameObject);
            InputSystem.actions.FindAction("PlayerControls");
        } else if (manager != this)
        {
            manager = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
