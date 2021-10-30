using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealthTracker : MonoBehaviour
{
    [SerializeField] private int _health = 5;
    [SerializeField] private int _defaultDamage = 1;
    [SerializeField] private GameObject _heartPrefab;
    [SerializeField] private Text _healthText;

    private const float _heartDefaultX = -8;
    private const float _heartDefaultY = 4.3f;
    private const float _heartXPositionOffset = 0.5f;
    private GameObject[] _hearts = new GameObject[5];

    // Start is called before the first frame update
    void Start()
    {
        _healthText.text = "Player HP: " + _health;

        for (int i = 0; i < _health; i++)
        {
            GameObject heartInstance = Instantiate(_heartPrefab);
            heartInstance.transform.position = new Vector3(_heartDefaultX + _heartXPositionOffset * i, _heartDefaultY, 0f);
            _hearts[i] = heartInstance;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage()
    {
        int rightmostHeartIndex = _health - 1;
        if (rightmostHeartIndex >= 0 && rightmostHeartIndex <= 4)
        {
            Destroy(_hearts[rightmostHeartIndex]);
        }

        _health -= _defaultDamage;
        _healthText.text = "Player HP: " + _health;


        if (_health <= 0)
        {
            RestartLevel();
        }
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
