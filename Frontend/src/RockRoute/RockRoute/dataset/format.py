import os
import json

Dir = os.path.dirname(os.path.abspath(__file__)) + "/dataset.json"


with open(Dir) as file:
    for line in file:
        lineOfJson = json.loads(line)
        print(lineOfJson["route_name"])



'''
def Find_IG_Username():
    FileDir = Find_Instagram_Dir() + "/personal_information/personal_Information/personal_information.json"
    with open(FileDir) as file:
        json_data = json.load(file)
        Username = json_data["profile_user"][0]["string_map_data"]["Username"]["value"]
        Name = json_data["profile_user"][0]["string_map_data"]["Name"]["value"]
        return((Username, Name))
'''