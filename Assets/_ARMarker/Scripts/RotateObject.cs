using UnityEngine;

/// <summary>
/// This is the code version of RotateObject visual script in the Mobile AR Development Pathway, mission "Create a marker-based AR app", Tutorial "Add a UI with rotation buttons".
/// </summary>
public class RotateObject : MonoBehaviour
{
    public float rotStep = 15f;         //The angle by which to rotate the object when a button is clicked (in degrees)
    private Setup setup;                //The setup script, which finds and stores the currently active modelObject in the scene


    /// <summary>
    /// At application startup, we get the Setup script. Since it is attached to the same object as the current script, we can simply use GetComponent to retrieve it.
    /// Note this only needs to happen once, since the Scripts GameObject will remain active throughout the application's lifetime.
    /// </summary>
    void Start()
    {
        setup = GetComponent<Setup>();
    }


    /// <summary>
    /// This method is called when the rotate left button is clicked. It simply calls a helper method, to avoid duplicate code.
    /// </summary>
    public void OnRotateLeftButtonClicked()
    {
        RotateModelObject( 1 );
    }

    /// <summary>
    /// See above.
    /// </summary>
    public void OnRotateRightButtonClicked()
    {
        RotateModelObject( -1 );
    }

    /// <summary>
    /// This method does the actual work. Note the null check, which makes sure we don't rotate anything if no object is found.
    /// </summary>
    /// <param name="direction">1 or -1</param>
    private void RotateModelObject( int direction )
    {
        if ( setup.GetModelObject() == null )
        {
            Debug.Log( "Attempting to rotate while object has not spawned" );
        }
        else
        {
            setup.GetModelObject().transform.Rotate( Vector3.up, rotStep * direction );
        }
    }

}
