using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomTransitionManager : MonoBehaviour
{
    private string currentRoom = "";

    private void Start()
    {
        EnterRoom("", "");
    }


    public void EnterRoom(string sceneName, string spawnID)
    {
        StartCoroutine(Transition(sceneName, spawnID));
    }

    private IEnumerator Transition(string sceneName, string spawnID)
    {
        if (!string.IsNullOrEmpty(currentRoom))
        {
            yield return SceneManager.UnloadSceneAsync(currentRoom);
            yield return SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        }

        currentRoom = SceneManager.GetActiveScene().name;
    }

    private void SetupRoom(string spawnID)
    {
        //SpawnPoint[] spawns = FindObjectOfType<SpawnPoint>
    }

}
