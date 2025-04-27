import pandas as pd
import json
import os

cwd = os.getcwd()

Dir = os.path.dirname(os.path.abspath(__file__)) + "/Dataset.pkl.zip"


df = pd.read_pickle(Dir, compression='zip')


df.to_json(Dir + 'CuratedWithRating.json', orient='records', lines=True)

with open(Dir + "CuratedWithRating.json", "r") as file:
    data = file.readlines()

json_list = []

for line in data:
    try:
        parsed_json = json.loads(line.strip())
        nice_json = json.dumps(parsed_json, indent=4)
        json_list.append(nice_json)
    except json.JSONDecodeError as e:
        print(f"Error parsing line: {e}")
        continue

with open(Dir + "ClimbingDataset.json", "w") as file:
    file.write("\n\n".join(json_list))

print(f"Formatted JSON saved to ClimbingDataset.json")