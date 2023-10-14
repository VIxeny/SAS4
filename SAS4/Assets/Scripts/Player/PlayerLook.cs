using UnityEngine;
using UnityEngine.InputSystem;

namespace Architecture
{
    public class PlayerLook : MonoBehaviour
    {
        private const string KeyboardMouseScheme = "Keyboard&Mouse";
        private const string GamepadScheme = "Gamepad";
        private string _currentControlScheme;
        private Vector2 _lookDirection;

        [SerializeField] private Camera playerCamera;

        public void OnControlsSchemeChanged(PlayerInput playerInput)
        {
            _currentControlScheme = playerInput.currentControlScheme;
        }

        private void Update()
        {
            switch (_currentControlScheme)
            {
                case KeyboardMouseScheme:
                    
                    break;
                case GamepadScheme:
                    if (_lookDirection.magnitude > 0.5f)
                    {
                        float angle = Mathf.Atan2(_lookDirection.y, _lookDirection.x) * Mathf.Rad2Deg - 90f;
                        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
                    }

                    break;
            }
        }

        public void GetGamepadLookDirection(InputAction.CallbackContext context)
        {
            _lookDirection = context.ReadValue<Vector2>();
        }
    }
}