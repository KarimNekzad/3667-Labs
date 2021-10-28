using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementAI : MonoBehaviour
{
    [SerializeField] private float _speed = 2.5f;
    [SerializeField] private float _differenceX = 0;
    [SerializeField] private float _differenceY = 0;
    [SerializeField] private float stoppingDistance = 2.5f;

    private Transform _target;
    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
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
        Vector2 previousPosition = transform.position;

        if (Vector2.Distance(transform.position, _target.position) > stoppingDistance)
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
        } 
        else if (_differenceX < -0.5)
        {
            transform.rotation = Quaternion.Euler(0, 0, 270f);
            _differenceX = 0;
            _differenceY = 0;
        }

        else if (_differenceY > 0.5)
        {
            transform.rotation = Quaternion.Euler(0, 0, 180f);
            _differenceX = 0;
            _differenceY = 0;
        }
        else if (_differenceY < -0.5)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0f);
            _differenceX = 0;
            _differenceY = 0;
        }
    }
}
