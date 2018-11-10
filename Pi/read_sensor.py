import Adafruit_DHT

sensor = Adafruit_DHT.DHT11

pin = 7

temperature, humidity = Adafruit_DHT.read_retry(sensor, pin)

if __name__ == "__main__":
    if humidity is not None and temperature is not None:
        print ("온도 = ", temperaturem "습도 = ", humidity)
    else
        print ("센서 값을 읽어오지 못했습니다")
