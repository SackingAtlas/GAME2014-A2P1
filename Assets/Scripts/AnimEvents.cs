using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimEvents : MonoBehaviour
{
    IntroScript sceneBrain;
    int count = 0;
    public bool PlayHasBegun = false;
    private void Start()
    {
        sceneBrain = GameObject.Find("SceneBrain").GetComponent<IntroScript>();
    }
    public void PunchDone()
    {
        ++count;
        if (count == 3)
            sceneBrain.PunchedOut();
    }
    public void FadedOut()
    {
        sceneBrain.Faded();
    }
    public void BlinkEye()
    {
        sceneBrain.Blink();
    }
    public void BlinkDone()
    {
        if (PlayHasBegun)
            Destroy(gameObject);
        sceneBrain.SetBlink();
    }
    public void EyeIsClosed()
    {
        if (PlayHasBegun)
            SceneManager.LoadScene("Game");
        else
        {
            sceneBrain.SetButtons();
        }
    }
    //public void PunchDone()
    //{

    //}
    //public void PunchDone()
    //{

    //}
    //public void PunchDone()
    //{

    //}
}
