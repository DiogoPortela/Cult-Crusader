using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArrowController : MonoBehaviour
{
    public GameObject pointingArrowRef;
    private new Camera camera;

    private void Awake() {
        camera = GetComponentInChildren<Camera>();
    }

    private void FixedUpdate()
    {
        var plane = new Plane(Vector3.up, Vector3.zero);
        var ray = camera.ScreenPointToRay(Input.mousePosition);

        float distance = 0;
        if (plane.Raycast(ray, out distance))
        {
            Vector3 mouseWorldPosition = ray.GetPoint(distance);
            Vector3 direction = (mouseWorldPosition - this.transform.position).normalized;
            float angle = Vector3.SignedAngle(pointingArrowRef.transform.forward, direction, Vector3.up);
            pointingArrowRef.transform.RotateAround(this.transform.position, Vector3.up, angle);
        }
    }
}
