using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroButtons : MonoBehaviour
{
    public void PlayPressed()
    {
        SceneManager.LoadScene("Game");
        GameObject.Find("Blink").GetComponent<AnimEvents>().PlayHasBegun = true;
        GameObject.Find("Blink").GetComponent<Animator>().SetBool("blink", true);
    }

    public void InstructionPressed()
    {
        GameObject.Find("SceneBrain").GetComponent<IntroScript>().Instructions();
    }

    public void BackPressed()
    {
        GameObject.Find("SceneBrain").GetComponent<IntroScript>().Back();
    }
}
