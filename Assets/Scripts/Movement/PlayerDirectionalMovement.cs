using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDirectionalMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody body;
    public float speed;
    public float vertical;
    public float horizontal;
    void Start()
    {
        body = GetComponent<Rigidbody>();
        transform.rotation = Quaternion.LookRotation(Camera.main.transform.forward, Camera.main.transform.up);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");
        transform.rotation = Quaternion.LookRotation(Camera.main.transform.forward, Camera.main.transform.up);
        var forwardMovement = (transform.forward * vertical) * speed * Time.fixedDeltaTime;
        var rightwardMovement = (transform.right * horizontal) * speed * Time.fixedDeltaTime;
        body.velocity = forwardMovement + rightwardMovement;
    }
}
