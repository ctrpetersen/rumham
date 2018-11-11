using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Manages level triggers etc.

    public GameObject PlayerPrefab;
    public Vector3 Offset;
    public Transform Camera;
    public Image LevelIntro;

    private GameObject Player;

    // Use this for initialization
    void Start()
    {
        Player = Instantiate(PlayerPrefab, new Vector3(-6, 0, 1), Quaternion.identity);
        StartCoroutine(FadeImage());
    }

    // Update is called once per frame
    void Update()
    {
        Camera.position = new Vector3(Player.transform.position.x + Offset.x, Player.transform.position.y + Offset.y,
            Offset.z);
    }

    IEnumerator FadeImage()
    {
        for (float i = 3; i >= 0; i -= Time.deltaTime)
        {
            LevelIntro.color = new Color(1, 1, 1, i);
            yield return null;
        }
    }
}
