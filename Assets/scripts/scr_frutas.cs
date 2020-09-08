using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_frutas : MonoBehaviour {

    public float velocidade;

    public scr_gerenciador linkG;

    private void Awake()
    {
        linkG = GameObject.Find("gerenciador").GetComponent<scr_gerenciador>();
    }

    void Start () {

        velocidade = linkG.velocidadeG;

	}
	
	void Update () {

        transform.Translate(Vector3.down * Time.deltaTime * velocidade);
	}

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "destruidor")
        {
            Destroy(gameObject);
        }
    }
}
