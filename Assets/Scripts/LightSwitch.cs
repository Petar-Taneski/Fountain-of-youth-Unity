using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    
    [SerializeField] private GameObject playerCamera;
    [SerializeField] private GameObject LampPost;


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
            myRenderer.material.color = Color.Lerp(myRenderer.material.color, myRenderer.material.color,Time.deltaTime/2f);
            timer += Time.deltaTime;
            if(timer >= 2f){
                LightControl(LampPost);    
                timer = 0f;        
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

    public void LightControl(GameObject obj){
        Light lightComponent = obj.GetComponent<Light>();
        if(lightComponent.enabled == false)
            lightComponent.enabled = true;
        else
            lightComponent.enabled = false;
    }

    

   


}
