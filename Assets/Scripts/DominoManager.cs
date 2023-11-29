using UnityEngine;

public class DominoManager : MonoBehaviour
{
    public GameObject dominoStructurePrefab; // Assign your DominoStructure prefab in the Unity Inspector
    public GameObject structureSpawnPoint; // Assign a GameObject in the Unity Inspector to act as the spawn point
    private GameObject currentStructure;
    public float resetDelay = 5f; // Time in seconds to reset the structure after it's knocked down

    void Start()
    {
        CreateNewStructure();
    }

    void Update()
    {
        // Add any additional game logic if needed
    }

    private void CreateNewStructure()
    {
        if (currentStructure != null)
        {
            Destroy(currentStructure);
        }
        if (structureSpawnPoint != null)
        {
            currentStructure = Instantiate(dominoStructurePrefab, structureSpawnPoint.transform.position, structureSpawnPoint.transform.rotation);
        }
        else
        {
            Debug.LogError("Spawn point not set for DominoStructure");
        }
    }

    // Call this method when the ball hits the structure
    public void OnDominoHit()
    {
        Invoke("CreateNewStructure", resetDelay);
    }

    // Example of how you might detect the collision
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball")) // Make sure your ball has the tag "Ball"
        {
            OnDominoHit();
        }
    }
}
