using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public string sceneToLoad;

    public void ChangeSceneNow()
    {
        SceneManager.LoadScene(sceneToLoad);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ChangeSceneNow();
    }
}
