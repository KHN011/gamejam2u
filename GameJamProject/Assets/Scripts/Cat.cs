
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using System.Collections;
using System.Threading;

public class Cat : Target
{
    [SerializeField] float speed;
    bool enableRandomization = false;
    bool facingLeft;


    // Start is called before the first frame update
    void Start()
    {
        //const float waitTime = 2.0f;
        //StartCoroutine(WaitAndPrint(waitTime));
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        if (enableRandomization)
        {            
            RandomizeMovement();
        }
        
    }

    public void onShooted()
    {
        // play sound
        // play anim ?
        // set score
        Destroy(gameObject);
    }

    private IEnumerator WaitAndPrint(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        enableRandomization = true;
    }

    void Move()
    {
        transform.position = Vector2.left * speed * Time.deltaTime;
    }

    void RandomizeMovement()
    {

    }
}
