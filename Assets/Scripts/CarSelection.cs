using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CarSelection : MonoBehaviour
{
    [SerializeField] private Button previousButton;
    [SerializeField] private Button nextButton;

    

    private int currentCar;
    public static bool isChrChange = false;
    public static bool isBack = false;

    private void Awake()
    {
        currentCar = 0;
        ChangeCar(0);
        // SelectCar(0);
    }


    public void SelectCar(int _index)
    {
        /*

        */

        PlayerPrefs.SetInt("CurrentCar", currentCar);
        GoLobby();
    }

    public void ChangeCar(int _change)
    {
        currentCar += _change;
        if (currentCar < 0)
        {
            currentCar = 4;
        }
        else if (currentCar > 4)
        {
            currentCar = 0;
        }

        previousButton.interactable = (currentCar != 0);
        nextButton.interactable = (currentCar != transform.childCount - 1);

        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(i == currentCar);
        }

        //SelectCar(currentCar);
    }

    public void GoLobby()
    {
        SceneManager.LoadScene("MainScene");
        isChrChange = true;   
    }

    public void Back()
    {
        SceneManager.LoadScene("MainScene");
        isBack = true;
        
    }
}
