using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    public TextMeshProUGUI textMeshPuntos;
    public TextMeshProUGUI textMeshVidas;



    void Start()
    {
        gameController.cajaRecolectadavalor += actualizaPuntos;
        gameController.vidaPerdidavalor += actualizaVidas;
    }

    // Update is called once per frame
    
    void actualizaPuntos(int puntos){
        textMeshPuntos.text = puntos.ToString();
    }
    void actualizaVidas(int vidas)
    {
        textMeshVidas.text = vidas.ToString();
    }

}
