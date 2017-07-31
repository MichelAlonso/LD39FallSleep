using UnityEngine;
using System.Collections;

public class Car : MonoBehaviour
{
    public new Rigidbody rigidbody;
    public float power;

    void Start()
    {
        if (rigidbody == null)
        {
            rigidbody = GetComponent<Rigidbody>();

        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float accel = Input.GetAxis("Vertical") * power;
        float rot = Input.GetAxis("Horizontal") * power;
        rigidbody.AddForce(transform.forward * accel, ForceMode.Force);
        rigidbody.AddTorque(transform.up * rot);
    }

    private void Reset()
    {
        transform.position = Vector3.zero;
    }
}
