
using UnityEngine;

public class Balloon : Target
{
    [SerializeField] float _speed;
    [SerializeField] float _timeToSwitchSec = 2;
    
    private float timeCounter = 0;
    private int _direction = -1;

    private void OnEnable()
    {
        GameController.gunShooting += onGunShooting;
    }

    private void OnDisable()
    {
        GameController.gunShooting -= onGunShooting;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public override void hit()
    {
        
        AudioManager.instance.PlayDelayed("Baloon pop", 0.1f);
        AudioManager.instance.PlayDelayed("Baloon deflate", 0.2f);
        AudioManager.instance.PlayDelayed("Duck laugh", 1.5f);

        base.hit();
    }

    private void Move()
    {
        timeCounter += Time.deltaTime;
        if (timeCounter >= _timeToSwitchSec)
        {
            _direction *= -1;
            timeCounter = 0;
        }
        transform.position += _direction * transform.up * _speed * Time.deltaTime;
        
    }

    private void onGunShooting(Vector2 position)
    {
        checkHit(position);
    }

}
