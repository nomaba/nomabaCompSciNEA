const int ledPin = 13; //LED L on the arduino board

void setup() 
{ 
  pinMode(ledPin, OUTPUT);

  digitalWrite(ledPin, LOW);

  Serial.begin(9600); //start the serial communication with the computer at speed 9600 baud
  
  delay(1000);
  Serial.println("ready");
}

void loop() 
{
  if (Serial.available()) // checks if the computer has sent anything to the arduino through the serialMonitor
  {
    String command = Serial.readStringUntil('\n'); //set the variable command to whatever was sent through the serialPort
    command.trim(); // removes unneccecary things from the message (\r, \n)

    if (command == "on") 
    {
      digitalWrite(ledPin, HIGH);
    } else if (command == "off") 
    {
      digitalWrite(ledPin, LOW);
    }
  } else
  {
    delay(500); //millis(); might be a better alternative because the arduino can check for things sent in the serial port while it waits [ask GPT for the difference between delay and millis]
    //The arduino might miss the data sent from the computer if delay is used
  }
}
