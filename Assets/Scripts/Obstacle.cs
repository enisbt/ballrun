using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private bool moving;
    [SerializeField] private float boundary = 1.25f;

    private float speed;
    private bool directionRight = true;

    private void Start()
    {
        speed = Random.Range(0.5f, 2f);
    }

    private void Update()
    {
        if (moving)
        {
            HandleMovement();
        }
    }

    private void HandleMovement()
    {
        if (directionRight)
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
        else
        {
            transform.Translate(-Vector3.right * Time.deltaTime * speed);
        }

        if (transform.position.x >= boundary)
        {
            directionRight = false;
        }
        else if (transform.position.x <= -boundary)
        {
            directionRight = true;
        }
    }
}
