using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // public static GameController Instance = null;

    [SerializeField] private CatController _catController;
    [SerializeField] private BirdController _birdController;

    public static System.Action<Vector2> gunShooting;
    public static System.Action<Target> targetCreated;
    public static System.Action<Target> targetDied;
    

    private void Start()
    {
        startGame();   
    }

    private void OnEnable()
    {
    }


    public void startGame()
    {
        _birdController.startSpawn();
        _catController.startSpawn();
    }

    public void endGame()
    {
        _birdController.stopSpawn();
        _catController.stopSpawn();
    }

    
}
