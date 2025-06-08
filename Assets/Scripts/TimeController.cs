using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    private List<TimeAffected> timeAffecteds = new List<TimeAffected>();


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Subscribe(TimeAffected timeAff)
    {
        timeAffecteds.Add(timeAff);
    }

    public void Unsubscribe(TimeAffected timeAff)
    {
        timeAffecteds.Remove(timeAff);
    }


    public void MoveIntoPast()
    {
        foreach (TimeAffected ta in timeAffecteds)
        {
            ta.IntoThePast();
        }
    }

    public void MoveIntoFuture()
    {
        foreach (TimeAffected ta in timeAffecteds)
        {
            ta.IntoTheFuture();
        }
    }
}
