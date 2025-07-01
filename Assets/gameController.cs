using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameController : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform[] pistas;

    public GameObject prefabObstacle;



    public Vector3 offsetZ = new Vector3 (0, 0, 0);
    void Start()
    {
      
       // Destroy(obstaculo,10f);
    }

    // Update is called once per frame

    float time = 0;
    float time2 = 0;
    void Update()
    {
        time += Time.deltaTime;
        time2 += Time.deltaTime;
        if (time>=1)
        {
            time = 0;


            int indiceRandom = Random.Range(0,3);
            GameObject obstaculo = Instantiate(prefabObstacle, pistas[indiceRandom].transform.position + offsetZ, pistas[1].transform.rotation);
            obstaculo.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -5);

        }
       

    }
}
