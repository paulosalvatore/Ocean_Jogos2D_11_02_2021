using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Jogador : MonoBehaviour
{
    public float velocidade = 1f;

    GameObject caixaColidindo;

    GameObject caixaArrastando;

    public Rigidbody2D rb;

    public int vida = 5;

    public Animator bandeiraAnimator;

    public Text vidasText;

    private void Start()
    {
        vidasText.text = $"Vidas: {vida}";
    }

    private void Update()
    {
        var h = Input.GetAxisRaw("Horizontal") * velocidade;
        var v = Input.GetAxisRaw("Vertical") * velocidade;

        rb.velocity = new Vector3(h, v, 0);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (caixaArrastando)
            {
                caixaArrastando.transform.parent = null;

                caixaArrastando = null;
            }
            else if (caixaColidindo)
            {
                caixaArrastando = caixaColidindo;

                caixaArrastando.transform.parent = transform;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Caixa"))
        {
            caixaColidindo = other.gameObject;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (caixaColidindo == other.gameObject)
        {
            caixaColidindo = null;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Inimigo"))
        {
            vida--;

            vidasText.text = $"Vidas: {vida}";

            if (vida <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
        else if (other.CompareTag("Vitória"))
        {
            bandeiraAnimator.SetTrigger("Ativar");
        }
    }
}
