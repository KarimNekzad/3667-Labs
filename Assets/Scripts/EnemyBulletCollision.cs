using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletCollision : MonoBehaviour
{
    [SerializeField] private AudioClip _enemyTakeDamage;

    private Animator _animator;
    private const int _idle = 0;
    private const int _takeDamage = 1;
    private const float _resetAnimationCooldown = 0.3f;
    private float _animationSwapTime = 0f;

    private EnemyHealthTracker _healthTracker;

    private void Awake()
    {
        _healthTracker = GetComponent<EnemyHealthTracker>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Time.time > _animationSwapTime)
        {
            _animator.SetInteger("animationState", _idle);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerBullet")
        {
            Destroy(collision.gameObject);
            _healthTracker.TakeDamage();
            AudioSource.PlayClipAtPoint(_enemyTakeDamage, transform.position);
            _animator.SetInteger("animationState", _takeDamage);
            _animationSwapTime = Time.time + _resetAnimationCooldown;
        }
    }
}
