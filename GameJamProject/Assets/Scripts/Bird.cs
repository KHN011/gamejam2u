using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : Target
{

    [SerializeField] float _minSpeed;
    [SerializeField] float _maxSpeed;

    [SerializeField] float _minMoveChangeTime;
    [SerializeField] float _maxMoveChangeTime;

    private float _speed = 0;
    private Vector3 _direction;
    private Transform _balloonTransform;

    private Coroutine _moveRandomizationRoutine = null;

    void Start()
    {
        //const float waitTime = 2.0f;
        //StartCoroutine(WaitAndPrint(waitTime));
        _speed = _maxSpeed;
        if (_moveRandomizationRoutine != null)
        {
            StopCoroutine(_moveRandomizationRoutine);
        }

        _moveRandomizationRoutine = StartCoroutine(moveRandomizationRoutine());

        System.Random rnd = new System.Random();
        int randomInt = rnd.Next(1, 4);
        if (randomInt < 3) AudioManager.instance.PlayDelayed("Duck quack" + randomInt, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public override void hit()
    {
        System.Random rnd = new System.Random();
        int randomInt = rnd.Next(1, 2);
        // AudioManager.instance.Play("Bird hit" + randomInt);
        base.hit();
    }

    private void Move()
    {
        transform.position += _direction * _speed * Time.deltaTime;
    }

    private IEnumerator moveRandomizationRoutine()
    {
        yield return new WaitForSeconds(_maxMoveChangeTime);

        while (true)
        {

            _speed = Random.Range(_minSpeed, _maxSpeed);
            yield return new WaitForSeconds(Random.Range(_minMoveChangeTime, _maxMoveChangeTime));
        }
    }

    public void setBalloon(Transform balloonTr)
    {
        if (balloonTr == null) return;
        _balloonTransform = balloonTr;

        _direction = balloonTr.position - transform.position;
        Move();
    }

}
