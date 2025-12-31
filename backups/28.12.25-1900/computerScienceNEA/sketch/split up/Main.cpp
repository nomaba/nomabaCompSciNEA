void setup()
{
  // put your setup code here, to run once:
  delay(2000); // This is here so that all the components have time to start up properly
  

  randomSeed(analogRead(0));


  irrecv.enableIRIn(); // Activate the IR sensor



  Serial.begin(9600); // Start the serial communication with the computer (if plugged in) at speed 9600 baud
  Serial1.begin(9600); // Start the serial communication with the HC-05 Module at speed 9600 baud
  Serial2.begin(9600); // Start the serial communication with the DFPlayerMini at speed 9600 baud



  lc.shutdown(0, false); // Wake up the MAX7219 from power-saving mode
  lc.setIntensity(0, 1); // Set brightness level (0 is min, 15 is max)
  lc.clearDisplay(0); // Clear the display (turn off all LEDs)
  lc.shutdown(1, false); // Wake up the MAX7219 from power-saving mode
  lc.setIntensity(1, 1); // Set brightness level (0 is min, 15 is max)
  lc.clearDisplay(1); // Clear the display (turn off all LEDs)
  


  // Start communication with DFPlayer Mini
  if (player.begin(Serial2)) 
  {
    Serial.println("OK");
    player.volume(15); // Set volume to maximum (0 to 30)
    player.playMp3Folder(3); // Play the "0003.mp3" in the "mp3" folder on the SD card
  } 
  else 
  {
    Serial.println("Connecting to DFPlayer Mini failed!");
  }



  // Set motor control pins as output
  pinMode(ENA, OUTPUT);
  pinMode(IN1, OUTPUT);
  pinMode(IN2, OUTPUT);
  pinMode(IN3, OUTPUT);
  pinMode(IN4, OUTPUT);
  pinMode(ENB, OUTPUT);
  // Set speed using PWM (0-255)
  analogWrite(ENA, 255);  // Full speed left motor
  analogWrite(ENB, 255);  // Full speed right motor



  pinMode(onboardLedPin, OUTPUT); // Set onboardLedPin as output
  pinMode(statePin, INPUT); // Set statePin as input // HIGH = connected to computer via bluetooth, LOW = not connected






  stopMotors(); // This is here just for good measure
  digitalWrite(onboardLedPin, LOW);

  delay(1000); // This is here just cus

  while (digitalRead(statePin) == LOW)
  {
    for (int i = 0; i < framesNumLoading; i++) 
    {
      drawFrame(LOADING[i]);
      delay(100); // 100ms wait time per frame
    }
  }

  drawFrame(SMILE[0]);

  player.playMp3Folder(4); //The bluetooth device is coneccted successfully

  bool stateRecieved = false;
  while (stateRecieved == false)///////////////////////////
  {
    if (Serial1.available()) // checks if the computer has sent anything to the arduino through the serialMonitor
    {
      command = Serial1.readStringUntil('\n'); //set the variable command to whatever was sent through the serialPort
      command.trim(); // removes unneccecary things from the message (\r, \n)

      if (command == "happy")
      {
        robotstate = "1"; //happy
        stateRecieved = true;
      }
    }
  }
}































void loop() 
{
  // put your main code here, to run repeatedly:
  
  
  checkForIR();

  checkForSerial1();
}































void doStateAction()
{
  if (robotstate == 1) // happy
  {
    stateHappy();
  }
  else if (robotstate == 2) // angry
  {
    stateAngry();
  }
  else if (robotstate == 3) // sad
  {
    stateSad();
  }
  else if (robotstate == 4) // sleepy
  {
    stateSleepy();
  }
  else if (robotstate == 5) // upsidedown
  {
    stateUpsidedown();
  }
  else if (robotstate == 6) // Curious
  {
    stateCurious();
  }
  else if (robotstate == 7) // upside down
  {
    stateIdle();
  } else 
  {
    stateIdle();
  }
}

void int randomNumber1to75()
{
  int randomNum = random(0, 75);
  return randomNum;
}

void int randomNumber1to50()
{
  int randomNum = random(0, 50);
  return randomNum;
}

void int randomNumber1to25()
{
  int randomNum = random(0, 25);
  return randomNum;
}

