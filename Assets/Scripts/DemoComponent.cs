using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    string numbers = "";
    int one = 20;
    int two = 40;
    int counter = 0;
    //Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 1; i <= 10; ++i)
        {
            numbers += i + " ";
        }
        Debug.Log(numbers);  
        
        while (one < two && one!=two )
        {
            counter += 1;
            one += 1;
        }
        Debug.Log("It took "+counter+" increments to make the numbers equal.");
    }

    //Update is called once per frame
    void Update()
    {
        Debug.Log("I am a custom component.");
    }
}
