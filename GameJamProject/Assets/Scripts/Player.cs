using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject _leftGunVisual;
    [SerializeField] private GameObject _rightGunVisual;
    
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
        AudioManager.instance.Play("Gun shot");
        GameController.gunTriggerPulling?.Invoke(targetPosition);
    }

    private void MoveGun(Vector2 targetPosition)
    {
        if (targetPosition.x < GameController.screenCenterPosX)
        {
            // left gun visual
            _leftGunVisual.SetActive(true);
            _rightGunVisual.SetActive(false);
            Vector3 pos = _leftGunVisual.transform.position;
            
            _leftGunVisual.transform.position = new Vector3(targetPosition.x * 0.3f, pos.y, pos.z);
        }
        else
        {
            // right gun visual
            _leftGunVisual.SetActive(false);
            _rightGunVisual.SetActive(true);
            Vector3 pos = _leftGunVisual.transform.position;
            _rightGunVisual.transform.position = new Vector3(targetPosition.x * 0.3f, pos.y, pos.z);
            
        }
    }

}
