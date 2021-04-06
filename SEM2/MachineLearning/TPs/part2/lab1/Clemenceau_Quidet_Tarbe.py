import numpy as np
import random

# normalizing 3rd column data
def normalize(y):
    a = np.zeros(3)
    a[y] = 1
    return a

# sigmoid function
def sig(x):
    return 1/(1 + np.exp(-x))

# sigmoid prime
def sig_prime(x):
    return np.exp(-x) / np.power(1 + np.exp(-x), 2)

# Feed Forward Neural Network
class FFNN:
    def __init__(self):
        file = open("data_ffnn_3classes.txt","r")
        data = np.loadtxt(file)
        
        # Input
        self.x_train = [np.reshape(x, (1, 2)) for x in data[:,:2].astype(float)]
        self.y_train = np.array([normalize(y) for y in np.array(data[:,2]).T.astype(int)])

        # Weights & Biases
        K = 5 # arbitrary: number of neurons in each layer
        self.W1 = np.random.rand(2, K)
        self.B1 = np.random.rand(1, K)
        self.W2 = np.random.rand(K, 3)
        self.B2 = np.random.rand(1, 3)
        self.alpha = 0.3 # weight adjustment multiplicator: if too big, good progress in the begining but not enough precision afterwards

    def predict(self, X):
        H1 = sig(np.dot(X, self.W1) + self.B1)
        return sig(np.dot(H1, self.W2) + self.B2)

    def train(self):
        print("\n==========================================Training==========================================")
        for i in range(1000):
            error = 0
            for X, Y_true in zip(self.x_train, self.y_train):
                H1 = sig(np.dot(X, self.W1) + self.B1)
                Y = sig(np.dot(H1, self.W2) + self.B2)
                dError = 0.5 * np.sum(np.power(Y_true - Y, 2))
                dB2 = (Y - Y_true) * sig_prime(np.dot(H1, self.W2) + self.B2)
                dW2 = np.dot(H1.T, dB2)
                dB1 = np.dot(dB2, self.W2.T * sig_prime(np.dot(X, self.W1) + self.B1))
                dW1 = np.dot(X.T, dB1)

                self.B2 -= self.alpha * dB2
                self.W2 -= self.alpha * dW2
                self.B1 -= self.alpha * dB1
                self.W1 -= self.alpha * dW1

                error += dError
            error /= len(self.x_train)
            print("epoch n°", i, ": error =", error)
    
    def compare(self):
        print("\n==========================================Comparison==========================================")
        for i in range(0,71):
            print("prediction:", network.predict(self.x_train[i]), "\n  original:", self.y_train[i], "\n")
            
    def test(self, arr):
        print("\n==========================================Testing==========================================")
        print("testing with", arr, ":", network.predict(arr))
            
            
network = FFNN()
network.train()
network.compare()
network.test(np.array([2,2]))
network.test(np.array([4,4]))
network.test(np.array([4.5,1.5]))