using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private bool _shoot = false;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private GameObject _player;
    [SerializeField] private AudioClip _playerShoot;

    private float cooldown = 0.4f;
    private float nextFireTime = 0f;

    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        _shoot = Input.GetButtonDown("Fire1");

        if (_shoot)
        {
            if (Time.time > nextFireTime)
            {
                Vector3 playerPosition = _player.transform.position;
                playerPosition.z += 1f;
                Vector2 playerMovementDirection = _player.GetComponent<PlayerMovement>().GetMovementDirection();

                GameObject bulletInstance = Instantiate(_bulletPrefab);
                bulletInstance.transform.position = MoveBulletInFrontOfPlayer(playerMovementDirection, playerPosition);
                bulletInstance.GetComponent<BulletMovement>().SetMovementDirection(playerMovementDirection);
                bulletInstance.tag = "PlayerBullet";

                AudioSource.PlayClipAtPoint(_playerShoot, transform.position);

                nextFireTime = Time.time + cooldown;
            }
        }
    }

    private Vector3 MoveBulletInFrontOfPlayer(Vector2 playerMovementDirection, Vector3 playerPosition)
    {
        Vector3 bulletPosition = playerPosition;
        const float halfPlayerSpriteWidth = 1.5f;

        if (playerMovementDirection.x == 1)
        {
            bulletPosition.x += halfPlayerSpriteWidth;
        }
        else if (playerMovementDirection.x == -1)
        {
            bulletPosition.x -= halfPlayerSpriteWidth;
        }
        else if (playerMovementDirection.y == 1)
        {
            bulletPosition.y += halfPlayerSpriteWidth;
        }
        else if (playerMovementDirection.y == -1)
        {
            bulletPosition.y -= halfPlayerSpriteWidth;
        }

        return bulletPosition;
    }
}
