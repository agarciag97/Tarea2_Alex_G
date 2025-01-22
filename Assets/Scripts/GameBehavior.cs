using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameBehavior : MonoBehaviour
{
    public void UpdateScene(string updatedText)
        {
            ProgressText.text = updatedText;
            Time.timeScale = 0f;
        }
    public int MaxItems = 4;

    public TMP_Text HealthText;
    public TMP_Text ItemText;
    public TMP_Text ProgressText;

    public Button WinButton;

    void Start()
    {
        ItemText.text += _itemsCollected;
        HealthText.text += _playerHP;
    }
    public Button LossButton;
    private int _itemsCollected = 0;
    public int Items
    {
        get { return _itemsCollected; }
        set
        {
            _itemsCollected = value;
            ItemText.text = "Items: " + Items;

            if (_itemsCollected >= MaxItems)
            {
                //ProgressText.text = "You've found all the items!";
                WinButton.gameObject.SetActive(true);
                UpdateScene("You've found all the items!");
                Time.timeScale = 0f;
            }
            else
            {
                ProgressText.text = "Item found, only " + (MaxItems - _itemsCollected) + " more!";
            }
        }
    }

    private int _playerHP = 1;
    public int HP
    {

        get { return _playerHP; }
        set
        {
            _playerHP = value;
            HealthText.text = "Health: " + HP;
            if(_playerHP <= 0) {
                ProgressText.text= "You want another life with that?";
                LossButton.gameObject.SetActive(true);
                UpdateScene("You want another life with that?");
                Time.timeScale = 0;
                } 
                else {
                            ProgressText.text = "Ouch... that's got hurt.";
                        }

            Debug.LogFormat("Lives: {0}", _playerHP);
        }
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }
}