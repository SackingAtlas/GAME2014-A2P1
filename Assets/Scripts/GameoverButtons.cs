using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameoverButtons : MonoBehaviour
{
    // Start is called before the first frame update
    public void Replay()
    {
        SceneManager.LoadScene("Intro");
    }

    // Update is called once per frame
    public void Gameover()
    {
        Application.Quit();
    }
}
