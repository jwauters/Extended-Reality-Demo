using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// A very simple script to load a scene based on its name
/// </summary>
public class SceneLoader : MonoBehaviour
{
    public void LoadScene( string sceneToLoad )
    {
        SceneManager.LoadScene( sceneToLoad );
    }
}
