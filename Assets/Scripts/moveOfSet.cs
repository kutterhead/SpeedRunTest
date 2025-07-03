using System.Drawing;
using UnityEngine;

public class moveOfSet : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public Material moveMaterial;
    public float ajuste = 1f;
    float valor = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        valor -= Time.deltaTime;
        moveMaterial.SetTextureOffset("_MainTex", ajuste * valor * Vector2.up);
        
    }
}
