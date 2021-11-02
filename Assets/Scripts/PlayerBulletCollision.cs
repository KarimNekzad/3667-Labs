using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletCollision : MonoBehaviour
{
    [SerializeField] private AudioClip _playerTakeDamage;

    private PlayerHealthTracker _healthTracker;

    private bool _takingDamage = false;
    private const float _animationCooldown = 0.6f;
    private float _resetAnimationState = 0f;

    private void Awake()
    {
        _healthTracker = GetComponent<PlayerHealthTracker>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_takingDamage)
        {
            if (Time.time > _resetAnimationState)
            {
                _takingDamage = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "EnemyBullet")
        {
            Destroy(collision.gameObject);
            _healthTracker.TakeDamage();
            AudioSource.PlayClipAtPoint(_playerTakeDamage, transform.position);
            _takingDamage = true;
            _resetAnimationState = Time.time + _animationCooldown;
        }
    }

    public bool IsTakingDamage()
    {
        return _takingDamage;
    }
}
