# Pharm.B System (Builder of Pharmacy)
Pharm.D is known as Doctor of pharmacy among all medicine universities. The pharmacy information system name and logo was inspired from this idea to simulate the database manegement system as Builder of Pharmacy as shown:

![logo](https://user-images.githubusercontent.com/101527083/219718133-340b48a5-80e4-420f-a492-df5d4fb10c0f.png)

## Aim
Pharmacy management software, — Pharm.B (Pharmacy Builder) — is to store important information about medications and patients in a much simpler way to ensure that the right prescriptions are given out at the right dosage. Furthermore, this new system is meant to be a multi-functional system that allows pharmacists to store the patient’s information and perpetuate the supply and organization of drugs. The system stores the patient’s information to perceive the allergies of the patient and guarantees that no patient would be prescribed a medication that would cause them to suffer from an allergic reaction. Moreover, the system will be very secure, up-to-date, and accurate, this is in order to decrease medication errors, increase patient safety, report drug usage, and track costs. The team members plan on implementing all this by adding inventory tracking, prescription filling and processing (taking all the necessary steps that should be taken to evaluate a prescription, verify its medical importance, benefits or side effects), and point of sale to the system. These three functions are the primary functions of any pharmacy information system; however, we developed some enhancements to it, making pharmacists’ and patients’ life much simpler, faster, and safer. Additionally, we are planning on adding a new feature to our system. Eventually, the development platform is utterly formal and organized. It will be structured by HTML, CSS, JavaScript and Tkinter.

## PREFACE 
This Software Requirement Specification (SRS) is intended for the pharmacy doctors ‘the admin of the system’ and pharmacists ‘the users’. This version of SRS covers the interface of release one of the Pharm-B (Builder of Pharmacy) system, which occurred at week 6 of the design process.

## UML (unified machine language)
The system had UML (unified machine language) designs to simplfy the stalkholders' desire — the pharmacist and doctors — of each requirement they need. 
## System Architecture 
The system architecture discusses the developed system’s modules and the underlying functions within each. The system is divided into 4 main modules: 
Information display module, Add product module, Search module, Payment module.

### Information display module 
The " Information display module " carries out the functions necessary to display important information about the desired product Including some of the vital data such as the reference number to check its availability, the lot number to track any faulty drug patches in the pharmacy and other important details such as the issue date, expiry date and the usage details, in order to enhance the pharmacist/patient relation and help pharmacist know the patient's needs better and give the patient the best service.
Medicine information:
* Medicine name
* Reference number: the medicine's code on the system in order to be found/handled throughout the process to check for its availability and quantity
* Company name: It is vital to keep record of the company name from whom the pharmacy buys the drugs/who is responsible for those drugs
* Type of medicine: Specifies the form in which the medicine comes in (Liquid, Tablet or Capsules)
* Lot number: the patch in which the drug came in to the pharmacy
* Issue date: For it's a must for the pharmacy to record the day the drug is added to the pharmacy
* Expiry date: The expiry date is a crucial information for the pharmacist and the patient
* Uses: It shows the pharmacist the health problems for which the medicine is mainly used for
*  side effects
*  Precautions and warnings: Important precautions related to the dosage/ allergies etc
*  Dosage: For the pharmacist to give the right dosage of the drug to the patient
*  Price
*  Quantity

### Add product module
The " Adding new product module” is mainly responsible for adding the newly coming drug " quantity-wise " with referral to the reference number and lot number to specify the needed product, functions such as: Add, Update, Clear and Delete are included in the module. whereas:
* Add: Enters a newly arriving product to the system’s dataset..
* Update: Updates the name, lot, and referral numbers of the products in the system for a pre-existing product.
* Clear: Clear the entered data from the boxes whiteout adding.
* Delete: Delete an existing product.

### Search module 
This module is mainly responsible for handling the search process of drugs with multiple options to facilitate finding the required drug with reference to the expiry  date for example. It also helps with adding and removing information about the drugs. The most important functions used are:
* Search: It searches for an entered drug name, referral number, or according to an option(s) selected from the “Search Options” function.
* Search Options: It is used to find the needed drug through filtration process such as the expiry date, the company’s name, the lot number...etc.
* Add Medicine: It allows the pharmacist to add a medicine to the system along with adding some required data about the drug in order to properly add it to the system.
* Delete: It deletes a selected drug from the dataset.
* Update: It updates the information of a specified drug on the dataset.
* Show All: It shows the whole dataset for preview.
* Exit: It exits the search process.

### Payment module 
The patient has one method to pay with "cash”.

### The system architecture diagram 
It divides the systems into sub modules as previously mentioned. It involves two parts: theoritical part and diagram attached with a table as shown. 

![image](https://user-images.githubusercontent.com/101527083/219721670-e7e7a402-e744-4025-bfcf-dc561c70d1f2.png)


![System Architecture](https://user-images.githubusercontent.com/101527083/219721055-397ce5bb-15c2-4239-949a-7ef421846730.PNG)


### Activity diagram
The aim of the activity diagram is to explain all the activities of the whole system. Activity means any function provided by the system shuch as (Add- Delete- Pay - Update - Search ...). 

![activity drawio](https://user-images.githubusercontent.com/101527083/219741572-7ba34e30-e74c-42e1-aa46-1f34c67a47ea.png)

![activity](https://user-images.githubusercontent.com/101527083/219741581-6cc95b76-64a8-4d59-895a-134006ffd580.PNG)


### Use cases diagram 
The main idea of use cases is to simplify the connection between the useres and programmers regarding what the customer needs and what the programer should implement in the system. It has include and extend relations to know the exceptions and handling the errors.

![use-case](https://user-images.githubusercontent.com/101527083/219722227-8e80d135-da16-44a5-9022-c637ad4fd4c6.png)


### Class diagram based on activity diagram and use cases 

The class diagram is so important in categorizing the system parts in an organized way. This helps to minimize the lines of codes by inheritance between the parent classes and child classes. For instance, instead of repeating a block of code for admin (doctor) and users(pharmacists) with a slight difference between both of them, we can make a parent class the has the abstraction of the main functions and extract two child classes from it. This is the main concept of `OOP(Object Oriented Programming)`

![Capture](https://user-images.githubusercontent.com/101527083/219723734-4f5925b2-2efb-4e77-876a-7382974e8c70.PNG)

### Class diagram based on interaction diagrams (sequence diagram and collaboration — communication — diagram)
There is a difference between the class diagram based on interaction diagrams and class diagram based on activity diagram and use cases. The one that based on the interaction diagram is more organized, specific after finishing a large part of technical coding journey and summarized.
![image](https://user-images.githubusercontent.com/101527083/219741951-77ebe1e6-b08d-47c9-8c98-455b3a34849b.png)


### Object diagram 

the object diagram demonstrates the interactions between the objects.
![Object](https://user-images.githubusercontent.com/101527083/219724398-120727db-c1da-4153-bebe-17e666379158.jpeg)

### state machince diagram 

The state machine diagram explains well every state in the system. The state has Do aspect which is the action done by the system user and a rounded rectangle to show the result of this action.
The images below shows the state machine diagrams of the main parts of the system. 

![STATE DIAGRAM png](https://user-images.githubusercontent.com/101527083/219739906-eda7e2e7-1768-4edb-8f31-5c4de1267809.png)

![STATE DIAGRAM drawio (1)](https://user-images.githubusercontent.com/101527083/219739968-485ebb80-4e29-46ac-a169-2352b81c2dd9.png)

![STATE DIAGRAM drawio (2)](https://user-images.githubusercontent.com/101527083/219740003-7fe6c179-8023-453f-aa2b-fd8adc7f7aab.png)

### Package diagram 
The package diagram clarifies the interactions between the classes and connections. Each class diagram is included into the package diagram with its methods and attributes in a hidden way. 

![image](https://user-images.githubusercontent.com/101527083/219742123-7260d782-d1a3-4314-bae4-df315cebb800.png)


### Deployment diagram 

The deployment diagram shows the hardware parts of the system in details.

![image](https://user-images.githubusercontent.com/101527083/219742294-4ad9ce5b-99b1-43a7-83ae-ed2c55c2577d.png)

### Database with SQL Server 
The database was collected manually with credits was earned by Dr. Ahmed yahia pharmacy in Borg Al-Arab City, Egypt. 

![image](https://user-images.githubusercontent.com/101527083/219745510-e43d2994-db6a-4eca-811f-107e6e2b0c50.png)

![image](https://user-images.githubusercontent.com/101527083/219746656-108a98f0-99cf-47e4-ad59-f32e6d51bc37.png)


![image](https://user-images.githubusercontent.com/101527083/219745710-0e8e3202-e51e-47ad-bcfc-a0a16acd7067.png)



### ER diagram 

It shows the primary key which is reference number and secondary key which is the medicine name. It is required for any system whether it has a website interface or not. The primary key is the reference number because it is unique for each medicine and has no repeatitions.  

![image](https://user-images.githubusercontent.com/101527083/219743677-4cf34e6f-2bb9-4936-838b-6764ce3ff856.png)


#### System desktop interface and login page (Tkinter)

![image](https://user-images.githubusercontent.com/101527083/219742921-edb35176-f63f-4a30-bf9a-0ffc72fe7269.png)


### System website interface (HTML,CSS, JavaScript)

![image](https://user-images.githubusercontent.com/101527083/219742684-146d5d8e-2e7a-4c37-a75a-376bb5408997.png)

![image](https://user-images.githubusercontent.com/101527083/219742785-ec6dc786-e1bf-4c02-a6fe-0515307d1d54.png)






