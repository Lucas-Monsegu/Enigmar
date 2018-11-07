using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class GoodDate : WrittenAnswer {
    
    void Start()
    {
        if (NumbersOnly)
        {

            GameObject j = GameObject.FindGameObjectWithTag("UITOP");
            if (j != null)
                j.GetComponent<InputField>().contentType = InputField.ContentType.IntegerNumber;
        }
        else
        {
            GameObject j = GameObject.FindGameObjectWithTag("UITOP");
            if (j != null)
                j.GetComponent<InputField>().contentType = InputField.ContentType.Alphanumeric;
        }
    }

    // Update is called once per frame
   override public void Test(string s)
    {

        int d = -1;
        if (s == "Lundi" || s == "lundi" || s == "Monday" || s == "monday")
        {
            d = (int)DayOfWeek.Monday;
        }
        else if (s == "Mardi" || s == "mardi" || s == "Tuesday" || s == "tuesday")
        {
            d = (int)DayOfWeek.Tuesday;
        }
        else if (s == "Mercredi" || s == "mecredi" || s == "Wednesday" || s == "wednesday")
        {
            d = (int)DayOfWeek.Wednesday;
        }
        else if (s == "Jeudi" || s == "jeudi" || s == "Thursday" || s == "thursday")
        {
            d = (int)DayOfWeek.Thursday;
        }
        else if (s == "Vendredi" || s == "vendredi" || s == "Friday" || s == "friday")
        {
            d = (int)DayOfWeek.Friday;
        }
        else if (s == "Samedi" || s == "samedi" || s == "Saturday" || s == "saturday")
        {
            d = (int)DayOfWeek.Saturday;
        }
        else if (s == "Dimanche" || s == "dimanche" || s == "Sunday" || s == "sunday")
        {
            d = (int)DayOfWeek.Sunday;
        }

        if (d == (int)DateTime.Now.DayOfWeek)
            transform.parent.GetComponent<MainMenu>().GoodAnswert();


    }
}
