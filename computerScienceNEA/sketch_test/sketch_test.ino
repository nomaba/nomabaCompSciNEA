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
int robotState = 0; // 0 = idle, 1 = happy, 2 = sad
int lv = 50; // level of love received from computer application // 50 is the default value

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
void checkSoundSensor()
{
  if (digitalRead(soundSensorPin) == HIGH)
  {
    // loud sound detected
    robotState = 7; // set robot state to scared
  }
  else
  {
    // no loud sound detected
    // do nothing
  }
}

const int tiltBallPin  = 40;
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


// config
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// misc



void checkForSerial1()
{
  unsigned long startTime = millis();
  if ((millis() - startTime) > 1000) 
  {
    // this will play every 1 second
    startTime = millis();



    if (Serial1.available()) // checks if the computer has sent anything to the arduino through the serialMonitor
    {
      command = Serial1.readStringUntil('\n'); //set the variable command to whatever was sent through the serialPort
      command.trim(); // removes unneccecary things from the message (\r, \n)


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
    }
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
  unsigned long startTime = millis();
  if ((millis() - startTime) > 1000) 
  {
    // this will play every 1 second
    startTime = millis();

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
void strafeLeftSlow() 
{
  analogWrite(ENA, 100);  // Slow speed left motor
  analogWrite(ENB, 180);  // normal speed right motor
  moveForward();
}
void turnRight() {
  digitalWrite(IN1, LOW);
  digitalWrite(IN2, LOW);
  digitalWrite(IN3, LOW);
  digitalWrite(IN4, HIGH);
}
void strafeRightSlow() 
{
  analogWrite(ENA, 180);  // normal speed left motor
  analogWrite(ENB, 100);  // Slow speed right motor
  moveForward();
}
void stopMotors() {
  digitalWrite(IN1, LOW);
  digitalWrite(IN2, LOW);
  digitalWrite(IN3, LOW);
  digitalWrite(IN4, LOW);
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
  analogWrite(ENA, 100);  // Slow speed left motor
  analogWrite(ENB, 100);  // Slow speed right motor
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
  while (getDistanceFront() < 15)
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
  0b00000000,0b00000000,0b00100100,0b00100100,0b00000000,0b01000010,0b00111100,0b00000000
}};
const int frameNumSmile = sizeof(SMILE);

//
//
//

const uint8_t HAPPY[][8] = {
{
  0b01111110,0b11111111,0b11000011,0b10000001,0b10000001,0b10011001,0b11111111,0b01111110
}};
const int frameNumHappy = sizeof(HAPPY)/8;

const uint8_t HAPPYBLINK[][8] = {
{
  0b01111110,0b11111111,0b11000011,0b10000001,0b10000001,0b10011001,0b11111111,0b01111110
},{
  0b01111110,0b11111111,0b11000011,0b10000001,0b10000001,0b10011001,0b11111111,0b01111110
},{
  0b01111110,0b11111111,0b11111111,0b10000001,0b10000001,0b11111111,0b11111111,0b01111110
},{
  0b01111110,0b11111111,0b11111111,0b11111111,0b11111111,0b11111111,0b11111111,0b01111110
},{
  0b01111110,0b11111111,0b11111111,0b11111111,0b11111111,0b11111111,0b11111111,0b01111110
},{
  0b01111110,0b11111111,0b11111111,0b10000001,0b10000001,0b11111111,0b11111111,0b01111110
},{
  0b01111110,0b11111111,0b11000011,0b10000001,0b10000001,0b10011001,0b11111111,0b01111110
},{
  0b01111110,0b11111111,0b11000011,0b10000001,0b10000001,0b10011001,0b11111111,0b01111110
}};
const int frameNumHappyBlink = sizeof(HAPPYBLINK)/8;


//
//
//

const uint8_t SAD[][8] = {
{
  0b01111110,0b11111111,0b10011001,0b10000001,0b10000001,0b11000011,0b11111111,0b01111110
}};
const int frameNumSad = sizeof(SAD)/8;

const uint8_t SADBLINK[][8] = {
{
  0b01111110,0b11111111,0b10011001,0b10000001,0b10000001,0b11000011,0b11111111,0b01111110
},{
  0b01111110,0b11111111,0b10011001,0b10000001,0b10000001,0b11000011,0b11111111,0b01111110
},{
  0b01111110,0b11111111,0b11111111,0b10000001,0b10000001,0b11111111,0b11111111,0b01111110
},{
  0b01111110,0b11111111,0b11111111,0b11111111,0b11111111,0b11111111,0b11111111,0b01111110
},{
  0b01111110,0b11111111,0b11111111,0b11111111,0b11111111,0b11111111,0b11111111,0b01111110
},{
  0b01111110,0b11111111,0b10011001,0b10000001,0b10000001,0b11000011,0b11111111,0b01111110
},{
  0b01111110,0b11111111,0b10011001,0b10000001,0b10000001,0b11000011,0b11111111,0b01111110
},{
  0b01111110,0b11111111,0b10011001,0b10000001,0b10000001,0b11000011,0b11111111,0b01111110
}};
const int frameNumSadBlink = sizeof(SADBLINK)/8;


//
//
//

const uint8_t FACINGFORWARD[][8] = {
{
  0b00000000,0b00111100,0b01111110,0b01100110,0b01100110,0b01111110,0b00111100,0b00000000
}};
const int frameNumFacingForward = sizeof(FACINGFORWARD)/8;

const uint8_t FACINGFORWARDBLINK[][8] = {
{
  0b00000000,0b00111100,0b01111110,0b01100110,0b01100110,0b01111110,0b00111100,0b00000000
},{
  0b00000000,0b00000000,0b01111110,0b01100110,0b01100110,0b01111110,0b00000000,0b00000000
},{
  0b00000000,0b00000000,0b00000000,0b01100110,0b01100110,0b00000000,0b00000000,0b00000000
},{
  0b00000000,0b00000000,0b00000000,0b00000000,0b00000000,0b00000000,0b00000000,0b00000000
},{
  0b00000000,0b00000000,0b00000000,0b00000000,0b00000000,0b00000000,0b00000000,0b00000000
},{
  0b00000000,0b00000000,0b00000000,0b01100110,0b01100110,0b00000000,0b00000000,0b00000000
},{
  0b00000000,0b00000000,0b01111110,0b01100110,0b01100110,0b01111110,0b00000000,0b00000000
},{
  0b00000000,0b00111100,0b01111110,0b01100110,0b01100110,0b01111110,0b00111100,0b00000000
}};
const int frameNumFacingForwardBlink = sizeof(FACINGFORWARDBLINK)/8;


//
//
//

const uint8_t LOOKINGLEFT[][8] = {
{
  0b01111110,0b11111111,0b10011111,0b00001111,0b00001111,0b10011111,0b11111111,0b01111110
}};
const int frameNumLookingLeft = sizeof(LOOKINGLEFT)/8;

//
//
//

const uint8_t LOOKINGRIGHT[][8] = {
{
  0b01111110,0b11111111,0b11111001,0b11110000,0b11110000,0b11111001,0b11111111,0b01111110
}};
const int frameNumLookingRight = sizeof(LOOKINGRIGHT)/8;

//
//
//

const uint8_t SLEEPING[][8] = {
{
  0b00000000,0b00000000,0b00000000,0b00000000,0b00000000,0b00000000,0b00000000,0b00000000
}};
const int frameNumSleeping = sizeof(SLEEPING)/8;

const uint8_t GOINGTOSLEEP[][8] = {
{
  0b00000000,0b00111100,0b01111110,0b01100110,0b01100110,0b01111110,0b00111100,0b00000000
},{
  0b00000000,0b00111100,0b01111110,0b01100110,0b01100110,0b01111110,0b00111100,0b00000000
},{
  0b00000000,0b00111100,0b01111110,0b01100110,0b01100110,0b01111110,0b00111100,0b00000000
},{
  0b00000000,0b00000000,0b01111110,0b01100110,0b01100110,0b01111110,0b00000000,0b00000000
},{
  0b00000000,0b00000000,0b00000000,0b01100110,0b01100110,0b00000000,0b00000000,0b00000000
},{
  0b00000000,0b00000000,0b00000000,0b00000000,0b00000000,0b00000000,0b00000000,0b00000000
},{
  0b00000000,0b00000000,0b00000000,0b00000000,0b00000000,0b00000000,0b00000000,0b00000000
},{
  0b00000000,0b00000000,0b00000000,0b01100110,0b01100110,0b00000000,0b00000000,0b00000000
},{
  0b00000000,0b00000000,0b01111110,0b01100110,0b01100110,0b01111110,0b00000000,0b00000000
},{
  0b00000000,0b00111100,0b01111110,0b01100110,0b01100110,0b01111110,0b00111100,0b00000000
},{
  0b00000000,0b00111100,0b01111110,0b01100110,0b01100110,0b01111110,0b00111100,0b00000000
},{
  0b00000000,0b00111100,0b01111110,0b01100110,0b01100110,0b01111110,0b00111100,0b00000000
},{
  0b00000000,0b00000000,0b01111110,0b01100110,0b01100110,0b01111110,0b00000000,0b00000000
},{
  0b00000000,0b00000000,0b01111110,0b01100110,0b01100110,0b01111110,0b00000000,0b00000000
},{
  0b00000000,0b00000000,0b00000000,0b01100110,0b01100110,0b00000000,0b00000000,0b00000000
},{
  0b00000000,0b00000000,0b00000000,0b01100110,0b01100110,0b00000000,0b00000000,0b00000000
},{
  0b00000000,0b00000000,0b00000000,0b00000000,0b00000000,0b00000000,0b00000000,0b00000000
},{
  0b00000000,0b00000000,0b00000000,0b00000000,0b00000000,0b00000000,0b00000000,0b00000000
},{
  0b00000000,0b00000000,0b00000000,0b00000000,0b00000000,0b00000000,0b00000000,0b00000000
},{
  0b00000000,0b00000000,0b00000000,0b01100110,0b01100110,0b00000000,0b00000000,0b00000000
},{
  0b00000000,0b00000000,0b00000000,0b01100110,0b01100110,0b00000000,0b00000000,0b00000000
},{
  0b00000000,0b00000000,0b01111110,0b01100110,0b01100110,0b01111110,0b00000000,0b00000000
},{
  0b00000000,0b00000000,0b01111110,0b01100110,0b01100110,0b01111110,0b00000000,0b00000000
},{
  0b00000000,0b00111100,0b01111110,0b01100110,0b01100110,0b01111110,0b00111100,0b00000000
},{
  0b00000000,0b00111100,0b01111110,0b01100110,0b01100110,0b01111110,0b00111100,0b00000000
},{
  0b00000000,0b00111100,0b01111110,0b01100110,0b01100110,0b01111110,0b00111100,0b00000000
},{
  0b00000000,0b00111100,0b01111110,0b01100110,0b01100110,0b01111110,0b00111100,0b00000000
},{
  0b00000000,0b00111100,0b01111110,0b01100110,0b01100110,0b01111110,0b00111100,0b00000000
},{
  0b00000000,0b00000000,0b01111110,0b01100110,0b01100110,0b01111110,0b00000000,0b00000000
},{
  0b00000000,0b00000000,0b01111110,0b01100110,0b01100110,0b01111110,0b00000000,0b00000000
},{
  0b00000000,0b00000000,0b01111110,0b01100110,0b01100110,0b01111110,0b00000000,0b00000000
},{
  0b00000000,0b00000000,0b00000000,0b01100110,0b01100110,0b00000000,0b00000000,0b00000000
},{
  0b00000000,0b00000000,0b00000000,0b01100110,0b01100110,0b00000000,0b00000000,0b00000000
},{
  0b00000000,0b00000000,0b00000000,0b01100110,0b01100110,0b00000000,0b00000000,0b00000000
},{
  0b00000000,0b00000000,0b00000000,0b01100110,0b01100110,0b00000000,0b00000000,0b00000000
},{
  0b00000000,0b00000000,0b00000000,0b01100110,0b01100110,0b00000000,0b00000000,0b00000000
},{
  0b00000000,0b00000000,0b00000000,0b00000000,0b00000000,0b00000000,0b00000000,0b00000000
},{
  0b00000000,0b00000000,0b00000000,0b00000000,0b00000000,0b00000000,0b00000000,0b00000000
},{
  0b00000000,0b00000000,0b00000000,0b00000000,0b00000000,0b00000000,0b00000000,0b00000000
},{
  0b00000000,0b00000000,0b00000000,0b00000000,0b00000000,0b00000000,0b00000000,0b00000000
},{
  0b00000000,0b00000000,0b00000000,0b00000000,0b00000000,0b00000000,0b00000000,0b00000000
},{
  0b00000000,0b00000000,0b00000000,0b00000000,0b00000000,0b00000000,0b00000000,0b00000000
}};
const int frameNumGoingToSleep = sizeof(GOINGTOSLEEP)/8;


//
//
//


// ////////////////////////////////////////////////////////////////////////////////////////////
// ////////////////////////////////////////////////////////////////////////////////////////////
// ////////////////////////////////////////////////////////////////////////////////////////////
// ////////////////////////////////////////////////////////////////////////////////////////////
// ////////////////////////////////////////////////////////////////////////////////////////////

void drawFrame(const uint8_t frame[8]) {
  for (int row = 0; row < 8; row++) {
    lc.setRow(0, row, frame[row]);
    lc.setRow(1, row, frame[row]);
  }
}

// ////////////////////////////////////////////////////////////////////////////////////////////
// ////////////////////////////////////////////////////////////////////////////////////////////
// ////////////////////////////////////////////////////////////////////////////////////////////
// ////////////////////////////////////////////////////////////////////////////////////////////
// ////////////////////////////////////////////////////////////////////////////////////////////

// Facial expressions for the MAX7219 LED Dot Matrix Module

void matrixLoading() //done
{
  lc.clearDisplay(0); // Clear the display (turn off all LEDs)
  lc.clearDisplay(1); // Clear the display (turn off all LEDs)

  drawFrame(LOADING[8]);
}

void matrixHappyFace() //done
{
  lc.clearDisplay(0); // Clear the display (turn off all LEDs)
  lc.clearDisplay(1); // Clear the display (turn off all LEDs)

  drawFrame(SMILE[0]);
}

void matrixIdleFace() 
{
  lc.clearDisplay(0); // Clear the display (turn off all LEDs)
  lc.clearDisplay(1); // Clear the display (turn off all LEDs)

  drawFrame(SMILE[0]);
}

void matrixSadFace()
{
  lc.clearDisplay(0); // Clear the display (turn off all LEDs)
  lc.clearDisplay(1); // Clear the display (turn off all LEDs)

  drawFrame(SMILE[0]);
}

void matrixAngryFace()
{
  lc.clearDisplay(0); // Clear the display (turn off all LEDs)
  lc.clearDisplay(1); // Clear the display (turn off all LEDs)

  drawFrame(SMILE[0]);
}

void matrixBoredFace()
{
  lc.clearDisplay(0); // Clear the display (turn off all LEDs)
  lc.clearDisplay(1); // Clear the display (turn off all LEDs)

  drawFrame(SMILE[0]);
}

void matrixTiredFace()
{
  lc.clearDisplay(0); // Clear the display (turn off all LEDs)
  lc.clearDisplay(1); // Clear the display (turn off all LEDs)

  drawFrame(SMILE[0]);
}

void matrixLookingAroundFace()
{
  lc.clearDisplay(0); // Clear the display (turn off all LEDs)
  lc.clearDisplay(1); // Clear the display (turn off all LEDs)

  drawFrame(SMILE[0]);
}

void matrixLookingLeft()
{
  lc.clearDisplay(0); // Clear the display (turn off all LEDs)
  lc.clearDisplay(1); // Clear the display (turn off all LEDs)

  drawFrame(SMILE[0]);
}

void matrixLookingRight()
{
  lc.clearDisplay(0); // Clear the display (turn off all LEDs)
  lc.clearDisplay(1); // Clear the display (turn off all LEDs)

  drawFrame(SMILE[0]);
}

void matrixSleepingFace()
{
  lc.clearDisplay(0); // Clear the display (turn off all LEDs)
  lc.clearDisplay(1); // Clear the display (turn off all LEDs)

  drawFrame(SMILE[0]);
}






// screen stuff
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

















  bool robotStateRecieved = false;
  bool LVRecieved = false;
  unsigned long startTime = millis() - 11000; // set to more than 10 seconds ago so that the sound plays immediately
  while (robotStateRecieved == false || LVRecieved == false)
  {
    if ((millis() - startTime) > 1000) 
    {
      startTime = millis();

      if (isBeeperOn == false)
      {
        digitalWrite(beeperPin, HIGH); // turn beeper on
        isBeeperOn = true;
      } else 
      {
        digitalWrite(beeperPin, LOW); // turn beeper off
        isBeeperOn = false;
      }    
    }

    if (Serial1.available()) // checks if the computer has sent anything to the arduino through the serialMonitor
    {
      command = Serial1.readStringUntil('\n'); //set the variable command to whatever was sent through the serialPort
      command.trim(); // removes unneccecary things from the message (\r, \n)

      if (command.startsWith("robotState: "))
      {
        // use string manipulation to get the robotState from the command
        String robotStateString = command.substring(7);
        robotState = robotStateString.toInt();

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
    delay(4);
    digitalWrite(beeperPin, LOW);
    delay(4);
  }
  delay(40);
  for (i = 0; i < 60; i++)
  {
    digitalWrite(beeperPin, HIGH);
    delay(3);
    digitalWrite(beeperPin, LOW);
    delay(3);
  }
  delay(40);
  for (i = 0; i < 80; i++)
  {
    digitalWrite(beeperPin, HIGH);
    delay(2);
    digitalWrite(beeperPin, LOW);
    delay(2);
  }
}































void loop() 
{
  // put your main code here, to run repeatedly:
  

  checkForIR();
  checkForSerial1();

  checkTiltBall();



  dorobotStateAction();
}































void dorobotStateAction()
{
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
  else if (robotState == 8) // idle
  {
    robotStateIdle();
  } else 
  {
    robotStateIdle();
  }
}

int randomNumber1to75()
{
  int randomNum = random(0, 75);
  return randomNum;
}

int randomNumber1to50()
{
  int randomNum = random(0, 50);
  return randomNum;
}

int randomNumber1to25()
{
  int randomNum = random(0, 25);
  return randomNum;
}

void robotStateHappy()
{
  drawFrame(SMILE[0]);



  if (randomNumber1to50() == 1)
  {
    // run forward full speed until obstacle detected
    motorSpeedFast();
    forwardUntilObstacle();

      Serial1.println("obstacle");

  } else if (randomNumber1to50() == 2)
  {
    // play happy sound ////////////////////////////////////////////////////////////////////////////////////////////
      Serial1.println("happy sound");
  
  } else if (randomNumber1to50() == 3)
  {
    // spin for 5 seconds at full speed
    motorSpeedFast();
    spinForDuration(5000);

      Serial1.println("spin");

  } else if (randomNumber1to50() == 4)
  {
  Serial1.println("FB");

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

  } else if (randomNumber1to50() == 5)
  {

      Serial1.println("LR");
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

void robotStateAngry()
{
  drawFrame(SMILE[0]);

  if (randomNumber1to50() == 1)
  {
    // keep on moving forward slowly for 30 seconds
    motorSpeedSlow();
    moveForward();
    delay(30000);
    stopMotors();

  } else if (randomNumber1to50() == 2)
  {
    // keep on moving backward slowly for 30 seconds
    motorSpeedSlow();
    moveBackward();
    delay(30000);
    stopMotors();
  } else if (randomNumber1to50() == 3)
  {
    // play angry sound///////////////////////////////////////////////////////////////////////////////////////////////////////////////

  } else if (randomNumber1to50() == 4)
  {
    // run forward until obstacle detected at full speed and play angry sound
    motorSpeedFast();
    forwardUntilObstacle();
    // play angry sound///////////////////////////////////////////////////////////////////////////////////////////////////////////////

  } else if (randomNumber1to50() == 6)
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

void robotStateSad()
{

  drawFrame(SMILE[0]);


  // if obstacle detected is infront turn around
  motorSpeedSlow();
  forwardUntilObstacle();
  turnRight();
  delay(500); // turn for 500 milliseconds
  stopMotors();


  

  if (randomNumber1to25() == 1)
  {
    // play sad sound //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
  } else 
  {
    // do nothing
  }
}

void robotStateSleepy()
{
  // say im sleepy and then switch all screen LEDs off ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
  drawFrame(SMILE[0]);////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

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
}

void robotStateUpsidedown()
{
  if (digitalRead(tiltBallPin) == LOW) // if the robot is upside down
  {
    // play nausious animation and sound then fart and sleep until IR remote input and right way round//////////////////////////////////////////////////////////////////
    drawFrame(SMILE[0]);////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

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
  } else
  {
    player.stop();
  }
}


void robotStateCurious()
{
  // go forward constantly and turn when obstacle detected
  motorSpeedNormal();
  forwardUntilObstacle();
  turnRight();
  delay(100); // turn for 100 milliseconds
  stopMotors();
}

void robotStateIdle()
{
  drawFrame(SMILE[0]);


  if (randomNumber1to25() == 1)
  {
    // keep on moving forward at a normal speed until obstacle detected then turn and repeat for 30 seconds
    // and play idle sound
    // play idle sound //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    motorSpeedNormal();
    forwardObstacleTurn(30000);

  } else if (randomNumber1to25() == 2)
  {
    // play idle sound //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

  } else if (randomNumber1to25() == 3)
  {
    // start spinning on the spot slowly for 30 seconds
    spinForDuration(30000);

  } else 
  {
    // do nothing
  }
}

void robotStateScared()
{
  // play scared sound //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
  motorSpeedFast();
  moveBackward();
  delay(1000); // back away for 1 second
  stopMotors();
}

void robotStateFollow()
{
  // use ultrasonic sensor and infared sensors to follow object infront

  bool playGameFollow = true;
  while (playGameFollow == true)
  {
    motorSpeedSlow();
    // read ultrasonic sensor and infared sensors
    if        ((digitalRead(infraredLeftPin) == LOW && digitalRead(infraredRightPin) == LOW && getDistanceFront() < 10) || (digitalRead(infraredLeftPin) == HIGH && digitalRead(infraredRightPin) == HIGH && getDistanceFront() < 10))
    {
      // object is in the centre
      moveForward();
    } else if (digitalRead(infraredLeftPin) == LOW && digitalRead(infraredRightPin) == HIGH)
    {
      // object is on the left
      strafeLeftSlow(); 
    } else if (digitalRead(infraredLeftPin) == HIGH && digitalRead(infraredRightPin) == LOW)
    {
      // object is on the right
      strafeRightSlow(); 
    } else 
    {
      // object is lost
      stopMotors();
    }


  }
}