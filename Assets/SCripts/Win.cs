using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Win : MonoBehaviour
{
    private int p1h;
    private int p2h;

    public Text _p1h;
    // public Text _p2h;
    public Image bgcolor;
    
    private void Awake()
    {
        p1h = PlayerPrefs.GetInt("p1h");
        p2h = PlayerPrefs.GetInt("p2h");
    }

    public void Update()
    {
        if (p1h > p2h)
        {
            Debug.Log("Player 1 Win");
            _p1h.text = "RED Win !";
            bgcolor.color = Color.red;

        }
        else
        {
            Debug.Log("player 2 Win");
            _p1h.text = "BLUE Win !";
            bgcolor.color  =  Color.blue; 
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
    }
    
    
}
