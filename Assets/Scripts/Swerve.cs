using UnityEngine;

public class Swerve : MonoBehaviour
{
    [SerializeField] private float swerveSpeed = 0.5f;
    [SerializeField] float maxSwerveAmount = 1f;
    [SerializeField] private float swerveForce = 10f;

    private float moveFactor;
    private float lastFrameFingerPosition;

    private Rigidbody rigidbody;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        HandleInput();
        HandleSwerve();
    }

    private void HandleInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lastFrameFingerPosition = Input.mousePosition.x;
        }
        else if (Input.GetMouseButton(0))
        {
            moveFactor = Input.mousePosition.x - lastFrameFingerPosition;
            lastFrameFingerPosition = Input.mousePosition.x;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            moveFactor = 0f;
        }
    }
    
    private void HandleSwerve()
    {
        float swerveAmount = Mathf.Clamp(Time.deltaTime * swerveSpeed * moveFactor, -maxSwerveAmount, maxSwerveAmount);
        rigidbody.AddForce(Vector3.left * swerveAmount * swerveForce);
    }
}
