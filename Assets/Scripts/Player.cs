using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float constantPush = 0.1f;
    [SerializeField] private float forceSpeedLimit = 50f;

    private bool lockedVertical = false;
    
    private Rigidbody rigidbody;
    private SceneManager sceneManager;

    private void Start()
    {
        sceneManager = FindObjectOfType<SceneManager>();
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (!lockedVertical && rigidbody.velocity.magnitude > 4)
        {
            // Sometimes a ghost collision happens where two adjacent road fragment connects. To cancel that
            // I am adding y position constraint to rigidbody.
            // Examples: https://forum.unity.com/threads/how-to-prevent-ghost-collisions-without-dots.906839/
            //           https://forum.unity.com/threads/walking-on-meshcolliders-generate-incorrect-collisions.895754/
            //           https://forum.unity.com/threads/ghost-collisions-on-adjacent-box-colliders.850951/
            rigidbody.constraints = RigidbodyConstraints.FreezePositionY;
            lockedVertical = true;
        }
        if (rigidbody.velocity.magnitude < forceSpeedLimit)
        {
            rigidbody.AddForce(-Vector3.forward * constantPush * Time.deltaTime);
        }
    }

    public float GetSpeed()
    {
        return rigidbody.velocity.magnitude;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Obstacle" || other.gameObject.tag == "Side Wall")
        {
            sceneManager.GameOver();
        }
    }
}
