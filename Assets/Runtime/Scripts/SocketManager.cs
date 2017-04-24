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

using System;
using System.Threading;
using System.Net.Sockets;


public class SocketManager {
	private static Socket sock = null;
	private static byte[] msg = new byte[1024];
	
	public static Action<int> onError;
	public static Action<byte[]> onData;
	public static string HOST;
	public static int PORT;
	
	public static void send(byte[] msg)
	{
		if(sock == null)
		{
			Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			try{
				s.Connect (HOST, PORT);
			}catch(Exception e)
			{
				if(onError!=null){
					Main.runInUnityThread(()=>{
						onError(1);
					});
				}
				Debug.LogError(e.Message);
				return;
			}
			sock = s;
			ThreadPool.QueueUserWorkItem(recvmsg);
		}
		
		try{
			sock.Send(msg);
			return;
		}catch(Exception e){
			Debug.LogError(e);
			dispose();
		}
	}
	
	private static void recvmsg(object obj)
	{
		while (true) {
			int len = 0;
			try{
				len = sock.Receive(msg);
				if(len == 0)
				{
					throw new Exception("recv zero and disconnectd!");
				}
				Debug.Log("recvmsg end: " + len);
			}catch(Exception e)
			{
				Debug.LogError("recvmsg error:" + e.ToString());
				dispose();
				break;
			}
			if(len <=0) continue;

			byte[] data = new byte[len];
			Array.Copy(msg,0,data,0,len);
			Main.runInUnityThread(()=>{
				onData(data);
			});
		}
	}
	
	public static void dispose(bool normal = false)
	{
		Debug.LogError ("dispose");
		if(sock != null){
			try{
				if(sock.Connected) sock.Shutdown(SocketShutdown.Both);
			}catch(Exception e)
			{
				Debug.LogError(e);
			}
			try{
				sock.Close();
			}catch(Exception e)
			{
				Debug.LogError(e);
			}
			if(normal == false && onError!=null)
			{
				Main.runInUnityThread(()=>{
					onError(2);
				});
			}
		}
		sock = null;
	}
	
}
