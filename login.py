from tkinter import *
from tkinter import messagebox
import os 




root=Tk()
root.title('Builder of P harmacy - login')
root.geometry ('900x500+300+200')
root.configure(bg='#fff')
root.resizable (False,False)
 
# add the logo here ya arwa 
 
img = PhotoImage(file = 'D:/CS/3rd/software-engineering/project/coding/Pharmacy_management-system-master/logo.png')
Label(root,image = img ,bg='white').place(x=50,y=50)
frame = Frame(root,width=350,height=350,bg='white')
frame.place(x=480,y=70)

heading= Label(frame,text='Login',fg='#001534',bg='white',font=('Microsoft TaHei UI Light',23,'bold'))
heading.place(x=120,y=5)

#-------------------


def on_enter(e):
    user.delete(0,'end')

def on_leave(e):
    name = user.get()
    if name == '':
        user.insert(0, "Username")
        
user=Entry(frame, width=25,fg='black',border = 0, bg='white' ,font=('Microsoft TaHei UI Light',11))
user.place(x=30,y=90)
user.insert(0, 'Username')

user.bind('<FocusIn>',on_enter)
user.bind('<FocusOut>',on_leave)

Frame(frame,width = 295, height= 2, bg= 'black').place(x=25,y=117)

#-------------------

#------------------
def on_enter(e):
    password.delete(0,'end')

def on_leave(e):
    name = password.get()
    if name == '':
        password.insert(0, "Password")
        
password=Entry(frame, width=25,fg='black',border = 0, bg='white' ,font=('Microsoft TaHei UI Light',11))
password.place(x=30,y=160)
password.insert(0, 'Password')
password.bind('<FocusIn>',on_enter)
password.bind('<FocusOut>',on_leave)
Frame(frame ,width = 295, height= 2, bg= 'black').place(x=25,y=187)


#-------------------
def run1():
   
    os.system("python med.py")
    
def sign_in():
    


    user_name = ["Arwa","Hossam","Shahd","Ashour","Mariam","Zizo"]
    userpassword = "2222"

    if user.get() in user_name and password.get() != userpassword:
        messagebox.showerror("Error","Password Wrong")
        
    elif user.get()=="" or password.get()=="":
        messagebox.showerror("Error","All fields are required")
    else:
        run1()
    
    
Button(frame,width=40, pady=7,text='Sign in',bg='#001534', fg='white',border = 0 ,command=sign_in).place(x=35,y=224)



root.mainloop() 