void stateHappy()
{
  drawFrame(SMILE[0]);

  if (randomNumber1to50() = 1)
  {
    // run forward full speed until obstacle detected
    motorSpeedFast();
    forwardUntilObstacle();

  } else if (randomNumber1to50() = 2)
  {
    // play happy sound ////////////////////////////////////////////////////////////////////////////////////////////
  
  } else if (randomNumber1to50() = 3)
  {
    // spin for 5 seconds at full speed
    motorSpeedFast();
    spinForDuration(5000);

  } else if (randomNumber1to50() = 4)
  {
    // go forward and backwards 5 times
    motorSpeedFast();
    for (int i = 0; i < 5; i++) // 5x loop
    {
      moveForward();
      delay(200);
      moveBackward();
      delay(200);
    }
    stopMotors();

  } else if (randomNumber1to50() = 5)
  {
    // turn left then right 5 times
    motorSpeedFast();
    for (int i = 0; i < 5; i++) // 5x loop
    {
      turnLeft();
      delay(200);
      turnRight();
      delay(200);
    }
    stopMotors();

  } else 
  {
    // do nothing
  }
}

void stateAngry()
{
  drawFrame(SMILE[0]);

  if (randomNumber1to100() = 1)
  {
    // keep on moving forward slowly for 30 seconds
    motorSpeedSlow();
    moveForward();
    delay(30000);
    stopMotors();

  } else if (randomNumber1to10() = 2)
  {
    // keep on moving backward slowly for 30 seconds
    motorSpeedSlow();
    moveBackward();
    delay(30000);
    stopMotors();
  } else if (randomNumber1to10() = 3)
  {
    // play angry sound///////////////////////////////////////////////////////////////////////////////////////////////////////////////

  } else if (randomNumber1to10() = 4)
  {
    // run forward until obstacle detected at full speed and play angry sound
    motorSpeedFast();
    forwardUntilObstacle();
    // play angry sound///////////////////////////////////////////////////////////////////////////////////////////////////////////////

  } else if (randomNumber1to10() = 6)
  {
    // turn left then right 5 times
    motorSpeedFast();
    for (int i = 0; i < 5; i++) // 5x loop
    {
      turnLeft();
      delay(200);
      turnRight();
      delay(200);
    }
    stopMotors();
  } else 
  {
    // do nothing
  }
}

void stateSad()
{

  drawFrame(SMILE[0]);


  // if obstacle detected is infront turn around
  motorSpeedSlow();
  forwardUntilObstacle();
  turnRight();
  delay(500); // turn for 500 milliseconds
  stopMotors();


  

  if (randomNumber1to25() = 1)
  {
    // play sad sound //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
  } else 
  {
    // do nothing
  }
}

void stateSleepy()
{
  // play sleeping animation and sound and sleep until upsidedown detected or ir remote input

  // play sleeping sound //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
  drawFrame(SMILE[0]);/////////////////////////////////////////////////////////////////////////////////////

  bool wokeUp = false;
  while (wokeUp == false)
  {
    checkForIR(); //////////////////////////////////////////////////////////////////////////
    if (digitalRead(tiltBallPin) == LOW) // if robot is upside down
    {
      wokeUp = true;
    }
  }
}

void stateUpsidedown()
{
  // play nausious animation and sound then fart and sleep until IR remote input and right way round

  // play upsidedown sound //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
  drawFrame(SMILE[0]);/////////////////////////////////////////////////////////////////////////////////////
  while (wokeUp == false)
  {
    checkForIR(); //////////////////////////////////////////////////////////////////////////
  }
}


void stateCurious()
{
  // go forward constantly and turn when obstacle detected
  motorSpeedNormal();
  forwardUntilObstacle();
  turnRight();
  delay(100); // turn for 100 milliseconds
  stopMotors();
}

void stateIdle()
{
  drawFrame(SMILE[0]);


  if (randomNumber1to100() = 1)
  {
    // keep on moving forward at a normal speed until obstacle detected then turn and repeat for 30 seconds
    // and play idle sound
    // play idle sound //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    motorSpeedNormal();
    forwardObstacleTurn(30000);

  } else if (randomNumber1to10() = 2)
  {
    // play idle sound //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

  } else if (randomNumber1to10() = 3)
  {
    // start spinning on the spot slowly for 30 seconds
    spinForDuration(30000);

  } else 
  {
    // do nothing
  }
}