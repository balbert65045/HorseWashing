using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyWall : MonoBehaviour
{
    [SerializeField] float BounceCoefficient = 1.3f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>())
        {
            ContactPoint contact = collision.GetContact(0);
            Vector3 reflectDir = (new Vector3(collision.gameObject.transform.position.x, 0, collision.gameObject.transform.position.z)) - (new Vector3(contact.point.x, 0, contact.point.z));
            collision.gameObject.GetComponent<PlayerMovement>().Bounce(reflectDir, BounceCoefficient);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
