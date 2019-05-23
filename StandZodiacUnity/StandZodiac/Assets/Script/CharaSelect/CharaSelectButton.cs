using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharaSelectButton : MonoBehaviour
{
    public GameObject CharaImage;

    bool invisible;
    // Start is called before the first frame update
    void Start()
    {
        invisible = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick(int number)
    {
        switch (number)
        {
            case 1:
                if (invisible == true)
                {
                    CharaImage.SetActive(true);
                    invisible = false;
                }
                else
                {
                    CharaImage.SetActive(false);
                    invisible = true;
                }
                break;
            case 2:
                if (invisible == true)
                {
                    CharaImage.SetActive(true);
                    invisible = false;
                }
                else
                {
                    CharaImage.SetActive(false);
                    invisible = true;
                }
                break;
            default:
                CharaImage.SetActive(false);
                invisible = true;
                break;
        }
        Debug.Log(number);
    }
}
