using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using Structure;
using UnityEngine.Serialization;
using Newtonsoft.Json;

namespace Scripts
{
    public class client : MonoBehaviour
    {
        internal Boolean SocketReady = false;
        TcpClient _mySocket;
        NetworkStream _theStream;
        StreamReader _theReader;
        String Host = "localhost";
        Int32 Port = 5050;
        private string _data;
        public Graph _graph;

        void Start()
        {
            //SetupSocket();
        }

        void FixedUpdate()
        {
            _data = ReadSocket();
            if (_data != "")
            {
                _graph = CreateGraphFromJson(_data);
            }

        }

        public static Graph CreateGraphFromJson(string jsonString)
        {
            return JsonConvert.DeserializeObject<Graph>(jsonString);
        }

        public void SetupSocket()
        {
            try
            {
                _mySocket = new TcpClient(Host, Port);
                _theStream = _mySocket.GetStream();
                _theReader = new StreamReader(_theStream);
                SocketReady = true;
            }
            catch (Exception e)
            {
                Debug.Log("Socket error: " + e);
            }
        }

        public String ReadSocket()
        {
            if (!SocketReady)
                return "";
            if (_theStream.DataAvailable)
                return _theReader.ReadToEnd();
            return "";
        }

        public void CloseSocket()
        {
            if (!SocketReady)
                return;
            _theReader.Close();
            _mySocket.Close();
            SocketReady = false;
        }
    }
}