using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Light))]
[RequireComponent(typeof(SphereCollider))]
public class SpotLightCollider : MonoBehaviour {
    public float maxDistance = 5f;
    new Light light;
    float spotAngle;
    SphereCollider sphereCollider;

    public Action<SpotLightCollider, float> OnHit;

    void Start () {
        light = GetComponent<Light>();
        sphereCollider = GetComponent<SphereCollider>();

        if (light.type == LightType.Spot)
        {
            spotAngle = light.spotAngle;
            sphereCollider.radius = light.range;
            sphereCollider.center = new Vector3(0, 0, light.range * .5f);
        }
	}

    private void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        if (CheckCollision(other))
        {
            float distance = Vector3.Distance(other.transform.position, transform.position);
            float power = Mathf.Min(maxDistance, distance);
            power = Math.Abs(power / maxDistance - 1) * light.intensity;
            power *= .25f;

            //Debug.Log(power);

            OnHit.Invoke(this, power, true);

            Debug.DrawLine(other.transform.position, transform.position, Color.green);
        }
        else
        {
            Debug.DrawLine(other.transform.position, transform.position, Color.red);
        }
    }

    private bool CheckCollision(Collider other)
    {
        bool hit = false;
        Vector3 target = other.transform.position;
        target.y += .8f;
        Vector3 targetDir = other.transform.position - transform.position;

        Ray ray = new Ray(transform.position, targetDir);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, light.range) && hitInfo.transform.CompareTag("Player"))
        {
            Debug.DrawLine(other.transform.position, transform.position, Color.yellow);

            float distance = Vector3.Distance(target, transform.position);
            float angle = Vector3.Angle(targetDir, transform.forward);
            float dist = (spotAngle * .5f) - distance * .5f;

            hit = angle < dist;
        }

        return hit;
    }
}
