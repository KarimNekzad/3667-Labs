using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D _rigidbody2D;
    [SerializeField] private Vector2 _movementDirection = new Vector2(0f, 0f);
    [SerializeField] private float _moveSpeed = 10.0f;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        _rigidbody2D.MovePosition(_rigidbody2D.position + _movementDirection * _moveSpeed * Time.fixedDeltaTime);
        DestroyBulletOutOfBounds();
    }

    public void SetMovementDirection(Vector2 movementDirection)
    {
        _movementDirection = movementDirection;
        Flip();
    }

    private void Flip()
    {
        if (_movementDirection.y != 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 90f);
        }
    }

    private void DestroyBulletOutOfBounds()
    {
        if (transform.position.x > 20 || transform.position.x < -20 || transform.position.y > 20 || transform.position.y < -20)
        {
            Destroy(gameObject);
        }
    }
}
