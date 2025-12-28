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