using TMPro;
using UnityEngine;

/// <summary>
/// This is the code version of RotateObject visual script in the Mobile AR Development Pathway, mission "Create a marker-based AR app".
/// Is it used in multiple tutorials, namely:
/// - "Add a UI with rotation buttons"
/// - "Add world space UI to your marker-based app"
/// - "Add spatial audio to your marker-based app"
/// </summary>
public class Setup : MonoBehaviour
{
    private GameObject modelObject;     //The spawned object in the scene. May be null.

    public TMP_Text feedbackText;       //A feedback text box showing which object is currently being tracked (if any). This is an extra feature which is not described in the tutorial.


    /// <summary>
    /// Called once per frame.
    /// This method constantly scans the scene for an object with the appropriate tag, and stores it in the modelObject if found. Otherwise the modelObject is set to null.
    /// Note that approach is expensive. Wherever possible, you should avoid calling FindObjectWithTag (or similar methods) in an Update. 
    /// However, since the XR Manager creates and destroys objects depending on whether there are tracked image objects in view, this is one of the simplest approaches to find the currently active object(s) - if any.
    /// </summary>
    private void Update()
    {
        GameObject[] trackedObjects = GameObject.FindGameObjectsWithTag( "modelObject" );

        //If trackedObjects contains anything, we'll take the first object from the list as the one to rotate. This means that if multiple images are being tracked, only one object will be rotated.
        //A simple exercise is to adjust this code to rotate all tracked objects. 
        if ( trackedObjects.Length > 0 )
        {
            modelObject = trackedObjects[0];
            feedbackText.text = "Tracked object:\n" + modelObject.name;
        }
        //No tracked objects, so we reset the object and text.
        else
        {
            modelObject = null;
            feedbackText.text = "Tracked object:\nNONE";
        }
    }

    /// <summary>
    /// Simple getter
    /// </summary>
    public GameObject GetModelObject()
    {
        return modelObject;
    }

    /// <summary>
    /// This method is used in the tutorial "Add world space UI to your marker-based app".
    /// A more complex getter which returns the gameobject which contains the canvas with info text.
    /// We work in two steps here: first we find a Canvas component in the children of the model object (if it exists). Since there is only one Canvas, we will always find the correct object this way.
    /// However, what we want to return is not the Canvas component, but the full gameobject. Fortunately, we can do this by calling the property gameObject.
    /// </summary>
    /// <returns>The gameobject containing the canvas component, which is a (hierarchical) child of modelObject; or null if there is no modelObject</returns>
    public GameObject GetInfoPanel()
    {
        if( modelObject != null )
        {
            return modelObject.GetComponentInChildren<Canvas>( true ).gameObject; //note the use of the parameter value 'true' here. This ensures we find the object, even if it is disabled.
        }
        else
        {
            return null;
        }
    }

    /// <summary>
    /// This method is used in the tutorial "Add spatial audio to your marker-based app".
    /// It is entirely analogous to the method GetInfoPanel, but here we do return the component, rather than the entire GameObject.
    /// The reason for this is that we will change a setting of the component (volume), rather than one of the GameObject (activeself).
    /// </summary>
    /// <returns>The AudioSource component present on a child of modelObject; or null if there is no modelObject</returns>
    public AudioSource GetAudioSource()
    {
        if( modelObject != null )
        {
            return modelObject.GetComponentInChildren<AudioSource>(); //no 'true' needed this time, since the AudioSource is always active.
        }
        else
        {
            return null;
        }
    }
}
