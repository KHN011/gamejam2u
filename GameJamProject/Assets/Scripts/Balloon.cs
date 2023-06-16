
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using System.Collections;
using System.Threading;

public class Balloon : Target
{
    [SerializeField] float _speed;
    [SerializeField] float _framesToSwitch = 2000;
    
    private int frameCounter = 0;
    private int _direction = -1;


    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public override void hit()
    {
        // play sound
        // play anim ?
        // set end ?
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
}
