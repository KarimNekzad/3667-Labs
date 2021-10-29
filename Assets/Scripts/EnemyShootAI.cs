using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootAI : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private float _startDelaySeconds = 1.0f;
    [SerializeField] private GameObject _enemy;
    [SerializeField] private AudioClip _enemyShoot;

    private float _shootIntervalSeconds = 1.5f;

    private void Awake()
    {
        _enemy = GameObject.FindGameObjectWithTag("Enemy");
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Shoot", _startDelaySeconds, _shootIntervalSeconds);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Shoot()
    {
        Vector3 enemyPosition = _enemy.transform.position;
        enemyPosition.z += 1;
        Vector2 enemyMovementDirection = _enemy.GetComponent<EnemyMovementAI>().GetMovementDirection();

        GameObject bulletInstance = Instantiate(_bulletPrefab);
        bulletInstance.transform.position = MoveBulletInFrontOfEnemy(enemyMovementDirection, enemyPosition);
        bulletInstance.GetComponent<BulletMovement>().SetMovementDirection(enemyMovementDirection);
        bulletInstance.tag = "EnemyBullet";

        AudioSource.PlayClipAtPoint(_enemyShoot, transform.position);
    }

    private Vector3 MoveBulletInFrontOfEnemy(Vector2 enemyMovementDirection, Vector3 enemyPosition)
    {
        Vector3 bulletPosition = enemyPosition;
        const float halfEnemySpriteWidth = 1.22f;

        if (enemyMovementDirection.x == 1)
        {
            bulletPosition.x += halfEnemySpriteWidth;
        }
        else if (enemyMovementDirection.x == -1)
        {
            bulletPosition.x -= halfEnemySpriteWidth;
        }
        else if (enemyMovementDirection.y == 1)
        {
            bulletPosition.y += halfEnemySpriteWidth;
        }
        else if (enemyMovementDirection.y == -1)
        {
            bulletPosition.y -= halfEnemySpriteWidth;
        }

        return bulletPosition;
    }
}
