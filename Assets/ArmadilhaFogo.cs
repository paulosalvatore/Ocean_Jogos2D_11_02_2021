using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmadilhaFogo : MonoBehaviour
{
    public GameObject armadilhaDesligada;

    public GameObject armadilhaLigada;

    public bool ligado;

    public float delayInicial;

    public float delay;

    void Start()
    {
        InvokeRepeating("AlternarEstadoArmadilha", delayInicial, delay);
    }

    void AlternarEstadoArmadilha()
    {
        ligado = !ligado;

        armadilhaDesligada.SetActive(!ligado);

        armadilhaLigada.SetActive(ligado);
    }
}
