import socket
import requests
import json
import time

IP = '0.0.0.0'
PORT = 14014
API_URL = "https://waterflowapirest20230615101114.azurewebsites.net/api/waterflows"

sock = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
sock.bind((IP, PORT))

while True:
    data, addr = sock.recvfrom(1024)
    data_str = data.decode()
    print("received data and from: ", data_str, addr)
    print()
    UnJsonWaterFlow = json.loads(data_str)
    print("Turning received data into a python object: ", UnJsonWaterFlow)
    #print(UnJsonWaterFlow.get('name'))
    response = requests.post(API_URL, json=UnJsonWaterFlow)
    print(response)
    time.sleep(2)



