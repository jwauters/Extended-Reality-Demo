using UnityEngine;

/// <summary>
/// This is the code version of the FilterUpdater, which is explained through visual scripting in the Mobile AR Development Pathway,
/// Mission "Create an interactive face filter", Tutorial "Save and load the glasses".
/// 
/// This script is attached to the same GameObject as the MeshChanger, and the code assumes this to be the case. It will no longer work if you attach it to a different GameObject.
/// </summary>
public class FilterUpdater: MonoBehaviour
{
    private string currentTag = "cat";
    public Material currentMaterial; //we make this material public so we can assign a default material in the inspector

    /// <summary>
    /// Update is called once per frame. We check if there is an object with the currentTag (this is not the case if no face is detected).
    /// If so, and its meshrenderer is not enabled, we enable it (thus making the object visible).
    /// Then we also set the material. 
    /// Note there is an issue with the current approach: the material is only set for the object with the current tag, so if we change glasses before selecting a different color, the glasses will be grey. 
    /// Try to come up with a solution!
    /// </summary>
    void Update()
    {
        GameObject foundObject = GameObject.FindGameObjectWithTag( currentTag );

        if( foundObject != null )
        {
            MeshRenderer renderer = foundObject.GetComponent<MeshRenderer>();
            if ( !renderer.enabled )
            {
                renderer.enabled = true;
                renderer.material = currentMaterial;
            }
        }
    }

    /// <summary>
    /// Simple setter, just like in Java
    /// </summary>
    public void SetCurrentTag( string tag )
    {
        currentTag = tag;
    }

    /// <summary>
    /// Ditto
    /// </summary>
    public void SetCurrentMaterial( Material mat )
    {
        currentMaterial = mat;
    }
}
