using UnityEngine;

/// <summary>
/// This is the code version of PlayAudio visual script in the Mobile AR Development Pathway, mission "Create a marker-based AR app", Tutorial "Add world space UI to your maker-based app".
/// </summary>
public class DisplayPopup : MonoBehaviour
{
    private Setup setup;                //The setup script, which finds and stores the currently active modelObject in the scene


    /// <summary>
    /// Identical to the RotateObject script.
    /// </summary>
    void Start()
    {
        setup = GetComponent<Setup>();
    }

    /// <summary>
    /// This method is called when the info button is clicked.
    /// It simply retrieves the canvas gameobject from the modelObject which is stored in the Setup script, and (if it exists) flips its visibility.
    /// </summary>
    public void OnButtonInfoClicked()
    {
        GameObject popup = setup.GetInfoPanel();
        if( popup ) // this is the same as if( popup != null )
        {
            popup.SetActive( !popup.activeSelf ); //simple way to set the new state to the inverse of the previous state. In this case applied to whether the gameobject is active.
        }
    }
}
