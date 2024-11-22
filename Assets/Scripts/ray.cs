using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Examen2 : MonoBehaviour
{
    public Text cuentaAtrasTexto;
    public int cuentaAtrasDuracion = 5;
    public string[] nombresObjetos;
    public string[] nombresEscenas;
    private bool estaContando = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                for (int i = 0; i < nombresObjetos.Length; i++)
                {
                    if (hit.transform.name == nombresObjetos[i] && !estaContando)
                    {
                        StartCoroutine(CuentaAtras(nombresEscenas[i]));
                        break;
                    }
                }
            }
        }
    }

    IEnumerator CuentaAtras(string escenaDestino)
    {
        estaContando = true;

        for (int i = cuentaAtrasDuracion; i >= 0; i--)
        {
            cuentaAtrasTexto.text = i.ToString();
            yield return new WaitForSeconds(1);
        }

        SceneManager.LoadScene(escenaDestino);
        estaContando = false;
    }
}
