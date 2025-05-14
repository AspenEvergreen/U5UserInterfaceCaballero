using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody trb;
    private float minS = 12;
    private float maxS = 16;
    private float maxT = 10;
    private float xR = 4;
    private float ySPos = -6;
    private GManager gManager;
    public int pointVal;

    // Start is called before the first frame update
    void Start()
    {
        gManager = GameObject.Find("GManager").GetComponent<GManager>();

        trb = GetComponent<Rigidbody>();

        // the force to send up
        trb.AddForce(RandomForce(), ForceMode.Impulse);
        trb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);

        transform.position = RandomSpawnPos();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minS, maxS);
    }

    float RandomTorque()
    {
        return Random.Range(-maxT, maxT);
    }

    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xR, xR), ySPos);
    }

    private void OnMouseDown()
    {
        Destroy(gameObject);
        gManager.UpdateScore(pointVal);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
