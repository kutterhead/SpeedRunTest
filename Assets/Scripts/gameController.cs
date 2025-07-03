using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameController : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    public Transform[] pistas;
    public GameObject[] prefabObstacle;

    [SerializeField]int indicePistaActual = 0;

    public Vector3 offsetZ = new Vector3 (0, 0, 0);


    public float time = 0;


    public float jumpForce = 10f;



    Rigidbody rb;
    [SerializeField] bool isMoving = true;
    [SerializeField] bool isGrounded = false;
    [SerializeField] int vidas = 3;
    [SerializeField] int puntos = 0;

    public static Action cajaRecolectada;
    public static Action vidaPerdida;
    public static Action<int> cajaRecolectadavalor;
    public static Action<int> vidaPerdidavalor;
    void Start()
    {
        indicePistaActual = 1;
        rb = player.GetComponent<Rigidbody>();
        // Destroy(obstaculo,10f);
    }

    // Update is called once per frame

    public float gameTime = 0;//tiempo de partida
    void Update()
    {

        gameTime += Time.deltaTime;
        time += Time.deltaTime;
        if (time >= 1)
        {
            time = 0;


            int indiceRandom = UnityEngine.Random.Range(0, 3);
            GameObject obstaculo = Instantiate(prefabObstacle[UnityEngine.Random.Range(0, prefabObstacle.Length)], pistas[indiceRandom].transform.position + offsetZ, pistas[1].transform.rotation);
            obstaculo.GetComponent<Rigidbody>().linearVelocity = new Vector3(0, 0, -10);

        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) && !isMoving)
        {

            indicePistaActual--;
            if (indicePistaActual < 0)
            {
                indicePistaActual = 0;
            }

            StartCoroutine(mueveIzquierda(indicePistaActual));
            //player.position = new Vector3(pistas[indicePistaActual].position.x, player.position.y, player.position.z);
        }





        if (Input.GetKeyDown(KeyCode.RightArrow) && !isMoving)
        {

            indicePistaActual++;
            if (indicePistaActual > 2)
            {
                indicePistaActual = 2;
            }
            //player.position = new Vector3(pistas[indicePistaActual].position.x, player.position.y, player.position.z);
            StartCoroutine(mueveIDerecha(indicePistaActual));


        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && !isMoving && isGrounded)
        {

            isGrounded = false;
            rb.linearVelocity = new Vector3(0, jumpForce, 0);

            


        }

    }


    float velocity = 5;
    IEnumerator mueveIzquierda(int index)
    {
        Debug.Log("pulsado L " + index);

        isMoving = true;
        while (true)
        {
            player.Translate(-transform.right*velocity*Time.deltaTime);
            if (player.transform.position.x <= pistas[index].position.x)
            {
                player.position = new Vector3(pistas[indicePistaActual].position.x, player.position.y, player.position.z);

                break;

            }



            yield return null;
        }
        isMoving = false;
    }

    IEnumerator mueveIDerecha(int index)
    {
       // Debug.Log("pulsado D " + index);

        isMoving = true;
        while (true)
        {
            player.Translate(transform.right * velocity * Time.deltaTime);
            if (player.transform.position.x >= pistas[index].position.x)
            {
                player.position = new Vector3(pistas[indicePistaActual].position.x, player.position.y, player.position.z);

                break;

            }



            yield return null;
        }
        isMoving = false;
    }



    //estas funciones deben ir en el suelo
    private void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
        Debug.Log(collision.gameObject.name);
    }
    private void OnTriggerEnter(Collider other)
    {
        isGrounded = true;
        //Debug.Log(other.gameObject.name);

        if (other.gameObject.CompareTag("Item"))
        {
            puntos++;
            Destroy(other.gameObject);
            Debug.Log($"Caja recolectada {puntos}.");
            cajaRecolectada?.Invoke();
            cajaRecolectadavalor?.Invoke(puntos);
        }
        else if (other.gameObject.CompareTag("Obstacle"))
            {
                vidas--;
                Destroy(other.gameObject);
                Debug.Log($"hemos perdido vida {vidas}.");
            vidaPerdida?.Invoke();
            vidaPerdidavalor?.Invoke(vidas);
            if (vidas < 0)
            {
                Debug.Log($"Game Over");

            }
        }

    }

    public void restaVida()
    {

    }
    public void sumaPuntos()
    {


    }


}
