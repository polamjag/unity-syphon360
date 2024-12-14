using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleFileBrowser;

public class MoviePlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var player = GameObject.FindObjectOfType<UnityEngine.Video.VideoPlayer>();
        player.GetComponent<UnityEngine.Video.VideoPlayer>().url = "";
        player.isLooping = true;
        FileBrowser.SetFilters(true, new FileBrowser.Filter("Movies", ".mov", ".mp4"));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("o"))
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
