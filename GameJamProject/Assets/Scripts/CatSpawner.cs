using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatSpawner : MonoBehaviour
{
    [SerializeField] private float _catSpawnFrequency = 5;
    [SerializeField] private Cat[] _catPrefabs;
    [SerializeField] private Transform[] _spawnPoints;

    private Coroutine _catSpawnerRoutine = null;
    
    
    public void startSpawnCats()
    {
        if (_catSpawnerRoutine != null)
        {
            StopCoroutine(_catSpawnerRoutine);
        }
        _catSpawnerRoutine = StartCoroutine(spawnCats());
    }

    private IEnumerator spawnCats()
    {
        while(true)
        {
            Cat cPref = _catPrefabs[Random.Range(0, _catPrefabs.Length)];
            int index = Random.Range(0, _spawnPoints.Length);
            Transform tr = _spawnPoints[index];
            Cat c = Instantiate(cPref, transform);
            c.transform.SetPositionAndRotation(tr.position, tr.rotation);

            if (false)
            {
               c.transform.Rotate(new Vector3(0, 180, 0));
            }
            // give back to TargetManager

            yield return new WaitForSeconds(_catSpawnFrequency);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
