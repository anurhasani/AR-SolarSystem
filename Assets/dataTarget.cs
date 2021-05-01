using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Vuforia
{
    public class dataTarget : MonoBehaviour
    {

        public Transform TextTargetName;
        public Transform TextDescription;
        public Transform ButtonAction;
        public Transform PanelDescription;

        public AudioSource soundTarget;
        public AudioClip clipTarget;

        // Use this for initialization
        void Start()
        {
            //add Audio Source as new game object component
            soundTarget = (AudioSource)gameObject.AddComponent<AudioSource>();
        }

        // Update is called once per frame
        void Update()
        {
            StateManager sm = TrackerManager.Instance.GetStateManager();
            IEnumerable<TrackableBehaviour> tbs = sm.GetActiveTrackableBehaviours();

            foreach (TrackableBehaviour tb in tbs)
            {
                string name = tb.TrackableName;
                ImageTarget it = tb.Trackable as ImageTarget;
                Vector2 size = it.GetSize();

                Debug.Log("Active image target:" + name + "  -size: " + size.x + ", " + size.y);

                string NewLine = System.Environment.NewLine;

                //Evertime the target found it will show “name of target” on the TextTargetName. Button, Description and Panel will visible (active)

                TextTargetName.GetComponent<Text>().text = name;
                ButtonAction.gameObject.SetActive(true);
                TextDescription.gameObject.SetActive(true);
                PanelDescription.gameObject.SetActive(true);

                // The Planet

                if (name == "earth")
                {
                    ButtonAction.GetComponent<Button>().onClick.AddListener(delegate { playSound("sounds/earthaudio"); });
                    TextDescription.GetComponent<Text>().text = " 3rd Planet in Solar System" + NewLine + "Distance from Sun : 150 Million KM" + NewLine + "The only Planet that inhabited by living things";

                }


                if (name == "mars")
                {
                    ButtonAction.GetComponent<Button>().onClick.AddListener(delegate { playSound("sounds/marsaudio"); });
                    TextDescription.GetComponent<Text>().text = "4th Planet in Solar System" + NewLine + "Distance from Sun: 241 Million KM" + NewLine + "Also known as the Red Planet";
                }

                if (name == "mercury")
                {
                    ButtonAction.GetComponent<Button>().onClick.AddListener(delegate { playSound("sounds/mercuryaudio"); });
                    TextDescription.GetComponent<Text>().text = "1st Planet in Solar System" + NewLine + "Distance from Sun : 39 million KM" + NewLine + "The Smallest Planet";
                }

                if (name == "venus")
                {
                    ButtonAction.GetComponent<Button>().onClick.AddListener(delegate { playSound("sounds/venusaudio"); });
                    TextDescription.GetComponent<Text>().text = "2nd Planet in Solar System" + NewLine + "Distance from Sun: 108 Million KM" + NewLine + "The Hottest Planet";
                }

                if (name == "jupiter")
                {
                    ButtonAction.GetComponent<Button>().onClick.AddListener(delegate { playSound("sounds/jupiteraudio"); });
                    TextDescription.GetComponent<Text>().text = "5th Planet in Solar System" + NewLine + "Distance from Sun : 486 million KM" + NewLine + "The largest Planet";
                }

                if (name == "saturn")
                {
                    ButtonAction.GetComponent<Button>().onClick.AddListener(delegate { playSound("sounds/saturnaudio"); });
                    TextDescription.GetComponent<Text>().text = "6th Planet in Solar System" + NewLine + "Distance from Sun : 932 million KM" + NewLine + "Very popular with its ring";
                }

                if (name == "uranus")
                {
                    ButtonAction.GetComponent<Button>().onClick.AddListener(delegate { playSound("sounds/uranusaudio"); });
                    TextDescription.GetComponent<Text>().text = "7th Planet in Solar System" + NewLine + "Distance from Sun : 1779 million KM" + NewLine + "Contains Methane which makes it blue";
                }


                if (name == "neptune")
                {
                    ButtonAction.GetComponent<Button>().onClick.AddListener(delegate { playSound("sounds/neptuneaudio"); });
                    TextDescription.GetComponent<Text>().text = "8th Planet in Solar System" + NewLine + "Distance from Sun: 2782 million KM" + NewLine + " It takes 165 earth year to orbit the sun";
                }



                if (name == "moon")
                {
                    ButtonAction.GetComponent<Button>().onClick.AddListener(delegate { playSound("sounds/moonaudio"); });
                    TextDescription.GetComponent<Text>().text = "This is the Earth's moon" + "Distance from Earth: 348 400 KM";
                }


              
                

            }
        }

        //function to play sound
        void playSound(string ss)
        {
            clipTarget = (AudioClip)Resources.Load(ss);
            soundTarget.clip = clipTarget;
            soundTarget.loop = false;
            soundTarget.playOnAwake = false;
            soundTarget.Play();
        }


       
    }
}
