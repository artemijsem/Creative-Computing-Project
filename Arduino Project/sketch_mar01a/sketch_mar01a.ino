#include <Uduino.h>
#include "DHT.h"

// Name of the board
Uduino uduino("DeepDive");

// Defining digital pin for DHT sensor and it's model
#define DHTPIN 2
#define DHTTYPE DHT22
DHT dht(DHTPIN, DHTTYPE);

void setup() {
  Serial.begin(9600);

  // Initializing DHT sensor
  dht.begin();
}

void loop() {
  uduino.update();
  if (uduino.isConnected()){
    
    // Read humidity in %
    float h = dht.readHumidity();
    
    // Read temperature as Celsius (the default)
    float t = dht.readTemperature();

    // Compute heat index in Celsius (isFahreheit = false)
    float hic = dht.computeHeatIndex(t, h, false);

    // Printing the results as a string variable so that Unity code would be able to format it into floats
    Serial.print(h);
    Serial.print(" ");
    Serial.print(t);
    Serial.print(" ");
    Serial.println(hic);
  }

}
