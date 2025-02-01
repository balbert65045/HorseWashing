using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyWall : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>())
        {
            ContactPoint contact = collision.GetContact(0);
            float xDiff = transform.position.x - contact.point.x;
            float zDiff = transform.position.z - contact.point.z;

            bool xReflect = false;
            if(Mathf.Abs(xDiff) > Mathf.Abs(zDiff))
            {
                xReflect = true;
            }

            collision.gameObject.GetComponent<PlayerMovement>().Bounce(xReflect);
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
