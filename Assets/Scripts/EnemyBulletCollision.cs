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

    // Start is called before the first frame update
    void Start()
    {
        //_audioSource.playOnAwake = false;
    }

    // Update is called once per frame
    void Update()
    {
        
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
