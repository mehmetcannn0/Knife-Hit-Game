using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeManager : MonoBehaviour
{

    [SerializeField] private List<GameObject> knifeList = new List<GameObject>();
    [SerializeField] private List<GameObject> knifeIconList = new List<GameObject>();
    [SerializeField] private Vector2 knifeIconPosition;
    [SerializeField] private GameObject knifePrefab;
    [SerializeField] private GameObject knifeIconPrefab;
    [SerializeField] private Color disableColor;
    //[SerializeField] private Color enableColor;
    [SerializeField] private int knifeCount;
    [SerializeField] private Transform knifeIconsParent;
    [SerializeField] private Transform knifeParent;

    private int currentKnifeIndex = 0;


    private void Start()
    {
        CreateKnife();
    }

    private void CreateKnife()
    {
        for (int i = 0; i < knifeCount; i++)
        {
            GameObject newKnife = Instantiate(knifePrefab, transform.position, Quaternion.identity);
            newKnife.transform.SetParent(knifeParent);
            newKnife.SetActive(false);
            knifeList.Add(newKnife);
            
            GameObject newKnifeIcon = Instantiate(knifeIconPrefab, knifeIconPosition, knifeIconPrefab.transform.rotation);
            knifeIconPosition.y += 0.4f;
            newKnifeIcon.transform.SetParent(knifeIconsParent);
            knifeIconList.Add(newKnifeIcon);

        }

        knifeList[0].SetActive(true);
        //knifeIconList[0].GetComponent<SpriteRenderer>().color = disableColor;
        

    }
    public void SetDisableKnifeIconColor()
    {
        Debug.Log("SetDisableKnifeIconColor");
        Debug.Log("currentKnifeIndex: " + currentKnifeIndex);
        Debug.Log("knifeIconList.Count: " + knifeIconList.Count);
        knifeIconList[(knifeIconList.Count-1)-currentKnifeIndex].GetComponent<SpriteRenderer>().color = disableColor;
    }

    public void SetActiveKnife()
    {

        if (currentKnifeIndex < knifeList.Count - 1)
        {
            currentKnifeIndex++;
            knifeList[currentKnifeIndex].SetActive(true);
        }
    }
  
}