using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInput : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }

    private void Fire()
    {
        var shot = BulletPool.Instance.GetObject();
        shot.transform.position = new Vector3(0, 2.5f, 0);
        shot.gameObject.SetActive(true);
    }
}
