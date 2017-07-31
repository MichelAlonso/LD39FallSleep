using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelicopterLight : MonoBehaviour {
    
    public GameObject target;
    public float speed = .1f;
	// Update is called once per frame
	void Update () {
        Vector3 targetPos = target.transform.position;
        targetPos.y = transform.position.y;

        Quaternion targetRot = Quaternion.LookRotation(target.transform.position);

        Vector3 pos = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * speed);
        Quaternion rot = Quaternion.Lerp(transform.rotation, targetRot, 0.1f);

        transform.rotation = rot;
        transform.position = pos;
	}
}
