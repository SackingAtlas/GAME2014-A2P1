using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroButtons : MonoBehaviour
{
    public void PlayPressed()
    {
        Debug.Log("1");
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
