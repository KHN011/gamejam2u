using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public Button playBtn;
    public Button howtoplayBtn;
    public Button exitBtn;
    public Button backBtn;
    public GameObject instructions;

    private void Start()
    {
        backBtn.gameObject.SetActive(false);
        instructions.SetActive(false);
    }

    public void onPlay()
    {
        SceneManager.LoadScene("Main");
    }

    public void onExit()
    {
        Application.Quit();
    }

    public void onHowtoplay()
    {

        playBtn.gameObject.SetActive(false);
        howtoplayBtn.gameObject.SetActive(false);
        exitBtn.gameObject.SetActive(false);
        backBtn.gameObject.SetActive(true);
        instructions.SetActive(true);
    }

    public void onBack()
    {
        playBtn.gameObject.SetActive(true);
        howtoplayBtn.gameObject.SetActive(true);
        exitBtn.gameObject.SetActive(true);
        backBtn.gameObject.SetActive(false);
        instructions.SetActive(false);
    }
}
