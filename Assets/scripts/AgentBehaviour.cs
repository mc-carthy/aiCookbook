using UnityEngine;

public class AgentBehaviour : MonoBehaviour {

    public GameObject target;
    protected Agent agent;

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

    public Vector3 GetOriAsVec (float orientation)
    {
        Vector3 vector = Vector3.zero;
        vector.x = Mathf.Sin (orientation * Mathf.Deg2Rad);
        vector.z = Mathf.Cos (orientation * Mathf.Deg2Rad);

        return vector.normalized;
    }

}
