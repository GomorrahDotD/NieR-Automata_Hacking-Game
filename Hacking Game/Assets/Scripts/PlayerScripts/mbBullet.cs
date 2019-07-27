using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mbBullet : MonoBehaviour
{
    public Transform effectSpawnLocation;
    public GameObject effectPrefab;

    [SerializeField] private float lifeSpan = 1f;
    [SerializeField] private float speed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        // Destroys the bullet after its lifeSpan is over
        lifeSpan -= Time.deltaTime;
        Debug.Log(lifeSpan);

        if (lifeSpan > 0)
        {
            //forward in local space
            Vector3 movement = new Vector3(0f, 0f, 1f) * speed * Time.deltaTime;
            //converts the local space vector to the world space vector
            movement = transform.TransformDirection(movement);
            transform.position += movement;
        }
        else Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(string.Format("Collision detected between {0} and {1}", gameObject.name, collision.collider.name));

        Instantiate(effectPrefab, effectSpawnLocation.position, effectSpawnLocation.rotation);
        Destroy(gameObject);
    }
}
