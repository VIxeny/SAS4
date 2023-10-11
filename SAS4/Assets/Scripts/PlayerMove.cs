using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMove : MonoBehaviour
{
    [SerializeField] private PlayerInput inputSystem;
    
    public void CheckChangingControls()
    {
        var controlScheme = inputSystem.currentControlScheme;
        Debug.Log(controlScheme);

        if (controlScheme == "Keyboard&Mouse")
        {
            Debug.Log("Let'sgo !!!KyeBoarde!");
        }
        else if (controlScheme == "Gamepad")
        {
            Debug.Log("Let'sgo !GamePaddd!!!");
        }
    }
}
