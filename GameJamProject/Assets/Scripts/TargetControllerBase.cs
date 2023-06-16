using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetControllerBase<T> : MonoBehaviour where T : Target
{
    [SerializeField] protected float _spawnFrequency = 5;
    [SerializeField] protected T[] _prefabs;
    [SerializeField] protected Transform[] _spawnPoints;

    protected Coroutine _spawnRoutine = null;
    protected List<T> _targets = new List<T>();

    private void OnEnable()
    {
        GameController.gunShooting += onGunShooting;
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
            if (_targets[i].checkHit(hitPosition))
            {
                kill(_targets[i]);
            }
        }
    }

    protected void kill(T target)
    {
        GameController.targetDied?.Invoke(target);
        _targets.Remove(target);
        target.hit();
    }

}
