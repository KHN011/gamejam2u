using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // public static GameController Instance = null;

    [SerializeField] private CatController _catController;
    [SerializeField] private BirdController _birdController;
    [SerializeField] private Balloon _balloon;

    public static System.Action<Vector2> gunShooting;
    public static System.Action<Target> targetCreated;
    public static System.Action<Target> targetDied;

    public static float screenTopPosY = 0f;
    public static float screenBottomPosY = 0f;
    public static float screenLeftPosX = 0f;
    public static float screenRightPosX = 0;
    public static float screenCenterPosX = 0f;
    

    private void Start()
    {
        setScreenPositions();
        startGame();   
    }

    private void OnEnable()
    {
        targetDied += onTargetDied;
    }

    private void OnDisable()
    {
        targetDied -= onTargetDied;
    }


    public void startGame()
    {
        // give valid balloon transform
        _birdController.balloon = _balloon;
        _birdController.startSpawn();
        _catController.startSpawn();
    }

    public void endGame()
    {
        _birdController.stopSpawn();
        _catController.stopSpawn();
        Debug.Log("end game");
    }

    private void setScreenPositions()
    {
        Vector3 leftBottomCorner = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0f));
        Vector3 rightTopCorner = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0f));

        screenBottomPosY = leftBottomCorner.y;
        screenLeftPosX = leftBottomCorner.x;
        screenTopPosY = rightTopCorner.y;
        screenRightPosX = rightTopCorner.x;

        screenCenterPosX = (screenRightPosX + screenLeftPosX) / 2f;

    }

    public static bool outOfScreen(Vector3 position)
    {
        return (position.x > screenRightPosX || position.y < screenLeftPosX
            || position.y > screenTopPosY || position.y < screenBottomPosY);
    }

    private void onTargetDied(Target t)
    {
        Balloon b = t as Balloon;
        if (b != null)
        {
            endGame();
        }
    }

    
}
