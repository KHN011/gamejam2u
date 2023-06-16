
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using System.Collections;
using System.Threading;

public class Cat : Target
{
    [SerializeField] float _minSpeed;
    [SerializeField] float _maxSpeed;

    [SerializeField] float _minMoveChangeTime;
    [SerializeField] float _maxMoveChangeTime;

    private float _speed = 0;
    private int _direction = 1;
    bool enableRandomization = true;

    private Coroutine _moveRandomizationRoutine = null;

    // Start is called before the first frame update
    void Start()
    {
        //const float waitTime = 2.0f;
        //StartCoroutine(WaitAndPrint(waitTime));
        _speed = _maxSpeed;
        if (_moveRandomizationRoutine != null)
        {
            StopCoroutine(_moveRandomizationRoutine);
        }

        if (enableRandomization)
        {
            _moveRandomizationRoutine = StartCoroutine(moveRandomizationRoutine());
        }

        AudioManager.instance.PlayDelayed("Cat purr", 0.5f);

    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public override void hit()
    {
        System.Random rnd = new System.Random();
        int randomInt = rnd.Next(1, 6);
         AudioManager.instance..Stop("Cat purr");
         AudioManager.instance..Play("Cat hit" + randomInt);
        // play sound
        // play anim ?
        // set score?
        base.hit();
    }

    private IEnumerator WaitAndPrint(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        enableRandomization = true;
    }

    private void Move()
    {
        transform.position += _direction * transform.right * _speed * Time.deltaTime;
        if (GameController.outOfScreen(transform.position))
        {
            _score = 0;
            die();
        }
    }

    private IEnumerator moveRandomizationRoutine()
    {
        yield return new WaitForSeconds(_maxMoveChangeTime);

        while (true)
        {

            _speed = Random.Range(_minSpeed, _maxSpeed);

            // zero is waiting
            _direction = Random.Range(0, 3) - 1;
            yield return new WaitForSeconds(Random.Range(_minMoveChangeTime, _maxMoveChangeTime));
        }
    }

    void Stop()
    {
        AudioManager.instance.Stop("Cat purr");
    }
}
