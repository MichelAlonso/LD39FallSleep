using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    new Camera camera;
    public GameObject target;
    public Vector3 distance;

    void Start () {
        camera = GetComponent<Camera>();
	}

    void Update () {
        camera.transform.LookAt(target.transform.position);

        Vector3 position = target.transform.position + distance;
        transform.position = Vector3.Lerp(transform.position, position, Time.deltaTime);
	}

    public void FlipDirection()
    {
        distance = new Vector3(distance.z, distance.y, distance.x);
    }
}
