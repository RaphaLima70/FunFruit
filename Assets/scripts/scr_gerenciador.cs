using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_gerenciador : MonoBehaviour
{
    public int nivel;
    public int pontos;
    public int vida;

    public float spawnRateG;
    public float velocidadeG;

    public Text pontuacaoText;
    public Text highScoreText;

    public GameObject loosePainel;
    public GameObject[] vidasImage;

    void Start()
    {
        Time.timeScale = 1;
        vida = 3;
        pontos = 0;
        nivel = 0;
    }

    void Update()
    {
        GerenciaVida();
        Nivelamento();
    }

    public void restart()
    {
        Application.LoadLevel(Application.loadedLevelName);
    }

    public void GerenciaVida()
    {
        pontuacaoText.text = ("Score: " + pontos);
        highScoreText.text = ("HighScore: " + PlayerPrefs.GetInt("highScore"));

        if (pontos > PlayerPrefs.GetInt("highScore"))
        {
            PlayerPrefs.SetInt("highScore", pontos);
        }


        if (vida == 3)
        {
            vidasImage[0].SetActive(true);
            vidasImage[1].SetActive(true);
            vidasImage[2].SetActive(true);
        }
        if (vida == 2)
        {

            vidasImage[2].SetActive(false);
        }
        if (vida == 1)
        {
            vidasImage[1].SetActive(false);
        }


        if (vida <= 0)
        {
            vida = 0;
            Time.timeScale = 0;
            loosePainel.SetActive(true);
        }
    }

    public void Nivelamento()
    {
        if (pontos <= 0)
        {
            nivel = 0;
        }
        else if (pontos > 10 && pontos <= 30)
        {
            nivel = 1;
        }
        else if (pontos > 30 && pontos <= 50)
        {
            nivel = 2;
        }
        else if (pontos > 50 && pontos <= 90)
        {
            nivel = 3;
        }

        else if (pontos > 10 && pontos <= 120)
        {
            nivel = 4;
        }
        else if (pontos > 120)
        {
            nivel = 5;
        }

        switch (nivel)
        {
            case 0:
                spawnRateG = 4;
                velocidadeG = 5;
                break;
            case 1:
                spawnRateG = 3;
                velocidadeG = 6;
                break;

            case 2:
                spawnRateG = 2;
                velocidadeG = 6;
                break;

            case 3:
                spawnRateG = 1;
                velocidadeG = 7;
                break;

            case 4:
                spawnRateG = 0.75f;
                velocidadeG = 7;
                break;

            default:
                spawnRateG = 0.5f;
                velocidadeG = 8;
                break;
        }

    }
}
