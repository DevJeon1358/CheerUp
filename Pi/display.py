from GUI import *
import json
import socket
import threading

client_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
client_socket.connect(("35.220.152.156", 3030))

client_socket.send("init 1".encode())
messages = client_socket.recv(400).decode()
# print(data)
messages = json.loads(messages.decode())
print(len(messages))
cnt = len(messages)-1
def receives():
    global cnt
    while True:
        t = client_socket.recv(400).decode()
        js = json.loads(t)
        print(js['Content'])
        upload_Sentence(js['Content'])
        messages.append(js)
        cnt = len(messages)-1
        upload_Data(str(len(messages)))
        
def receives_thread():
        thread=threading.Thread(target=receives)
        thread.daemon=True #프로그램 종료시 프로세스도 함께 종료 (백그라운드 재생 X)
        thread.start()

def upButton_Click():
    global cnt
    if cnt < len(messages) - 1:
        cnt = cnt + 1
        print(cnt)
        upload_Sentence(messages[cnt]['Content'])
        
def downButton_Click(self):
    global cnt
    if cnt > 0:
        cnt = cnt - 1
        print(cnt)
        upload_Sentence(messages[cnt]['Content'])

def upload_place(data):
    ui.place.setText(data)
    
def upload_Data(data):
    ui.cheering_data.setText(data)

def upload_Sentence(data):
    ui.cheering_sentence.setText(data)

def upload_Humidity_Data(data):
    ui.humidity_data.setText(data)

def upload_Temperature_Data(data):
    ui.temperature_data.setText(data)

if __name__ == "__main__":
    import sys
    app = QtWidgets.QApplication(sys.argv)
    Dialog = QtWidgets.QDialog()
    ui = Ui_Dialog()
    ui.setupUi(Dialog)
    ui.index_up.clicked.connect(upButton_Click)
    ui.index_down.clicked.connect(downButton_Click)
    receives_thread()
    upload_Data(str(cnt+1))
    upload_Sentence(messages[cnt-1]['Content'])
    Dialog.show()
    sys.exit(app.exec_())
    


