using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carController : MonoBehaviour
{
    [SerializeField] private Rigidbody SphereRB;
    [SerializeField] private float fwdAcccel =  8f, rvsAccel = 4f, maxSpeed = 50f, turnStrength = 180;
    private float Vertical;
    private float turnInput;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        turnInput = Input.GetAxisRaw("Horizontal");
        Vertical = Input.GetAxisRaw("Vertical");
        
    }
    private void FixedUpdate()
    {
        if(Vertical >= 0)
            Vertical *= fwdAcccel;
        else {
            Vertical *= rvsAccel;
        }
        SphereRB.AddForce(transform.forward * Vertical);
        float fwdForce = 0;
        
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, turnInput * turnStrength * Time.deltaTime , 0f));
        transform.position = SphereRB.transform.position;
    }
}
