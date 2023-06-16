
using UnityEngine;

public class Balloon : Target
{
    [SerializeField] float _speed;
    [SerializeField] float _framesToSwitch = 2000;
    
    private int frameCounter = 0;
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
        AudioManager am = FindObjectOfType<AudioManager>();
        AudioManager.instance.PlayDelayed("Baloon pop", 0.1f);
        AudioManager.instance.PlayDelayed("Baloon deflate", 0.2f);
        base.hit();
    }

    private void Move()
    {
        if(frameCounter >= _framesToSwitch)
        {
            _direction *= -1;
            frameCounter = 0;
        }
        transform.position += _direction * transform.up * _speed * Time.deltaTime;
        frameCounter++;
    }

    private void onGunShooting(Vector2 position)
    {
        checkHit(position);
    }

}
