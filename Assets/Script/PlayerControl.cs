using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerControl : MonoBehaviour
{
    [SerializeField] private float playerSpeed;


    private float horizontal;
    private float vertical;

    

    
    void Update()
    {
        movementControl();
    }

    private void movementControl()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        Vector3 directions = new Vector3(horizontal, 0.0f, vertical) * playerSpeed * Time.deltaTime;
        transform.Translate(directions);
    }
}
