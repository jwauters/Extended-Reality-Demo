using UnityEngine;

/// <summary>
/// We take a different approach to the MeshChanger script here. Instead of having one script for all buttons, here we attach an instance of this script to each button.
/// We then configure each button with a public attribute material, which is assigned in the inspector per button.
/// When a button is clicked, we set this material to all glasses. Only one should be visible, but this way the color remains correct when we switch glasses.
/// </summary>
public class MaterialChanger : MonoBehaviour
{
    //the material to be assigned when this button is clicked
    public Material materialToBeAssigned;

    //This variable is used in the tutorial "Save and load the glasses"
    public FilterUpdater filterUpdater;

    /// <summary>
    /// When the current button is clicked, we assign the correct material to all glasses.
    /// </summary>
    public void OnChangeGlassesButtonClick()
    {
        //we can print the gameobject's name here to see which button was clicked.
        ////Note we could not do this for the MeshChanger script, since that would always print the name of the empty gameobject to which it was attached.
        Debug.Log( "Material button clicked: " + gameObject.name );

        //Same as in MeshChanger
        MeshRenderer catGlasses = GameObject.FindGameObjectWithTag( "cat" ).GetComponent<MeshRenderer>();
        MeshRenderer monocleGlasses = GameObject.FindGameObjectWithTag( "monocle" ).GetComponent<MeshRenderer>();
        MeshRenderer starGlasses = GameObject.FindGameObjectWithTag( "stars" ).GetComponent<MeshRenderer>();

        // Note that we are setting the enabled status to true or false by comparing the object's tag with the parameter.
        catGlasses.material = materialToBeAssigned;
        monocleGlasses.material = materialToBeAssigned;
        starGlasses.material = materialToBeAssigned;

        //We pass the current material to the filterUpdater, which is reponsible for saving and loading when the camera loses track of the face. Used in the tutorial "Save and load the glasses".
        filterUpdater.SetCurrentMaterial( materialToBeAssigned );
    }
}
