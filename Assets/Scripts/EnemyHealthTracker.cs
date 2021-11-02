using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemyHealthTracker : MonoBehaviour
{
    [SerializeField] private int _health = 5;
    [SerializeField] private int _defaultDamage = 1;
    [SerializeField] private GameObject _heartPrefab;
    [SerializeField] private Text _healthText;

    private const float _heartDefaultX = 5.3f;
    private const float _heartDefaultY = 4.3f;
    private const float _heartXPositionOffset = 0.5f;
    private GameObject[] _hearts = new GameObject[5];
    private GameObject _player;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _healthText.text = "Enemy HP: " + _health;

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
        _healthText.text = "Enemy HP: " + _health;

        if (_health <= 0)
        {
            int level = SceneManager.GetActiveScene().buildIndex - 1;

            PlayerPrefs.SetInt("Level", level);
            AdvanceLevel();

            const int basePoints = 3;
            PersistentData.instance.SetScore(PersistentData.instance.GetScore() + basePoints * (level - 1));

            if (PlayerPrefs.GetString("Difficulty") == "Medium")
            {
                PersistentData.instance.SetScore(PersistentData.instance.GetScore() + basePoints);
            }
            else if (PlayerPrefs.GetString("Difficulty") == "Hard")
            {
                PersistentData.instance.SetScore(PersistentData.instance.GetScore() + basePoints * 2);
            }

            int playerHP = _player.GetComponent<PlayerHealthTracker>().GetHealth();
            PersistentData.instance.SetScore(PersistentData.instance.GetScore() + playerHP);
        }
    }

    private void AdvanceLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
