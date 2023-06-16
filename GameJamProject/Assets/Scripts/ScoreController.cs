using UnityEngine;

public class ScoreController : MonoBehaviour
{
    private int _score = 0;


    private void OnEnable()
    {
        GameController.targetDied += onTargetDied;
    }

    private void OnDisable()
    {
        GameController.targetDied -= onTargetDied;
    }

    private void onTargetDied(Target t)
    {
        _score += t.Score;
        Debug.Log("score: " + _score);
    }
}
