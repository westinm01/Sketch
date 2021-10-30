using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss1_remove_rocks : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        if (screenPosition.y > Screen.height || screenPosition.y < 0)
            Destroy(this.gameObject);
    }
}
