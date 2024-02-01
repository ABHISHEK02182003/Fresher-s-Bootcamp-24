from abc import ABC, abstractmethod

class Component(ABC):
    @abstractmethod
    def setComponent(self, componentName):
        pass
    
    @abstractmethod
    def getComponent(self):
        pass

class Engine(Component):
    def setComponent(self, engineName):
        self.engineName = engineName
        
    def getComponent(self):
        return self.engineName

class FuelPump(Component):
    def setComponent(self, fuelPumpName):
        self.fuelPump = fuelPumpName
    
    def getComponent(self):
        return self.fuelPump

class StartUpMotor(Component):
    def setComponent(self, startUpMotorName):
        self.startUpMotorName = startUpMotorName
    
    def getComponent(self):
        return self.startUpMotorName

class Transmission(Component):
    def setComponent(self, transmissionName):
        self.transmission = transmissionName
    
    def getComponent(self):
        return self.transmission

class Car:
    def __init__(self, engineObj, transmissionObj):
        self.engine = engineObj
        self.transmission = transmissionObj
        
    def getDetails(self):
        return "Engine: {}, Transmission: {}".format(self.engine.getComponent(), self.transmission.getComponent())

class DiContainer:
    @staticmethod
    def createEngine():
        return Engine()
        
    @staticmethod
    def createTransmission():
        return Transmission()
        
    @staticmethod
    def createCar():
        engine1 = DiContainer.createEngine()
        transmission1 = DiContainer.createTransmission()
        return Car(engine1, transmission1)

def main():
    log1 = Log()
    carObj = DiContainer.createCar()
    log1.writeLog(carObj.getDetails())

if __name__ == "__main__":
    main()
