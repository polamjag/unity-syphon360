using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MoviePlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var player = GameObject.Find("Movie360");
        player.GetComponent<UnityEngine.Video.VideoPlayer>().url = "/Users/satoru/Desktop/ayutthaya_-_easy_tripod_paint___360_vr_master_series___free_download (1080p).mp4";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("p"))
        {
            var player = GameObject.Find("Movie360");
            player.SetActive(false);
            string path = EditorUtility.OpenFilePanel("Overwrite with mp4", "", "mov,mp4,insv");
            player.GetComponent<UnityEngine.Video.VideoPlayer>().url = path;
            player.SetActive(true);
        }
    }
}
