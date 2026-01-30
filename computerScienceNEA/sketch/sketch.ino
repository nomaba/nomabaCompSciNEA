#include <DFRobotDFPlayerMini.h>

#include <DFRobotDFPlayerMini.h>
#include "IRremote.h"
#include "LedControl.h"
#include "SR04.h"

// //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// notes:
// * get a local version of dfrobotdfplayermini and ledControl
// * 
// 
// //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


// PIN variables and other variables and some code for components

String previousButtonPress = "null";
String command = "null";
bool soundSensorActive = true;
int robotState = 0; // 0 = idle, 1 = happy, 2 = sad
int lv = 50; // Relationship value received from computer application // 50 is the default value

// ///


// Motor Driver L298N
// Motor A (Left)
const int ENA = 53;
const int IN1 = 51;
const int IN2 = 49;
// Motor B (Right)
const int IN3 = 47;
const int IN4 = 45;
const int ENB = 43;


// HC-05 bluetooth module
// HIGH = Bluetooth connected and serial port active
const int statePin = 41;


const int infraredLeftPin  = 39;
const int infraredRightPin  = 37;

const int soundSensorPin  = 35;
bool checkSoundSensorForLoudSound()
{
  if (soundSensorActive == true)
  {
    if (digitalRead(soundSensorPin) == HIGH)
    {
      // loud sound detected
      robotState = 7; // set robot state to scared
      changeLVByValue(-5); // decrease LV by 5
      return true; // there was a loud sound
    }
    else
    {
      // no loud sound detected
      // do nothing
      return false; // there was no loud sound
    }
  }
  return false;
}

const int tiltBallPin  = 40;
bool upsideDown()
{
  if (digitalRead(tiltBallPin) == HIGH)
  {
    // The robot is upright
    // do nothing
    return false;
  }
  else
  {
    // The robot is upside down
    return true;
  }
}
void checkTiltBall()
{
  if (digitalRead(tiltBallPin) == HIGH)
  {
    // The robot is upright
    // do nothing
  }
  else
  {
    // The robot is upside down
    robotState = 5; // set robot state to upside down
    changeLVByValue(-5); // decrease LV by 5
  }
}

bool isRobotUpsideDown()
{
  if (digitalRead(tiltBallPin) == HIGH)
  {
    //the robot is upright
    return false;
  }
  else
  {
    // the robot is upside down
    return true;
  }
}


// MAX7219 LED Dot Matrix Module
LedControl lc = LedControl(52, 48, 50, 2); // Created variable called ledMatrix that contains the location of the pins for the module // LedControl(DIN pin, CLK pin, CS pin, number of matrixes);)


// IR Receiver
const int receiver = 46;
// Declare objects
IRrecv irrecv(receiver);     // create instance of 'irrecv'
decode_results results;      // create instance of 'decode_results'


// LEDs and beeper
const int beeperPin = 13; //beeper and LED L on the arduino board
bool isBeeperOn = false;


// DFPlayer Mini MP3 Module
DFRobotDFPlayerMini player; // create the df player object


// SR04 Ultrasonic Distance Sensor Module
#define TRIG_PIN 42 //Ultrasonic Distance Sensor TRIG connected at PIN 42
#define ECHO_PIN 44 //Ultrasonic Distance Sensor ECHO connected at PIN 44
SR04 sr04 = SR04(ECHO_PIN, TRIG_PIN); // created variable called "sr04" that stores the location of the pins connected to the SR04 Ultrasonic Distance Sensor module

long getDistanceFront()
{
  return sr04.Distance();
}

const int motionSensorPin = 38; // PIR Motion Sensor connected at PIN 38
bool motionDetected()
{
  if (digitalRead(motionSensorPin) == HIGH)
  {
    return true;
  }
  else
  {
    return false;
  }
}


// config
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// screen stuff




// Frames for the MAX7219 LED Dot Matrix Module
// Stored in consts so that the frames can be stored in FLASH memory instead of the SRAM memory 

const uint8_t LOADING[][8] = {
{
  0b11111100,0b11111100,0b00000000,0b00000000,0b00000000,0b00000000,0b00000000,0b00000000
},{
  0b00111111,0b00111111,0b00000000,0b00000000,0b00000000,0b00000000,0b00000000,0b00000000
},{
  0b00001111,0b00001111,0b00000011,0b00000011,0b00000000,0b00000000,0b00000000,0b00000000
},{
  0b00000011,0b00000011,0b00000011,0b00000011,0b00000011,0b00000011,0b00000000,0b00000000
},{
  0b00000000,0b00000000,0b00000011,0b00000011,0b00000011,0b00000011,0b00000011,0b00000011
},{
  0b00000000,0b00000000,0b00000000,0b00000000,0b00000011,0b00000011,0b00001111,0b00001111
},{
  0b00000000,0b00000000,0b00000000,0b00000000,0b00000011,0b00000011,0b00111111,0b00111111
},{
  0b00000000,0b00000000,0b00000000,0b00000000,0b00000000,0b00000000,0b11111100,0b11111100
},{
  0b00000000,0b00000000,0b00000000,0b00000000,0b11000000,0b11000000,0b11110000,0b11110000
},{
  0b00000000,0b00000000,0b11000000,0b11000000,0b11000000,0b11000000,0b11000000,0b11000000
},{
  0b11000000,0b11000000,0b11000000,0b11000000,0b11000000,0b11000000,0b00000000,0b00000000
},{
  0b11110000,0b11110000,0b11000000,0b11000000,0b00000000,0b00000000,0b00000000,0b00000000
}};
const int framesNumLoading = sizeof(LOADING) / sizeof(LOADING[0]);

//
//
//

const uint8_t SMILE[][8] = {
{
  0b00000000,
  0b00110100,
  0b00110010,
  0b00000010,
  0b00000010,
  0b00110010,
  0b00110100,
  0b00000000
}};
const int SMILE_LENGTH = sizeof(SMILE)/8;

const uint8_t SAD[][8] = {
{
  0b00000000,
  0b00110010,
  0b00110100,
  0b00000100,
  0b00000100,
  0b00110100,
  0b00110010,
  0b00000000
}};
const int SAD_LENGTH = sizeof(SAD)/8;

