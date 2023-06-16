using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private int _score = 0;
    // size of target
    [SerializeField] private float _radius = 0;

    public int Score { get => _score; }

    public Vector2 worldPosition()
    {
        return new Vector2(transform.position.x, transform.position.y);
    }

    public bool checkHit(Vector2 worldPos)
    {
        return Vector2.Distance(worldPos, worldPosition()) < _radius;
    }
    
    public virtual void hit()
    {
        // GetComponent<AudioSource>().Play();
        Destroy(gameObject);
    }
    
    private void Update()
    {
        // some movement
    }
}
