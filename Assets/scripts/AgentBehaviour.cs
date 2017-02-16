using UnityEngine;

public class AgentBehaviour : MonoBehaviour {

    public GameObject target;
    protected Agent agent;

    public float maxSpeed;
    public float maxAccel;
    public float maxRotation;
    public float maxAngularAccel;

    public virtual void Awake ()
    {
        agent = GetComponent<Agent> ();
    }

    public virtual void Update ()
    {
        agent.SetSteering (GetSteering ());
    }

    public virtual Steering GetSteering ()
    {
        return new Steering ();
    }

    public float MapToRange (float rotation)
    {
        rotation %= 360f;
        if (Mathf.Abs (rotation) > 180f)
        {
            if (rotation < 0f)
            {
                rotation += 360f;
            }
            else
            {
                rotation -= 360f;
            }
        }
        return rotation;
    }

}
