using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHealthTracker : MonoBehaviour
{
    [SerializeField] private int _health = 5;
    [SerializeField] private int _defaultDamage = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage()
    {
        _health -= _defaultDamage;

        if (_health <= 0)
        {
            AdvanceLevel();
        }
    }

    private void AdvanceLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
