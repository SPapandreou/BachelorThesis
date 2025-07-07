using UnityEngine;

namespace MovingEnemy.UnityComponents
{
    public class Enemy : MonoBehaviour
    {
        public Vector3 direction;
        public float speed;
        private void Update()
        {
            transform.position += direction * speed * Time.deltaTime;
        }
    }
}