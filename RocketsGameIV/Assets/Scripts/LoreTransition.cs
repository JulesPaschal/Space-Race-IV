using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoreTransition : MonoBehaviour
{
    private bool Lore_Complete = false;
    public float Active_Count;
    private GameObject lore_array;

    public GameObject lore_1;
    public GameObject lore_2;
    public GameObject lore_3;
    public GameObject lore_4;
    public GameObject lore_5;
    public GameObject lore_6;
    public GameObject lore_7;
    public GameObject lore_8;
    public GameObject lore_9;
    public GameObject lore_10;
    public GameObject lore_11;
    public GameObject lore_12;
    public GameObject lore_13;
    public GameObject lore_14;


    void Start()
    {
        lore_1.SetActive(true);
        lore_2.SetActive(false);
        lore_3.SetActive(false);
        lore_4.SetActive(false);
        lore_5.SetActive(false);
        lore_6.SetActive(false);
        lore_7.SetActive(false);
        lore_8.SetActive(false);
        lore_9.SetActive(false);
        lore_10.SetActive(false);
        lore_11.SetActive(false);
        lore_12.SetActive(false);
        lore_13.SetActive(false);
        lore_14.SetActive(false);

        Active_Count = 1f;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!Lore_Complete)
            {
                Active_Count++;

                Advance();
            }
            else
            {
                Skip();
            }
        }
    }

    void Advance()
    {
        if(Active_Count == 2)
        {
            lore_1.SetActive(false);
            lore_2.SetActive(true);
        }
        else if(Active_Count == 3)
        {
            lore_2.SetActive(false);
            lore_3.SetActive(true);
        }
        else if (Active_Count == 4)
        {
            lore_3.SetActive(false);
            lore_4.SetActive(true);
        }
        else if (Active_Count == 5)
        {
            lore_4.SetActive(false);
            lore_5.SetActive(true);
        }
        else if (Active_Count == 6)
        {
            lore_5.SetActive(false);
            lore_6.SetActive(true);
        }
        else if (Active_Count == 7)
        {
            lore_6.SetActive(false);
            lore_7.SetActive(true);
        }
        else if (Active_Count == 8)
        {
            lore_7.SetActive(false);
            lore_8.SetActive(true);
        }
        else if (Active_Count == 9)
        {
            lore_8.SetActive(false);
            lore_9.SetActive(true);
        }
        else if (Active_Count == 10)
        {
            lore_9.SetActive(false);
            lore_10.SetActive(true);
        }
        else if (Active_Count == 11)
        {
            lore_10.SetActive(false);
            lore_11.SetActive(true);
        }
        else if (Active_Count == 12)
        {
            lore_11.SetActive(false);
            lore_12.SetActive(true);
        }
        else if (Active_Count == 13)
        {
            lore_12.SetActive(false);
            lore_13.SetActive(true);
        }
        else if (Active_Count == 14)
        {
            lore_13.SetActive(false);
            lore_14.SetActive(true);
        }

    }

    void Skip()
    {
        SceneManager.LoadScene("Level1");
    }
 
}
