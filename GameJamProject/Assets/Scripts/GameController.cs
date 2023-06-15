using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance = null;

    [SerializeField] private CatSpawner _catSpawner;



    private TargetManager _targetManager = null;

    public System.Action<Vector2> onGunFiredAction;

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
        onGunFiredAction += onGunFired;
    }

    public void startGame()
    {
        _catSpawner.startSpawnCats();
    }

    public void endGame()
    {

    }

    private void onGunFired(Vector2 bulletPos)
    {
        _targetManager.checkHit(bulletPos);
    }

    public void addTarget(Target t)
    {
        _targetManager.createTarget(t);
    }
}