const uint8_t ANGRY[][8] = {
{
  0b00000000,
  0b10011001,
  0b01011010,
  0b00000010,
  0b00000010,
  0b01011010,
  0b10011001,
  0b00000000
}};
const int ANGRY_LENGTH = sizeof(ANGRY)/8;

const uint8_t CURIOUS[][8] = {
{
  0b00000000,
  0b01011000,
  0b01011001,
  0b00000001,
  0b00000001,
  0b10011001,
  0b10011000,
  0b00000000
}};
const int CURIOUS_LENGTH = sizeof(CURIOUS)/8;

const uint8_t SCARED[][8] = {
{
  0b00100000,
  0b01011001,
  0b10011010,
  0b00000010,
  0b00000010,
  0b10011010,
  0b01011001,
  0b00100000
}};
const int SCARED_LENGTH = sizeof(SCARED)/8;

const uint8_t IDLE[][8] = {
{
  0b00000000,
  0b00110010,
  0b00110010,
  0b00000010,
  0b00000010,
  0b00110010,
  0b00110010,
  0b00000000
}};
const int IDLE_LENGTH = sizeof(IDLE)/8;

const uint8_t DICEONE[][8] = {
{
  0b00000000,
  0b00000000,
  0b00000000,
  0b00011000,
  0b00011000,
  0b00000000,
  0b00000000,
  0b00000000
}};
const int DICEONE_LENGTH = sizeof(DICEONE)/8;

const uint8_t DICETWO[][8] = {
{
  0b11000000,
  0b11000000,
  0b00000000,
  0b00000000,
  0b00000000,
  0b00000000,
  0b00000011,
  0b00000011
}};
const int DICETWO_LENGTH = sizeof(DICETWO)/8;

const uint8_t DICETHREE[][8] = {
{
  0b11000000,
  0b11000000,
  0b00000000,
  0b00011000,
  0b00011000,
  0b00000000,
  0b00000011,
  0b00000011
}};
const int DICETHREE_LENGTH = sizeof(DICETHREE)/8;

const uint8_t DICEFOUR[][8] = {
{
  0b11000011,
  0b11000011,
  0b00000000,
  0b00000000,
  0b00000000,
  0b00000000,
  0b11000011,
  0b11000011
}};
const int DICEFOUR_LENGTH = sizeof(DICEFOUR)/8;

const uint8_t DICEFIVE[][8] = {
{
  0b11000011,
  0b11000011,
  0b00000000,
  0b00011000,
  0b00011000,
  0b00000000,
  0b11000011,
  0b11000011
}};
const int DICEFIVE_LENGTH = sizeof(DICEFIVE)/8;

const uint8_t DICESIX[][8] = {
{
  0b11011011,
  0b11011011,
  0b00000000,
  0b00000000,
  0b00000000,
  0b00000000,
  0b11011011,
  0b11011011
}};
const int DICESIX_LENGTH = sizeof(DICESIX)/8;

const uint8_t LOADING2[][8] = {
{
  0b00000000,
  0b00000000,
  0b01100110,
  0b01011010,
  0b01011010,
  0b01100110,
  0b00000000,
  0b00000000
}};
const int LOADING2_LENGTH = sizeof(LOADING2)/8;

const uint8_t ARROWRIGHT[][8] = {
{
  0b00000000,
  0b00011000,
  0b00011000,
  0b01011010,
  0b01111110,
  0b00111100,
  0b00011000,
  0b00000000
}};
const int ARROWRIGHT_LENGTH = sizeof(ARROWRIGHT)/8;

const uint8_t GUN[][8] = {
{
  0b00000000,
  0b00111100,
  0b00111100,
  0b00111000,
  0b00110000,
  0b00110000,
  0b00110000,
  0b00000000
}};
const int GUN_LENGTH = sizeof(GUN)/8;

const uint8_t GUNSHOT[][8] = {
{ 
  0b11111111, 0b11111111, 0b11111111, 0b11111111, 0b11111111, 0b11111111, 0b11111111, 0b11111111 
},{ 
  0b00000000, 0b00000000, 0b00000000, 0b00000000, 0b00000000, 0b00000000, 0b00000000, 0b00000000 
},{ 
  0b11111111, 0b11111111, 0b11111111, 0b11111111, 0b11111111, 0b11111111, 0b11111111, 0b11111111 
},{ 
  0b00000000, 0b00000000, 0b00000000, 0b00000000, 0b00000000, 0b00000000, 0b00000000, 0b00000000 
},{ 
  0b11111111, 0b11111111, 0b11111111, 0b11111111, 0b11111111, 0b11111111, 0b11111111, 0b11111111 
},{ 
  0b00000000, 0b00000000, 0b00000000, 0b00000000, 0b00000000, 0b00000000, 0b00000000, 0b00000000 
},{ 
  0b11111111, 0b11111111, 0b11111111, 0b11111111, 0b11111111, 0b11111111, 0b11111111, 0b11111111 
},{ 
  0b00000000, 0b00000000, 0b00000000, 0b00000000, 0b00000000, 0b00000000, 0b00000000, 0b00000000 
}};
const int GUNSHOT_LENGTH = sizeof(GUNSHOT) / 8;

const uint8_t BLANK[][8] = {
{
  0b11111111, 0b10000001, 0b10000001, 0b10000001, 0b10000001, 0b10000001, 0b10000001, 0b11111111
},{
  0b00000000, 0b00000000, 0b00000000, 0b00000000, 0b00000000, 0b00000000, 0b00000000, 0b00000000
}};
const int BLANK_LENGTH = sizeof(BLANK)/8;



const uint8_t bluetoothLogo[][8] = {
{
  0b00000000,
  0b00100100,
  0b01011010,
  0b11111111,
  0b00011000,
  0b00100100,
  0b00000000,
  0b00000000
}};
const int frameNumbluetoothLogo = sizeof(bluetoothLogo)/8;


//
//
//


// ////////////////////////////////////////////////////////////////////////////////////////////
// ////////////////////////////////////////////////////////////////////////////////////////////
// ////////////////////////////////////////////////////////////////////////////////////////////
// ////////////////////////////////////////////////////////////////////////////////////////////
// ////////////////////////////////////////////////////////////////////////////////////////////

void drawFrame(const uint8_t frame[8]) // draws frame on both matrices
{
  for (int row = 0; row < 8; row++) 
  {
    lc.setRow(0, row, frame[row]);
    lc.setRow(1, row, frame[row]);
  }
}


