using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectiveList : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip _objTamamlama;
    public TextMeshProUGUI objectivetext;
    public bool firstJump = true;
    public bool isMoved = true;
    public bool firstShot = true;
    int index = 0;
    void Start()
    {

    }
    void Update()
    {
        CurrentObj();
    }

    public void TutObjMove()
    {
        if(isMoved && index == 0)
        {
            isMoved = false;
            ObjTransiton();
        }
    }

    public void TutObjJump()
    {    
        if (firstJump && index == 1)
        {  
            firstJump = false;
            ObjTransiton();
        }
    }

    public void TutObjShoot()
    {  if(firstShot && index == 2)
    {
        firstShot = false;
        ObjTransiton();
    }

    }

   void ObjTransiton()
    {
        audioSource.PlayOneShot(_objTamamlama);
        index++;

    }

    void CurrentObj()
    {
        if (index == 0)
        {
              objectivetext.text = "WASD ile Hareket et";
        }
        if (index == 1)
        {
            objectivetext.text = "Space Tuşuna Basıp Zıpla";
        }
        if (index == 2)
        {
             objectivetext.text = " Sağ Tıkla Nişan al ve Sol Tıkla Ateş et";
        }
        if (index == 3)
        {
           objectivetext.text ="Sıradaki hedef neyse o ";
        }
        if (index == 4)
        {

        }

    }


}
