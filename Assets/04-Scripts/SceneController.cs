using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public AudioManager audioManager;
    public Renderer fadeRenderer;
    public CanvasGroup exitMessage;
    public Material opaqueCover;
    public ObjectiveValues objectiveValues;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        string current_scene_name = SceneManager.GetActiveScene().name;
        Color c = fadeRenderer.material.color;
        c.a = 1f;
        fadeRenderer.material.color = c;
        exitMessage.alpha = 0;

        if (current_scene_name == "Boss")
            audioManager.musics[0].source.volume = audioManager.musics[0].source.volume / 4;
        else if (current_scene_name == "Office")
        {
            if (objectiveValues.gameStarted)
            {
                player.transform.position = new Vector3(-2.75f, 0f, -2f);
                player.transform.RotateAround(player.transform.position, Vector3.up, 45f);
            }
        }
        audioManager.PlayMusic("officeambience");

        StartCoroutine(Fade());
    }

    IEnumerator Fade()
    {
        Color c = fadeRenderer.material.color;
        for (float alpha = 1f; alpha >= 0; alpha -= 0.01f)
        {
            c.a = alpha;
            fadeRenderer.material.color = c;
            yield return new WaitForSeconds(.01f);
        }
    }

    IEnumerator Cover()
    {
        Color c = fadeRenderer.material.color;
        for (float alpha = 0f; alpha <= 1; alpha += 0.01f)
        {
            c.a = alpha;
            fadeRenderer.material.color = c;
            yield return new WaitForSeconds(.01f);
        }
        yield return new WaitForSeconds(1f);
    }

    public void Quit()
    {
        StartCoroutine(Cover());
        StartCoroutine(QuitGame());
    }

    IEnumerator QuitGame()
    {
        yield return new WaitForSeconds(1f);
        fadeRenderer.material = opaqueCover;
        for (float alpha = 0f; alpha <= 1; alpha += 0.01f)
        {
            exitMessage.alpha = alpha;
            yield return new WaitForSeconds(.01f);
        }

        yield return new WaitForSeconds(3f);
        Application.Quit();
    }

    public void ChangeScene(string scene_name)
    {
        StartCoroutine(Cover());
        StartCoroutine("SceneLoad", scene_name);
    }

    IEnumerator SceneLoad(string scene_name)
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(scene_name);
    }
}
