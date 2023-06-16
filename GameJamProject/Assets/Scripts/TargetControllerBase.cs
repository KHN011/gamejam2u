using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetControllerBase<T> : MonoBehaviour where T : Target
{
    [SerializeField] protected float _spawnFrequency = 5;
    [SerializeField] private float _speedUpTimeThreshold = 5f;
    [SerializeField] protected T[] _prefabs;
    [SerializeField] protected Transform[] _spawnPoints;

    private float _timeCounter = 0;
    protected Coroutine _spawnRoutine = null;
    protected List<T> _targets = new List<T>();

    private void OnEnable()
    {
        GameController.gunShooting += onGunShooting;
        GameController.targetDied += onTargetDied;
    }

    private void OnDisable()
    {
        GameController.gunShooting -= onGunShooting;
    }

    public void startSpawn()
    {
        if (_spawnRoutine != null)
        {
            StopCoroutine(_spawnRoutine);
            _spawnRoutine = null;
        }
        _spawnRoutine = StartCoroutine(spawnRoutine());
    }

    public void stopSpawn()
    {
        StopAllCoroutines();
        _spawnRoutine = null;
    }

    protected IEnumerator spawnRoutine()
    {
        while (true)
        {
            createTarget();            
            yield return new WaitForSeconds(_spawnFrequency);
        }
    }

    protected virtual void createTarget()
    {
        T pref = _prefabs[Random.Range(0, _prefabs.Length)];
        Transform tr = _spawnPoints[Random.Range(0, _spawnPoints.Length)];
        T target = Instantiate(pref, transform);
        target.transform.SetPositionAndRotation(tr.position, tr.rotation);

        _targets.Add(target);
        GameController.targetCreated?.Invoke(target);

    }


    protected void onGunShooting(Vector2 hitPosition)
    {
        // can safely remove elements in reverse mode
        for (int i = _targets.Count - 1; i > -1; i--)
        {
            _targets[i].checkHit(hitPosition);
        }
    }
       

    protected virtual void onTargetDied(Target t)
    {
        T temp = t as T;
        if (_targets.Contains(temp) && temp != null)
        {
            _targets.Remove(temp);
        }
    }

    protected virtual void Update()
    {
        _timeCounter += Time.deltaTime;

        if (_timeCounter > _speedUpTimeThreshold)
        {
            _spawnFrequency *= 0.7f;
            _timeCounter = 0f;
        }
    }

}
