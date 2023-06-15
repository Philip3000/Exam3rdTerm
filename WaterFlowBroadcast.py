import datetime
import json
import socket
import random
import time
import datetime

PORT = 14014


def send_broadcast():
    #Opretter en socket hvor AF_INET betyder IPv4 og SOCK_DGRAM betyder UDP
    s = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
    s.setsockopt(socket.SOL_SOCKET, socket.SO_BROADCAST, 1)
    print("What is the waterflow's name?")
    name = input()

    while True:
        #tilfældig int mellem 1-10
        volume = random.randint(1, 10)
        #laver beskeden
        waterFlow = { "name": name, "volume": volume}
        jsonWaterFlow = json.dumps(waterFlow)
        print("Objektet som Json: " + jsonWaterFlow)

        #Sender beskeden som broadcast type til den angivne port og indkoder beskeden
        s.sendto(jsonWaterFlow.encode(), ("<broadcast>", PORT))
        #venter i 2 sekunder
        time.sleep(2)


send_broadcast()