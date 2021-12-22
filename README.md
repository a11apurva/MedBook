# MedBook

**A Health and Fitness Windows Phone App**

*Runner's up at Microsoft code.fun.do Manipal, 2015 and National Finalists in Microsoft Imagine Cup - 2016, India.*

Team Members:
- Anubhav Apurva
- Prashant Kumar
- Utsava Verma
- Yashashvi Tarana

## Demo Video
<br/>

<a href="https://www.youtube.com/watch?v=dAF8IR7sbRw&feature=youtu.be
" target="_blank"><img src="https://upload.wikimedia.org/wikipedia/commons/3/34/YouTube_logo_%282017%29.png" 
alt="IMAGE ALT TEXT HERE" width="220" height="45" border="10" /></a>

<br/>

## MedBook Alexa skill

<a href="https://www.amazon.com/dp/B07CR86TBF/ref=syps?s=digital-skills&ie=UTF8&qid=1526462108&sr=1-1&keywords=MedBook" target="_blank"><img src="https://images-na.ssl-images-amazon.com/images/I/516NZCAAvgL.png" 
alt="IMAGE ALT TEXT HERE" width="100" height="100" border="10" /></a>

[MedBook](https://www.amazon.com/dp/B07CR86TBF/ref=syps?s=digital-skills&ie=UTF8&qid=1526462108&sr=1-1&keywords=MedBook) is also your one stop Alexa skill for all your Medical queries.

[MedBook-Alexa GitHub Repo](https://github.com/a11apurva/MedBook-Alexa)

<br/>

## Steps to install the app
 
- MedBook is built for Windows Phone 8.1 and above. 
- To run the application, deploy the application on Windows Phone 8.1 platform or above. 
- To use the heartbeat monitoring feature, Microsoft Band should be connected via Bluetooth 
- Nugets to be installed : Windows Azure Mobile Services, Windows Azure Web Services, Json.NET, Microsoft Band SDK


## Implemented Features:

The primary feature of the app is to **store and manage Medical records and documents in a structured manner over a cloud server** i.e. Microsoft Azure. The records can be accessed by healtcare professionals after OTP based authentication.

Other signfact features include: 

1. Emergency Message
	- Send co-ordinates of current location to the 3 saved emergency contacts
	
2. Call a doctor
	- One tap call to the 3 saved emergency doctor contacts
	
3. Notifications
	- Set reminders about pills and doctor/lab appointments
	
4. Store Records
	- Store medical history including X-rays and prescriptions chronologically 
	
5. Nearby Hospitals
	- Find nearest hospitals and its route upon selecting a hospital
	
6. Find Medicines
	- Find medicines containing a particular drug and its alternative if that drug is not present in the store
	
7. Blood Bank
	- Find nearest blood banks by searching (a) by city name, (b) by pin code, (c) by using GPS
	
8. Heartbeat
	- Configured with the Microsoft Band to find HeartBeat , Skin Temperature, UV Exposure.
	
9. BMI Calculator
	- Calculates the BMI based on height and weight Input
	
10. Web Portal
	- A web portal which allows patient's medical history to be viewed
	- A unique username and password for each patient
	- OTP based authentication for the authorized viewers such as a doctor
	


## Future Implementation:

1. General/Private Consultation
	* General Consultation
		* A Medical Qeury by an individual can be answered by any doctor registered on the App.
	* Private Consultation
		* A medical query by an individual can be answered only by a particular doctor of that person's choice 
		
2. Blood Bank using local conectivity
	* To be able to find people(who have the app installed) of the same blood type within a certain(eg 1km) radius
	* A user will have to switch on(and agree to) this facility if they want to receive requests to donate blood
	
3. Accelerometer
	* Configure the Band to send notification to emergency contact and people during an emergency. (testing this using acceleration)
	* For the elderly - Detect fall or loss of balance
	
4. Background Montioring of HeartBeat Using Microsoft Band
	* To continuously track heart-beat in background and plot a graph. Right now the heartbeat monitor works only when the App is open.
	
5. Voice Control for visually impared
	* To empower the visually impaired community.
	
6. Calorie Calculator
	* Calculate the calorie in-take
	
7. Health Tips
	* Daily Health tips
	





