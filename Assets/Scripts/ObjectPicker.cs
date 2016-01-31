using UnityEngine;
using System.Collections;

public class ObjectPicker : MonoBehaviour
{

    public GameObject[] _pickUps;
    public GameObject _camera;

    public GameObject _pickedUpObject;
    public GameObject _selectedObject;

    public float _pickUpRange;

    Shader standardShader;
    Shader outlineShader;

    // Use this for initialization
    void Start()
    {
        //standardShader = Shader.Find("Standard");
        //outlineShader = Shader.Find("Outlined/Silhouetted Bumped Diffuse");

        _pickUps = GameObject.FindGameObjectsWithTag("PickUp");
    }


    // Update is called once per frame
    void Update()
    {

        _selectedObject = null;

        //Vector3 forward = _camera.transform.TransformDirection(Vector3.forward);
        RaycastHit hit;

        Camera _cam = _camera.GetComponent<Camera>();

        Vector3 camForward = _cam.transform.forward;
        Vector3 camPosition = _cam.transform.position;

        RaycastHit[] hitArray = Physics.RaycastAll(camPosition, camForward, _pickUpRange);


        for (int i = 0; i < hitArray.Length; i++)
        {
            if (hitArray[i].collider.gameObject.tag == "PickUp")
            {
                _selectedObject = hitArray[i].collider.gameObject;

                //if (Input.GetMouseButtonDown(0))
                //{
                //    _pickedUpObject = _selectedObject;
                //}
            }
        }

        //If an object is being picked up, hold infront of camera
        //if (_pickedUpObject != null)
        //{
        //    _pickedUpObject.transform.position = camPosition + (camForward * 2.0f);

        //    //Drop Object; Right Click
        //    if (Input.GetMouseButtonDown(1))
        //    {
        //        _pickedUpObject.GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 0.0f, 0.0f);
        //        _pickedUpObject = null;
        //    }

        //    //Throw Object; Middle Click
        //    if (Input.GetMouseButtonDown(2))
        //    {
        //        _pickedUpObject.GetComponent<Rigidbody>().velocity = camForward * 10.0f;
        //        _pickedUpObject = null;
        //    }
        //}

        //Highlight currently selected or picked up object
        foreach (GameObject obj in _pickUps)
        {
            if (obj == _selectedObject || obj == _pickedUpObject)
            {
                if (obj.name == "wardrobe" || obj.name == "door")
                {
                    Color green = new Color(0, 0.9f, 0);
                    obj.GetComponent<Renderer>().materials[0].color = green;
                }
                else
                {
                    obj.GetComponent<Renderer>().materials[0].color = Color.yellow;
                }
                //obj.GetComponent<Renderer>().materials[0].shader = outlineShader;
            }
            else
            {
                obj.GetComponent<Renderer>().materials[0].color = Color.white;
                //obj.GetComponent<Renderer>().materials[0].shader = standardShader;
            }
        }

    }

}
