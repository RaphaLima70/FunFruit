using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_drag : MonoBehaviour {

    Vector3 ponteiro;
    public float minX, maxX;
    
    public void Update()
    {
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, minX, maxX), transform.position.y);
    }

    public void OnMouseDrag()
    {
        ponteiro = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        ponteiro.y = transform.position.y;
        ponteiro.z = transform.position.z;
        transform.position = ponteiro;
    }

}
