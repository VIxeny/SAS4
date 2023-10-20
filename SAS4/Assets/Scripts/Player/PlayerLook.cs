using UnityEngine;

namespace Player
{
    public class PlayerLook : MonoBehaviour
    {
        public PlayerMain playerMain;

        private void Update()
        {
            RotatePlayer();
        }

        private void RotatePlayer()
        {
            float angle = playerMain.playerInputScript.Angle;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
    }
}