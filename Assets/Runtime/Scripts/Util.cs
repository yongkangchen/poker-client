/**
https://github.com/yongkangchen/poker-server

Copyright (C) 2016  Yongkang Chen lx1988cyk#gmail.com

GNU GENERAL PUBLIC LICENSE
   	Version 3, 29 June 2007

Copyright (C) 2007 Free Software Foundation, Inc. <http://fsf.org/>
Everyone is permitted to copy and distribute verbatim copies
of this license document, but changing it is not allowed.
**/
﻿
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;

public class Util {
	private const int HEADER_SIZE = 44;
	public static byte[] ClipBytes(AudioClip clip)
	{
		float[] data = new float[clip.samples * clip.channels];
		clip.GetData(data, 0);

		List<float> data2 = new List<float>();
		for (int i = 0; i < data.Length; i++)
        {
            if (data[i] != 0)
            {
                data2.Add(data[i]);
            }
        }
        
        clip = AudioClip.Create("voice", data2.Count, clip.channels, clip.frequency, false);
        clip.SetData(data2.ToArray(), 0);

		MemoryStream s = new MemoryStream (clip.samples * 2 + HEADER_SIZE);
		WriteHeader (s, clip);
		ConvertAndWrite (s, clip);

		byte[] ret = s.ToArray();
		return ret;
	}

	public static System.Array CreateArray(string t, int n)
	{
		return System.Array.CreateInstance (System.Type.GetType(t), n);
	}

	public static Texture2D ScaleTexture(Texture2D originalTexture, int width, int height){
		Texture2D newTexture = new Texture2D(width, height);
		float scaleX = originalTexture.width / width;
		float scaleY = originalTexture.height / height;
		int maxX = originalTexture.width - 1;
		int maxY = originalTexture.height - 1;
		for(int y = 0; y < newTexture.height; y++) {
			for(int x = 0; x < newTexture.width; x++) {
				float targetX = x * scaleX;
				float targetY = y * scaleY;
				int x1 = Mathf.Min(maxX, Mathf.FloorToInt(targetX));
				int y1 = Mathf.Min(maxY, Mathf.FloorToInt(targetY));
				int x2 = Mathf.Min(maxX, x1 + 1);
				int y2 = Mathf.Min(maxY, y1 + 1);

				float u = targetX - x1;
				float v = targetY - y1 ;
				float w1 = (1 - u) * (1 - v);
				float w2 = u * (1 - v);
				float w3 = (1 - u) * v;
				float w4 = u * v;
				Color color1 = originalTexture.GetPixel(x1, y1);
				Color color2 = originalTexture.GetPixel(x2, y1);
				Color color3 = originalTexture.GetPixel(x1, y2);
				Color color4 = originalTexture.GetPixel(x2,  y2);
				Color color = new Color(Mathf.Clamp01(color1.r * w1 + color2.r * w2 + color3.r * w3+ color4.r * w4),
					Mathf.Clamp01(color1.g * w1 + color2.g * w2 + color3.g * w3 + color4.g * w4),
					Mathf.Clamp01(color1.b * w1 + color2.b * w2 + color3.b * w3 + color4.b * w4),
					Mathf.Clamp01(color1.a * w1 + color2.a * w2 + color3.a * w3 + color4.a * w4)
				);
				newTexture.SetPixel(x, y, color);
			}
		}
		newTexture.Apply();
		return newTexture;
	}

	private static void WriteHeader(Stream fileStream, AudioClip clip)
	{

		int hz = clip.frequency;
		int channels = clip.channels;
		int samples = clip.samples;

		Byte[] riff = System.Text.Encoding.UTF8.GetBytes("RIFF");
		fileStream.Write(riff, 0, 4);

		Byte[] chunkSize = BitConverter.GetBytes(fileStream.Length - 8);
		fileStream.Write(chunkSize, 0, 4);

		Byte[] wave = System.Text.Encoding.UTF8.GetBytes("WAVE");
		fileStream.Write(wave, 0, 4);

		Byte[] fmt = System.Text.Encoding.UTF8.GetBytes("fmt ");
		fileStream.Write(fmt, 0, 4);

		Byte[] subChunk1 = BitConverter.GetBytes(16);
		fileStream.Write(subChunk1, 0, 4);

		UInt16 two = 2;
		UInt16 one = 1;

		Byte[] audioFormat = BitConverter.GetBytes(one);
		fileStream.Write(audioFormat, 0, 2);

		Byte[] numChannels = BitConverter.GetBytes(channels);
		fileStream.Write(numChannels, 0, 2);

		Byte[] sampleRate = BitConverter.GetBytes(hz);
		fileStream.Write(sampleRate, 0, 4);

		Byte[] byteRate = BitConverter.GetBytes(hz * channels * 2); // sampleRate * bytesPerSample*number of channels, here 44100*2*2  
		fileStream.Write(byteRate, 0, 4);

		UInt16 blockAlign = (ushort)(channels * 2);
		fileStream.Write(BitConverter.GetBytes(blockAlign), 0, 2);

		UInt16 bps = 16;
		Byte[] bitsPerSample = BitConverter.GetBytes(bps);
		fileStream.Write(bitsPerSample, 0, 2);

		Byte[] datastring = System.Text.Encoding.UTF8.GetBytes("data");
		fileStream.Write(datastring, 0, 4);

		Byte[] subChunk2 = BitConverter.GetBytes(samples * channels * 2);
		fileStream.Write(subChunk2, 0, 4);

	}

	private static void ConvertAndWrite(Stream fileStream, AudioClip clip)
	{
		float[] samples = new float[clip.samples];
		clip.GetData(samples, 0);

		Int16[] intData = new Int16[samples.Length];

		Byte[] bytesData = new Byte[samples.Length * 2];

		int rescaleFactor = 32767; 

		for (int i = 0; i < samples.Length; i++)
		{
			intData[i] = (short)(samples[i] * rescaleFactor);
			Byte[] byteArr = new Byte[2];
			byteArr = BitConverter.GetBytes(intData[i]);
			byteArr.CopyTo(bytesData, i * 2);
		}

		fileStream.Write(bytesData, 0, bytesData.Length);
	}
}