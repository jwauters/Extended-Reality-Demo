using UnityEngine;

/// <summary>
/// This is the code version of PlayAudio visual script in the Mobile AR Development Pathway, mission "Create a marker-based AR app", Tutorial "Add spatial audio to your marker-based app".
/// </summary>
public class PlayAudio : MonoBehaviour
{
    private Setup setup;                //The setup script, which finds and stores the currently active modelObject in the scene


    /// <summary>
    /// Identical to the RotateObject and DisplayPopup scripts.
    /// </summary>
    void Start()
    {
        setup = GetComponent<Setup>();
    }

    /// <summary>
    /// This method is called when the audio button is clicked.
    /// It simply retrieves the AudioSource gameobject from the modelObject which is stored in the Setup script, and (if it exists) sets the volume to either 1 or 0, depending on the current state.
    /// Note that this is a somewhat different approach to the tutorial, where the loop for the audio was turned off and the audio is played on button click.
    /// See if you can adjust the code to make it function like that!
    /// </summary>
    public void OnButtonAudioClicked()
    {
        Debug.Log( "Button clicked" );
        AudioSource audio = setup.GetAudioSource();
        if ( audio ) // this is the same as if( audio != null )
        {
            audio.volume = audio.volume == 0 ? 1 : 0; //shorthand if-notation. This is equal to the statement in comment below
            /*
            if( audio.volume == 0 )
            {
                audio.volume = 1;
            }
            else
            {
                audio.volume = 0;
            }
            */
        }
    }
}
