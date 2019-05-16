using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour
{
    [SerializeField] Text scoreCount; //отображение набранных очков
    [SerializeField] AudioClip[] clips; //массив звуков для воспроизведения
    [SerializeField] GameObject deadPanel;

    Rigidbody2D rb2d; //физ. компонент игрока
    AudioSource source; //компонент отвечает за проигрывание музыки (звуков)

    int score = 0;

    bool isLive = true;

    void Start()
    {
        source = GetComponent<AudioSource>(); //использовать у объекта компонент AudioSource
        rb2d = GetComponent<Rigidbody2D>();//использовать у объекта компонент Rigidbody2D 
        rb2d.freezeRotation = true; //отключили физическое вращение объекта
    }

    void Update()
    {
        scoreCount.text = "Vodka: " + score.ToString(); //изменяем отображение очков на экране

        if (isLive == false)
        {
            deadPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (PlayerPrefs.GetInt("Score") < score)
        {
            PlayerPrefs.SetInt("Score", score);
        }
        //deadPanel.SetActive(true);
        //Time.timeScale = 0;
        SceneManager.LoadScene(0);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        score++;
        source.PlayOneShot(clips[0]);
    }
}
