using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField] private Color gazed;
    [SerializeField] private GameObject playerCamera;


    private float timer = 0f;
    private bool collecting = false;
    private MeshRenderer myRenderer;

    // Start is called before the first frame update
    void Start()
    {
        myRenderer = GetComponent<MeshRenderer>();
    }   

    // Update is called once per frame
    void Update()
    {
        if(collecting){
            myRenderer.material.color = Color.Lerp(myRenderer.material.color, gazed,Time.deltaTime/2f);
            timer += Time.deltaTime;
            if(timer >= 2f){
                Vector3 teleportPose = new Vector3(transform.position.x, playerCamera.transform.position.y, transform.position.z);
                playerCamera.transform.position = teleportPose;
                myRenderer.enabled = false;
            }
        }
    }

    public void OnPointerEnter(){
        GazeAt(true);
    }

    public void OnPointerExit(){
        GazeAt(false);
    }

    public void GazeAt(bool gazing){
        if(gazing){
            collecting = true;
        }
        else{
            timer = 0f;
            collecting = false;
        }
    }


}
