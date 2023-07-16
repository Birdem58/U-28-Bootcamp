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
    public bool firstRun = true;
    public bool firstShot = true;
    public bool liweiVadiDuvar = true;

    public bool liweiDinle = true;

    public bool liweiBilgi = true;
    public int objtutKristal = 0;
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
        if (isMoved && index == 0)
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
    public void TutObjRun()
    {
        if (firstRun && index == 2)
        {
            firstRun = false;
            ObjTransiton();
        }
    }


    public void TutObjShoot()
    {
        if (firstShot && index == 3)
        {
            firstShot = false;
            ObjTransiton();
        }

    }

    public void TutObjKristal()
    {
        objtutKristal++;
        if (objtutKristal == 15 && index == 4)
        {
            objtutKristal = 0;
            ObjTransiton();
        }
    }

    public void LiweiVadiTrigger()
    {
        if (liweiVadiDuvar && index == 5)
        {
            liweiVadiDuvar = false;
            ObjTransiton();
        }
    }

    public void LiWeiKonusma()
    {
        if (liweiDinle && index == 6)
        {
            liweiDinle = false;
            ObjTransiton();
        }
    }
    public void LiWeiBilgi()
    {
        if (liweiBilgi && index == 7)
        {
            liweiBilgi = false;
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
            objectivetext.text = "Shift Tuşuna basarak koş";
        }
        if (index == 3)
        {
            objectivetext.text = " Sağ Tıkla Nişan al ve Sol Tıkla Ateş et";
        }
        if (index == 4)
        {
            objectivetext.text = "Gölün Solundaki Kristalleri Topla" + objtutKristal.ToString() + "/15";
        }
        if (index == 5)
        {
            objectivetext.text = "Vadiye doğru ilerle";
        }
        if (index == 6)
        {
            objectivetext.text = "Ağaçların arasındaki yabancı ile Konuş";
        }
        if (index == 7)
        {
            objectivetext.text = "Li Wei'yi dinle";
        }
        if (index == 8)
        {
            objectivetext.text = "Chris'i kurtarmak için köye in";
        }

    }


}
