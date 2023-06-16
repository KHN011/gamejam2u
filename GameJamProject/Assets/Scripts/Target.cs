using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] protected int _score = 0;
    // size of target
    [SerializeField] protected float _radius = 0;

    public int Score { get => _score; }

    public Vector2 worldPosition()
    {
        return new Vector2(transform.position.x, transform.position.y);
    }

    public void checkHit(Vector2 worldPos)
    {
        if (Vector2.Distance(worldPos, worldPosition()) < _radius)
        {
            hit();
        }
    }

    public virtual void hit()
    {
        // play sound
        // play anim ?
        // set end ?
        die();
    }
    

    public virtual void die()
    {
        GameController.targetDied?.Invoke(this);
        Destroy(gameObject);
    }
   
}
