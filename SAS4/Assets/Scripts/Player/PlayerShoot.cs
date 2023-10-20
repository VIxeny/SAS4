using Enemy;
using UnityEngine;

namespace Player
{
    public class PlayerShoot : MonoBehaviour
    {
        public PlayerMain playerMain;
        [SerializeField] private Transform firePoint;
        private readonly float _maxDistance = Constants.DistanceOfFlyingBullet;
        private float _spread;
        private int _damage;
        [SerializeField] float spreadMultiplier = 2;

        [SerializeField] private Rigidbody2D rb;

        [SerializeField] private bool debugOn;

        private void Log(string text)
        {
            if (debugOn)
                Debug.Log(text);
        }

        private void Start()
        {
            WeaponChanged();
        }

        private void WeaponChanged()
        {
            _spread = playerMain.playerEquipment.CurrentWeapon.Spread;
            _damage = playerMain.playerEquipment.CurrentWeapon.Damage;
        }

        public void Shoot()
        {
            var raycast = BulletHit();
            bool isEnemy = raycast.collider != null && raycast.collider.gameObject.CompareTag("Enemy");
            if (isEnemy)
            {
                Log("<color=red>Enemy</color> hit");
                EnemyHealth enemyHealth = raycast.collider.gameObject.GetComponent<EnemyHealth>();

                enemyHealth.GetDamage(_damage);
            }
            else
            {
                Log("Miss");
            }
        }

        private RaycastHit2D BulletHit()
        {
            Vector3 bulletStartPos = firePoint.position;
            float angle;
            if (rb.velocity == Vector2.zero)
            {
                angle = Random.Range(-_spread, _spread);
            }
            else
            {
                angle = Random.Range(-_spread, _spread) * spreadMultiplier;
            }

            Vector3 bulletDirection = Quaternion.Euler(0, 0, angle) * firePoint.up;

            var raycast = Physics2D.Raycast(bulletStartPos, bulletDirection);

            Debug.DrawRay(bulletStartPos,
                raycast.distance == 0 ? bulletDirection * _maxDistance : bulletDirection * raycast.distance,
                Color.red, 2f);

            return raycast;
        }
    }
}