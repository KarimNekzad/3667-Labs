using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletCollision : MonoBehaviour
{
    [SerializeField] private AudioClip _enemyTakeDamage;

    private EnemyHealthTracker _healthTracker;

    private void Awake()
    {
        _healthTracker = GetComponent<EnemyHealthTracker>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerBullet")
        {
            Destroy(collision.gameObject);
            _healthTracker.TakeDamage();
            AudioSource.PlayClipAtPoint(_enemyTakeDamage, transform.position);
        }
    }
}
