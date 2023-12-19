using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f; // Speed of the bullet
    public float lifetime = 2f; // Time before the bullet is destroyed
    private Transform cam; // Reference to the camera

    public void Initialize(Transform cameraTransform)
    {
        cam = cameraTransform;
    }

    void Start()
    {
        // Set the bullet to destroy itself after a certain time to avoid clutter
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        // Move the bullet forward
        transform.Translate(cam.forward * speed * Time.deltaTime, Space.World);
    }

    void OnCollisionEnter(Collision collision)
    {
        // Uncomment the line below if you want the bullet to be destroyed on collision
        // Destroy(gameObject);

        // Add logic here for what happens when the bullet collides with something
        // For example, you might damage an enemy, play a particle effect, etc.
    }
}
