using UnityEngine;

public class BoatShooting : MonoBehaviour
{
    [SerializeField] float rayDistance = 5;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("space"))
        {
            if (Physics2D.Raycast(transform.position, transform.up * rayDistance, rayDistance))
            {
                Debug.Log("AAAAA");
            }
        }

        Debug.DrawRay(transform.position, transform.up * rayDistance, Color.red);
    }
}
