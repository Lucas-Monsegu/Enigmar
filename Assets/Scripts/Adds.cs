/*
using UnityEngine;
using UnityEngine.Advertisements;
using System.Collections;

public class Adds : MonoBehaviour
{

    // Use this for initialization
    IEnumerator Start()
    {

        
        Advertisement.Initialize("1174266", true);
        yield return new WaitForSeconds(2);
        StartCoroutine(ShowAdds());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator ShowAdds()
    {
        while (!Advertisement.IsReady())
        {
            yield return null;
        }
        Advertisement.Show("rewardedVideo", new ShowOptions() { resultCallback = HandleAdResult });
    }
    private void HandleAdResult(ShowResult result)
    {
        switch(result)
        {
            case ShowResult.Finished:
                print("mdr");
                break;
            case ShowResult.Skipped:
                print("ah il a quitté bravo");
                break;
            case ShowResult.Failed:
                print("met internet t serieux");
                break;
        }
    }
}
*/