﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.Linq;

public class SettingMenu : MonoBehaviour
{
   public AudioMixer audioMixer;

   Resolution[] resolutions;

   public Dropdown resolutionDropdown;

   public void Start(){
   		resolutions = Screen.resolutions.Select(resolution => new Resolution { width = resolution.width, height = resolution.height}).Distinct().ToArray();
   		resolutionDropdown.ClearOptions();

   		List<string> options = new List<string>();

   		int currentResolutionIndex = 0 ;

   		for(int i = 0; i < resolutions.Length; i++){
   			string option = resolutions[i].width + "x" + resolutions[i].height;
   			options.Add(option);

   			if(resolutions[i].width == Screen.width && resolutions[i].height == Screen.height){
   				currentResolutionIndex = i ;
   			}
   		}

   		resolutionDropdown.AddOptions(options);
   		resolutionDropdown.value = currentResolutionIndex;
   		resolutionDropdown.RefreshShownValue();
   }
   
   public void SetResolution(int resolutionIndex){

   	 Resolution resolution = resolutions[resolutionIndex];
   	 Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
   }
   public void SetVolume(float volume){

   
   	audioMixer.SetFloat("volume", volume);
   }

   public void SetFullScreen(bool isFullScreen){

   		Screen.fullScreen = isFullScreen;
   }


}
