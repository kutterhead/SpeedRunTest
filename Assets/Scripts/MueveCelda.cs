using UnityEngine;

public class MueveCelda : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public Material baldosas;


    public float velocidad = 10f;
    float tiempo = 0f;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        tiempo += Time.deltaTime;
        baldosas.SetTextureOffset("_MainTex", new Vector2(0,-1) * tiempo * velocidad);

    }
}
