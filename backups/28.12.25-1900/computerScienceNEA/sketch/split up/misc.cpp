void checkForSerial1()
{
  if (Serial1.available()) // checks if the computer has sent anything to the arduino through the serialMonitor
  {
    command = Serial1.readStringUntil('\n'); //set the variable command to whatever was sent through the serialPort
    command.trim(); // removes unneccecary things from the message (\r, \n)

    //translateSerial();

    if (command == "forward") 
    {
        Serial1.println("moving forwards");
        moveForward();
        delay(500);

    } else if (command == "backward") 
    {
        Serial1.println("moving backwards");
        moveBackward();
        delay(500);

    } else if (command == "right")
    {
        Serial1.println("turning right");
        turnRight();
        delay(500);

    } else if (command == "left")
    {
        Serial1.println("turning left");
        turnLeft();
        delay(500);
    } 
  } else
  {
    delay(500); //millis(); might be a better alternative because the arduino can check for things sent in the serial port while it waits [ask GPT for the difference between delay and millis]
    //The arduino might miss the data sent from the computer if delay is used
  }
}

void translateSerial1()
{
  if (command == "forwards")
  {
    moveForward();
  }
  else if (command == "backwards")
  {
    moveBackward();
  }
  else if (command == "left")
  {
    turnLeft();
  }
  else if (command == "right")
  {
    turnRight();
  }
  else if (command == "stop")
  {
    stopMotors();
  }
}

void checkForIR()
{
  if (irrecv.decode(&results)) // have we received an IR signal?
  {
    translateIR(); 
    irrecv.resume(); // receive the next value
    delay(600);
  }
  else{
    
  }
}



void translateIR() // takes action based on IR code received
// describing Remote IR codes 
{
  switch(results.value)
  {
    case 0xFF629D: Serial.println("VOL+"); moveForward(); previousButtonPress = "VOL+"; break;
    case 0xFF22DD: Serial.println("FAST BACK"); turnLeft(); previousButtonPress = "FAST BACK"; break;
    case 0xFFC23D: Serial.println("FAST FORWARD"); turnRight(); previousButtonPress = "FAST FORWARD"; break;
    case 0xFFE01F: Serial.println("DOWN"); moveBackward(); previousButtonPress = "DOWN"; break;
    case 0xFFA857: Serial.println("VOL-"); moveBackward(); previousButtonPress = "VOL-"; break;
    case 0xFF906F: Serial.println("UP"); moveForward(); previousButtonPress = "UP"; break;
    case 0xFFFFFFFF: Serial.println(" REPEAT");
      if (previousButtonPress == "VOL+"){
        moveForward();
      }
      else if (previousButtonPress == "FAST BACK"){
        turnLeft();
      }
      else if (previousButtonPress == "FAST FORWARD"){
        turnRight();
      }
      else if (previousButtonPress == "DOWN"){
        moveBackward();
      }
      else if (previousButtonPress == "VOL-"){
        moveBackward();
      }
      else if (previousButtonPress == "UP"){
        moveForward();
      }
    break;  
  default: 
    stopMotors();
  }

  //delay(100); // Do not get immediate repeat
}
