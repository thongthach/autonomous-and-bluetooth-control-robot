#include "BluetoothSerial.h"
const int motor[3][2] = {{14,33},{21,18},{27,26}};



const int pot = 34;
BluetoothSerial SerialBT;
char incoming_char, incoming_c;
void setup() {

  
  for(int i=0; i< 3; i++){
    for(int n=0;n<2;n++){
      pinMode(motor[i][n], OUTPUT);
    }
  }
  pinMode(pot, INPUT);
  Serial.begin(115200);
  SerialBT.begin("ESP32");

}

void loop() {
  //digitalWrite(motor[0][0], HIGH);
  int pot_data = analogRead(pot);
  //WHEN THE AWSD MOVEMENT FROM THE UNITY SENDING TO THE ESP32 
  if(SerialBT.available()){
    incoming_char = SerialBT.read();
  }
  
  //FOR THE Serial
  //FOR FORWARD
  if(incoming_char == 'W')
  {
    for(int i=0; i< 3; i++)
    {
      
      digitalWrite(motor[i][0], HIGH);
      digitalWrite(motor[i][1], LOW);
    }
    //delay(2000);
  }
  
  //FOR BACKWARD
  if(incoming_char == 'S')
  {
    for(int i=0; i< 3; i++)
    {
      
      digitalWrite(motor[i][1], HIGH);
      digitalWrite(motor[i][0], LOW);
    }
    //delay(2000);
   
  }
  
  //FOR LEFT TURN
  if(incoming_char == 'A')
  {
    
      digitalWrite(motor[0][0], HIGH);
      digitalWrite(motor[1][0], HIGH);
      digitalWrite(motor[2][0], LOW);
    
    //delay(2000);
    
  }

  if(incoming_char == 'K')
  {
    
    for(int i=0; i< 3; i++)
    {
      
      digitalWrite(motor[i][1], LOW);
      digitalWrite(motor[i][0], LOW);
    }  
    
    //delay(2000);
    
  }
  
}
  


