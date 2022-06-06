using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeasonTimer : MonoBehaviour
{
    public const int endOfYear      = 3660;
    public const int springStart    = 610;
    public const int summerStart    = 610 + 910;
    public const int fallStart      = 610 + 910*2;
    public const int winterStart    = 610 + 910*3;

    public Color springColor = new Color(0, 1, 0, 1);
    public Color summerColor = new Color(1, 1, 0, 1);
    public Color fallColor   = new Color(233f/255f, 133f/255f, 33f/255f);
    public Color winterColor = new Color(1, 1, 1, 1);

    public Sprite testImage;

    public Slider sliderSeasons;
    public float time = 48;

    // Start is called before the first frame update
    void Start()
    {
        //testImage = Assets.Images.Load <Sprite>("DayNightSliderBackground");

        sliderSeasons.maxValue = 3660;
        sliderSeasons.value = time;
    }

    // Update is called once per frame
    void Update()
    {
        sliderSeasons.value++;

        switch (sliderSeasons.value)
        {
            case endOfYear:
                sliderSeasons.value = 0;
                Debug.Log("Reset SeasonSlider");
                break;
            case springStart:
				//sliderSeasons.gameObject.transform.Find("Background").GetComponent<Image>().sprite = testImage;
				sliderSeasons.gameObject.transform.Find("Background").GetComponent<Image>().color = springColor;
                Debug.Log("Spring time");
                break;
            case summerStart:
                sliderSeasons.gameObject.transform.Find("Background").GetComponent<Image>().color = summerColor;
                Debug.Log("Summer~");
                break;
            case fallStart:
                sliderSeasons.gameObject.transform.Find("Background").GetComponent<Image>().color = fallColor;
                Debug.Log("Fall!");
                break;
            case winterStart:
                sliderSeasons.gameObject.transform.Find("Background").GetComponent<Image>().color = winterColor;
                Debug.Log("Winter.");
                break;
        }
	}
}

            //if (sliderSeasons.value = 61)
            //{
            //	sliderSeasons.gameObject.transform.Find("Background").GetComponent<Image>().color = summerColor;
            //	sliderSeasons.gameObject.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color = summerColor;
            //	sliderSeasons.gameObject.transform.Find("Background").GetComponent<Image>().image = "..\\Assets\\Images\\SeasonsSpringToSummer.png";

                //	sliderSeasons.BackGround.Color = Color.green;
                //	Fill.Color = Color.Lerp(Color.green, Color.red);
                //	sliderSeasons.Background.Color = Colo
                //	sliderSeasons.Background = "..\\Assets\\Images\\SeasonsSpringToSummer.png";
                //}
                //else if (242 > sliderSeasons.value > 151)
                //{
                //	sliderSeasons.Background = "..\\Assets\\Images\\SeasonsSummerToFall.png";
                //}