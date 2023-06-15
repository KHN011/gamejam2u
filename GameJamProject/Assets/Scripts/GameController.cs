using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance = null;


    private TargetManager _targetManager = null;

    private void Awake()
    {
        /*
        if (Instance != this)
        {
            DestroyImmediate(this.gameObject);
        }
        
        if (Instance == null)
        {
            Instance = this;

            
        }
        */
        init();
    }

    private void Start()
    {
        
    }

    private void init()
    {
        _targetManager = new TargetManager();
    }

    public void startGame()
    {

    }

    public void endGame()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
