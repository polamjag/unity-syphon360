using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleFileBrowser;

public class MoviePlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var player = GameObject.Find("Movie360");
        player.GetComponent<UnityEngine.Video.VideoPlayer>().url = "/Users/satoru/Desktop/ayutthaya_-_easy_tripod_paint___360_vr_master_series___free_download (1080p).mp4";
        FileBrowser.SetFilters(true, new FileBrowser.Filter("Movies", ".mov", ".mp4"));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("p"))
        {
			FileBrowser.ShowLoadDialog((paths) => {
				if (paths[0] != null)
                {
					var player = GameObject.Find("Movie360");
					player.GetComponent<UnityEngine.Video.VideoPlayer>().url = paths[0];
				}
			}, () => {}, FileBrowser.PickMode.Files, false, null, null, "Load Movie", "Load");
		}
    }
}
