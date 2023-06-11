using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutDownTree : MonoBehaviour
{
    [SerializeField] private Color gazed;
    [SerializeField] private GameObject playerCamera;
    [SerializeField] private GameObject treeUncut;


    private float timer = 0f;
    private bool collecting = false;
    private bool used = false;



    // Start is called before the first frame update
    void Start()
    {

    }   

    // Update is called once per frame
    void Update()
    {

        if(collecting){
            timer += Time.deltaTime;
            if(timer >= 2f && !used){

                Belittle(treeUncut);
                used = true;
            
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

    public void Belittle(GameObject obj1){
        obj1.transform.localScale *= 0.25f;
    }


}