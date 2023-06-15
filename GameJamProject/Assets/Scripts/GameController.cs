using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance = null;

    [SerializeField] private CatSpawner _catSpawner;



    private TargetManager _targetManager = null;

    private void Awake()
    {
        
        if (Instance != this && Instance != null)
        {
            DestroyImmediate(this.gameObject);
        }
        
        if (Instance == null)
        {
            Instance = this;

            
        }
        init();
    }

    private void Start()
    {
        startGame();   
    }

    private void init()
    {
        _targetManager = new TargetManager();
    }

    public void startGame()
    {
        _catSpawner.startSpawnCats();
    }

    public void endGame()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
