using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerInputScript : MonoBehaviour
    {
        public PlayerMain playerMain;

        public Vector2 MoveDirection { get; private set; }

        public float Angle { get; private set; }
        private Vector2 _lookDirection;
        [SerializeField] private Camera playerCamera;

        private const string KeyboardMouseScheme = "Keyboard&Mouse";
        private const string GamepadScheme = "Gamepad";
        private string _currentControlScheme;

        public void OnControlsSchemeChanged(PlayerInput playerInput)
        {
            _currentControlScheme = playerInput.currentControlScheme;
            
            Cursor.visible = _currentControlScheme switch
            {
                KeyboardMouseScheme => true,
                GamepadScheme => false,
                _ => Cursor.visible
            };
        }

        public void GetMove(InputAction.CallbackContext context)
        {
            MoveDirection = context.ReadValue<Vector2>();
        }


        public void GetGamepadLookDirection(InputAction.CallbackContext context)
        {
            _lookDirection = context.ReadValue<Vector2>();
        }

        public void GetFirePressed(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                playerMain.playerShoot.Shoot();
            }

            Random.Range(12, 34);
        }

        private void Update()
        {
            switch (_currentControlScheme)
            {
                case KeyboardMouseScheme:
                    LookDirectionForKeyboardMouse();
                    CalculateAngle();
                    break;
                case GamepadScheme:
                    if (_lookDirection.magnitude > 0.5f)
                    {
                        CalculateAngle();
                    }
                    break;
            }
        }

        private void LookDirectionForKeyboardMouse()
        {
            var mousePos = playerCamera.ScreenToWorldPoint(Input.mousePosition);
            _lookDirection = mousePos - transform.position;
        }

        private void CalculateAngle()
        {
            Angle = Mathf.Atan2(_lookDirection.y, _lookDirection.x) * Mathf.Rad2Deg - 90f;
        }
    }
}