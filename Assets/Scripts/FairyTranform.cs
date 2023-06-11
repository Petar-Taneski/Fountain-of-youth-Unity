using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FairyTranform : MonoBehaviour
{
    
    [SerializeField] private GameObject playerCamera;
    [SerializeField] private GameObject GreenFairy;
    [SerializeField] private GameObject RedFairy;


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
                 FairyTransformation(GreenFairy,RedFairy);
                        
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

    public void FairyTransformation(GameObject obj1, GameObject obj2){
    
        obj2.transform.position = obj1.transform.position;
        obj2.transform.rotation = obj1.transform.rotation;
        obj2.transform.localScale = obj2.transform.localScale;
        
        Destroy(obj1);
    }

    

   


}
