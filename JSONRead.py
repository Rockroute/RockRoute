import os
import json

dir_path = os.path.dirname(os.path.realpath(__file__))
commentsFileDir = dir_path + "/ClimbingDataset.json"


with open(commentsFileDir) as f:
    THEJSON = json.load(f)


print(THEJSON[0])