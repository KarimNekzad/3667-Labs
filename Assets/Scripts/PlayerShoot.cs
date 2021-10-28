using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private bool _shoot = false;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Vector3 _playerPosition;
    [SerializeField] private GameObject _player;

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
            Debug.Log("Shooting!");

            _playerPosition = _player.transform.position;
            _playerPosition.z += 1f;
            Vector2 playerMovementDirection = _player.GetComponent<PlayerMovement>().GetMovementDirection();

            GameObject bulletInstance = Instantiate(_bulletPrefab);
            bulletInstance.transform.position = MoveBulletInFrontOfPlayer(playerMovementDirection);
            bulletInstance.GetComponent<BulletMovement>().SetMovementDirection(playerMovementDirection);
        }
    }

    private Vector3 MoveBulletInFrontOfPlayer(Vector2 playerMovementDirection)
    {
        Vector3 bulletPosition = _playerPosition;
        float halfPlayerSpriteWidth = 1.5f;

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
