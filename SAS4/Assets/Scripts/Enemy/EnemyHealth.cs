using System.Collections;
using UnityEngine;

namespace Enemy
{
    public class EnemyHealth : MonoBehaviour
    {
        [SerializeField] private int health = 10;
        [SerializeField] private float timeToDisappear = 2.0f;

        public void GetDamage(int damage)
        {
            health -= damage;
            
            if(health <= 0)
                Death();
        }

        private void Death()
        {
            Debug.Log("Enemy Died");
            StartCoroutine(Disappear());
        }

        private IEnumerator Disappear()
        {
            yield return new WaitForSeconds(timeToDisappear);
            Destroy(gameObject);
        }
    }
}
