import matplotlib.pyplot as plt
import numpy as np
import pandas as pd

data = pd.read_csv(r"./data/framingham.csv")

for column in data.columns:
    data[column] = (data[column] - data[column].min()) / (
        data[column].max() - data[column].min()
    )

data.plot.bar()
