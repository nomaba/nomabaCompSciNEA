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
int robotstate = 0; // 0 = idle, 1 = happy, 2 = sad

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


// MAX7219 LED Dot Matrix Module
LedControl lc = LedControl(52, 48, 50, 2); // Created variable called ledMatrix that contains the location of the pins for the module // LedControl(DIN pin, CLK pin, CS pin, number of matrixes);)


// IR Receiver
int receiver = 46;
// Declare objects
IRrecv irrecv(receiver);     // create instance of 'irrecv'
decode_results results;      // create instance of 'decode_results'


// LEDs
const int onboardLedPin = 13; //LED L on the arduino board


// DFPlayer Mini MP3 Module
DFRobotDFPlayerMini player; // create the df player object


// SR04 Ultrasonic Distance Sensor Module
#define TRIG_PIN 42 //Ultrasonic Distance Sensor TRIG connected at PIN 42
#define ECHO_PIN 44 //Ultrasonic Distance Sensor ECHO connected at PIN 44
SR04 sr04 = SR04(ECHO_PIN, TRIG_PIN); // created variable called "sr04" that stores the location of the pins connected to the SR04 Ultrasonic Distance Sensor module
long distanceFront = 0; // variable that holds numbers of max size 4 bytes
void getDistanceFront()
{
    distanceFront = sr04.Distance();
}