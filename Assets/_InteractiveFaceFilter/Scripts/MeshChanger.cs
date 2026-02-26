using UnityEngine;

/// <summary>
/// This is the code version of the MeshChanger, which is explained through visual scripting in the Mobile AR Development Pathway,
/// Mission "Create an interactive face filter", Tutorial "Create a visual script to detect a button press".
/// Note that if you know how to code, this is much quicker and simpler than the visual scripting approach, and requires very litte code.
/// 
/// In this case we implemented the functionality in a single script which is added to the scene once, on an empty GameObject called "Scripts". 
/// Each of the glasses buttons call the method OnChangeGlassesButtonClicked, but with a different parameter (check this in the editor).
/// </summary>
public class MeshChanger : MonoBehaviour
{
    /// <summary>
    /// When a button is clicked, all three glasses need to be updated. The one with the same tag as this button should have its mesh renderer enabled, the other two should have them disabled.
    /// </summary>
    /// <param name="tag">the tag of the glasses that should be visible</param>
    public void OnChangeGlassesButtonClick( string tag )
    {
        Debug.Log( "Glasses button clicked" );

        //The statement GameObject.FindGameObjectWithTag retrieves the gameobject with the specified tag.
        //The call to GetComponent retrieves the specified component from this gameObject. In this case, we use MeshRenderer, since this is the component we want to adjust. Note that this could return null, if no such component exists on the gameObject! 
        //We then store the result as a local variable. Note that this is quite inefficient, it would be better to do this once (in the Start method) and store the glasses as attributes.
        //However, that is difficult in this case, since the XR Origin object is responsible for creating the glasses, and they may not exist yet when we execute the Start method on this gameobject.
        //There are ways around this, of course, but for simplicity's sake, we simply retrieve the objexts each time we click a button.
        MeshRenderer catGlasses = GameObject.FindGameObjectWithTag( "cat" ).GetComponent<MeshRenderer>();
        MeshRenderer monocleGlasses = GameObject.FindGameObjectWithTag( "monocle" ).GetComponent<MeshRenderer>();
        MeshRenderer starGlasses = GameObject.FindGameObjectWithTag( "stars" ).GetComponent<MeshRenderer>();

        // Note that we are setting the enabled status to true or false by comparing the object's tag with the parameter.
        catGlasses.enabled = catGlasses.gameObject.tag == tag;
        monocleGlasses.enabled = monocleGlasses.gameObject.tag == tag;
        starGlasses.enabled = starGlasses.gameObject.tag == tag;

        //Save the current tag in the FilterUpdater. We can simply call GetComponent on ourselves here, since the FilterUpdater script is attached to the same gameobject as the MeshChanger.
        GetComponent<FilterUpdater>().SetCurrentTag( tag );
    }
}
