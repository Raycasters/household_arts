using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class SubtitleDisplayer : MonoBehaviour
{
 // public TextAsset Subtitle;
  private IEnumerator subtitlesCoroutine;
 
  public Text Text;
  public Text Text2;
  public float timer = 0;

  [Range(0, 1)]
  public float FadeTime;
  //public float elapsedTime = 0;

	void Start(){

	
	}

	void Update(){
		//StartCoroutine (Begin());
	}


    public void StartSubtitles(TextAsset Subtitle, float sTime)
    {
        //subtitlesCoroutine = FindObjectOfType<SubtitleDisplayer>().Begin(SubtitleIntro);
        //StartCoroutine(subtitlesCoroutine);
        //StartCoroutine(FindObjectOfType<SubtitleDisplayer>().Begin(Subtitle));

        subtitlesCoroutine = Begin(Subtitle, sTime);
        StartCoroutine(subtitlesCoroutine);
    }

 /*   private IEnumerator Begin(TextAsset Subtitle, float sTime)
  {
    Debug.Log("Subtitles begin");
    var currentlyDisplayingText = Text;
    var fadedOutText = Text2;

    currentlyDisplayingText.text = string.Empty;
    fadedOutText.text = string.Empty;

    currentlyDisplayingText.gameObject.SetActive(true);
    fadedOutText.gameObject.SetActive(true);

    yield return FadeTextOut(currentlyDisplayingText);
    yield return FadeTextOut(fadedOutText);

    var parser = new SRTParser(Subtitle);
 
    timer = sTime;
    Debug.Log("Subtitles startTime:" + timer);
    SubtitleBlock currentSubtitle = null;

    while (true)
    {
      timer += Time.deltaTime;

      var elapsed = timer; 
      //elapsedTime = elapsed;
 
      var subtitle = parser.GetForTime(elapsed);
 
      if (subtitle != null)
      {
        Debug.Log("AFTER subtitle:" + subtitle.Text);
        if (!subtitle.Equals(currentSubtitle))
        {
          currentSubtitle = subtitle;
   
          // Swap references around
          var temp = currentlyDisplayingText;
          currentlyDisplayingText = fadedOutText;
          fadedOutText = temp;

          // Switch subtitle text
          currentlyDisplayingText.text = currentSubtitle.Text;

          // And fade out the old one. Yield on this one to wait for the fade to finish before doing anything else.
          StartCoroutine(FadeTextOut(fadedOutText));

          // Yield a bit for the fade out to get part-way
          yield return new WaitForSeconds(FadeTime / 3);

          // Fade in the new current
          yield return FadeTextIn(currentlyDisplayingText);
        }
        yield return null;
      }
      else
      {
        Debug.Log("Subtitles ended");
        StartCoroutine(FadeTextOut(currentlyDisplayingText));
        yield return FadeTextOut(fadedOutText);
        currentlyDisplayingText.gameObject.SetActive(false);
        fadedOutText.gameObject.SetActive(false);
        StopSubtitles();
        yield break;
      }

    }
  }*/


    private IEnumerator Begin(TextAsset Subtitle, float sTime)
    {
        Debug.Log("Subtitles begin");
        var currentlyDisplayingText = Text;
        var fadedOutText = Text2;

        currentlyDisplayingText.text = string.Empty;
        fadedOutText.text = string.Empty;

        currentlyDisplayingText.gameObject.SetActive(true);
        fadedOutText.gameObject.SetActive(true);

        yield return FadeTextOut(currentlyDisplayingText);
        yield return FadeTextOut(fadedOutText);

        var parser = new SRTParser(Subtitle);

        timer = sTime;
        Debug.Log("Subtitles startTime:" + timer);
        SubtitleBlock currentSubtitle = null;
        SubtitleBlock currentSubtitle2 = null;

        while (true)
        {
            timer += Time.deltaTime;
            var elapsed = timer;
            var dic = parser.GetForTime(elapsed);

            var subtitle = dic.Count > 0 ? dic[0] : null;
            var subtitle2 = dic.Count >1 ? dic[1] : null;
 

            if (subtitle != null)
            {
                if (!subtitle.Equals(currentSubtitle) && !subtitle2.Equals(currentSubtitle2))
                {
                    currentSubtitle = subtitle;
                    currentSubtitle2 = subtitle2;

                    // Switch subtitle text
                    currentlyDisplayingText.text = subtitle.Text;
                    fadedOutText.text = subtitle2.Text;

                    // And fade out the old one. Yield on this one to wait for the fade to finish before doing anything else.
                    //StartCoroutine(FadeTextOut(currentlyDisplayingText));
                    //StartCoroutine(FadeTextOut(fadedOutText));

                    // Yield a bit for the fade out to get part-way
                    yield return new WaitForSeconds(FadeTime / 3);

                    // Fade in the new current
                    yield return FadeTextIn(currentlyDisplayingText);
                    yield return FadeTextIn(fadedOutText);
                }
                yield return null;
            }
            else
            {
                Debug.Log("Subtitles ended");
                StartCoroutine(FadeTextOut(currentlyDisplayingText));
                yield return FadeTextOut(fadedOutText);
                currentlyDisplayingText.gameObject.SetActive(false);
                fadedOutText.gameObject.SetActive(false);
                StopSubtitles();
                yield break;
            }

        }
    }

  void OnValidate()
  {
    FadeTime = ((int)(FadeTime * 10)) / 10f;
  }

  IEnumerator FadeTextOut(Text text)
  {
    var toColor = text.color;
    toColor.a = 0;
    yield return Fade(text, toColor, Ease.OutSine);
  }

  IEnumerator FadeTextIn(Text text)
  {
    var toColor = text.color;
    toColor.a = 1;
    yield return Fade(text, toColor, Ease.InSine);
  }

  IEnumerator Fade(Text text, Color toColor, Ease ease)
  {
    yield return DOTween.To(() => text.color, color => text.color = color, toColor, FadeTime).SetEase(ease).WaitForCompletion();
  }

  public void StopSubtitles()
  {
    Debug.Log("Subtitles Stop");
    if (subtitlesCoroutine == null) { return; }
    StopCoroutine(subtitlesCoroutine);
    Text.text = "";
    Text2.text = "";
    subtitlesCoroutine = null;
   }
}
