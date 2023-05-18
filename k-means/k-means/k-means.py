
from sklearn.cluster import KMeans
import pandas as pd
import numpy as np
import matplotlib.pyplot as plt
from matplotlib import style
import tkinter as tk
from tkinter import ttk

def getKMeans():
    style.use("ggplot")
    #enable us to make visualization

    col1 = str(entry2.get())
    col2 = str(entry3.get())

    df = pd.read_csv("Mall_Customers.csv",sep=",", usecols=[col1, col2])
     #dataset processing
    df_x = df.iloc[:, 0:2]
     #choose no. of rows & columns
    x_array = np.array(df_x)

    k = int(entry1.get())
    # no. of groups
    if k > 1:
        nCluster = k
    else:
        nCluster = 1

    kmeans = KMeans(n_clusters=nCluster)

    #KMeans Model , Visualization

    kmeans.fit(x_array)
    df["kluster"] = kmeans.labels_
    output = plt.scatter(x_array[:, 0], x_array[:, 1], s=100, c=df.kluster, marker="o", alpha=1, )
    centers = kmeans.cluster_centers_
    plt.scatter(centers[:, 0], centers[:, 1], c="red", s=200, alpha=1, marker="o")
    plt.title("K-Means")
    plt.xlabel(col1)
    plt.ylabel(col2)
    plt.colorbar(output)
    plt.show()
    
    quit()

def getPower():
    x1 = entry1.get()

    label4 = tk.Label(root, text= float(x1)**2,font=('helvetica', 10, 'bold'))
    canvas1.create_window(200, 230, window=label4)

root= tk.Tk()

canvas1 = tk.Canvas(root, width = 500, height = 400,  relief = 'raised')
canvas1.pack()

label1 = tk.Label(root, text='K-Means')
label1.config(font=('helvetica', 14))
canvas1.create_window(250, 25, window=label1)

label2 = tk.Label(root, text='N-Cluster :')
label2.config(font=('helvetica', 10))
canvas1.create_window(250, 100, window=label2)

entry1 = tk.Entry (root) 
canvas1.create_window(250, 140, window=entry1)

label3 = tk.Label(root, text='Choose Xlabel , YLabel From : Age , Annual_Income , Spending_Score')
label3.config(font=('helvetica', 10))
canvas1.create_window(250, 180, window=label3)

#n = tk.StringVar()
#LabelsComobox = ttk.Combobox(canvas1, width=27, textvariable=n)
#LabelsComobox['values'] = ('Gender',
#                         'Age',
#                          'Annual_Income',
#                          'Spending_Score')
#LabelsComobox.grid(column=1, row=5)

entry2 = tk.Entry(root)
canvas1.create_window(250, 220, window=entry2)

entry3 = tk.Entry(root)
canvas1.create_window(250, 260, window=entry3)

button1 = tk.Button(text='K-Means Visualization', command=getKMeans, bg='brown', fg='white', font=('helvetica',9,'bold'))
canvas1.create_window(250, 300, window=button1)

root.mainloop()