void drawFrameOnMatrix0(const uint8_t frame[8]) // draws frame on matrxix 0 only
{
  for (int row = 0; row < 8; row++) 
  {
    lc.setRow(0, row, frame[row]);
  }
}

void drawFrameOnMatrix1(const uint8_t frame[8]) // draws frame on both matrix 1 only
{
  for (int row = 0; row < 8; row++) 
  {
    lc.setRow(1, row, frame[row]);
  }
}

void emptyScreen() 
{
    for (int row = 0; row < 8; row++) 
    {
        lc.setRow(0, row, 0); //turn off every light in a row
        lc.setRow(1, row, 0);  
    }
}




// screen stuff
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// misc




unsigned long startTimecheckForSerial1 = millis();

void checkForSerial1()
{
  if ((millis() - startTimecheckForSerial1) > 1000) 
  {
    // this will play every 1 second
    startTimecheckForSerial1 = millis();


    if (Serial1.available()) // checks if the computer has sent anything to the arduino through the serialMonitor
    {
      command = Serial1.readStringUntil('\n'); //set the variable command to whatever was sent through the serialPort
      command.trim(); // removes unneccecary things from the message (\r, \n)

      translateSerial1();
    }
  } 
}

void translateSerial1()
{
  if (robotState == 14) // if robot is in instructions state (wait and listen to commands from computer)
  {
    if (command == "moveForward") 
    {
      moveForward();
      delay(500);
      stopMotors();
      changeLVByValue(1); // increase LV by 1
    } 
    else if (command == "moveBackward") 
    {
      moveBackward();
      delay(500);
      stopMotors();
      changeLVByValue(1); // increase LV by 1
    } 
    else if (command == "turnRight")
    {
      turnRight();
      delay(500);
      stopMotors();
      changeLVByValue(1); // increase LV by 1
    } 
    else if (command == "turnLeft")
    {
      turnLeft();
      delay(500);
      stopMotors();
      changeLVByValue(1); // increase LV by 1
    } 
    else if (command == "stopMotors")
    {
      stopMotors();
      changeLVByValue(-1); // decrease LV by 1
    } 
    else if (command == "forwardUntilObstacle")
    {
      forwardUntilObstacle();
      changeLVByValue(1); // increase LV by 1
    }
    else if (command.startsWith("spinForDuration Time: "))
    {
      // use string manipulation to get the time from the command
      String stringTime = command.substring(22);
      int intTime = stringTime.toInt();
      spinForDuration(intTime);
      changeLVByValue(1); // increase LV by 1
    }
    else if (command.startsWith("forwardObstacleTurn Time: "))
    {
      // use string manipulation to get the time from the command
      String stringTime = command.substring(26);
      int intTime = stringTime.toInt();
      forwardObstacleTurn(intTime);
      changeLVByValue(1); // increase LV by 1
    }
    else if (command == "motorSpeedSlow")
    {
      motorSpeedSlow();
      changeLVByValue(1); // increase LV by 1
    }
    else if (command == "motorSpeedNormal")
    {
      motorSpeedNormal();
      changeLVByValue(1); // increase LV by 1
    }
    else if (command == "motorSpeedFast")
    {
      motorSpeedFast();
      changeLVByValue(1); // increase LV by 1
    }
    else if (command.startsWith("playAudio: "))
    {
      // use string manipulation to get the audio track number from the command
      String stringTrackNum = command.substring(11);
      int intTrackNum = stringTrackNum.toInt();
      player.playMp3Folder(intTrackNum); // Play the specified track in the "mp3" folder on the SD card
    }
  }
  else if (robotState == 11) // Dice
  {
    if (command == "roll 1 dice")
    {
      player.playMp3Folder(22); // Play the "0022.mp3" in the "mp3" folder on the SD card // dice throw sound
      // matrix 1 display dice1 roll number

      for (int j = 0; j < LOADING2_LENGTH; j++)
      {
        drawFrame(LOADING2[j]);
      }
      changeLVByValue(1); // increase LV by 1

      int randomNum = randomNumber1to6();

      if (randomNum == 1)
      {
        for (int j = 0; j < DICEONE_LENGTH; j++)
        {
          drawFrameOnMatrix1(DICEONE[j]);
        }
      } 
      else if (randomNum == 2)
      {
        for (int j = 0; j < DICETWO_LENGTH; j++)
        {
          drawFrameOnMatrix1(DICETWO[j]);
        }
      }
      else if (randomNum == 3)
      {
        for (int j = 0; j < DICETHREE_LENGTH; j++)
        {
          drawFrameOnMatrix1(DICETHREE[j]);
        }
      }
      else if (randomNum == 4)
      {
        for (int j = 0; j < DICEFOUR_LENGTH; j++)
        {
          drawFrameOnMatrix1(DICEFOUR[j]);
        }
      }
      else if (randomNum == 5)
      {
        for (int j = 0; j < DICEFIVE_LENGTH; j++)
        {
          drawFrameOnMatrix1(DICEFIVE[j]);
        }
      }
      else if (randomNum == 6)
      {
        for (int j = 0; j < DICESIX_LENGTH; j++)
        {
          drawFrameOnMatrix1(DICESIX[j]);
        }
      }


      for (int j = 0; j < ARROWRIGHT_LENGTH; j++)
      {
        drawFrameOnMatrix0(ARROWRIGHT[j]);
      }
      
    }
    else if (command == "roll 2 dice")
    {
      player.playMp3Folder(22); // Play the "0022.mp3" in the "mp3" folder on the SD card // dice throw sound
      // matrix 1 display dice1 roll number
      // matrix 2 display dice2 roll number 


      for (int j = 0; j < LOADING2_LENGTH; j++)
      {
        drawFrame(LOADING2[j]);
      }
      changeLVByValue(1); // increase LV by 1

      int randomNum1 = randomNumber1to6();
      delay(1000);
      int randomNum2 = randomNumber1to6();
      

      if (randomNum1 == 1)
      {
        for (int j = 0; j < DICEONE_LENGTH; j++)
        {
          drawFrameOnMatrix1(DICEONE[j]);
        }
      } 
      else if (randomNum1 == 2)
      {
        for (int j = 0; j < DICETWO_LENGTH; j++)
        {
          drawFrameOnMatrix1(DICETWO[j]);
        }
      }
      else if (randomNum1 == 3)
      {
        for (int j = 0; j < DICETHREE_LENGTH; j++)
        {
          drawFrameOnMatrix1(DICETHREE[j]);
        }
      }
      else if (randomNum1 == 4)
      {
        for (int j = 0; j < DICEFOUR_LENGTH; j++)
        {
          drawFrameOnMatrix1(DICEFOUR[j]);
        }
      }
      else if (randomNum1 == 5)
      {
        for (int j = 0; j < DICEFIVE_LENGTH; j++)
        {
          drawFrameOnMatrix1(DICEFIVE[j]);
        }
      }
      else if (randomNum1 == 6)
      {
        for (int j = 0; j < DICESIX_LENGTH; j++)
        {
          drawFrameOnMatrix1(DICESIX[j]);
        }
      }






      if (randomNum2 == 1)
      {
        for (int j = 0; j < DICEONE_LENGTH; j++)
        {
          drawFrameOnMatrix0(DICEONE[j]);
        }
      } 
      else if (randomNum2 == 2)
      {
        for (int j = 0; j < DICETWO_LENGTH; j++)
        {
          drawFrameOnMatrix0(DICETWO[j]);
        }
      }
      else if (randomNum2 == 3)
      {
        for (int j = 0; j < DICETHREE_LENGTH; j++)
        {
          drawFrameOnMatrix0(DICETHREE[j]);
        }
      }
      else if (randomNum2 == 4)
      {
        for (int j = 0; j < DICEFOUR_LENGTH; j++)
        {
          drawFrameOnMatrix0(DICEFOUR[j]);
        }
      }
      else if (randomNum2 == 5)
      {
        for (int j = 0; j < DICEFIVE_LENGTH; j++)
        {
          drawFrameOnMatrix0(DICEFIVE[j]);
        }
      }
      else if (randomNum2 == 6)
      {
        for (int j = 0; j < DICESIX_LENGTH; j++)
        {
          drawFrameOnMatrix0(DICESIX[j]);
        }
      }
    }
  }
  else if (robotState == 12) // RR
  {
    // run a random number from 1-6 
    // if the number lands on 1 then shoot and move backwards tiny bit as recoil

    if (command == "shootRR")
    {
      changeLVByValue(1); // increase LV by 1
      int randomNum = randomNumber1to6();
      if (randomNum == 1)
      {
        player.playMp3Folder(18); // Play the "0018.mp3" in the "mp3" folder on the SD card // gun shot sound
        delay(100);
        for (int j = 0; j < GUNSHOT_LENGTH; j++)
        {
          drawFrame(GUNSHOT[j]);

          delay(100); // 100ms wait time per frame
        }
        Serial1.println("RRLive");
      }
      else 
      {
        player.playMp3Folder(19); // Play the "0019.mp3" in the "mp3" folder on the SD card // empty gun shot sound
        delay(100);
        for (int i = 0; i < BLANK_LENGTH; i++) 
        {
          drawFrameOnMatrix0(BLANK[i]);
          
          delay(1000); // 1000ms wait time per frame
        }
        Serial1.println("RRBlank");
      }
    }
  }
  else if (robotState == 13) // Bowling
  {
    if (command == "rollTheBall")
    {
      changeLVByValue(1); // increase LV by 1
      bool timerComplete = false;
      bool objectHit = false;
      unsigned long timerBowling = millis();
      moveForward();
      while (timerComplete == false)
      {
        if (millis() - timerBowling >= 3000) 
        {
          // 3 seconds have passed
          timerComplete = true;
          
        }
        if (getDistanceFront() < 7 || digitalRead(infraredLeftPin) == LOW || digitalRead(infraredRightPin) == LOW)
        {
          objectHit = true;
        }
      }
      if (objectHit == true)
      {
        stopMotors();
        Serial1.println("object hit");
        player.playMp3Folder(21); // Play the "0021.mp3" in the "mp3" folder on the SD card // bowling pin strike sound
        delay(5000);
        player.playMp3Folder(20); // Play the "0020.mp3" in the "mp3" folder on the SD card // celebration sound
      } else 
      {
        Serial1.println("object not hit");
        player.playMp3Folder(10); // Play the "0021.mp3" in the "mp3" folder on the SD card // bowling pin strike sound
      }
      stopMotors();
    }
  }


  if (command.startsWith("robotState: "))
  {
    // use string manipulation to get the robotState from the command
    String robotStateString = command.substring(12);
    robotState = robotStateString.toInt();

    unsigned char i;
    for (i = 0; i < 60; i++)
    {
      digitalWrite(beeperPin, HIGH);
      delay(6);
      digitalWrite(beeperPin, LOW);
      delay(6);
    }
    delay(40);
    for (i = 0; i < 60; i++)
    {
      digitalWrite(beeperPin, HIGH);
      delay(5);
      digitalWrite(beeperPin, LOW);
      delay(5);
    }
  }

  if (command.startsWith("playAudio: "))
  {
    // use string manipulation to get the robotState from the command
    String stringAudioNum = command.substring(11);
    int intAudioNum = stringAudioNum.toInt();

    player.playMp3Folder(intAudioNum); // Play the specified track in the "mp3" folder on the SD card
  }

  if (command == "newHighScore")
  {
    player.playMp3Folder(20); // Play the "0020.mp3" in the "mp3" folder on the SD card // celebration sound
  }


}


