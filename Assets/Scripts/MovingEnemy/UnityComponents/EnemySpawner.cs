using UnityEngine;

namespace MovingEnemy.UnityComponents
{
    public class EnemySpawner : MonoBehaviour
    {
        public Enemy enemyPrefab;
        
        public int enemyCount;
        public float minSpeed;
        public float maxSpeed;


        private void Start()
        {
            var gridSize = Mathf.CeilToInt(Mathf.Sqrt(enemyCount));
            var offset = (gridSize - 1) / 0.5f;
            
            for (var i = 0; i < enemyCount; i++)
            {
                var x = i % gridSize;
                var y = i / gridSize;
                var direction = Random.insideUnitCircle.normalized;
                var position = new Vector3(x - offset, 0, y - offset);
                var enemy = Instantiate(enemyPrefab, position,  Quaternion.identity);
                enemy.direction = new Vector3(direction.x, 0, direction.y);
                enemy.speed = Random.Range(minSpeed, maxSpeed);
            }
        }
    }
}