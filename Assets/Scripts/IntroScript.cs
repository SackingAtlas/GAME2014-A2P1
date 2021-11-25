using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroScript : MonoBehaviour
{
     GameObject bg1, bg2, man, blink, fist, hole, eye, fade, instructButton, playButton, backButton, instructions, instructions1;
    private bool moveEye;
    //public bool PlayHasBegun;
    public float speed;
    void Start()
    {
        bg1 = GameObject.Find("IntroBG");
        bg2 = GameObject.Find("BG");
        man = GameObject.Find("IntroGuy");
        blink = GameObject.Find("Blink");
        fist = GameObject.Find("fist");
        hole = GameObject.Find("Hole");
        eye = GameObject.Find("EYE");
        fade = GameObject.Find("BlackFade");
        instructButton = GameObject.Find("InstructionsButton");
        instructions = GameObject.Find("Instructions");
        instructions1 = GameObject.Find("Instructions1");
        playButton = GameObject.Find("PlayButton");
        backButton = GameObject.Find("BackButton");

        DontDestroyOnLoad(blink);

        bg2.SetActive(false);
        blink.SetActive(false);
        hole.SetActive(false);
        eye.SetActive(false);
        instructButton.SetActive(false);
        playButton.SetActive(false);
        backButton.SetActive(false);
        instructions.SetActive(false);
        instructions1.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (moveEye)
        {
            eye.transform.position = Vector2.MoveTowards(eye.transform.position, transform.position, speed * Time.deltaTime);
            if(eye.transform.position.x > -0.1f)
            {
                moveEye = false;
                blink.GetComponent<Animator>().SetBool("blink", true);
            }
        }
    }

    public void PunchedOut()
    {
        hole.SetActive(true);
        fade.GetComponent<Animator>().Play("BlackOutAnim");
        //man.SetActive(false);
        //bg1.SetActive(false);
        fist.GetComponent<Animator>().Play("ShrinkFist");
        man.GetComponent<Animator>().Play("ShrinkGuy");
        bg1.GetComponent<Animator>().Play("ShrinkBg");
    }
    public void Faded()
    {
        fist.SetActive(false);
        hole.SetActive(false);

        bg2.SetActive(true);
        eye.SetActive(true);
        blink.SetActive(true);
        fade.GetComponent<Animator>().Play("FadeIn");
        moveEye = true;
    }

    public void Blink()
    {
        blink.SetActive(true);
    }
    public void SetBlink()
    {
        blink.GetComponent<Animator>().SetBool("blink", false);
    }

    public void Instructions()
    {
        backButton.SetActive(true);
        playButton.SetActive(false);
        instructButton.SetActive(false);
        instructions.SetActive(true);
        instructions1.SetActive(true);
    }

    public void Back()
    {
        backButton.SetActive(false);
        playButton.SetActive(true);
        instructButton.SetActive(true);
        instructions.SetActive(false);
        instructions1.SetActive(false);
    }

    public void SetButtons()
    {
        instructButton.SetActive(true);
        playButton.SetActive(true);
    }
}
