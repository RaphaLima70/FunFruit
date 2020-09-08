using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_player : MonoBehaviour {


    public BoxCollider2D colisao;

    public scr_gerenciador linkG;

    public Animator animacao;

    public AudioSource comeu;
    public AudioSource dano;

    private void Awake()
    {
        linkG = GameObject.Find("gerenciador").GetComponent<scr_gerenciador>();
    }

    IEnumerator TomarDano()
    {
        animacao.SetInteger("estado", 1);
        yield return new WaitForSeconds(1);
        colisao.enabled = true;
        animacao.SetInteger("estado", 0);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "fruta")
        {
            comeu.Play();
            Debug.Log("pontuou");
            linkG.pontos += 2;
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "dano")
        {
            dano.Play();
            colisao.enabled = false;
            StartCoroutine(TomarDano());
            Debug.Log("tomou dano");
            linkG.vida--;
            Destroy(other.gameObject);
        }
    }
}
