using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMovement : MonoBehaviour
{
    public float moveSpeed = 20;
    public GameObject backGround;

    public Vector3 offset = new Vector3(45, 0 , 0);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        if(transform.position.x < 0)
        {
            Instantiate(backGround, transform.position + offset, transform.rotation);
            Destroy(gameObject);
        }
    }
}
