using UnityEngine;

namespace Player
{
    public class PlayerMove : MonoBehaviour
    {
        public PlayerMain playerMain;
        [SerializeField] private Rigidbody2D rb;
        [SerializeField] [Range(1, 10)] private float movingSpeed = 5f;

        private void Update()
        {
            Move();
        }

        private void Move()
        {
            Vector2 moveDirection = playerMain.playerInputScript.MoveDirection;
            rb.velocity =  moveDirection * movingSpeed;
        }
    }
}