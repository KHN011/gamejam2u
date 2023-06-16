using UnityEngine;

public class ScoreController : MonoBehaviour
{
    private int _score = 0;

    [SerializeField] private TMPro.TextMeshProUGUI _scoreText;


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
        _scoreText.SetText(_score.ToString());
    }

    public void resetScore()
    {
        _score = 0;
        _scoreText.SetText(_score.ToString());
    }
}
