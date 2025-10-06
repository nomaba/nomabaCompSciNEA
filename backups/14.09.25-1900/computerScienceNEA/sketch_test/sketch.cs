#include "IRremote.h"

String previousButtonPress = "null";
// Motor A (Left)
const int ENA = 2;//5
const int IN1 = 3;//4
const int IN2 = 4;//3

// Motor B (Right)
const int IN3 = 5;//2
const int IN4 = 6;//7
const int ENB = 7;//6

int receiver = 11; // Signal Pin of IR receiver to Arduino Digital Pin 11
/*-----( Declare objects )-----*/
IRrecv irrecv(receiver);     // create instance of 'irrecv'
decode_results results;      // create instance of 'decode_results'

const int ledPin = 13; //LED L on the arduino board

//
//
//

String command = "null";

//
//
//

void setup() 
{
  irrecv.enableIRIn(); // Activate the IR sensor

  Serial.begin(9600); // Start the serial communication with the computer at speed 9600 baud
  
  // Set motor control pins as output
  pinMode(ENA, OUTPUT);
  pinMode(IN1, OUTPUT);
  pinMode(IN2, OUTPUT);
  pinMode(IN3, OUTPUT);
  pinMode(IN4, OUTPUT);
  pinMode(ENB, OUTPUT);

  // Set ledPin as output
  pinMode(ledPin, OUTPUT);

  //
  //
  //

  // Set speed using PWM (0-255)
  analogWrite(ENA, 255);  // Full speed left motor
  analogWrite(ENB, 255);  // Full speed right motor

  stopMotors(); // This is here just to make sure

  digitalWrite(ledPin, LOW);

  //
  //
  //

  Serial.println("ready");

  delay(1000); // This is here just cus
}


//
//
//
//
//

void loop() 
{
  if (irrecv.decode(&results)) // have we received an IR signal?
  {
    translateIR(); 
    irrecv.resume(); // receive the next value
    delay(600);
  }
  else{
    //delay(50);
    stopMotors();
  }

  //
  //
  //

  if (Serial.available()) // checks if the computer has sent anything to the arduino through the serialMonitor
  {
    command = Serial.readStringUntil('\n'); //set the variable command to whatever was sent through the serialPort
    command.trim(); // removes unneccecary things from the message (\r, \n)

    //translateSerial();

    if (command == "1") 
    {
      Serial.println("poopoo");
      digitalWrite(ledPin, HIGH);
      
      digitalWrite(IN1, LOW);
      digitalWrite(IN2, HIGH);
      digitalWrite(IN3, LOW);
      digitalWrite(IN4, HIGH);


      delay(1000);

    } else if (command == "0") 
    {
      Serial.println("VOL+");
      digitalWrite(ledPin, LOW);
      moveBackward();
    }
  } else
  {
    delay(500); //millis(); might be a better alternative because the arduino can check for things sent in the serial port while it waits [ask GPT for the difference between delay and millis]
    //The arduino might miss the data sent from the computer if delay is used
  }
}


//
//
//
//
//

void translateSerial()
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

//
//
//
//
//

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


//
//
//
//
//
//

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