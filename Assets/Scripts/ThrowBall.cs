using UnityEngine;

public class ThrowBall : MonoBehaviour
{
    public float ballThrowForce = 600f; //throw force
    private Rigidbody rb;
    private bool isHeld = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !isHeld)
        {
            PickUp();
        }
        else if (Input.GetKeyDown(KeyCode.E) && isHeld)
        {
            Throw();
        }
    }

    void PickUp()
    {
        isHeld = true;
        rb.isKinematic = true; 
        transform.SetParent(Camera.main.transform); 
        transform.localPosition = new Vector3(0, 0, 2); 
    }

    void Throw()
    {
        isHeld = false;
        transform.SetParent(null); 
        rb.isKinematic = false; 
        rb.AddForce(Camera.main.transform.forward * ballThrowForce); //Throw ball forward
    }
}
