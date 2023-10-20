using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    private readonly Vector3 _offset = new Vector3(0, 0, -10);
    [SerializeField] private Transform player;

    private void Update()
    {
        transform.position = player.position + _offset;
    }
}