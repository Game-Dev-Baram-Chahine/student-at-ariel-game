using System.Collections;
using UnityEngine;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * This component triggers an explosion effect and destroys its object
 * whenever its object collides with something in a velocity above the threshold.
 */
[RequireComponent(typeof(Rigidbody2D))]
public class CollisionExploder : MonoBehaviour
{
    [SerializeField]
    float minImpulseForExplosion = 1.0f;

    [SerializeField]
    GameObject explosionEffect = null;

    [SerializeField]
    float explosionEffectTime = 0.68f;

    [SerializeField]
    string wonScreen = "WonScreen";

    [SerializeField]
    string gameOverScreen = "GameOver";

    [SerializeField]
    string astroidTag = "Astroid";

    [SerializeField]
    string planetTag = "Jupiter";

    [SerializeField]
    int collisionAngle = 5;

    private Rigidbody2D rb;

    public GameObject rightBorder;
    public GameObject leftBorder;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (checkBorder())
        {
            StartCoroutine(Explosion());
        }
    }
    /// <summary>
    /// Check if the spaceship is out of bounds
    /// </summary>
    /// <returns>true if the ship is out of bounds</returns>
    private bool checkBorder()
    {
        if (rightBorder.transform.position.x <= rb.transform.position.x ||
            leftBorder.transform.position.x >= rb.transform.position.x ||
            rightBorder.transform.position.y <= rb.transform.position.y)
        {
            return true;
        }
        return false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // In 3D, the Collision object contains an .impulse field.
        // In 2D, the Collision2D object does not contain it - so we have to compute it.
        // Impulse = F * DeltaT = m * a * DeltaT = m * DeltaV
        float impulse = collision.relativeVelocity.magnitude * rb.mass;
        float angle = rb.transform.rotation.z;
        print(impulse);
        Debug.Log(
            gameObject.name
                + " collides with "
                + collision.collider.name
                + " at velocity "
                + collision.relativeVelocity
                + " [m/s], impulse "
                + impulse
                + " [kg*m/s]"
        );
        // Check if the collision is also an explosion.
        if (
            impulse > minImpulseForExplosion
            || angle > collisionAngle
            || angle < -collisionAngle
            || collision.collider.tag == astroidTag
        )
        {
            // Start the explosion
            StartCoroutine(Explosion());
        }
        else
        {
            // Go to the "WonScreen" scene.
            int currentIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentIndex + 1);
        }
    }

    IEnumerator Explosion()
    {
        explosionEffect.SetActive(true);
        yield return new WaitForSeconds(explosionEffectTime);
        var myScene = SceneManager.GetActiveScene();
        var sceneName = myScene.name;
        SceneManager.LoadScene(sceneName);
    }
}
