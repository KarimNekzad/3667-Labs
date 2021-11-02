using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayPlayerData : MonoBehaviour
{

    [SerializeField] private Text _scoreText;
    [SerializeField] private Text _playerNameText;
    [SerializeField] private Text _levelText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _playerNameText.text = "Player: " + PersistentData.instance.GetName();
        _scoreText.text = "Score: " + PersistentData.instance.GetScore();
        _levelText.text = "Level: " + PersistentData.instance.GetLevel();
    }
}
