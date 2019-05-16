using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    [SerializeField] GameObject bird; //игрок
    [SerializeField] GameObject[] columnsPrefabs; //массив колонн
    [SerializeField] float force; //сила поднятия игрока вверх
    [SerializeField] GameObject startPanel;//панель начала игры

    [HideInInspector] public int score = 0; //очки

    Vector2 columnPosition; //позиция создания колонны
    GameObject column; //колонна

    void Start()
    {
        Time.timeScale = 0;
        startPanel.SetActive(true);
        StartCoroutine(ColumnSpawn());
    }

    void Update()
    {
        columnPosition = new Vector2(7, Random.Range(-1.5f, 1.5f));

        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Home) || Input.GetKey(KeyCode.Escape))
            {
                Application.Quit();
                return;
            }
        }
    }

    IEnumerator ColumnSpawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            column = Instantiate(columnsPrefabs[Random.Range(0, columnsPrefabs.Length)]);
            column.transform.position = columnPosition;
            column.transform.parent = transform;
            yield return new WaitForSeconds(.65f);
        }
    }

    public void ButtonUp()
    {
        bird.GetComponent<Rigidbody2D>().AddForce(Vector2.up * force, ForceMode2D.Impulse);
    }

    public void StartGame()
    {
        Time.timeScale = 1;
        startPanel.SetActive(false);
    }
}
