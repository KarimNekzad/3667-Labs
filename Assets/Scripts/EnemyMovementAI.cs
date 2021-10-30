using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementAI : MonoBehaviour
{
    [SerializeField] private float _differenceX = 0;
    [SerializeField] private float _differenceY = 0;
    [SerializeField] private float _stoppingDistance = 2.5f;
    [SerializeField] private Vector2 _movementDirection;
    [SerializeField] private float _speed = 2.5f;

    private Transform _target;
    private Rigidbody2D _rigidbody2D;
    private bool _isMovingRight = false;
    private bool _isMovingLeft = false;
    private bool _isMovingUp = false;
    private bool _isMovingDown = false;
    
    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Start is called before the first frame update
    void Start()
    {
        SetMovementSpeedDifficulty(PlayerPrefs.GetString("Difficulty"));

        int currentLevel = PlayerPrefs.GetInt("Level");
        if (currentLevel == 2)
        {
            _speed *= 1.5f;
        }
        else if (currentLevel == 3)
        {
            _speed *= 2.0f;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        Vector2 previousPosition = transform.position;

        if (Vector2.Distance(transform.position, _target.position) > _stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, _target.position, _speed * Time.fixedDeltaTime);
        }

        Flip(previousPosition);

        _rigidbody2D.velocity = new Vector2(0, 0);
    }

    private void Flip(Vector2 previousPosition)
    {
        _differenceX += previousPosition.x - transform.position.x;
        _differenceY += previousPosition.y - transform.position.y;

        if (_differenceX > 0.5)
        {
            transform.rotation = Quaternion.Euler(0, 0, 90f);
            _differenceX = 0;
            _differenceY = 0;
            _isMovingLeft = true;
            _isMovingRight = false;
            _isMovingUp = false;
            _isMovingDown = false;
        } 
        else if (_differenceX < -0.5)
        {
            transform.rotation = Quaternion.Euler(0, 0, 270f);
            _differenceX = 0;
            _differenceY = 0;
            _isMovingRight = true;
            _isMovingLeft = false;
            _isMovingUp = false;
            _isMovingDown = false;
        }

        else if (_differenceY > 0.5)
        {
            transform.rotation = Quaternion.Euler(0, 0, 180f);
            _differenceX = 0;
            _differenceY = 0;
            _isMovingDown = true;
            _isMovingUp = false;
            _isMovingRight = false;
            _isMovingLeft = false;
        }
        else if (_differenceY < -0.5)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0f);
            _differenceX = 0;
            _differenceY = 0;
            _isMovingUp = true;
            _isMovingDown = false;
            _isMovingRight = false;
            _isMovingLeft = false;
        }

        SetMovementDirection();
    }

    private void SetMovementDirection()
    {
        if (_isMovingRight)
        {
            _movementDirection.x = 1;
            _movementDirection.y = 0;
        }
        else if (_isMovingLeft)
        {
            _movementDirection.x = -1;
            _movementDirection.y = 0;
        } 
        else if (_isMovingUp)
        {
            _movementDirection.y = 1;
            _movementDirection.x = 0;
        }
        else if (_isMovingDown)
        {
            _movementDirection.y = -1;
            _movementDirection.x = 0;
        }
    }

    public Vector2 GetMovementDirection()
    {
        return _movementDirection;
    }

    private void SetMovementSpeedDifficulty(string difficulty)
    {
        switch (difficulty)
        {
            case "Easy":
                _speed = 2.0f;
                break;
            case "Medium":
                _speed = 2.5f;
                break;
            case "Hard":
                _speed = 3.0f;
                break;
        }
    }
}
