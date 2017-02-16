﻿using UnityEngine;

public class Agent : MonoBehaviour {

    public float maxSpeed;
    public float maxAccel;
    public float maxRotation;
    public float maxAngularAccel;
    public float orientation;
    public float rotation;
    public Vector3 velocity;
    protected Steering steering;

    private void Start ()
    {
        velocity = Vector3.zero;
        steering = new Steering ();
    }

    public virtual void Update ()
    {
        Vector3 displacement = velocity * Time.deltaTime;
        orientation += rotation * Time.deltaTime;

        if (orientation < 0)
        {
            orientation += 360f;
        }
        if (orientation > 360)
        {
            orientation -= 360f;
        }

        transform.Translate (displacement, Space.World);
        transform.rotation = new Quaternion ();
        transform.Rotate (Vector3.up, orientation);
    }

    public virtual void LateUpdate ()
    {
        velocity += steering.linear * Time.deltaTime;
        rotation += steering.angular * Time.deltaTime;

        if (velocity.magnitude > maxSpeed)
        {
            velocity.Normalize ();
            velocity *= maxSpeed;
        }

        if (steering.angular == 0.0f)
        {
            rotation = 0.0f;
        }

        if (steering.linear.sqrMagnitude == 0)
        {
            velocity = Vector3.zero;
        }

        steering = new Steering ();
    }

    public void SetSteering (Steering steering)
    {
        this.steering = steering;
    }

}
