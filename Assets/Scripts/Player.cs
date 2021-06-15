using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float constantPush = 0.1f;
    [SerializeField] private float forceSpeedLimit = 50f;

    private Rigidbody rigidbody;
    private SceneManager sceneManager;

    private void Start()
    {
        sceneManager = FindObjectOfType<SceneManager>();
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (rigidbody.velocity.magnitude < forceSpeedLimit)
        {
            rigidbody.AddForce(-Vector3.forward * constantPush * Time.deltaTime);
        }
    }

    public float GetTopSpeed()
    {
        return forceSpeedLimit;
    }

    public float GetSpeed()
    {
        return rigidbody.velocity.magnitude;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            sceneManager.GameOver();
        }
    }
}