unsigned long startTimecheckForIR = millis();


void checkForIR()
{
  if ((millis() - startTimecheckForIR) > 1000) 
  {
    // this will play every 1 second
    startTimecheckForIR = millis();

    if (irrecv.decode(&results)) // have we received an IR signal?
    {
      translateIR(); 
      irrecv.resume(); // receive the next value
      delay(600);
    }
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
}





// misc
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// LV


void setRobotStateViaLV()
{
  if (lv <= 0)
  {
    robotState = 7; // scared
  }
  else if (lv >= 1 && lv <= 19)
  {
    robotState = 2; // angry
  }
  else if (lv >= 20 && lv <= 39)
  {
    robotState = 3; // sad
  }
  else if (lv >= 40 && lv <= 59)
  {
    robotState = 10; // idle
  }
  else if (lv >= 60 && lv <= 79)
  {
    robotState = 1; // happy
  }
  else if (lv >= 80 && lv <= 99)
  {
    robotState = 9; // attached
  }
}

void changeLVByValue(int value)
{
  lv = lv + value;
  Serial1.println("UPDATE LV: " + lv);
}


// LV
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// movement




// The next few subroutines control the movement of the robot
void moveForward() {
  digitalWrite(IN1, LOW);
  digitalWrite(IN2, HIGH);
  digitalWrite(IN3, LOW);
  digitalWrite(IN4, HIGH);
}
void moveBackward() {
  digitalWrite(IN1, HIGH);
  digitalWrite(IN2, LOW);
  digitalWrite(IN3, HIGH);
  digitalWrite(IN4, LOW);
}
void turnLeft() {
  digitalWrite(IN1, LOW);
  digitalWrite(IN2, HIGH);
  digitalWrite(IN3, LOW);
  digitalWrite(IN4, LOW);
}
void turnRight() {
  digitalWrite(IN1, LOW);
  digitalWrite(IN2, LOW);
  digitalWrite(IN3, LOW);
  digitalWrite(IN4, HIGH);
}
void stopMotors() {
  digitalWrite(IN1, LOW);
  digitalWrite(IN2, LOW);
  digitalWrite(IN3, LOW);
  digitalWrite(IN4, LOW);
}
void strafeLeftSlow() 
{
  analogWrite(ENA, 100);  // Slow speed left motor
  analogWrite(ENB, 180);  // normal speed right motor
  moveForward();
}
void strafeRightSlow() 
{
  analogWrite(ENA, 180);  // normal speed left motor
  analogWrite(ENB, 100);  // Slow speed right motor
  moveForward();
}




void motorSpin()
{
  digitalWrite(IN1, HIGH);
  digitalWrite(IN2, LOW);
  digitalWrite(IN3, LOW);
  digitalWrite(IN4, HIGH);
}

void motorSpeedSlow()
{
  analogWrite(ENA, 130);  // Slow speed left motor
  analogWrite(ENB, 130);  // Slow speed right motor
}

void motorSpeedNormal()
{
  analogWrite(ENA, 180);  // Normal speed left motor
  analogWrite(ENB, 180);  // Normal speed right motor
}

void motorSpeedFast()
{
  analogWrite(ENA, 255);  // Fast speed left motor
  analogWrite(ENB, 255);  // Fast speed right motor
}















// millis() is a function that returns the number of milliseconds since the arduino powered on


// run forward until obstacle detected then turn and repeat for time specified by duration
void forwardObstacleTurn(unsigned long duration)
{
  unsigned long startTime = millis(); // what is the value of millis() when the subroutine starts

  while ((millis() - startTime) < duration)
  {
    moveForward();

    if (getDistanceFront() < 15) // obstacle within 15 cm
    {
      turnRight();
      delay(100); // turn for 500 milliseconds
    }
  }

  stopMotors(); // stop after duration
}


// run forward until obstacle detected 
void forwardUntilObstacle()
{
  while (getDistanceFront() > 15)
  {
    moveForward();
  }
  stopMotors(); // stop after obstacle detected
}


// run forward until obstacle detected then turn and repeat for time specified by duration
void spinForDuration(unsigned long duration)
{
  unsigned long startTime = millis(); // what is the value of millis() when the subroutine starts

  while ((millis() - startTime) < duration)
  {
    motorSpin();
  }

  stopMotors(); // stop after duration
}

// movement
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// Random number generators

int randomNumber1to5()
{
  return random(1, 6);   // 1–5
}

int randomNumber1to6()
{
  return random(1, 7);   // 1–6
}

int randomNumber1to2()
{
  return random(1, 3);   // 1–2
}

int randomNumber1to3()
{
  return random(1, 4);   // 1–3
}


// Random number generators
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// main




void setup()
{
  // put your setup code here, to run once:
  delay(2000); // This is here so that all the components have time to start up properly
  

  pinMode(beeperPin, OUTPUT); // Set beeperPin as output
  pinMode(statePin, INPUT); // Set statePin as input // HIGH = connected to computer via bluetooth, LOW = not connected
  pinMode(tiltBallPin, INPUT); // Set tiltBallPin as input
  pinMode(infraredLeftPin, INPUT); // Set infraredLeftPin as input
  pinMode(infraredRightPin, INPUT); // Set infraredRightPin as input
  pinMode(soundSensorPin, INPUT); // Set loudSoundSensorPin as input
  pinMode(motionSensorPin, INPUT); // Set motionSensorPin as input


  randomSeed(analogRead(A0));



  irrecv.enableIRIn(); // Activate the IR sensor



  Serial.begin(9600); // Start the serial communication with the computer (if plugged in) at speed 9600 baud
  Serial1.begin(9600); // Start the serial communication with the HC-05 Module at speed 9600 baud
  Serial2.begin(9600); // Start the serial communication with the DFPlayerMini at speed 9600 baud


  lc.shutdown(0, false); // Wake up the MAX7219 from power-saving mode
  lc.setIntensity(0, 0); // Set brightness level (0 is min, 15 is max)
  lc.clearDisplay(0); // Clear the display (turn off all LEDs)
  lc.shutdown(1, false); // Wake up the MAX7219 from power-saving mode
  lc.setIntensity(1, 0); // Set brightness level (0 is min, 15 is max)
  lc.clearDisplay(1); // Clear the display (turn off all LEDs)
  


  // Start communication with DFPlayer Mini
  if (player.begin(Serial2)) 
  {
    Serial.println("OK");
    player.volume(15); // Set volume to maximum (0 to 30)
    player.playMp3Folder(17); // Play the "0017.mp3" in the "mp3" folder on the SD card
  } 
  else 
  {
    Serial.println("Connecting to DFPlayer Mini failed!");

    bool error = true;
    while (error == true) // play an alarm sound (high pitch then low pitch and repeat)
    {
      unsigned char i; //counter
      while(1)
      {
        //output an frequency to the buzzer
        for(i=0;i<80;i++)
        {
          digitalWrite(beeperPin,HIGH);
          delay(1);
          digitalWrite(beeperPin,LOW);
          delay(1);
        }
        //output another frequency
        for(i=0;i<100;i++)
        {
          digitalWrite(beeperPin,HIGH);
          delay(2);
          digitalWrite(beeperPin,LOW);
          delay(2);
        }
      }
      //green text
    }
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










  stopMotors(); // This is here just for good measure
  digitalWrite(beeperPin, LOW);

  delay(1000); // This is here just cus


  unsigned long startTime2 = millis();
  while (digitalRead(statePin) == LOW)
  {
    for (int j = 0; j < frameNumbluetoothLogo; j++)
    {
      drawFrameOnMatrix1(bluetoothLogo[j]);
    }
    
    for (int i = 0; i < framesNumLoading; i++) 
    {
      drawFrameOnMatrix0(LOADING[i]);
      
      delay(100); // 100ms wait time per frame
    }

    if ((millis() - startTime2) > 10000) 
    {
      startTime2 = millis();

      player.playMp3Folder(17); // Play the "0017.mp3" in the "mp3" folder on the SD card
    }
  }



  lc.clearDisplay(1);
  lc.clearDisplay(0);



  unsigned char j;
  for (j = 0; j < 40; j++)
  {
    digitalWrite(beeperPin, HIGH);
    delay(6);
    digitalWrite(beeperPin, LOW);
    delay(6);
  }
  delay(40);
  for (j = 0; j < 50; j++)
  {
    digitalWrite(beeperPin, HIGH);
    delay(5);
    digitalWrite(beeperPin, LOW);
    delay(5);
  }
  delay(40);
  for (j = 0; j < 80; j++)
  {
    digitalWrite(beeperPin, HIGH);
    delay(4);
    digitalWrite(beeperPin, LOW);
    delay(4);
  }













  bool robotStateRecieved = false;
  bool LVRecieved = false;
  unsigned long startTime = millis() - 11000; // set to more than 10 seconds ago so that the sound plays immediately
  while (robotStateRecieved == false || LVRecieved == false)
  {
    if (isBeeperOn && millis() - startTime >= 1000)
    {
      digitalWrite(beeperPin, LOW);   // turn OFF after 1s
      isBeeperOn = false;
      startTime = millis();
    }
    else if (!isBeeperOn && millis() - startTime >= 5000)
    {
      digitalWrite(beeperPin, HIGH);  // turn ON after 5s
      isBeeperOn = true;
      startTime = millis();
    }

    if (Serial1.available()) // checks if the computer has sent anything to the arduino through the serialMonitor
    {
      command = Serial1.readStringUntil('\n'); //set the variable command to whatever was sent through the serialPort
      command.trim(); // removes unneccecary things from the message (\r, \n)

      if (command.startsWith("robotState: "))
      {
        // use string manipulation to get the robotState from the command
        String robotStateString = command.substring(12);
        robotState = robotStateString.toInt();

        Serial1.println(robotState);

        robotStateRecieved = true;
      } else if (command.startsWith("LV: "))
      {
        // use string manipulation to get the LV from the command
        String lvString = command.substring(4);
        lv = lvString.toInt(); 

        LVRecieved = true;
      }      
    }
  }




  unsigned char i;
  for (i = 0; i < 60; i++)
  {
    digitalWrite(beeperPin, HIGH);
    delay(6);
    digitalWrite(beeperPin, LOW);
    delay(6);
  }
  delay(40);
  for (i = 0; i < 60; i++)
  {
    digitalWrite(beeperPin, HIGH);
    delay(5);
    digitalWrite(beeperPin, LOW);
    delay(5);
  }
  delay(40);
  for (i = 0; i < 80; i++)
  {
    digitalWrite(beeperPin, HIGH);
    delay(4);
    digitalWrite(beeperPin, LOW);
    delay(4);
  }

  digitalWrite(beeperPin, LOW);

  
}






























unsigned long fiveMinTimerStartTime = millis();
bool fiveMinTimerStarted = false;
bool stateActionPerformed = false;
unsigned long startTimeStateAction = millis();

int followCounter = 0;

int previousState = 0;

void loop() 
{
  

  // put your main code here, to run repeatedly:
  checkForIR();
  checkForSerial1();
  checkTiltBall();



  if (robotState == 14)
  {
    for (int j = 0; j < LOADING2_LENGTH; j++)
    {
      drawFrame(LOADING2[j]);
    }
  } 
  else if (robotState == 0) // state pending. to be recieved via LV
  {
    setRobotStateViaLV();
  }
  else if (robotState == 11) // dice
  {
    checkForSerial1();
  }
  else if (robotState == 12) // RR
  {
    checkForSerial1();
    for (int j = 0; j < GUN_LENGTH; j++)
    {
      drawFrame(GUN[j]);
    }
  }
  else if (robotState == 8) // follow state
  {
    robotStateFollow();

    if (followCounter >= 5)
    {
      changeLVByValue(1); // increase LV by 1
      followCounter = 0;
    }
    else
    {
      followCounter = followCounter + 1;
    }

  }

  if (robotState == 1 || robotState == 2 || robotState == 3 ||
      robotState == 4 || robotState == 5 || robotState == 6 ||
      robotState == 7 || robotState == 9 || robotState == 10)
  {

    if (checkSoundSensorForLoudSound() == true)
    {
      dorobotStateAction();
    }
    if (stateActionPerformed == false)
    {
      
      dorobotStateAction();
      
      stateActionPerformed = true;
    }
  }

  
  if ((millis() - startTimeStateAction) > 8000) 
  {
    stateActionPerformed = false;
    
  }

  
  stopMotors(); // This is here just for good measure


  robotStateUpsidedown();

  if (robotState == 1 || robotState == 2 || robotState == 3 ||
      robotState == 4 || robotState == 5 || robotState == 6 ||
      robotState == 7 || robotState == 9 || robotState == 10)
  {
    if (previousState != robotState)
    {
      previousState = robotState;
      fiveMinTimerStartTime = millis(); //start timer
      fiveMinTimerStarted = true;
    }
  }
  
  if ((millis() - fiveMinTimerStartTime >= 300000) && fiveMinTimerStarted == true)
  {
    // 5 minutes have passed

    robotStateSleepy();
  }

}































void dorobotStateAction()
{

  digitalWrite(beeperPin, HIGH);
  delay(100);
  digitalWrite(beeperPin, LOW);


  if (robotState == 1) // happy
  {
    robotStateHappy();
  }
  else if (robotState == 2) // angry
  {
    robotStateAngry();
  }
  else if (robotState == 3) // sad
  {
    robotStateSad();
  }
  else if (robotState == 4) // sleepy
  {
    robotStateSleepy();
  }
  else if (robotState == 5) // upsidedown
  {
    robotStateUpsidedown();
  }
  else if (robotState == 6) // Curious
  {
    robotStateCurious();
  }
  else if (robotState == 7) // scared
  {
    robotStateScared();
  }
  else if (robotState == 8) // Follow
  {
    robotStateFollow();
  }
  else if (robotState == 9) // attached
  {
    robotStateAttached();
  }
  else if (robotState == 10) // idle
  {
    robotStateIdle();
  } 
  else if (robotState == 11) // Dice
  {
    //Dice game
  }
  else if (robotState == 12) //RR 
  {
    //robotStateRR();
  }
  else if (robotState == 13) // Bowling
  {
    //robotStateBowling();
  }
  else if (robotState == 14) // instructions // for admin accounts and home page and car bot game
  {
    robotStateInstructions();
  } else 
  {
    robotStateInstructions();
  }
}




void robotStateHappy()
{
  for (int j = 0; j < SMILE_LENGTH; j++)
  {
    drawFrame(SMILE[j]);
  }

  int randomNum = randomNumber1to5();

  if (randomNum == 1)
  {
    // run forward full speed until obstacle detected
    player.playMp3Folder(14); // Play the "0014.mp3" in the "mp3" folder on the SD card // laugh
    motorSpeedFast();
    forwardUntilObstacle();
    Serial1.println("obstacle");

  } else if (randomNum == 2)
  {
    // play happy sound 
    player.playMp3Folder(7); // Play the "0007.mp3" in the "mp3" folder on the SD card // cheer

  } else if (randomNum == 3)
  {
    // spin for 5 seconds at full speed
    player.playMp3Folder(7); // Play the "0007.mp3" in the "mp3" folder on the SD card // cheer
    motorSpeedFast();
    spinForDuration(5000);
    Serial1.println("spin");

  } else if (randomNum == 4)
  {
    Serial1.println("FB");

    // go forward and backwards 5 times
    player.playMp3Folder(14); // Play the "0014.mp3" in the "mp3" folder on the SD card // laugh
    motorSpeedFast();
    for (int i = 0; i < 5; i++) // 5x loop
    {
      moveForward();
      delay(200);
      moveBackward();
      delay(200);
    } 

  } else if (randomNum == 5)
  {
    Serial1.println("LR");
    // turn left then right 5 times
    player.playMp3Folder(7); // Play the "0007.mp3" in the "mp3" folder on the SD card // cheer
    motorSpeedFast();
    for (int i = 0; i < 5; i++) // 5x loop
    {
      turnLeft();
      delay(200);
      turnRight();
      delay(200);
    }

  } else 
  {
    // do nothing
  }

  startTimeStateAction = millis();
}

void robotStateAngry()
{
  for (int j = 0; j < ANGRY_LENGTH; j++)
  {
    drawFrame(ANGRY[j]);
  }



  int randomNum = randomNumber1to5();

  
  if (randomNum == 1)
  {
    // keep on moving forward slowly for 30 seconds
    player.playMp3Folder(10); // Play the "0010.mp3" in the "mp3" folder on the SD card // angry
    motorSpeedSlow();
    moveForward();
    delay(30000);
    stopMotors();

  } else if (randomNum == 2)
  {
    // keep on moving backward slowly for 30 seconds
    player.playMp3Folder(10); // Play the "0010.mp3" in the "mp3" folder on the SD card // angry
    motorSpeedSlow();
    moveBackward();
    delay(30000);
    stopMotors();
  } else if (randomNum == 3)
  {
    // play angry sound
    player.playMp3Folder(10); // Play the "0010.mp3" in the "mp3" folder on the SD card // angry

  } else if (randomNum == 4)
  {
    // run forward until obstacle detected at full speed and play angry sound
    player.playMp3Folder(10); // Play the "0010.mp3" in the "mp3" folder on the SD card // angry
    motorSpeedFast();
    forwardUntilObstacle();

  } else if (randomNum == 5)
  {
    // turn left then right 5 times
    player.playMp3Folder(10); // Play the "0010.mp3" in the "mp3" folder on the SD card // angry
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

  startTimeStateAction = millis();
}

void robotStateSad()
{

  for (int j = 0; j < SAD_LENGTH; j++)
  {
    drawFrame(SAD[j]);
  }
  
  player.playMp3Folder(11); // Play the "0011.mp3" in the "mp3" folder on the SD card // cry


  // if obstacle detected is infront turn around
  motorSpeedSlow();
  forwardUntilObstacle();
  turnRight();
  delay(500); // turn for 500 milliseconds
  stopMotors();


  



  startTimeStateAction = millis();
}

void robotStateSleepy()
{
  // say im sleepy and then switch all screen LEDs off ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
  
  player.playMp3Folder(13); // Play the "0013.mp3" in the "mp3" folder on the SD card // faint
  emptyScreen(); 

  bool wokenUp = false;
  while (wokenUp == false)
  { 
    // if any button on the ir remote is pressed then wake up
    switch(results.value)
    {
      case 0xFFA25D:   wokenUp = true; break;
      case 0xFFE21D:   wokenUp = true; break;
      case 0xFF629D:   wokenUp = true; break;
      case 0xFF22DD:   wokenUp = true; break;
      case 0xFF02FD:   wokenUp = true; break;
      case 0xFFC23D:   wokenUp = true; break;
      case 0xFFE01F:   wokenUp = true; break;
      case 0xFFA857:   wokenUp = true; break;
      case 0xFF906F:   wokenUp = true; break;
      case 0xFF9867:   wokenUp = true; break;
      case 0xFFB04F:   wokenUp = true; break;
      case 0xFF6897:   wokenUp = true; break;
      case 0xFF30CF:   wokenUp = true; break;
      case 0xFF18E7:   wokenUp = true; break;
      case 0xFF7A85:   wokenUp = true; break;
      case 0xFF10EF:   wokenUp = true; break;
      case 0xFF38C7:   wokenUp = true; break;
      case 0xFF5AA5:   wokenUp = true; break;
      case 0xFF42BD:   wokenUp = true; break;
      case 0xFF4AB5:   wokenUp = true; break;
      case 0xFF52AD:   wokenUp = true; break;
      case 0xFFFFFFFF: wokenUp = true; break;  

      default: 
      wokenUp = true;
    }
  }

  setRobotStateViaLV(); // set robot state via LV again after waking up
  fiveMinTimerStartTime = millis(); // reset 5 min timer 
}

void robotStateUpsidedown()
{
  if (digitalRead(tiltBallPin) == LOW) // if the robot is upside down
  {
    // play nausious animation and sound then fart and sleep until IR remote input and right way round//////////////////////////////////////////////////////////////////

    player.playMp3Folder(15); // Play the "0015.mp3" in the "mp3" folder on the SD card // scream
    
    for (int j = 0; j < SCARED_LENGTH; j++)
    {
      drawFrame(SCARED[j]);
    }

    bool wokenUp = false;
    while (wokenUp == false && digitalRead(tiltBallPin) == LOW) // the robot is not upside down anymore and has been woken up by the ir remote
    { 
      // if any button on the ir remote is pressed then wake up
      switch(results.value)
      {
        case 0xFFA25D:   wokenUp = true; break;
        case 0xFFE21D:   wokenUp = true; break;
        case 0xFF629D:   wokenUp = true; break;
        case 0xFF22DD:   wokenUp = true; break;
        case 0xFF02FD:   wokenUp = true; break;
        case 0xFFC23D:   wokenUp = true; break;
        case 0xFFE01F:   wokenUp = true; break;
        case 0xFFA857:   wokenUp = true; break;
        case 0xFF906F:   wokenUp = true; break;
        case 0xFF9867:   wokenUp = true; break;
        case 0xFFB04F:   wokenUp = true; break;
        case 0xFF6897:   wokenUp = true; break;
        case 0xFF30CF:   wokenUp = true; break;
        case 0xFF18E7:   wokenUp = true; break;
        case 0xFF7A85:   wokenUp = true; break;
        case 0xFF10EF:   wokenUp = true; break;
        case 0xFF38C7:   wokenUp = true; break;
        case 0xFF5AA5:   wokenUp = true; break;
        case 0xFF42BD:   wokenUp = true; break;
        case 0xFF4AB5:   wokenUp = true; break;
        case 0xFF52AD:   wokenUp = true; break;
        case 0xFFFFFFFF: wokenUp = true; break;  

        default: 
        wokenUp = true;
      }
    }
    robotState = 0; // set robot state to pending so that it can be set via LV again
  } 

  
}


void robotStateCurious()
{
  for (int j = 0; j < CURIOUS_LENGTH; j++)
  {
    drawFrame(CURIOUS[j]);
  }

  // go forward constantly and turn when obstacle detected
  motorSpeedNormal();
  forwardUntilObstacle();
  turnRight();
  delay(100); // turn for 100 milliseconds
  stopMotors();
  startTimeStateAction = millis();
}

void robotStateIdle()
{
  for (int j = 0; j < IDLE_LENGTH; j++)
  {
    drawFrame(IDLE[j]);
  }


  int randomNum = randomNumber1to3();

  if (randomNum == 1)
  {
    // keep on moving forward at a normal speed until obstacle detected then turn and repeat for 30 seconds
    // and play idle sound
    // play idle sound //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    motorSpeedNormal();
    forwardObstacleTurn(30000);

  } else if (randomNum == 2)
  {
    // play idle sound //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

  } else if (randomNum == 3)
  {
    // start spinning on the spot slowly for 30 seconds
    spinForDuration(30000);

  } else 
  {
    // do nothing
  }
  startTimeStateAction = millis();
}

void robotStateScared()
{
  for (int j = 0; j < SCARED_LENGTH; j++)
  {
    drawFrame(SCARED[j]);
  }
  player.playMp3Folder(15); // Play the "0015.mp3" in the "mp3" folder on the SD card // scared
  motorSpeedSlow();
  moveForward();
  bool stopBeingScared = false;
  while (stopBeingScared == false)
  {
    if (isRobotUpsideDown() == true)
    {
      stopBeingScared = true;
    }
  }
  stopMotors();
  changeLVByValue(5); // increase LV by 5
  robotState = 0;
}


void robotStateAttached()
{
  if (motionDetected() == true)
  {
    moveForward();
    delay(1000); // move towards the object for 1 seconds
    stopMotors();
  } 
}

void robotStateFollow()
{

  for (int j = 0; j < CURIOUS_LENGTH; j++)
  {
    drawFrame(CURIOUS[j]);
  }
  // use ultrasonic sensor and infared sensors to follow object infront

  bool playGameFollow = true;
  motorSpeedSlow();
  unsigned long soundlastPlayTime = 0;
  const unsigned long soundplayInterval = 5000; // 5 seconds
  bool lastAudioPlayedIs12 = false;
  while (playGameFollow == true)
  {
    if (millis() - soundlastPlayTime >= soundplayInterval) 
    {
      if (lastAudioPlayedIs12 == false)
      {
        player.playMp3Folder(12); // Play the "0012.mp3" in the "mp3" folder on the SD card // evil laugh
        lastAudioPlayedIs12 = true;
      }
      else
      {
        player.playMp3Folder(9); // Play the "0009.mp3" in the "mp3" folder on the SD card // amazed
        lastAudioPlayedIs12 = false;
      }
    soundlastPlayTime = millis();
    }
    // read ultrasonic sensor and infared sensors
    if((digitalRead(infraredLeftPin) == LOW && digitalRead(infraredRightPin) == LOW) || (getDistanceFront() < 10))
    {
      // object is in the centre
      moveForward();
      delay(50);
    } else if (digitalRead(infraredLeftPin) == LOW && digitalRead(infraredRightPin) == HIGH)
    {
      // object is on the left
      turnLeft();
      delay(50);
    } else if (digitalRead(infraredLeftPin) == HIGH && digitalRead(infraredRightPin) == LOW)
    {
      // object is on the right
      turnRight();
      delay(50);
    } else 
    {
      // object is lost
      stopMotors();
    }
  }
}

void robotStateInstructions()
{
  //literally do nothing
}








