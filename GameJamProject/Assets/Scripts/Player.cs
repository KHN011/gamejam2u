using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Sprite _leftGunVisual;
    [SerializeField] private Sprite _rightGunVisual;
    // Start is called before the first frame update
    

    // Update is called once per frame
    private void Update()
    {
        Vector3 temp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos2D = new Vector2(temp.x, temp.y);

        MoveGun(mousePos2D);

        if (Input.GetMouseButtonDown(0))
        {
            Fire(mousePos2D);
        }
    }

    private void Fire(Vector2 targetPosition)
    {
        // via GameController _targetManager.checkHit(mousePos2D);
        // play sound
    }

    private void MoveGun(Vector2 targetPosition)
    {
        if (targetPosition.x > Screen.width / 2)
        {
            // left gun visual
        }
        else
        {
            // right gun visual
        }
    }
}
